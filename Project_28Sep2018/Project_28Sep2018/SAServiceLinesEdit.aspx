<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SAServiceLinesEdit.aspx.cs" Inherits="Project_28Sep2018.SAServiceLinesEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <table class="nav-justified">
            <tr>
                <td style="width: 374px">
                    <asp:Label ID="editnames" runat="server" Text="Name:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="names" runat="server" Height="22px" Width="260px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 374px">
                    <asp:Label ID="editslms" runat="server" Text="Operation Managers:"></asp:Label>
                </td>
                <td>
                    <asp:CheckBoxList runat="server">
                    </asp:CheckBoxList>
                </td>
            </tr>
        </table>
    <br />
</p>
<p>
</p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="cancel" runat="server" BackColor="#99CCFF" Font-Bold="True" Height="30px" OnClick="cancel_Click" Text="Cancel" ToolTip="click to cancel" Width="80px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="update" runat="server" BackColor="#99CCFF" Font-Bold="True" Height="30px" OnClick="update_Click" Text="Update" ToolTip="click to update" Width="80px" />

<p>
</p>
<p>
</p>
</asp:Content>
