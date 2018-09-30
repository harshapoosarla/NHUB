using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Repository
{
    public class SLManagers
    {
        public DataTable SLMTab = new DataTable();
        private SqlConnection connection = new SqlConnection();
        SqlDataAdapter adapter;
        public DataTable GetSLManagers()
        {
            string ConnectionString = @"Data Source = ACULAP-119;Initial Catalog = NotificationHub;Integrated Security = True";
            string sql = "select u.UserName,u.Id from AspNetUserRoles ur join AspNetUsers u on ur.UserId=u.Id join AspNetRoles r on r.Id = ur.RoleId and r.Name = 'ServiceLine Manager' ";
            adapter = new SqlDataAdapter(sql, ConnectionString);
            adapter.Fill(SLMTab);

            return SLMTab;
          }

       
    }
}
