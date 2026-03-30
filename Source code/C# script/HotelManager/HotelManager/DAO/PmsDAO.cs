using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;

namespace HotelManager.DAO
{
    public class PmsDAO
    {
        private static PmsDAO instance;
        public static PmsDAO Instance { get { if (instance == null) instance = new PmsDAO(); return instance; } }
        private PmsDAO() { }

        #region Dashboard Metrics

        public int GetTodayArrivals()
        {
            string query = "SELECT COUNT(*) FROM BookRoom WHERE CAST(DateCheckIn AS DATE) = @today";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { DateTime.Now.Date });
            return result != null && result != DBNull.Value ? (int)result : 0;
        }

        public int GetTodayDepartures()
        {
            string query = "SELECT COUNT(*) FROM BookRoom WHERE CAST(DateCheckOut AS DATE) = @today";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { DateTime.Now.Date });
            return result != null && result != DBNull.Value ? (int)result : 0;
        }

        public double GetOccupancyPercent()
        {
            int totalRooms = GetTotalRooms();
            if (totalRooms == 0) return 0;
            int occupied = GetOccupiedRooms();
            return (double)occupied / totalRooms * 100;
        }

        public decimal GetRevPAR(int month, int year)
        {
            int totalRooms = GetTotalRooms();
            if (totalRooms == 0) return 0;
            string query = "SELECT ISNULL(SUM(TotalPrice), 0) FROM Bill WHERE MONTH(DateOfCreate) = @month AND YEAR(DateOfCreate) = @year";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { month, year });
            int totalRevenue = result != null && result != DBNull.Value ? (int)result : 0;
            return (decimal)totalRevenue / totalRooms;
        }

        public int GetTotalRooms()
        {
            string query = "SELECT COUNT(*) FROM Room";
            object result = DataProvider.Instance.ExecuteScalar(query);
            return result != null && result != DBNull.Value ? (int)result : 0;
        }

        public int GetOccupiedRooms()
        {
            string query = "SELECT COUNT(*) FROM Room r JOIN StatusRoom sr ON r.IDStatusRoom = sr.ID WHERE sr.Name = N'Có người'";
            object result = DataProvider.Instance.ExecuteScalar(query);
            return result != null && result != DBNull.Value ? (int)result : 0;
        }

        public int GetAvailableRooms()
        {
            string query = "SELECT COUNT(*) FROM Room r JOIN StatusRoom sr ON r.IDStatusRoom = sr.ID WHERE sr.Name = N'Trống'";
            object result = DataProvider.Instance.ExecuteScalar(query);
            return result != null && result != DBNull.Value ? (int)result : 0;
        }

        #endregion

        #region Dynamic Pricing

        public decimal CalculateDynamicPrice(decimal basePrice)
        {
            double occupancy = GetOccupancyPercent();
            if (occupancy > 80)
                return basePrice * 1.20m;
            if (occupancy < 30)
                return basePrice * 0.90m;
            return basePrice;
        }

        #endregion

        #region Housekeeping

        public DataTable GetDirtyRooms()
        {
            string query = "SELECT r.ID, r.Name AS RoomName, sr.Name AS Status, rt.Name AS RoomType " +
                           "FROM Room r " +
                           "JOIN StatusRoom sr ON r.IDStatusRoom = sr.ID " +
                           "JOIN RoomType rt ON r.IDRoomType = rt.ID " +
                           "WHERE sr.Name NOT IN (N'Trống', N'Có người')";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool SetRoomStatus(int roomId, int statusId)
        {
            string query = "UPDATE Room SET IDStatusRoom = @statusId WHERE ID = @roomId";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { statusId, roomId }) > 0;
        }

        public DataTable GetAllRoomStatuses()
        {
            string query = "SELECT * FROM StatusRoom";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        #endregion

        #region Overbooking Prevention

        public bool IsRoomAvailable(int roomId, DateTime checkIn, DateTime checkOut)
        {
            string query = "SELECT COUNT(*) FROM ReceiveRoom rr " +
                           "JOIN BookRoom br ON rr.IDBookRoom = br.ID " +
                           "WHERE rr.IDRoom = @roomId AND br.DateCheckIn < @checkOut AND br.DateCheckOut > @checkIn";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { roomId, checkOut, checkIn });
            int count = result != null && result != DBNull.Value ? (int)result : 0;
            return count == 0;
        }

        #endregion

        #region AI Smart Check-In Parser

        public static Dictionary<string, string> ParseBookingEmail(string rawText)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            if (string.IsNullOrWhiteSpace(rawText))
            {
                result["Name"] = "Unknown";
                return result;
            }

            result["Name"] = ParseGuestName(rawText);

            DateTime checkIn = ParseDate(rawText, new[] { @"check[\s-]?in", "arrival", "arriving" });
            if (checkIn != DateTime.MinValue)
                result["CheckIn"] = checkIn.ToString("yyyy-MM-dd");

            DateTime checkOut = ParseDate(rawText, new[] { @"check[\s-]?out", "departure", "departing" });
            if (checkOut != DateTime.MinValue)
                result["CheckOut"] = checkOut.ToString("yyyy-MM-dd");

            decimal price = ParsePrice(rawText);
            if (price > 0)
                result["Price"] = price.ToString("0.##");

            return result;
        }

        private static string ParseGuestName(string text)
        {
            string[] patterns = new[]
            {
                @"(?:Guest\s*Name|Guest|Name|Customer|Booked\s*by)\s*[:=]\s*(.+?)(?:\r?\n|$)",
                @"(?:Mr|Mrs|Ms|Dr)\.?\s+([A-Z][a-zA-Z]+(?:\s+[A-Z][a-zA-Z]+)+)"
            };

            foreach (string pattern in patterns)
            {
                Match match = Regex.Match(text, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                if (match.Success)
                {
                    string name = match.Groups[1].Value.Trim();
                    if (!string.IsNullOrEmpty(name))
                        return name;
                }
            }

            return "Unknown";
        }

        private static DateTime ParseDate(string text, string[] keywords)
        {
            string keywordPattern = string.Join("|", keywords);

            string[] datePatterns = new[]
            {
                @"(?:" + keywordPattern + @")\s*[:=]?\s*(\d{4}[-/]\d{1,2}[-/]\d{1,2})",
                @"(?:" + keywordPattern + @")\s*[:=]?\s*(\d{1,2}[-/]\d{1,2}[-/]\d{4})",
                @"(?:" + keywordPattern + @")\s*[:=]?\s*([A-Za-z]+\.?\s+\d{1,2},?\s+\d{4})",
                @"(?:" + keywordPattern + @")\s*[:=]?\s*(\d{1,2}\s+[A-Za-z]+\.?\s+\d{4})"
            };

            string[] parseFormats = new[]
            {
                "yyyy-MM-dd", "yyyy/MM/dd",
                "MM-dd-yyyy", "MM/dd/yyyy",
                "dd-MM-yyyy", "dd/MM/yyyy",
                "MMM dd, yyyy", "MMM dd yyyy",
                "MMMM dd, yyyy", "MMMM dd yyyy",
                "dd MMM yyyy", "dd MMMM yyyy",
                "MMM d, yyyy", "MMMM d, yyyy",
                "d MMM yyyy", "d MMMM yyyy"
            };

            foreach (string pattern in datePatterns)
            {
                Match match = Regex.Match(text, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                if (match.Success)
                {
                    string dateStr = match.Groups[1].Value.Trim().TrimEnd(',');
                    DateTime dateResult;
                    if (DateTime.TryParseExact(dateStr, parseFormats,
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out dateResult))
                        return dateResult;
                    if (DateTime.TryParse(dateStr, CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out dateResult))
                        return dateResult;
                }
            }

            return DateTime.MinValue;
        }

        private static decimal ParsePrice(string text)
        {
            string[] patterns = new[]
            {
                @"(?:Price|Rate|Total|Cost|Amount|Charge)\s*[:=]?\s*\$?\s*([\d,]+\.?\d*)",
                @"\$\s*([\d,]+\.?\d*)"
            };

            foreach (string pattern in patterns)
            {
                Match match = Regex.Match(text, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                if (match.Success)
                {
                    string priceStr = match.Groups[1].Value.Replace(",", "");
                    decimal priceResult;
                    if (decimal.TryParse(priceStr, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out priceResult))
                        return priceResult;
                }
            }

            return 0m;
        }

        #endregion

        #region Sentiment Analysis

        public static string AnalyzeGuestSentiment(string notes)
        {
            if (string.IsNullOrWhiteSpace(notes))
                return "Normal";

            string lower = notes.ToLowerInvariant();

            string[] highValueKeywords = new[]
            {
                "vip", "anniversary", "honeymoon", "birthday", "celebration",
                "special occasion", "loyalty", "returning"
            };

            string[] highMaintenanceKeywords = new[]
            {
                "complaint", "unhappy", "dissatisfied", "refund", "problem",
                "issue", "allergic", "disability", "wheelchair", "medical"
            };

            foreach (string keyword in highValueKeywords)
            {
                if (lower.Contains(keyword))
                    return "High-Value";
            }

            foreach (string keyword in highMaintenanceKeywords)
            {
                if (lower.Contains(keyword))
                    return "High-Maintenance";
            }

            return "Normal";
        }

        #endregion

        #region Availability Calendar

        public DataTable GetAvailabilityCalendar(DateTime startDate, DateTime endDate)
        {
            string query = "SELECT r.Name AS RoomName, rt.Name AS RoomType, " +
                           "br.DateCheckIn, br.DateCheckOut, c.Name AS GuestName " +
                           "FROM BookRoom br " +
                           "JOIN Customer c ON br.IDCustomer = c.ID " +
                           "JOIN RoomType rt ON br.IDRoomType = rt.ID " +
                           "LEFT JOIN ReceiveRoom rr ON rr.IDBookRoom = br.ID " +
                           "LEFT JOIN Room r ON rr.IDRoom = r.ID " +
                           "WHERE br.DateCheckIn <= @endDate AND br.DateCheckOut >= @startDate " +
                           "ORDER BY br.DateCheckIn";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { endDate, startDate });
        }

        #endregion
    }
}
