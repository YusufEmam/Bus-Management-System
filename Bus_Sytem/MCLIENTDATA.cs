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
    public partial class MCLIENTDATA : Form
    {
        public MCLIENTDATA()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MANAGERPAGE managerpage = new MANAGERPAGE();
            managerpage.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=YUSUF;Initial Catalog=Online_Bus;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from client where clientid =@id", con);
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=YUSUF;Initial Catalog=Online_Bus;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("update client set name =@name, workingemail= @workingemail, address =@address where clientid =@id", con);
                cmd.Parameters.AddWithValue("@id", comboBox1.Text);
                cmd.Parameters.AddWithValue("name", textBox2.Text);
                cmd.Parameters.AddWithValue("workingemail", textBox3.Text);
                cmd.Parameters.AddWithValue("address", textBox4.Text);
                con.Open();
                int rowaff = cmd.ExecuteNonQuery();
                if (rowaff > 0)
                {
                    MessageBox.Show("Client updated successfully!");
                }
                else
                {
                    MessageBox.Show("Client not updated");
                }
                con.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void MCLIENTDATA_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'online_BusDataSet16.client' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.online_BusDataSet16.client);

        }
    }
}
