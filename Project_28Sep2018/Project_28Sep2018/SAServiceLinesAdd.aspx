<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SAServiceLinesAdd.aspx.cs" Inherits="Project_28Sep2018.SAServiceLineAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
        <br />
       
        <table class="nav-justified">
            <tr>
                <td style="width: 415px">
                    <asp:Label ID="name" runat="server" Text="Name:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="ServiceLineName" runat="server" Width="260px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 415px">
                    <asp:Label ID="slms" runat="server" Text="ServiceLine Managers:"></asp:Label>
                </td>
                <td>
                    <asp:CheckBoxList ID="SLMList" runat="server" Height="22px" Width="260px">
                    </asp:CheckBoxList>
                </td>
            </tr>
        </table>
    
    <p>
    </p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="cancel" runat="server" BackColor="#99CCFF" Font-Bold="True" Height="30px" OnClick="cancel_Click" Text="Cancel" ToolTip="click to cancel" Width="80px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="AddServiceLine" runat="server" OnClick="AddServiceLine_Click" Text="Add Service Line" BackColor="#99CCFF" Font-Bold="True" Height="30px" />
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
