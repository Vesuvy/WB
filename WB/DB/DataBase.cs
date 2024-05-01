using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WB.DB
{
    internal class DataBase
    {
        private readonly string _connectionString =
            @"Data Source=LAPTOP-0BEQOP00\SQLEXPRESS;Initial Catalog=Globa_Wildberries;Integrated Security=True";

        private readonly SqlConnection _connection;

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-0BEQOP00\SQLEXPRESS;Initial Catalog=Globa_Wildberries;Integrated Security=True");

        public void openConnection() {
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
        }
        public void closeConnection() {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
        }
        public SqlConnection getConnection() {
            return con;
        }

    }
}
