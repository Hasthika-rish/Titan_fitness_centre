using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace loginForm
{
    public partial class ManageEquipments : Form
    {
        private static string connectionString = "Data Source=database/gms.db;Version=3;";

        public ManageEquipments()
        {
            InitializeComponent();
            LoadEquipmentData(); // Load data when form opens
        }

        // Load data into DataGridView
        private void LoadEquipmentData()
        {
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT EquipmentID, Name, Type, Quantity, Cost FROM Equipment";
                    using (var adapter = new SQLiteDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt; // Bind to DataGridView
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Save Equipment (Insert/Update)
        private void button4_Click(object sender, EventArgs e)
        {
            string equipmentID = textBox1.Text;
            string name = textBox2.Text;
            string type = textBox3.Text;

            if (string.IsNullOrWhiteSpace(equipmentID) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(type))
            {
                MessageBox.Show("Please enter valid data in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string quantityText = textBox2.Text;
            string statusText = textBox3.Text;

            // Parse the fields to ensure they are valid numbers
            int quantity;
            if (!int.TryParse(quantityText, out quantity))
            {
                MessageBox.Show("Please enter a valid quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Parse the statusText as a double (for cost)
            double cost;
            if (!double.TryParse(statusText, out cost))
            {
                MessageBox.Show("Please enter a valid cost.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = EquipmentController.SaveEquipment(equipmentID, name, type, quantity, cost);

            if (success)
            {
                MessageBox.Show("Equipment saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEquipmentData(); // Refresh DataGridView
                ResetFields();
            }
            else
            {
                MessageBox.Show("Failed to save equipment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Remove Equipment
        private void button2_Click(object sender, EventArgs e)
        {
            string equipmentID = textBox1.Text;

            if (string.IsNullOrWhiteSpace(equipmentID))
            {
                MessageBox.Show("Enter an Equipment ID to remove.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to remove this equipment?",
                                                   "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                bool success = EquipmentController.RemoveEquipment(equipmentID);
                if (success)
                {
                    MessageBox.Show("Equipment removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEquipmentData(); // Refresh DataGridView
                    ResetFields();
                }
                else
                {
                    MessageBox.Show("Equipment not found or failed to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Reset Fields when clicking "Reset to Default"
        private void button3_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        // Helper function to clear input fields
        private void ResetFields()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
    }
}
