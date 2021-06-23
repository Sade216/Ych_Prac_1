using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Packedges_beta_0._1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Continue_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Visible = false;
        }

        private void Personal_data_approve_CheckedChanged(object sender, EventArgs e)
        {
            if (Personal_data_approve.Checked == true)
            {
                Continue.Enabled = true;
                
            }
            else
            {
                Continue.Enabled = false;
            }
        }
    }
}
