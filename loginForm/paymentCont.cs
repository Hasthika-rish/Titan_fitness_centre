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

    public class PaymentController
    {
        private static string connectionString = "Data Source=database/gms.db;Version=3;";

        public static void ProcessPayment(string paymentID, string memberID, double amount, string date, string method, string status, string membershipType)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Payment (PaymentID, MemberID, Amount, Date, Method, Status, MembershipType) VALUES (@id, @memberID, @amount, @date, @method, @status, @membershipType)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", paymentID);
                    cmd.Parameters.AddWithValue("@memberID", memberID);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@method", method);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@membershipType", membershipType);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Dictionary<string, object> GenerateInvoice(string paymentID)
        {
            Dictionary<string, object> invoiceDetails = new Dictionary<string, object>();

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Payment WHERE PaymentID = @id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", paymentID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            invoiceDetails["MemberID"] = reader["MemberID"].ToString();
                            invoiceDetails["Amount"] = Convert.ToDouble(reader["Amount"]);
                            invoiceDetails["Date"] = reader["Date"].ToString();
                            invoiceDetails["Method"] = reader["Method"].ToString();
                            invoiceDetails["Status"] = reader["Status"].ToString();
                            invoiceDetails["MembershipType"] = reader["MembershipType"].ToString();
                        }
                    }
                }
            }
            return invoiceDetails;
        }

        public static List<Dictionary<string, object>> GetPaymentHistory(string memberID)
        {
            List<Dictionary<string, object>> paymentHistory = new List<Dictionary<string, object>>();

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Payment WHERE MemberID = @id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", memberID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var paymentRecord = new Dictionary<string, object>
                            {
                                ["PaymentID"] = reader["PaymentID"].ToString(),
                                ["Amount"] = Convert.ToDouble(reader["Amount"]),
                                ["Date"] = reader["Date"].ToString(),
                                ["Method"] = reader["Method"].ToString(),
                                ["Status"] = reader["Status"].ToString(),
                                ["MembershipType"] = reader["MembershipType"].ToString()
                            };
                            paymentHistory.Add(paymentRecord);
                        }
                    }
                }
            }
            return paymentHistory;
        }

        public static bool ValidatePayment(string paymentID)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Status FROM Payment WHERE PaymentID = @id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", paymentID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && reader["Status"].ToString() == "Completed")
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }

}
