using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Repository;

namespace Project_28Sep2018
{
    public partial class SAServiceLinesDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Context.User.IsInRole("Super Admin"))
            {
                Response.Redirect("Access.aspx");
            }
            
        }

        protected void yes_Click(object sender, EventArgs e)
        {
            
            ServiceLineRepository inventory = new ServiceLineRepository();
            int Id = Convert.ToInt32(Request.QueryString["Id"]);

            //int Id = Convert.ToInt32(Request.QueryString["Id"]);
            //DeleteServiceLine deleteServiceLine = new DeleteServiceLine();
            //Response.Redirect("SAServiceLines.aspx");

            inventory.DeleteServiceLine(Id);

            Response.Redirect("SAServiceLines.aspx");
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SAServiceLines.aspx");
        }
    }
}