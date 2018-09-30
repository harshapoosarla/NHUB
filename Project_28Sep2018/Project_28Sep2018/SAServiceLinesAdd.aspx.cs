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
            if (!IsPostBack)
            {
                DAL.Repository.SLManagers SLMRepo = new DAL.Repository.SLManagers();
                SLMRepo.GetSLManagers();


                SLMList.DataSource = SLMRepo.SLMTab;
                SLMList.DataTextField = "UserName";
                SLMList.DataValueField = "Id";
                SLMList.DataBind();
            }
        }

        //protected void create_Click(object sender, EventArgs e)
        //{
        //    string ServLineName = ServiceLineName.Text;
        //    string SLMIds="";
        //    SLMIds = SLMIds.Substring(-1);
        //    for(int SLMcount=0;SLMcount< SLMList.Items.Count; SLMcount++)
        //    {
        //        if (SLMList.Items[SLMcount].Selected)
        //        {
        //            SLMIds = SLMList.Items[SLMcount].Value+",";
        //        }
        //    }
        //    DAL.Repository.ServiceLineRepository SLMRepo = new DAL.Repository.ServiceLineRepository();
            
        //    SLMRepo.InsertServiceLine(ServLineName, SLMIds);

        //    Response.Redirect("~/SAServiceLines.aspx");
        //}
        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SAServiceLines.aspx");
        }

        protected void AddServiceLine_Click(object sender, EventArgs e)
        {
            string ServLineName = ServiceLineName.Text;
            string SLMIds = "";
           
            
            for (int SLMcount = 0; SLMcount < SLMList.Items.Count; SLMcount++)
            {
                if (SLMList.Items[SLMcount].Selected)
                {
                    SLMIds = SLMIds+SLMList.Items[SLMcount].Value + ",";
                }
            }
            SLMIds = SLMIds.Substring(0, SLMIds.Length - 1);
            DAL.Repository.ServiceLineRepository SLMRepo = new DAL.Repository.ServiceLineRepository();

            SLMRepo.InsertServiceLine(ServLineName, SLMIds);

            Response.Redirect("~/SAServiceLines.aspx");

        }
    }
}