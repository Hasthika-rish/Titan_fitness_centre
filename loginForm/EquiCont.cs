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

    public class EquipmentController
    {
        private static string connectionString = "Data Source=database/gms.db;Version=3;";

        public static void AddEquipment(string equipmentID, string name, string type, int quantity, double cost)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Equipment (EquipmentID, Name, Type, Quantity, Cost) VALUES (@id, @name, @type, @quantity, @cost)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", equipmentID);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@cost", cost);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void RemoveEquipment(string equipmentID)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Equipment WHERE EquipmentID = @id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", equipmentID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Dictionary<string, object> GetEquipmentDetails(string equipmentID)
        {
            Dictionary<string, object> equipmentDetails = new Dictionary<string, object>();

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Equipment WHERE EquipmentID = @id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", equipmentID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            equipmentDetails["Name"] = reader["Name"].ToString();
                            equipmentDetails["Type"] = reader["Type"].ToString();
                            equipmentDetails["Quantity"] = Convert.ToInt32(reader["Quantity"]);
                            equipmentDetails["Cost"] = Convert.ToDouble(reader["Cost"]);
                        }
                    }
                }
            }
            return equipmentDetails;
        }

        public static void AddQuantity(string equipmentID, int additionalQuantity)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Equipment SET Quantity = Quantity + @quantity WHERE EquipmentID = @id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", equipmentID);
                    cmd.Parameters.AddWithValue("@quantity", additionalQuantity);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}
