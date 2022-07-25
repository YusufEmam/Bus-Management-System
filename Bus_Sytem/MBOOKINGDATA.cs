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
    public partial class MBOOKINGDATA : Form
    {
        public MBOOKINGDATA()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MANAGERPAGE managerpage = new MANAGERPAGE();
            managerpage.ShowDialog();
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

        private void MBOOKINGDATA_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'online_BusDataSet19.booking' table. You can move, or remove it, as needed.
            this.bookingTableAdapter.Fill(this.online_BusDataSet19.booking);

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
