<%@ Page Title="" Language="C#" MasterPageFile="~/Sources/MainPage.Master" AutoEventWireup="true" CodeBehind="QLNV.aspx.cs" Inherits="GroupProject.ManageStaff.QLNV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
        .auto-style2 {
            width: 173px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Button ID="Bt_Add" runat="server" Text="+ Add new staff" />
            </td>
            <td>
                <asp:Button ID="Bt_View" runat="server" Text="View" />
            </td>
            <td>
                <asp:Button ID="Bt_Edit" runat="server" Text="Edit" />
            </td>
            <td class="auto-style2">
                <asp:Button ID="Bt_Delete" runat="server" Text="Delete" />
            </td>
            <td>
                <asp:Button ID="Bt_Import" runat="server" Text="Import" />
            </td>
            <td>
                <asp:Button ID="Bt_Export" runat="server" Text="Export" />
            </td>
            <td>
                <asp:Button ID="Bt_Print" runat="server" Text="Print" />
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td>ID </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
