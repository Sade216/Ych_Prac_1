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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int vibor_1 = Form1.vibor;
            if(vibor_1 == 0)
            {
                Voditel();
            }
            else
            {
                Zakazchik();
            }
        }
        void Voditel()
        {

        }
        void Zakazchik()
        {

        }
    }
}
