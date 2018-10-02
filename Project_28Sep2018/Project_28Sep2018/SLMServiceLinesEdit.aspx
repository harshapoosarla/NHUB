<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SLMServiceLinesEdit.aspx.cs" Inherits="Project_28Sep2018.SLMServiceLinesEdit1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <table class="nav-justified">
            <tr>
                <td style="width: 342px">
                    <asp:Label ID="editnames" runat="server" Text="Name:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="ServLineName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 342px">
                    <asp:Label ID="operationalmanager" runat="server" Text="OperationalManagers:"></asp:Label>
                </td>
                <td>
                    <asp:CheckBoxList ID="OMCheckList" runat="server">
                    </asp:CheckBoxList>
                    <br />
                    <asp:CheckBoxList ID="OMCheckList1" runat="server">
                    </asp:CheckBoxList>
                     <asp:CheckBoxList ID="CheckBoxList2" runat="server">
                    </asp:CheckBoxList>
                </td>
            </tr>
        </table>
    </p>
    <p>
    </p>
    <p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="cancel" runat="server" BackColor="#99CCFF" Font-Bold="True" Height="30px" OnClick="cancel_Click" Text="Cancel" ToolTip="click to cancel" Width="80px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="update" runat="server" BackColor="#99CCFF" Font-Bold="True" Height="30px" OnClick="update_Click" Text="Update" ToolTip="click to update" Width="80px" />

    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
