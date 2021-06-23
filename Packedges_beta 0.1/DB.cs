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
    class DB
    {
        SqlConnection connection = new SqlConnection("workstation id=LoginOnApp.mssql.somee.com;packet size=4096;user id=OiLe_xD_SQLLogin_1;pwd=drrfcrefio;data source=LoginOnApp.mssql.somee.com;persist security info=False;initial catalog=LoginOnApp");

        public void openConnection()
        {
            if(connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void closeConnection()
        {
            if(connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public SqlConnection GetConnection()
        {
            return connection;
        }

        
    }
}
