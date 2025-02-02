using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace loginForm
{
    public partial class EquipmentManger : Form
    {
        private List<Equipment> equipmentList = new List<Equipment>();

        public EquipmentManger()
        {
            InitializeComponent();
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string equipmentID = textBox1.Text.Trim();
            string quantity = textBox2.Text.Trim();
            string status = textBox3.Text.Trim();

            if (string.IsNullOrEmpty(equipmentID) || string.IsNullOrEmpty(quantity) || string.IsNullOrEmpty(status))
            {
                MessageBox.Show("Please fill all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Equipment newEquipment = new Equipment
            {
                EquipmentID = equipmentID,
                Quantity = int.Parse(quantity),
                Status = status
            };
            equipmentList.Add(newEquipment);

            MessageBox.Show("Equipment added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadEquipmentData();
        }

        private void LoadEquipmentData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = equipmentList;
        }

        private void EquipmentManger_Load(object sender, EventArgs e)
        {
            LoadEquipmentData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click event
        }
    }

    public class Equipment
    {
        public string EquipmentID { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
    }
}