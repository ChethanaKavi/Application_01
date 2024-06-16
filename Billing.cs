using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;    //header file

namespace Final_Project
{
    public partial class Billing : Form
    {
        public Billing()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\cheth\Documents\Supermarket.mdf;Integrated Security=True;Connect Timeout=30");
        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Order fr = new Order();
            fr.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Catergory fr = new Catergory();
            fr.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Seller_Page fr = new Seller_Page();
            fr.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer fr=new Customer();
            fr.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            

        }
       
        private void button9_Click(object sender, EventArgs e)
        {
            string InvoiceDate;
            string InvoiceID;
            string CustomerName;
            string ContactNo;
            string Town;
            string ProductName;
            string ProductPrice;
            string Quantity;
            string TotalPrice;


            InvoiceDate = textBox1.Text;
            InvoiceID = textBox2.Text;
            CustomerName = textBox3.Text;
            ContactNo = textBox4.Text;
            Town = textBox5.Text;
            ProductName = textBox6.Text;
            ProductPrice = textBox7.Text;
            Quantity = textBox8.Text;
            TotalPrice = textBox9.Text;




            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into bill values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            display_data();
            MessageBox.Show("Data Successfully inserted");
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            textBox6.Text = " ";
            textBox7.Text = " ";
            textBox8.Text = " ";
            
           
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
           
        }

        private void display_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from bill";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Billing_Load(object sender, EventArgs e)
        {
            display_data();
            display_data2();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           
                
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["InvoiceDate"].Value.ToString();
                textBox2.Text = row.Cells["InvoiceID"].Value.ToString();
                textBox3.Text = row.Cells["CustomerName"].Value.ToString();
                textBox4.Text = row.Cells["ContactNo"].Value.ToString();
                textBox5.Text = row.Cells["Town"].Value.ToString();
                textBox6.Text = row.Cells["ProductName"].Value.ToString();
                textBox7.Text = row.Cells["ProductPrice"].Value.ToString();
                textBox8.Text = row.Cells["Quantity"].Value.ToString();
                textBox9.Text = row.Cells["TotalPrice"].Value.ToString();
                
                
                
            }
        }
        private void display_data2()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Productname,Productprice,Quantity from product";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                textBox6.Text = row.Cells["ProductName"].Value.ToString();
                textBox7.Text = row.Cells["ProductPrice"].Value.ToString();
                textBox8.Text = row.Cells["Quantity"].Value.ToString();
            }
        }

        
        private void button7_Click_2(object sender, EventArgs e)
        {
            
            int Productprice, Quantity,TotalPrice;
            Productprice = int.Parse(textBox7.Text);
            Quantity = int.Parse(textBox8.Text);
            TotalPrice = Productprice * Quantity;
            textBox9.Text = TotalPrice.ToString();

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
        int Rs = 0;
        private void button12_Click(object sender, EventArgs e)
        {
            int TotalPrice;
            TotalPrice = int.Parse(textBox9.Text);
            Rs = Rs + TotalPrice;
            textBox10.Text = Rs.ToString();
            
        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            


        }
       

       
       

    }
}
