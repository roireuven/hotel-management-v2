using System;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace HotelManager.DAO
{
    public class SettingsDAO
    {
        private static SettingsDAO instance;
        internal static SettingsDAO Instance { get { if (instance == null) instance = new SettingsDAO(); return instance; } }
        private SettingsDAO() { }

        internal string GetSettingString(string name)
        {
            try
            {
                DataTable dt = DataProvider.Instance.ExecuteQuery(
                    "SELECT Describe FROM Parameter WHERE Name = @name", new object[] { name });
                if (dt.Rows.Count > 0)
                    return dt.Rows[0]["Describe"] as string ?? "";
            }
            catch { }
            return "";
        }

        internal double GetSettingValue(string name)
        {
            try
            {
                DataTable dt = DataProvider.Instance.ExecuteQuery(
                    "SELECT Value FROM Parameter WHERE Name = @name", new object[] { name });
                if (dt.Rows.Count > 0 && dt.Rows[0]["Value"] != DBNull.Value)
                    return Convert.ToDouble(dt.Rows[0]["Value"]);
            }
            catch { }
            return 0;
        }

        internal bool SaveSetting(string name, double value, string describe)
        {
            try
            {
                int count = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(
                    "SELECT COUNT(*) FROM Parameter WHERE Name = @name", new object[] { name }));
                if (count > 0)
                {
                    return DataProvider.Instance.ExecuteNoneQuery(
                        "UPDATE Parameter SET Value = @value , Describe = @describe , DateModify = GETDATE() WHERE Name = @name",
                        new object[] { value, describe, name }) > 0;
                }
                else
                {
                    return DataProvider.Instance.ExecuteNoneQuery(
                        "INSERT INTO Parameter (Name, Value, Describe, DateModify) VALUES ( @name , @value , @describe , GETDATE())",
                        new object[] { name, value, describe }) > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        internal DataTable GetTableData(string tableName)
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM [" + tableName + "]");
        }

        internal string ExportTableToCsv(string tableName)
        {
            DataTable dt = GetTableData(tableName);
            return DataTableToCsv(dt);
        }

        internal bool ExportTableToCsvFile(string tableName, string filePath)
        {
            try
            {
                string csv = ExportTableToCsv(tableName);
                File.WriteAllText(filePath, csv, Encoding.UTF8);
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal bool ExportAllToZip(string zipPath)
        {
            string[] tables = {
                "Room", "Customer", "BookRoom", "Service", "Bill",
                "BillDetails", "ReceiveRoom", "ReceiveRoomDetails",
                "RoomType", "ServiceType", "CustomerType", "Staff",
                "StaffType", "StatusRoom", "StatusBill", "Parameter",
                "REPORT", "ACCESS", "JOB"
            };

            string tempDir = Path.Combine(Path.GetTempPath(), "HotelExport_" + DateTime.Now.Ticks);
            try
            {
                Directory.CreateDirectory(tempDir);
                foreach (string table in tables)
                {
                    try
                    {
                        string csv = ExportTableToCsv(table);
                        File.WriteAllText(Path.Combine(tempDir, table + ".csv"), csv, Encoding.UTF8);
                    }
                    catch { }
                }

                if (File.Exists(zipPath))
                    File.Delete(zipPath);
                ZipFile.CreateFromDirectory(tempDir, zipPath);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                try { Directory.Delete(tempDir, true); } catch { }
            }
        }

        internal bool ImportFromZip(string zipPath)
        {
            string tempDir = Path.Combine(Path.GetTempPath(), "HotelImport_" + DateTime.Now.Ticks);
            try
            {
                ZipFile.ExtractToDirectory(zipPath, tempDir);
                string[] csvFiles = Directory.GetFiles(tempDir, "*.csv");
                int imported = 0;
                foreach (string csvFile in csvFiles)
                {
                    string tableName = Path.GetFileNameWithoutExtension(csvFile);
                    if (ImportCsvToTable(csvFile, tableName))
                        imported++;
                }
                return imported > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                try { Directory.Delete(tempDir, true); } catch { }
            }
        }

        private bool ImportCsvToTable(string csvFilePath, string tableName)
        {
            try
            {
                string[] lines = File.ReadAllLines(csvFilePath, Encoding.UTF8);
                if (lines.Length < 2) return false;

                string[] headers = ParseCsvLine(lines[0]);
                for (int i = 1; i < lines.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(lines[i])) continue;
                    string[] values = ParseCsvLine(lines[i]);
                    if (values.Length != headers.Length) continue;

                    StringBuilder cols = new StringBuilder();
                    StringBuilder parms = new StringBuilder();
                    object[] paramValues = new object[headers.Length];

                    for (int j = 0; j < headers.Length; j++)
                    {
                        if (j > 0) { cols.Append(", "); parms.Append(", "); }
                        cols.Append("[" + headers[j] + "]");
                        parms.Append("@p" + j);
                        paramValues[j] = values[j];
                    }

                    string query = string.Format(
                        "INSERT INTO [{0}] ({1}) VALUES ({2})",
                        tableName, cols.ToString(), parms.ToString());

                    try
                    {
                        DataProvider.Instance.ExecuteNoneQuery(query, paramValues);
                    }
                    catch { }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string[] ParseCsvLine(string line)
        {
            var fields = new System.Collections.Generic.List<string>();
            bool inQuotes = false;
            StringBuilder field = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (inQuotes)
                {
                    if (c == '"')
                    {
                        if (i + 1 < line.Length && line[i + 1] == '"')
                        {
                            field.Append('"');
                            i++;
                        }
                        else
                        {
                            inQuotes = false;
                        }
                    }
                    else
                    {
                        field.Append(c);
                    }
                }
                else
                {
                    if (c == '"')
                    {
                        inQuotes = true;
                    }
                    else if (c == ',')
                    {
                        fields.Add(field.ToString());
                        field.Clear();
                    }
                    else
                    {
                        field.Append(c);
                    }
                }
            }
            fields.Add(field.ToString());
            return fields.ToArray();
        }

        private string DataTableToCsv(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sb.Append(EscapeCsvField(dt.Columns[i].ColumnName));
                if (i < dt.Columns.Count - 1) sb.Append(",");
            }
            sb.AppendLine();

            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sb.Append(EscapeCsvField(row[i]?.ToString() ?? ""));
                    if (i < dt.Columns.Count - 1) sb.Append(",");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        private string EscapeCsvField(string field)
        {
            if (field.Contains(",") || field.Contains("\"") || field.Contains("\n") || field.Contains("\r"))
                return "\"" + field.Replace("\"", "\"\"") + "\"";
            return field;
        }
    }
}
