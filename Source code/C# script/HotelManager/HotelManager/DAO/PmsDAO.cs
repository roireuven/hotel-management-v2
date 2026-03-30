using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;

namespace HotelManager.DAO
{
    public class PmsDAO
    {
        private static PmsDAO instance;

        public static PmsDAO Instance
        {
            get { if (instance == null) instance = new PmsDAO(); return instance; }
            private set { instance = value; }
        }

        private PmsDAO() { }

        public int GetTodayArrivals()
        {
            string query = "SELECT COUNT(*) FROM BookRoom WHERE CAST(CheckInDate AS DATE) = CAST(GETDATE() AS DATE)";
            object result = DataProvider.Instance.ExecuteScalar(query);
            return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
        }

        public int GetTodayDepartures()
        {
            string query = "SELECT COUNT(*) FROM BookRoom WHERE CAST(CheckOutDate AS DATE) = CAST(GETDATE() AS DATE)";
            object result = DataProvider.Instance.ExecuteScalar(query);
            return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
        }

        public double GetOccupancyPercent()
        {
            int total = GetTotalRooms();
            if (total == 0) return 0;
            int occupied = GetOccupiedRooms();
            return Math.Round((double)occupied / total * 100, 1);
        }

        public decimal GetRevPAR(int month, int year)
        {
            int total = GetTotalRooms();
            if (total == 0) return 0;
            string query = "SELECT ISNULL(SUM(TotalPrice), 0) FROM Bill WHERE MONTH(CreateDate) = @month AND YEAR(CreateDate) = @year";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { month, year });
            decimal revenue = result != null && result != DBNull.Value ? Convert.ToDecimal(result) : 0;
            int daysInMonth = DateTime.DaysInMonth(year, month);
            return Math.Round(revenue / (total * daysInMonth), 0);
        }

        public int GetTotalRooms()
        {
            string query = "SELECT COUNT(*) FROM Room";
            object result = DataProvider.Instance.ExecuteScalar(query);
            return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
        }

        public int GetOccupiedRooms()
        {
            string query = "SELECT COUNT(*) FROM Room WHERE idStatusRoom = 2";
            object result = DataProvider.Instance.ExecuteScalar(query);
            return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
        }

        public int GetAvailableRooms()
        {
            string query = "SELECT COUNT(*) FROM Room WHERE idStatusRoom = 1";
            object result = DataProvider.Instance.ExecuteScalar(query);
            return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
        }

        public DataTable GetDirtyRooms()
        {
            string query = "SELECT r.id AS [Room ID], r.Name AS [Room], rt.Name AS [Type] FROM Room r JOIN RoomType rt ON r.idRoomType = rt.id WHERE r.idStatusRoom = 3";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public decimal CalculateDynamicPrice(decimal basePrice)
        {
            double occupancy = GetOccupancyPercent();
            if (occupancy >= 90)
                return Math.Round(basePrice * 1.3m, 0);
            if (occupancy >= 70)
                return Math.Round(basePrice * 1.15m, 0);
            if (occupancy <= 30)
                return Math.Round(basePrice * 0.85m, 0);
            return basePrice;
        }

        public static Dictionary<string, string> ParseBookingEmail(string text)
        {
            var result = new Dictionary<string, string>();
            if (string.IsNullOrWhiteSpace(text))
                return result;

            var nameMatch = Regex.Match(text, @"(?:name|guest|customer)[:\s]+([A-Za-z\s]+)", RegexOptions.IgnoreCase);
            if (nameMatch.Success)
                result["Name"] = nameMatch.Groups[1].Value.Trim();

            var checkinMatch = Regex.Match(text, @"(?:check[\-\s]?in|arrival)[:\s]+(\d{1,2}[\/\-]\d{1,2}[\/\-]\d{2,4})", RegexOptions.IgnoreCase);
            if (checkinMatch.Success)
                result["CheckIn"] = checkinMatch.Groups[1].Value.Trim();

            var checkoutMatch = Regex.Match(text, @"(?:check[\-\s]?out|departure)[:\s]+(\d{1,2}[\/\-]\d{1,2}[\/\-]\d{2,4})", RegexOptions.IgnoreCase);
            if (checkoutMatch.Success)
                result["CheckOut"] = checkoutMatch.Groups[1].Value.Trim();

            var priceMatch = Regex.Match(text, @"(?:price|rate|cost|total)[:\s]+\$?([\d,\.]+)", RegexOptions.IgnoreCase);
            if (priceMatch.Success)
                result["Price"] = priceMatch.Groups[1].Value.Trim();

            return result;
        }

        public static string AnalyzeGuestSentiment(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "Neutral";

            string lower = text.ToLower();
            int positive = 0;
            int negative = 0;

            string[] positiveWords = { "great", "excellent", "wonderful", "amazing", "good", "love", "happy", "clean", "comfortable", "friendly", "best", "perfect", "nice", "pleased", "recommend" };
            string[] negativeWords = { "bad", "terrible", "awful", "dirty", "noisy", "rude", "worst", "horrible", "poor", "complaint", "disappointed", "broken", "cold", "slow", "uncomfortable" };

            foreach (string w in positiveWords)
                if (lower.Contains(w)) positive++;
            foreach (string w in negativeWords)
                if (lower.Contains(w)) negative++;

            if (positive > negative)
                return "Positive";
            if (negative > positive)
                return "Negative";
            return "Neutral";
        }
    }
}
