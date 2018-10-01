using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_28Sep2018
{
    public partial class SLMServiceLinesEdit1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Context.User.IsInRole("Super Admin"))
            {
                Response.Redirect("Access.aspx");
            }
            if (!IsPostBack)
            {


            }
        }
    }
}