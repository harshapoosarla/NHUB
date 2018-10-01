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
        public DataTable ServLineManTab = new DataTable();
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

        public DataTable getServLineDetails(string pServLineId)
        {

            SqlDataAdapter adapter;
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACULAP-119;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();
                string sql = "select u.id,u.UserName from ServiceLineManager sm, AspNetUsers u where  sm.UserId=u.Id and ServiceLineId=" + pServLineId;
                adapter = new SqlDataAdapter(sql, connection);
                //SqlCommand sqlCommand = new SqlCommand(sql, connection);
                adapter.Fill(ServLineManTab);

            }
            return ServLineManTab;
        }





        public void InsertServiceLine(string pServLineName, string pSLMids)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACULAP-119;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("Proc_InsertServiceLine", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                //sqlCommand.Parameters.Add("@pServLineName", SqlDbType.NVarChar, 50).Value = pServLineName;
                int ServLineId = 0;//=Convert.ToInt32(sqlCommand.Parameters.Add("@pServLineId", SqlDbType.NVarChar, 50).Value);
                SqlParameter parServLineName = new SqlParameter()
                {
                    ParameterName = "@pServLineName",
                    SqlDbType = SqlDbType.Char,
                    Value = pServLineName,
                    Direction = ParameterDirection.Input
                };
                sqlCommand.Parameters.Add(parServLineName);
                SqlParameter parServiceLineId = new SqlParameter()
                {
                    ParameterName = "@pServLineId",

                    SqlDbType = SqlDbType.Int,
                    Value = ServLineId,
                    Direction = ParameterDirection.Output
                };
                sqlCommand.Parameters.Add(parServiceLineId);
                sqlCommand.ExecuteNonQuery();
                ServLineId = Convert.ToInt32(sqlCommand.Parameters["@pServLineId"].Value);
                string[] Slm = pSLMids.Split(',');
                foreach (string slms in Slm)
                {


                    SqlCommand sqlCommand1 = new SqlCommand("Proc_InsertServLineManagers", connection);
                    sqlCommand1.CommandType = CommandType.StoredProcedure;
                    //sqlCommand1.Parameters.Add("@pId", SqlDbType.Int).Value =pId;
                    sqlCommand1.Parameters.Add("@pServiceLineId", SqlDbType.Int).Value = ServLineId;
                    sqlCommand1.Parameters.Add("@pUserId", SqlDbType.NVarChar).Value = slms;



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

        public void EditServiceLine(int pServLineId, string pSLMids)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACULAP-119;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("Proc_EditServLineManagers", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                //sqlCommand.Parameters.Add("@pServLineName", SqlDbType.NVarChar, 50).Value = pServLineName;
                //int ServLineId = 0;//=Convert.ToInt32(sqlCommand.Parameters.Add("@pServLineId", SqlDbType.NVarChar, 50).Value);
               
                SqlParameter parServiceLineId = new SqlParameter()
                {
                    ParameterName = "@pServiceLineId",

                    SqlDbType = SqlDbType.Int,
                    Value = pServLineId,
                    Direction = ParameterDirection.Input
                };
                sqlCommand.Parameters.Add(parServiceLineId);
                sqlCommand.ExecuteNonQuery();
                
                string[] Slm = pSLMids.Split(',');
                var Slm1 = Slm.Distinct();
                foreach (string slms in Slm1)
                {


                    SqlCommand sqlCommand1 = new SqlCommand("Proc_InsertServLineManagers", connection);
                    sqlCommand1.CommandType = CommandType.StoredProcedure;
                    //sqlCommand1.Parameters.Add("@pId", SqlDbType.Int).Value =pId;
                    sqlCommand1.Parameters.Add("@pServiceLineId", SqlDbType.Int).Value = pServLineId;
                    sqlCommand1.Parameters.Add("@pUserId", SqlDbType.NVarChar).Value = slms;



                    sqlCommand1.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
       



    }
    public class SLMServiceLine {
        public List<ServiceLine> servicelinelist = new List<ServiceLine>();
        public List<ServiceLine> getSLDetails(string pUserId)
        {
            
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACULAP-119;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("Proc_ServiceLines", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@pUserId", SqlDbType.VarChar, 10).Value = pUserId;
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
    }
    public class SelectAllUsers
    {
        public List<Users> servicelinelist = new List<Users>();
        public DataTable ServLineManTab = new DataTable();
        public List<Users> getDetails()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACULAP-119;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("selectallproc", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //sqlCommand.Parameters.Add("@Action", SqlDbType.VarChar, 10).Value = "SELECT";
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        servicelinelist.Add(new Users
                        {
                            Id = sqlDataReader["Id"].ToString(),
                            UserName = (sqlDataReader["UserName"].ToString())
                        });
                    }
                }
            }
            return servicelinelist;

        }
    }
}