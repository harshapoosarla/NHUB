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
            if (!IsPostBack)
            {

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

                CheckBoxList1.DataSource = selectAllUsers.getDetails();
                CheckBoxList1.DataTextField = "UserName";
                CheckBoxList1.DataValueField = "Id";

                CheckBoxList1.DataBind();
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            int ServLineId = Convert.ToInt32(Request.QueryString["ID"]);
            string SLMIds="";
            ServiceLineRepository SLrepo = new ServiceLineRepository();


            for (int SLMcount = 0; SLMcount < SLMcheckList.Items.Count; SLMcount++)
            {
                if (SLMcheckList.Items[SLMcount].Selected)
                {
                    SLMIds = SLMIds + SLMcheckList.Items[SLMcount].Value + ",";
                }
            }
            
            for (int SLMcount = 0; SLMcount < CheckBoxList1.Items.Count; SLMcount++)
            {
                if (CheckBoxList1.Items[SLMcount].Selected)
                {
                    SLMIds = SLMIds + CheckBoxList1.Items[SLMcount].Value + ",";
                }
            }
            SLMIds = SLMIds.Substring(0, SLMIds.Length - 1);


            SLrepo.EditServiceLine(ServLineId, SLMIds);


            Response.Redirect("~/SAServiceLines.aspx");
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SAServiceLines.aspx");
        }

 
    }
}