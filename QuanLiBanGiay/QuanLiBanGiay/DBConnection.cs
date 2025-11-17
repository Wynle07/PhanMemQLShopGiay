using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanGiay
{
    public static class DBConnection
    {
        //private static readonly string connectionString = "Data Source=ADMIN\\SQLSERVERMS;Initial Catalog=QL_BANGIAY;Integrated Security=True;TrustServerCertificate=True";
        //private static readonly string connectionString = "Data Source=HOMEPC\\MSSQLSERVER01;Initial Catalog=QL_BANGIAY;Integrated Security=True;TrustServerCertificate=True";
        private static readonly string connectionString = "Data Source=.;Initial Catalog=QL_BANGIAY;Integrated Security=True;TrustServerCertificate=True";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }


        public static void OpenConnection(SqlConnection conn)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }


        public static void CloseConnection(SqlConnection conn)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
    }
}
