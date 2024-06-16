using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class Admin_Login : Form
    {
        public Admin_Login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //move to previous page of login page
            this.Hide();
            Login fr = new Login();
            fr.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Username;
            string Password;

            Username = textBox1.Text;
            Password = textBox2.Text;

            if (Username == "admin" && Password == "admin123")
            {
                MessageBox.Show("Login successfully");
                //move to the admin page
                this.Hide();
                Admin_Seller fr = new Admin_Seller();
                fr.ShowDialog();

            }
            else
            {
                MessageBox.Show("If you are Admin please enter correct username and password");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //hide password
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void Admin_Login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
