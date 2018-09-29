using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_28Sep2018
{
    public partial class SAServiceLinesEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void update_Click(object sender, EventArgs e)
        {
            Response.Redirect("SAServiceLines.aspx");
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SAServiceLines.aspx");
        }
    }
}