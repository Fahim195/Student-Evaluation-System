using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEvaluation_System.DAL.DAO
{
    class DBconnection
    {
        public static SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection();
            string DbSereverLink = @"Data Source=DESKTOP-304LGOR\SQLEXPRESS;Database=StudentEvaluationSystem;Integrated Security=SSPI";
            connection.ConnectionString = DbSereverLink;
            connection.Open();
            return connection;
        }
    }
}
