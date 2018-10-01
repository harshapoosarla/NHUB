using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Repository;
using Microsoft.AspNet.Identity;

namespace Project_28Sep2018
{
    public partial class SLMServiceLinesEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Context.User.IsInRole("ServiceLine Manager"))
            {
                Response.Redirect("Access.aspx");
            }
            Table table = new Table();
            table.ID = "1";
            PlaceHolder1.Controls.Add(table);

            string SlmUId = Context.User.Identity.GetUserId();

            SLMServiceLine SLMService = new SLMServiceLine();
            
            SLMService.getSLDetails(SlmUId);
            for (int count = 0; count < SLMService.servicelinelist.Count; count++)
            {
                TableRow row = new TableRow();
                table.Rows.Add(row);

                TableCell cell = new TableCell();
                row.Cells.Add(cell);

                Label label = new Label();
                label.Text = SLMService.servicelinelist[count].Name;
                label.Width = 150;
                PlaceHolder1.Controls.Add(label);

                HyperLink edit = new HyperLink();
                edit.Text = "Edit";
                edit.NavigateUrl = "~/SLMServiceLinesEdit.aspx?ID=" + SLMService.servicelinelist[count].Id + "&&ServLineName=" + SLMService.servicelinelist[count].Name;
                edit.Width = 150;
                PlaceHolder1.Controls.Add(edit);
                PlaceHolder1.Controls.Add(new LiteralControl("<br/>"));
            }
        }
    }
}