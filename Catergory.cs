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
    public partial class Catergory : Form
    {
        public Catergory()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\cheth\Documents\Supermarket.mdf;Integrated Security=True;Connect Timeout=30");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Order fr = new Order();
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
            Customer fr = new Customer();
            fr.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Billing fr = new Billing();
            fr.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string CatergoryID ;
            string CatergoryName;
            string Description;
            
            CatergoryID = textBox1.Text;
            CatergoryName = textBox2.Text;
            Description = textBox3.Text;

            if (CatergoryID == "" || CatergoryName == "" || Description == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into catergory values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                display_data();
                MessageBox.Show("Data Successfully Inserted");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string CatergoryID ;
            string CatergoryName;
            string Description;
            
            CatergoryID = textBox1.Text;
            CatergoryName = textBox2.Text;
            Description = textBox3.Text;

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update catergory set CatergoryID='" + textBox1.Text + "',CatergoryName='" + textBox2.Text + "',Description='" + textBox3.Text + "' where CatergoryID='"+textBox1.Text+"'";
                cmd.ExecuteNonQuery();
                con.Close();
                display_data();
                MessageBox.Show("Data Successfully Updated");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string CatergoryID ;
            string CatergoryName;
            string Description;
            
            CatergoryID = textBox1.Text;
            CatergoryName = textBox2.Text;
            Description = textBox3.Text;

            

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from catergory where catergoryID='" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                display_data();
                MessageBox.Show("Data Successfully Removed");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
        }
        private void display_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from catergory";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Catergory_Load(object sender, EventArgs e)
        {
            display_data();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["CatergoryID"].Value.ToString();
                textBox2.Text = row.Cells["CatergoryName"].Value.ToString();
                textBox3.Text = row.Cells["Description"].Value.ToString();
                

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("CatergoryName like '%" + textBox4.Text + "%'");
        }
    }
}
