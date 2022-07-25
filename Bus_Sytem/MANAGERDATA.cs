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
    public partial class MANAGERDATA : Form
    {
        public MANAGERDATA()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ADMINPAGE adminpage = new ADMINPAGE();
            adminpage.ShowDialog();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=YUSUF;Initial Catalog=Online_Bus;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from manager, contact_manager where managerid =@managerid and cmanagerid =@cmanagerid", con);
            cmd.Parameters.AddWithValue("@managerid", comboBox1.Text);
            cmd.Parameters.AddWithValue("@cmanagerid", comboBox1.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[2].ToString();
                textBox3.Text = dr[3].ToString();
                textBox4.Text = dr[4].ToString();
                textBox5.Text = dr[6].ToString();
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=YUSUF;Initial Catalog=Online_Bus;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("insert into manager(managerid,password,name,workingemail,address) values(@managerid,@password,@name,@workingemail,@address)", con);
                cmd.Parameters.AddWithValue("managerid", textBox1.Text);
                cmd.Parameters.AddWithValue("password", textBox6.Text);
                cmd.Parameters.AddWithValue("name", textBox2.Text);
                cmd.Parameters.AddWithValue("workingemail", textBox3.Text);
                cmd.Parameters.AddWithValue("address", textBox4.Text);
                con.Open();
                int rowaff = cmd.ExecuteNonQuery();
                if (rowaff > 0)
                {
                    MessageBox.Show("Manager added successfully!");
                }
                else
                {
                    MessageBox.Show("Manager not added");
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=YUSUF;Initial Catalog=Online_Bus;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("update manager set name =@name, workingemail= @workingemail, address =@address where managerid =@id", con);
                cmd.Parameters.AddWithValue("@id", comboBox1.Text);
                cmd.Parameters.AddWithValue("name", textBox2.Text);
                cmd.Parameters.AddWithValue("workingemail", textBox3.Text);
                cmd.Parameters.AddWithValue("address", textBox4.Text);
                con.Open();
                int rowaff = cmd.ExecuteNonQuery();
                if (rowaff > 0)
                {
                    MessageBox.Show("Manager updated successfully!");
                }
                else
                {
                    MessageBox.Show("Manager not updated");
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
                SqlCommand cmd = new SqlCommand("delete from manager where managerid = @id", con);
                cmd.Parameters.AddWithValue("@id", comboBox1.Text);
                con.Open();
                int rowaff = cmd.ExecuteNonQuery();
                if (rowaff > 0)
                {
                    MessageBox.Show("Manager deleted successfully!");
                }
                else
                {
                    MessageBox.Show("Manager not deleted");
                }
                con.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void MANAGERDATA_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'online_BusDataSet17.manager' table. You can move, or remove it, as needed.
            this.managerTableAdapter1.Fill(this.online_BusDataSet17.manager);

        }
    }
}
