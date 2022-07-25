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
    public partial class MANAGERPAGE : Form
    {
        public MANAGERPAGE()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            MANAGERLOGIN managerlogin = new MANAGERLOGIN();
            managerlogin.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MEMPLOYEEDATA memployee = new MEMPLOYEEDATA();
            memployee.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MBUSDATA mbusdata = new MBUSDATA();
            mbusdata.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MCLIENTDATA mclientdata = new MCLIENTDATA();
            mclientdata.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MBOOKINGDATA mbookingdata = new MBOOKINGDATA();
            mbookingdata.ShowDialog();
        }
    }
}
