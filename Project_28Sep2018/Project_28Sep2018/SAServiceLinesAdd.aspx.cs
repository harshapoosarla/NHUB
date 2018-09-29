using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace Project_28Sep2018
{
    public partial class SAServiceLineAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Context.User.IsInRole("Super Admin"))
            {
                Response.Redirect("Access.aspx");
            }

            DAL.Repository.SLManagers SLMRepo = new DAL.Repository.SLManagers();
            SLMRepo.GetSLManagers();


            SLMList.DataSource = SLMRepo.SLMTab;
            SLMList.DataTextField = "UserName";
            SLMList.DataValueField = "Id";
            SLMList.DataBind();





    }

        protected void create_Click(object sender, EventArgs e)
        {
            string ServLineName = ServiceLineName.Text;
            string SLMIds;

            for(int SLMcount=0;SLMcount< SLMList.Items.Count; SLMcount++)
            {
                if (SLMList.Items[SLMcount].Selected)
                {
                    SLMIds = SLMList.Items[SLMcount].Value+",";
                }
            }










            Response.Redirect("SAServiceLines.aspx");
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SAServiceLines.aspx");
        }
    }
}