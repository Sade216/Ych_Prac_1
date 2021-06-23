using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

namespace Packedges_beta_0._1
{
    public partial class Form2 : Form
    {
        public int isLogin;
        public string userEmail_ref;

        Form3 form3;
        Form4 form4;

        public int form3_isOpened = 0;
        public int form4_isOpened = 0;

        Button[] btn;

        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            if(isLogin == 0)
            {
                btn_add.Enabled = false;
            }
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                e.Cancel = false;
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private Boolean databaseOutput()
        {
            List<string> row = null;

            DB db = new DB();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * FROM [Order] WHERE [isOrdered] = 0", db.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            string[] firstName = new string[100];
            string[] lastName = new string[100];
            string[] email = new string[100];
            string[] whereFrom = new string[100];
            string[] where = new string[100];
            string[] desc = new string[100];
            string[] date = new string[100];
            string[] time = new string[100];

            if (table.Rows.Count > 0)
            {
                row = new List<string>();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        row.Add(table.Rows[i][j].ToString());
                    }

                    
                    #region---присовение элементов---
                    firstName[i] = table.Rows[i][1].ToString();
                    lastName[i] = table.Rows[i][2].ToString();
                    email[i] = table.Rows[i][3].ToString();
                    whereFrom[i] = table.Rows[i][4].ToString();
                    where[i] = table.Rows[i][5].ToString();
                    desc[i] = table.Rows[i][6].ToString();
                    date[i] = table.Rows[i][7].ToString();
                    time[i] = table.Rows[i][8].ToString();
                    #endregion
                    FlowLayoutPanel[] tb = new FlowLayoutPanel[i + 2];
                    for (int f = 0; f < tb.Length; f++)
                    {
                        Button[] lb = new Button[f];
                        for (int l = 0; l < lb.Length; l++)
                        {
                            lb[l] = new System.Windows.Forms.Button();
                            lb[l].Location = new System.Drawing.Point(10, 10 + (i * 100));
                            lb[l].Size = new System.Drawing.Size(400, 100);
                            lb[l].Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
                            lb[l].Click += (sender, args) =>
                            {
                                
                                if(MessageBox.Show($"Имя:{firstName[l - 1]} \nФамилия:{lastName[l - 1]}\nОтуда:{whereFrom[l - 1]}\nКуда:{where[l - 1]}\nДата:{date[l - 1]}\nВремя:{time[l - 1]}\nОписание:{desc[l - 1]}\n", "Зарезервировать?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    reserveOrder(email[l - 1], where[l - 1], whereFrom[l - 1]);
                                }
                            };
                            lb[l].Text = $"Имя:{firstName[i]} \nФамилия:{lastName[i]}\nОтуда:{whereFrom[i]}\nКуда:{where[i]}\nДата:{date[i]}\nВремя:{time[i]}\nОписание:{desc[i]}\n";
                            panel1.Controls.Add(lb[l]);
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        private Boolean filteredDatabaseOutPut()
        {
            List<string> row = null;

            DB db = new DB();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * FROM [Order] WHERE [isOrdered] = 0", db.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            string[] firstName = new string[100];
            string[] lastName = new string[100];
            string[] email = new string[100];
            string[] whereFrom = new string[100];
            string[] where = new string[100];
            string[] desc = new string[100];
            string[] date = new string[100];
            string[] time = new string[100];

            if (table.Rows.Count > 0)
            {
                row = new List<string>();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        row.Add(table.Rows[i][j].ToString());
                    }


                    #region---присовение элементов---
                    firstName[i] = table.Rows[i][1].ToString();
                    lastName[i] = table.Rows[i][2].ToString();
                    email[i] = table.Rows[i][3].ToString();
                    whereFrom[i] = table.Rows[i][4].ToString();
                    where[i] = table.Rows[i][5].ToString();
                    desc[i] = table.Rows[i][6].ToString();
                    date[i] = table.Rows[i][7].ToString();
                    time[i] = table.Rows[i][8].ToString();
                    #endregion
                    FlowLayoutPanel[] tb = new FlowLayoutPanel[i + 2];
                    for (int f = 0; f < tb.Length; f++)
                    {
                        Button[] lb = new Button[f];
                        for (int l = 0; l < lb.Length; l++)
                        {
                            lb[l] = new System.Windows.Forms.Button();
                            lb[l].Location = new System.Drawing.Point(10, 10 + (i * 100));
                            lb[l].Size = new System.Drawing.Size(400, 100);
                            lb[l].Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
                            lb[l].Click += (sender, args) =>
                            {

                                if (MessageBox.Show($"Имя:{firstName[l - 1]} \nФамилия:{lastName[l - 1]}\nОтуда:{whereFrom[l - 1]}\nКуда:{where[l - 1]}\nДата:{date[l - 1]}\nВремя:{time[l - 1]}\nОписание:{desc[l - 1]}\n", "Зарезервировать?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    reserveOrder(email[l - 1], where[l - 1], whereFrom[l - 1]);
                                }
                            };
                            lb[l].Text = $"Имя:{firstName[i]} \nФамилия:{lastName[i]}\nОтуда:{whereFrom[i]}\nКуда:{where[i]}\nДата:{date[i]}\nВремя:{time[i]}\nОписание:{desc[i]}\n";
                            panel1.Controls.Add(lb[l]);
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        void reserveOrder(string email, string where, string whereFrom)
        {
            DB db = new DB();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("UPDATE [Order] SET [isOrdered] = 1 WHERE [email] = @uE AND [where] = @w AND [where_from] = @wF", db.GetConnection());

            command.Parameters.AddWithValue("@uE", email);
            command.Parameters.AddWithValue("@wF", whereFrom);
            command.Parameters.AddWithValue("@w", where);

            adapter.SelectCommand = command;
            adapter.Fill(table);
        }
        private void button_Clicked(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            databaseOutput();
        }

        private void log_reg_btn_Click_1(object sender, EventArgs e)
        {
            if (form4 == null || form4.IsDisposed)
            {
                this.Visible = false;
                form4 = new Form4();
                form4.Show();
            }
        }

        private void btn_add_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            form3 = new Form3();
            form3.Show();
        }

        private void tableLayoutPanel3_MouseHover_1(object sender, EventArgs e)
        {
            userEmail_ref = Form4.Data.userEmail;
            if (userEmail_ref != null)
            {
                log_reg_btn.Text = userEmail_ref;
            }
            if (isLogin == 1)
            {
                btn_add.Enabled = true;
                log_reg_btn.Enabled = false;
            }
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            
        }
    }
}
