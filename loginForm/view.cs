using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace TitanFitnessApp
{
    public partial class AccountOverviewForm : Form
    {
        public AccountOverviewForm()
        {
            InitializeComponent();
        }

        // Method to load account data from the database
        private void LoadAccountData(int accountID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TitanFitnessConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT Name, MembershipType, JoinDate FROM Accounts WHERE AccountID = @AccountID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@AccountID", accountID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Display data in the gray box
                        lblName.Text = reader["Name"].ToString();
                        lblMembershipType.Text = reader["MembershipType"].ToString();
                        lblJoinDate.Text = reader["JoinDate"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Account not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading account data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Event handler for form load
        private void AccountOverviewForm_Load(object sender, EventArgs e)
        {
            // Load data for a specific account (e.g., AccountID = 1)
            LoadAccountData(1);
        }
    }
}