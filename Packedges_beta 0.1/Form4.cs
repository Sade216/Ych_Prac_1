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
using System.Text.RegularExpressions;

namespace Packedges_beta_0._1
{
    public partial class Form4 : Form
    {
        Form2 form2;
        Form3 form3;

        public static class Data
        {
            public static string userEmail { get; set; }
        }

        public Form4()
        {
            InitializeComponent();
        }
        private Boolean userLogin(string email, string pass)
        {
            DB db = new DB();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * FROM [Login] WHERE [email] = @uE  AND [password] = @uP COLLATE Latin1_GENERAL_CS_AS", db.GetConnection());


            command.Parameters.Add("@uE", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("@uP", SqlDbType.VarChar).Value = pass;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Log_In_btn_Click(object sender, EventArgs e)
        {
            string email = EmailField.Text;
            string pass = PassField.Text;
            if(userLogin(email, pass) == true)
            {
                MessageBox.Show("Вы успешно вошли в аккаунт.");
                this.Close();

                form2.userEmail_ref = email;
                Data.userEmail = email;
                form2.isLogin = 1;
                form2.Visible = true;
            }
            else
            {
                MessageBox.Show("Вы ввели что-то неверно...");
                this.Close();
                form2.isLogin = 0;
                form2.Visible = true;
            }
                
        }
        
        private void reg_btn_Click(object sender, EventArgs e)
        {
            Form5 reg = new Form5();
            reg.Visible = true;
            this.Visible = false;
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            form2 = new Form2();
            form3 = new Form3();
            form2.Visible = true;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void EmailField_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EmailField.Text?.Trim()))
            {
                const string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                var email = EmailField.Text.Trim().ToLowerInvariant();

                if (Regex.Match(email, pattern).Success)
                {
                    EmailField.ForeColor = Color.ForestGreen;
                }
                else
                {
                    EmailField.ForeColor = Color.Red;
                }
            }
        }
    }
}
