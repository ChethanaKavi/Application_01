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
    public partial class Seller_Page : Form
    {
        public Seller_Page()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\cheth\Documents\Supermarket.mdf;Integrated Security=True;Connect Timeout=30");

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {   
            string Productid;
            string Productname;
            string Quantity;
            string Productprice;
            string Description;


            Productid= textBox1.Text;
            Productname = textBox2.Text;
            Quantity=textBox3.Text;
            Productprice=textBox4.Text;
            Description=textBox5.Text;

            if (Productid == "" || Productname == "" || Quantity == "" || Productprice == "" || Description == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
               
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into product values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                display_data();
                MessageBox.Show("Data Successfully Inserted");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }

        }

        private void Seller_Page_Load(object sender, EventArgs e)
        {
            display_data();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string Productid;
            string Productname;
            string Quantity;
            string Productprice;
            string Description;


            Productid = textBox1.Text;
            Productname = textBox2.Text;
            Quantity = textBox3.Text;
            Productprice = textBox4.Text;
            Description = textBox5.Text;

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update product set Productid='" + textBox1.Text + "',Productname='" + textBox2.Text + "',Quantity='" + textBox3.Text + "',Productprice='" + textBox4.Text + "',Description='" + textBox5.Text + "'where Productid='" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                display_data();
                MessageBox.Show("Data Successfully Updated");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string Productid;
            string Productname;
            string Quantity;
            string Productprice;
            string Description;


            Productid = textBox1.Text;
            Productname = textBox2.Text;
            Quantity = textBox3.Text;
            Productprice = textBox4.Text;
            Description = textBox5.Text;

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from product where Productid='" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                display_data();
                MessageBox.Show("Data Successfully Removed");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
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
            cmd.CommandText = "select * from product";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["Productid"].Value.ToString();
                
                textBox3.Text = row.Cells["Quantity"].Value.ToString();
                textBox4.Text = row.Cells["Productprice"].Value.ToString();
                textBox5.Text = row.Cells["Description"].Value.ToString();

            }

        
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Description like '%" + textBox6.Text + "%'");
        }
        



    }
}
