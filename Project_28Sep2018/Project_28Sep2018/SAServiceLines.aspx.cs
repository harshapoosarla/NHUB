using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Model;
using DAL.Repository;
namespace Project_28Sep2018
{
    public partial class ServiceLines : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           //if (!Context.User.IsInRole("Super Admin"))
           //{
           //    Response.Redirect("Access.aspx");
           //}
           Table table = new Table();
           table.ID = "1";
           PlaceHolder1.Controls.Add(table);
           ServiceLineRepository lineRepository = new ServiceLineRepository();
           lineRepository.getDetails();
             for (int count = 0; count < lineRepository.servicelinelist.Count; count++)
             {
                TableRow row = new TableRow();
                table.Rows.Add(row);

                TableCell cell = new TableCell();
                row.Cells.Add(cell);

                Label label = new Label();
                label.Text = lineRepository.servicelinelist[count].Name;
                label.Width = 150;
                PlaceHolder1.Controls.Add(label);

                HyperLink edit = new HyperLink();
                edit.Text = "Edit";
                edit.NavigateUrl = "~/SAServiceLinesEdit.aspx ? ID= " + lineRepository.servicelinelist[count].Id;
                edit.Width = 150;
                PlaceHolder1.Controls.Add(edit);

                HyperLink Delete = new HyperLink();
                Delete.Text = "Delete";
                Delete.NavigateUrl = "~/SAServiceLinesDelete.aspx?ID= " + lineRepository.servicelinelist[count].Id;
                Delete.Width = 150;
                PlaceHolder1.Controls.Add(Delete);
                PlaceHolder1.Controls.Add(new LiteralControl("<br/>"));
             }
        }
        protected void addserviceline_Click(object sender, EventArgs e)
        {
            Response.Redirect("SAServiceLinesAdd.aspx");
        }
    }
}