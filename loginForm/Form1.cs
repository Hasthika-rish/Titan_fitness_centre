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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // Initialize the form
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;  // Assuming your textbox name is txtUsername
            string password = txtPassword.Text;  // Assuming your textbox name is txtPassword

            if (username == "admin" && password == "password")
            {
                // Open Main UI
                MainUI mainForm = new MainUI(); // Assuming your main form name is MainUI
                mainForm.Show();

                // Hide Login Form (or use this.Close() to close it completely)
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
