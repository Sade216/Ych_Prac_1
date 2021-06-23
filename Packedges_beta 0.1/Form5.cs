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
    public partial class Form5 : Form
    {
        Form2 form2;
        public Form5()
        {
            InitializeComponent();
        }

        public void create_btn_Click(object sender, EventArgs e)
        {
            string firstName = FirstNameField.Text;
            string lastName = LastNameField.Text;
            string email = EmailField.Text;
            string pass = SecondaryPassField.Text;
            userRegister(firstName, lastName, email, pass);
            this.Visible = false;
            form2 = new Form2();
            form2.Visible = true;
        }
        private Boolean userRegister(string firstName, string lastName, string email, string pass)
        {
            DB db = new DB();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("INSERT INTO [Login] ([first_name],[last_name],[email],[password]) VALUES (@uFN, @uLN, @uE, @uP) COLLATE Latin1_GENERAL_CS_AS", db.GetConnection());

            command.Parameters.Add("@uFN", SqlDbType.NVarChar).Value = firstName;
            command.Parameters.Add("@uLN", SqlDbType.NVarChar).Value = lastName;
            command.Parameters.Add("@uE", SqlDbType.NVarChar).Value = email;
            command.Parameters.Add("@uP", SqlDbType.NVarChar).Value = pass;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Регистрация прошла успешно.");
                db.closeConnection();
                return true;
            }
            else
            {
                MessageBox.Show("Такой пользователь уже существует.");
                db.closeConnection();
                return false;
            }
            
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            form2 = new Form2();
            form2.Visible = true;
        }

        private void Form5_Load(object sender, EventArgs e)
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

        private void PrimaryPassField_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
