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
    public partial class ADMINPAGE : Form
    {
        public ADMINPAGE()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ADMINLOGIN adminlogin = new ADMINLOGIN();
            adminlogin.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MANAGERDATA managerdata = new MANAGERDATA();
            managerdata.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            EMPLOYEEDATA employeedata = new EMPLOYEEDATA();
            employeedata.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            BUSDATA busdata = new BUSDATA();
            busdata.ShowDialog();
        }
    }
}
