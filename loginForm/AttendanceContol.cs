using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loginForm
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;

    public class AttendanceController
    {
        private static string connectionString = "Data Source=database/gms.db;Version=3;";

        public static void MarkAttendance(string memberID, string date, string time, string status)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Attendance (MemberID, Date, Time, Status) VALUES (@id, @date, @time, @status)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", memberID);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@time", time);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void CancelAttendance(string memberID, string date)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Attendance WHERE MemberID = @id AND Date = @date";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", memberID);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<string> ViewAttendance(string memberID)
        {
            List<string> attendanceRecords = new List<string>();

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Date, Time, Status FROM Attendance WHERE MemberID = @id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", memberID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string record = $"Date: {reader["Date"]}, Time: {reader["Time"]}, Status: {reader["Status"]}";
                            attendanceRecords.Add(record);
                        }
                    }
                }
            }
            return attendanceRecords;
        }
    }

}
