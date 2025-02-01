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
    public partial class MainUI : Form
    {
        public MainUI()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            EquipmentManger equipmentManger = new EquipmentManger();//opens equipment manager form
            equipmentManger.Show();//shows the form
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UserManager userManager = new UserManager();//opens user manager form
            userManager.Show();//shows the form
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 viewacccount = new Form2();//opens view account form
            viewacccount.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();//opens login form
            form1.Show();//shows the form
            this.Hide();//close the main UI after open login UI
        }

        private void button2_Click(object sender, EventArgs e)  
        {
            category category = new category();//opens category form
            category.Show();//shows the form
        }

        private void button8_Click(object sender, EventArgs e) //opens upgrade membership form
        {
            UpgradeMem upgradeMem = new UpgradeMem();//opens upgrade membership form
            upgradeMem.Show(); //shows the form 
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Attendance attendance = new Attendance();//opens attendance form
            attendance.Show();//shows the form
        }
    }
}
