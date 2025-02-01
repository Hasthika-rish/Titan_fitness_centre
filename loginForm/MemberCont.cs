using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loginForm
{
    using System;
    using System.Data.SQLite;

    public class MemberController
    {
        private static string connectionString = "Data Source=database/gms.db;Version=3;";

        public static void Register(string memberID, string name, string joinDate, string email, string contactNumber, string membershipType, string paymentDetails)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Member (MemberID, Name, JoinDate, Email, ContactNumber, MembershipType, PaymentDetails) VALUES (@id, @name, @date, @email, @contact, @membershipType, @payment)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", memberID);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@date", joinDate);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@contact", contactNumber);
                    cmd.Parameters.AddWithValue("@membershipType", membershipType);
                    cmd.Parameters.AddWithValue("@payment", paymentDetails);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}
