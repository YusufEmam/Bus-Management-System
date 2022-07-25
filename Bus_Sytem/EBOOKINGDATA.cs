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

namespace Bus_Sytem
{
    public partial class EBOOKINGDATA : Form
    {
        public EBOOKINGDATA()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            EMPLOYEEPAGE employeepage = new EMPLOYEEPAGE();
            employeepage.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=YUSUF;Initial Catalog=Online_Bus;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from booking where bookingid =@id", con);
            cmd.Parameters.AddWithValue("@id", comboBox1.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                textBox4.Text = dr[3].ToString();
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=YUSUF;Initial Catalog=Online_Bus;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("insert into booking(bookingid,busno,seatno,journeydate) values(@id,@busno,@seatno,@journeydate)", con);
                cmd.Parameters.AddWithValue("id", textBox1.Text);
                cmd.Parameters.AddWithValue("busno", textBox2.Text);
                cmd.Parameters.AddWithValue("seatno", textBox3.Text);
                cmd.Parameters.AddWithValue("journeydate", textBox4.Text);
                con.Open();
                int rowaff = cmd.ExecuteNonQuery();
                if (rowaff > 0)
                {
                    MessageBox.Show("Booking added successfully!");
                }
                else
                {
                    MessageBox.Show("Booking not added");
                }
                con.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void EBOOKINGDATA_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'online_BusDataSet12.booking' table. You can move, or remove it, as needed.
            this.bookingTableAdapter1.Fill(this.online_BusDataSet12.booking);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=YUSUF;Initial Catalog=Online_Bus;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("update booking set busno= @busno, seatno =@seatno, journeydate =@journeydate where bookingid =@id", con);
                cmd.Parameters.AddWithValue("@id", comboBox1.Text);
                cmd.Parameters.AddWithValue("busno", textBox2.Text);
                cmd.Parameters.AddWithValue("seatno", textBox3.Text);
                cmd.Parameters.AddWithValue("journeydate", textBox4.Text);
                con.Open();
                int rowaff = cmd.ExecuteNonQuery();
                if (rowaff > 0)
                {
                    MessageBox.Show("Booking updated successfully!");
                }
                else
                {
                    MessageBox.Show("Booking not updated");
                }
                con.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=YUSUF;Initial Catalog=Online_Bus;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("delete from booking where bookingid = @id", con);
                cmd.Parameters.AddWithValue("@id", comboBox1.Text);
                con.Open();
                int rowaff = cmd.ExecuteNonQuery();
                if (rowaff > 0)
                {
                    MessageBox.Show("Booking deleted successfully!");
                }
                else
                {
                    MessageBox.Show("Booking not deleted");
                }
                con.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
