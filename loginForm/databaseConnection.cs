using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace loginForm
{
    public class databaseConnection
    {
        private static databaseConnection instance;
        private static readonly object lockObject = new object(); // For thread safety
        private MySqlConnection connection;
        private string connectionString = "server=localhost;database=gym_management_system;user=root;password=;";

        // Private constructor to prevent instantiation from outside
        private databaseConnection()
        {
            connection = new MySqlConnection(connectionString);
        }

        // Singleton instance getter (Thread-Safe)
        public static databaseConnection GetInstance()
        {
            if (instance == null)
            {
                lock (lockObject)  // Ensures thread-safety when accessing the instance
                {
                    if (instance == null)
                    {
                        instance = new databaseConnection();
                    }
                }
            }
            return instance;
        }

        // Open connection
        public bool OpenConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                    MessageBox.Show("Database connected successfully!");
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Connection Error: " + ex.Message);
                return false;
            }
        }


        // Close connection
        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        // Execute SELECT queries
        public DataTable ExecuteQuery(string query, MySqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();
            try
            {
                if (OpenConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Query Execution Error: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dataTable;
        }

        // Execute INSERT, UPDATE, DELETE queries
        public bool ExecuteNonQuery(string query, MySqlParameter[] parameters = null)
        {
            try
            {
                if (OpenConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Query Execution Error: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return false;
        }
    }
}


