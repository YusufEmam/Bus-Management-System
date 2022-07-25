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
    public partial class EMPLOYEELOGIN : Form
    {
        public EMPLOYEELOGIN()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LOGIN login = new LOGIN();
            login.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=YUSUF;Initial Catalog=Online_Bus;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select employeeid,password from employee where employeeid = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.Hide();
                EMPLOYEEPAGE employeepage = new EMPLOYEEPAGE();
                employeepage.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wrong Employee ID/Password!");
            }
            con.Close();
        }
    }
}
