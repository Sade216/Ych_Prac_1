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
    public partial class Form3 : Form
    {
        public string userFN;
        public string userLN;
        public string userEmail;

        Form2 form2;

        public Form3()
        {
            InitializeComponent();
        }
        private Boolean findFLN(string userEmail)
        {
            DB db = new DB();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * FROM [Login] WHERE [email] = @uE COLLATE Latin1_GENERAL_CS_AS", db.GetConnection());


            command.Parameters.Add("@uE", SqlDbType.NVarChar).Value = userEmail;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                userFN = table.Rows[0][1].ToString();
                userLN = table.Rows[0][2].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
        private Boolean isOrderCreated(string userFN, string userLN, string userEmail, string where_from, string where, string description, string Data, string Time, string Price, int state)
        {
            DB db = new DB();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("INSERT INTO [Order] ([first_name],[last_name],[email],[where_from],[where],[description],[Data],[Time],[Price],[isOrdered]) VALUES (@uFN, @uLN, @uE, @wF, @w, @desc, @data, @time, @price, @iO)", db.GetConnection());

            command.Parameters.Add("@uFN", SqlDbType.NVarChar).Value = userFN;
            command.Parameters.Add("@uLN", SqlDbType.NVarChar).Value = userLN;
            command.Parameters.Add("@uE", SqlDbType.VarChar).Value = userEmail;
            command.Parameters.Add("@wF", SqlDbType.NVarChar).Value = where_from;
            command.Parameters.Add("@w", SqlDbType.NVarChar).Value = where;
            command.Parameters.Add("@desc", SqlDbType.NVarChar).Value = description;
            command.Parameters.Add("@data", SqlDbType.Date).Value = Data;
            command.Parameters.Add("@time", SqlDbType.Time).Value = Time;
            command.Parameters.Add("@price", SqlDbType.Money).Value = Price;
            command.Parameters.Add("@iO", SqlDbType.Int).Value = state;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Создание заказа прошло успешно.");
                db.closeConnection();
                return true;
            }
            else
            {
                MessageBox.Show("Во время создания заказа произошла ошибка.");
                db.closeConnection();
                return false;
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            userEmail = Form4.Data.userEmail;
            if (userEmail != null)
            {
                findFLN(userEmail);
            }
            form2 = new Form2();
            form2.isLogin = 1;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void createOrder_btn_Click(object sender, EventArgs e)
        {
            string where_from = otkydaField.Text;
            string where = kydaField.Text;
            string description = descField.Text;
            string Date = dateField.Text;
            string Time = timeField.Text;
            string Price = priceField.Text;
            int state = 0;

            #region --if--
            if (otkydaField.Text == null)
                MessageBox.Show("Вы не заполнили поле Откуда.", "?????", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (kydaField.Text == null)
                MessageBox.Show("Вы не заполнили поле Куда.", "?????", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (descField.Text == null)
                MessageBox.Show("Вы не заполнили поле Описание.", "?????", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (dateField.Text == null)
                MessageBox.Show("Вы не заполнили поле Дата.", "?????", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (timeField.Text == null)
                MessageBox.Show("Вы не заполнили поле Время.", "?????", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (priceField.Text == null)
                MessageBox.Show("Вы не заполнили поле Цена.", "?????", MessageBoxButtons.OK, MessageBoxIcon.Error);
            #endregion

            isOrderCreated(userFN, userLN, userEmail, where_from, where, description, Date, Time, Price, state);
            this.Close();
            form2.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
