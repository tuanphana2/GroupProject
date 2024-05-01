<%@ Page Title="" Language="C#" MasterPageFile="~/Sources/MainPage.Master" AutoEventWireup="true" CodeBehind="ManageStaff.aspx.cs" Inherits="GroupProject.Sources.ManageStaff.ManageStaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;">
    <tr>
        <td>
            <asp:Button ID="Bt_Add" runat="server" Text="+ Add new staff" OnClick="Bt_Add_Click" />
        </td>
        <td>
            <asp:Button ID="Bt_View" runat="server" Text="View" OnClick="Bt_View_Click" />
        </td>
        <td>
            <asp:Button ID="Bt_Edit" runat="server" Text="Edit" OnClick="Bt_Edit_Click" />
        </td>
        <td class="auto-style2">
            <asp:Button ID="Bt_Delete" runat="server" Text="Delete" OnClick="Bt_Delete_Click" />
        </td>
        <td>
            <asp:Button ID="Bt_Import" runat="server" Text="Import" OnClick="Bt_Import_Click" />
        </td>
        <td>
            <asp:Button ID="Bt_Export" runat="server" Text="Export" OnClick="Bt_Export_Click" />
        </td>
        <td>
            <asp:Button ID="Bt_Print" runat="server" Text="Print" OnClick="Bt_Print_Click" />
        </td>
    </tr>
</table>
</asp:Content>
