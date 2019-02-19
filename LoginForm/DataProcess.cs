using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace LoginForm
{
    public class DataProcess
    { 

        public SqlConnection GetConnection()
        {
          
           var connect = new SqlConnection("Data Source =LEBINHAN-LAPTOP\\SQLEXPRESS; " +
               "Initial Catalog = StudentInformation; User ID = sa; Password = thaybadao");
            return connect;
        }
        public bool CheckLogin(string StdName, string StdPass)
        {
           string sql = "SELECT * FROM [dbo].[Student] WHERE StdName= @u  AND StdPass=@p";            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = GetConnection();
            cmd.Parameters.AddWithValue("@u", StdName);
            cmd.Parameters.AddWithValue("@p", StdPass);
            cmd.Connection.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            bool result = rd.HasRows;
            cmd.Connection.Close();
            return result;
        }
    }
}
