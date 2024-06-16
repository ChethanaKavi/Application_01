using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //header file

namespace Final_Project
{
    public partial class Seller_Login : Form
    {
        public Seller_Login()
        {
            InitializeComponent();
        }
       

        //connection string 
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\cheth\Documents\Supermarket.mdf;Integrated Security=True;Connect Timeout=30");

      
        private void button1_Click(object sender, EventArgs e)
        {
            string Username;
            string Password;

            Username = textBox1.Text;
            Password = textBox2.Text;

            if (Username == "" || Password == "")
            {
                MessageBox.Show("Please enter Username and password");
            }
            else
            {   
                con.Open();
                SqlCommand cmd =new SqlCommand ("select * from seller where Username=@username and Password=@password",con);
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Login successfully");

                    //move to seller page
                    this.Hide();
                    Seller_Page fr = new Seller_Page();
                    fr.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Incorrect username or password");
                }
                con.Close();
                

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //move to the login page
            this.Hide();
            Login fr = new Login();
            fr.ShowDialog();
        }

        private void Seller_Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
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
    }
}
