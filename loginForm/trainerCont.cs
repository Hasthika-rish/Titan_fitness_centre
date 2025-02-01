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

    public class TrainerController
    {
        private static string connectionString = "Data Source=database/gms.db;Version=3;";

        public static void CreateProfile(string trainerID, string name, string contactInfo, string specialization)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Trainer (TrainerID, Name, ContactInfo, Specialization) VALUES (@id, @name, @contact, @specialization)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", trainerID);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@contact", contactInfo);
                    cmd.Parameters.AddWithValue("@specialization", specialization);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void ManageProfile(string trainerID, string contactInfo, string specialization)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Trainer SET ContactInfo = @contact, Specialization = @specialization WHERE TrainerID = @id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", trainerID);
                    cmd.Parameters.AddWithValue("@contact", contactInfo);
                    cmd.Parameters.AddWithValue("@specialization", specialization);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<string> ViewAssignedClasses(string trainerID)
        {
            List<string> assignedClasses = new List<string>();

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ClassName FROM Classes WHERE TrainerID = @id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", trainerID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            assignedClasses.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return assignedClasses;
        }
    }

}
