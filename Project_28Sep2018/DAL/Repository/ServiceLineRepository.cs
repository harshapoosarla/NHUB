using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL.Repository
{
    public class ServiceLineRepository
    {
        public List<ServiceLine> servicelinelist = new List<ServiceLine>();
        public List<ServiceLine> getDetails()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACULAP-119;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("selectproc", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@Action", SqlDbType.VarChar, 10).Value = "SELECT";
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        servicelinelist.Add(new ServiceLine
                        {
                            Id = Convert.ToInt32(sqlDataReader["Id"].ToString()),
                            Name = (sqlDataReader["Name"].ToString())
                        });
                    }
                }
            }
            return servicelinelist;
        }
       

        public void InsertServiceLine(string pServLineName,string pSLMids)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACULAP-119;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("Proc_InsertServiceLine", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = pServLineName;
                int ServLineId =Convert.ToInt32(sqlCommand.Parameters.Add("@pServLineId", SqlDbType.NVarChar, 50).Value);
                string[] Slm = pSLMids.Split(',');
                foreach (string slms in Slm)
                {


                    SqlCommand sqlCommand1 = new SqlCommand("Proc_InsertServLineManagers", connection);
                    sqlCommand1.CommandType = CommandType.StoredProcedure;
                    sqlCommand1.Parameters.Add("@pId", SqlDbType.Int).Value =pId;
                    sqlCommand1.Parameters.Add("@pServiceLineID",SqlDbType.Int).Value=
                    sqlCommand1.Parameters.Add("@pUserId", SqlDbType.NVarChar).Value =
                    
                    sqlCommand1.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public void DeleteServiceLine(int pId)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=ACULAP-119;Initial Catalog=NotificationHub;Integrated Security=True";
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("Proc_DeleteServiceLine", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@pId", SqlDbType.Int).Value = pId;
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }
    }
}
