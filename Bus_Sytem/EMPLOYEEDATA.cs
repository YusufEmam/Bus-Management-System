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
    public partial class EMPLOYEEDATA : Form
    {
        public EMPLOYEEDATA()
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
            SqlCommand cmd = new SqlCommand("select * from employee, contact_employee where employeeid =@id and cemployeeid =@empid", con);
            cmd.Parameters.AddWithValue("@id", comboBox1.Text);
            cmd.Parameters.AddWithValue("@empid", comboBox1.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[2].ToString();
                textBox3.Text = dr[3].ToString();
                textBox4.Text = dr[4].ToString();
                textBox5.Text = dr[7].ToString();
            }
            con.Close();
        }

        private void EMPLOYEEDATA_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'online_BusDataSet2.employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.online_BusDataSet2.employee);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=YUSUF;Initial Catalog=Online_Bus;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("insert into employee(employeeid,password,name,workingemail,address) values(@id,@password,@name,@workingemail,@address)", con);
                cmd.Parameters.AddWithValue("id", textBox1.Text);
                cmd.Parameters.AddWithValue("password", textBox6.Text);
                cmd.Parameters.AddWithValue("name", textBox2.Text);
                cmd.Parameters.AddWithValue("workingemail", textBox3.Text);
                cmd.Parameters.AddWithValue("address", textBox4.Text);
                con.Open();
                int rowaff = cmd.ExecuteNonQuery();
                if (rowaff > 0)
                {
                    MessageBox.Show("Employee added successfully!");
                }
                else
                {
                    MessageBox.Show("Employee not added");
                }
                con.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=YUSUF;Initial Catalog=Online_Bus;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("update employee set name =@name, workingemail= @workingemail, address =@address where employeeid =@id", con);
                cmd.Parameters.AddWithValue("@id", comboBox1.Text);
                cmd.Parameters.AddWithValue("name", textBox2.Text);
                cmd.Parameters.AddWithValue("workingemail", textBox3.Text);
                cmd.Parameters.AddWithValue("address", textBox4.Text);
                con.Open();
                int rowaff = cmd.ExecuteNonQuery();
                if (rowaff > 0)
                {
                    MessageBox.Show("Employee updated successfully!");
                }
                else
                {
                    MessageBox.Show("Employee not updated");
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=YUSUF;Initial Catalog=Online_Bus;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("delete from employee where employeeid = @id", con);
                cmd.Parameters.AddWithValue("@id", comboBox1.Text);
                con.Open();
                int rowaff = cmd.ExecuteNonQuery();
                if (rowaff > 0)
                {
                    MessageBox.Show("Employee deleted successfully!");
                }
                else
                {
                    MessageBox.Show("Employee not deleted");
                }
                con.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
