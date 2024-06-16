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
    public partial class Admin_Seller : Form
    {
        public Admin_Seller()
        {
            InitializeComponent();
        }
        
        
        SqlConnection con =new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\cheth\Documents\Supermarket.mdf;Integrated Security=True;Connect Timeout=30");
    
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Login fr = new Admin_Login();
            fr.ShowDialog();
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            string SellerID;
            string Name;
            string Password;
            string Contactno;
            
            SellerID= textBox1.Text;
            Name = textBox2.Text;
            Password=textBox3.Text;
            Contactno=textBox5.Text;


            if (SellerID == "" || Name == "" || Password == "" || Contactno == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Addseller values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                displaydata();
                MessageBox.Show("Data Successfully Added");
                textBox1.Text = " ";
                textBox2.Text = " ";
                textBox3.Text = " ";
                textBox5.Text = " ";
                
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string SellerID;
            string Name;
            string Password;
            string Contactno;

            SellerID = textBox1.Text;
            Name = textBox2.Text;
            Password = textBox3.Text;
            Contactno = textBox5.Text;

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Addseller set SellerID='" + textBox1.Text + "',Name='" + textBox2.Text + "',Password='" + textBox3.Text + "',ContactNo='" + textBox5.Text + "'where SellerID='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            displaydata();
            MessageBox.Show("Data Successfully updated");
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox5.Text = " ";  
        }

        private void button4_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Addseller where SellerID='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            displaydata();
            MessageBox.Show("Data Successfully Deleted");
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox5.Text = " ";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["SellerID"].Value.ToString();
                textBox2.Text = row.Cells["Name"].Value.ToString();
                textBox3.Text = row.Cells["Password"].Value.ToString();
                textBox5.Text = row.Cells["ContactNo"].Value.ToString();
            }
        }

        private void Admin_Seller_Load(object sender, EventArgs e)
        {
            displaydata();
          
        }
        private void displaydata()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Addseller";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Catergory fr = new Catergory();
            fr.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name like '%" + textBox4.Text + "%'");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
