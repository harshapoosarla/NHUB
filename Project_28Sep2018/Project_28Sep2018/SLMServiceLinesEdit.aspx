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
                    <asp:Label ID="slname" runat="server" Text="ServiceLineName"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 342px">
                    <asp:Label ID="operationalmanager" runat="server" Text="OperationalManagers:"></asp:Label>
                </td>
                <td>
                    <asp:CheckBoxList ID="omlist" runat="server">
                    </asp:CheckBoxList>
                    <br />
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                    </asp:CheckBoxList>
                </td>
            </tr>
        </table>
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
    <p>
    </p>
    <p>
    </p>
</asp:Content>
