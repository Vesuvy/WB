using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WB.Models.Database;

namespace WB.DB
{
    internal class IDataBase
    {
        public void UpdateProduct(Products product)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnectionKey"].ConnectionString))
            {
                sqlConnection.Open();

                string queryString = "UPDATE Products SET Title = @Title, Price = @Price WHERE Id = @Id";
                SqlCommand command = new SqlCommand(queryString, sqlConnection);
                command.Parameters.Add("@Id", SqlDbType.Int).Value = product.Id;
                command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = product.Title;
                command.Parameters.Add("@Price", SqlDbType.Decimal).Value = product.Price;

                command.ExecuteNonQuery();

                queryString = "UPDATE Orders_Details SET Quantity = @Quantity WHERE FK_Product = @Id";
                command = new SqlCommand(queryString, sqlConnection);
                command.Parameters.Add("@Id", SqlDbType.Int).Value = product.Id;
                command.Parameters.Add("@Quantity", SqlDbType.Int).Value = product.Quantity;

                command.ExecuteNonQuery();
            }
        }

        public void DeleteProduct(Products product)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnectionKey"].ConnectionString))
            {
                sqlConnection.Open();

                string queryString = "DELETE FROM Orders_Details WHERE FK_Product = @Id";
                SqlCommand command = new SqlCommand(queryString, sqlConnection);
                command.Parameters.Add("@Id", SqlDbType.Int).Value = product.Id;

                command.ExecuteNonQuery();

                queryString = "DELETE FROM Products WHERE Id = @Id";
                command = new SqlCommand(queryString, sqlConnection);
                command.Parameters.Add("@Id", SqlDbType.Int).Value = product.Id;

                command.ExecuteNonQuery();
            }
        }
    }
}
