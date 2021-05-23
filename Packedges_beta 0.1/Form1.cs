using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Packedges_beta_0._1
{
    public partial class Form1 : Form
    {
        Form2 form = new Form2();
        int is_opened = 0;
        public static int vibor;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (is_opened == 0)
            {
                form.Show();
                is_opened = 1;
            }
            this.Visible = false;
            vibor = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (is_opened == 0)
            {
                form.Show();
                is_opened = 1;
            }
            this.Visible = false;
            vibor = 1;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
