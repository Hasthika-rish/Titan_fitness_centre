using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace loginForm
{
    public class EquipmentController
    {
        private static string connectionString = "Data Source=database/gms.db;Version=3;";

        // Save or Update Equipment Details
        public static bool SaveEquipment(string equipmentID, string name, string type, int quantity, double cost)
        {
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO Equipment (EquipmentID, Name, Type, Quantity, Cost) 
                        VALUES (@id, @name, @type, @quantity, @cost) 
                        ON CONFLICT(EquipmentID) 
                        DO UPDATE SET Name=@name, Type=@type, Quantity=@quantity, Cost=@cost";

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
                return true; // Success
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Remove Equipment
        public static bool RemoveEquipment(string equipmentID)
        {
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Equipment WHERE EquipmentID = @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", equipmentID);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; // Return true if deletion was successful
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Get Equipment Details
        public static Dictionary<string, object> GetEquipmentDetails(string equipmentID)
        {
            Dictionary<string, object> equipmentDetails = new Dictionary<string, object>();

            try
            {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return equipmentDetails;
        }

        // Increase Equipment Quantity
        public static bool AddQuantity(string equipmentID, int additionalQuantity)
        {
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Equipment SET Quantity = Quantity + @quantity WHERE EquipmentID = @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", equipmentID);
                        cmd.Parameters.AddWithValue("@quantity", additionalQuantity);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; // Return true if update was successful
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}