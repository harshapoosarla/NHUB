using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Repository;

namespace Project_28Sep2018
{
    public partial class SAServiceLinesEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Context.User.IsInRole("Super Admin"))
            {
                Response.Redirect("Access.aspx");
            }

            string ServLineName = Request.QueryString["ServLineName"];
            ServiceLineName.Text = ServLineName;
            string ServLineId = Request.QueryString["ID"];
            ServiceLineRepository SLRepo = new ServiceLineRepository();
            SLRepo.getServLineDetails(ServLineId);
            SelectAllUsers selectAllUsers = new SelectAllUsers();
            
            SLMcheckList.DataSource = SLRepo.ServLineManTab;
            SLMcheckList.DataTextField = "UserName";
            SLMcheckList.DataValueField = "Id";
           

            SLMcheckList.DataBind();
            for (int i = 0; i < SLMcheckList.Items.Count; i++)
            {
                SLMcheckList.Items[i].Selected = true;
            }
            SLMcheckList.DataSource = selectAllUsers.getDetails();
            SLMcheckList.DataTextField = "UserName";
            SLMcheckList.DataValueField = "Id";
          
            SLMcheckList.DataBind();

        }

        protected void update_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SAServiceLines.aspx");
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SAServiceLines.aspx");
        }

 
    }
}