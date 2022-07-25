using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bus_Sytem
{
    public partial class EMPLOYEEPAGE : Form
    {
        public EMPLOYEEPAGE()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            EMPLOYEELOGIN employeelogin = new EMPLOYEELOGIN();
            employeelogin.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            EBOOKINGDATA ebookingdata = new EBOOKINGDATA();
            ebookingdata.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            EBUSDATA ebusdata = new EBUSDATA();
            ebusdata.ShowDialog();
        }
    }
}
