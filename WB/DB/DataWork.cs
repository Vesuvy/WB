using Microsoft.Data.SqlClient;
using System;

namespace WB.DB
{
    internal class DataWork
    {
        private readonly string _connectionString = 
            @"Data Source=localhost;Initial Catalog=Store;Integrated Security=True";
        private readonly SqlConnection _connection;

        public DataWork()
        {
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }
        public DataWork(string newConnectionString)
        {
            _connectionString = newConnectionString;
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }
        public void CloseConnection()
        {
            _connection.Close();
        }

    }
}
