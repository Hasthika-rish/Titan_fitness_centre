using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace loginForm
{
    public class AttendanceController
    {
        public static bool MarkAttendance(string memberID, string date, string time, string status)
        {
            string query = "INSERT INTO Attendance (MemberID, Date, Time, Status) VALUES (@id, @date, @time, @status)";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@id", memberID),
                new MySqlParameter("@date", date),
                new MySqlParameter("@time", time),
                new MySqlParameter("@status", status)
            };

            return databaseConnection.GetInstance().ExecuteNonQuery(query, parameters);
        }

        public static bool CancelAttendance(string memberID, string date)
        {
            string query = "DELETE FROM Attendance WHERE MemberID = @id AND Date = @date";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@id", memberID),
                new MySqlParameter("@date", date)
            };

            return databaseConnection.GetInstance().ExecuteNonQuery(query, parameters);
        }

        public static List<string> ViewAttendance(string memberID)
        {
            List<string> attendanceRecords = new List<string>();
            string query = "SELECT Date, Time, Status FROM Attendance WHERE MemberID = @id";
            MySqlParameter[] parameters = { new MySqlParameter("@id", memberID) };

            DataTable result = databaseConnection.GetInstance().ExecuteQuery(query, parameters);

            foreach (DataRow row in result.Rows)
            {
                string record = $"Date: {row["Date"]}, Time: {row["Time"]}, Status: {row["Status"]}";
                attendanceRecords.Add(record);
            }

            return attendanceRecords;
        }
    }
}
