using System;
using System.Drawing;
using System.Windows.Forms;

namespace loginForm
{
    public partial class UpgradeMem : Form
    {
        public UpgradeMem()
        {
            InitializeComponent();
            textBox3.MaxLength = 3; // Set max length during form initialization
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            ValidateCVV();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Block invalid input
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void UpgradeMem_Load(object sender, EventArgs e)
        {
            textBox3.MaxLength = 3; // Ensure CVV input is only 3 digits
        }
        private void ValidateCVV()
        {
            string cvv = textBox3.Text;

            if (cvv.Length != 3)
            {
                label6.Text = "Invalid!";
                label6.ForeColor = Color.Red;
            }
            else
            {
                label6.Text = "CVV is a 3 digits number";
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
