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

namespace Final_Project
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        //connection string
        SqlConnection con = new SqlConnection(@" Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\cheth\Documents\Supermarket.mdf;Integrated Security=True;Connect Timeout=30");
  
        private void button1_Click(object sender, EventArgs e)
        {


                string CustomerID;
                string CustomerName;
                string ContactNo;
                string Town;

                CustomerID = textBox1.Text;
                CustomerName = textBox2.Text;
                ContactNo = textBox3.Text;
                Town = textBox4.Text;

                if (CustomerID == "" || CustomerName == "" || ContactNo == "" || Town == "")
                {
                    MessageBox.Show("Missing information");
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into customer values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data Succesfully Inserted");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string CustomerID;
            string CustomerName;
            string ContactNo;
            string Town;

            CustomerID = textBox1.Text;
            CustomerName = textBox2.Text;
            ContactNo = textBox3.Text;
            Town = textBox4.Text;

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update customer set CustomerID='" + textBox1.Text + "',CustomerName='" + textBox2.Text + "',ContactNo='" + textBox3.Text + "',Town='" + textBox4.Text + "'where CustomerID='"+textBox1.Text+"'";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Succesfully Edited");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            

        

        }

        private void button10_Click(object sender, EventArgs e)
        {
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from customer where CustomerID='" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("data successfully deleted");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Catergory fr = new Catergory();
            fr.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer fr = new Customer();
            fr.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Order fr = new Order();
            fr.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Billing fr = new Billing();
            fr.ShowDialog();
        }
        private void display_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from customer";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void Customer_Load(object sender, EventArgs e)
        {
            display_data();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["CustomerID"].Value.ToString();
                textBox2.Text = row.Cells["CustomerName"].Value.ToString();
                textBox3.Text = row.Cells["ContactNo"].Value.ToString();
                textBox4.Text = row.Cells["Town"].Value.ToString();
            }
                
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("CustomerName like '%" + textBox5.Text + "%'");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Seller_Page fr = new Seller_Page();
            fr.ShowDialog();
        }
    }
}
