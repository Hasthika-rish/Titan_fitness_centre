using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace loginForm
{
    public partial class Attendance : Form
    {
        private databaseConnection db; // Database connection instance

        public Attendance()
        {
            InitializeComponent();
            db = databaseConnection.GetInstance(); // Singleton database connection
            LoadAttendanceData(); // Load data on form load
        }

        private void LoadAttendanceData()
        {
            try
            {
                string query = "SELECT member_id, name, date, status FROM attendance"; // Modify based on your DB structure
                DataTable dataTable = db.ExecuteQuery(query);

                if (dataTable.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dataTable; // Bind data to DataGridView
                }
                else
                {
                    MessageBox.Show("No attendance records found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // You can handle cell click events here if needed
        }
    }
}
