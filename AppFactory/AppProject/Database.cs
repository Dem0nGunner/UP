using Microsoft.Data.SqlClient;
using System;
namespace DataBaser
{
    internal class DataBase
    {
        SqlConnection connect = new SqlConnection(@"Data Source = DESKTOP-OFQHG3Q\GOODOUBLE;Initial Catalog = УП; TrustServerCertificate=True; Integrated Security = True");
        public void text() { if (connect!=null) {  Console.WriteLine("ГОТОВО"); } }
        public void openConnection() { if (connect.State == System.Data.ConnectionState.Closed) { connect.Open(); } }
        public void closeConnection() { if (connect.State == System.Data.ConnectionState.Open) { connect.Close(); } }
        public SqlConnection getConnection() { return connect; }
    }
}