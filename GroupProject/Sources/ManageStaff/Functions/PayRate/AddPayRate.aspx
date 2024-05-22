<%@ Page Title="" Language="C#" MasterPageFile="~/Sources/MainPage.Master" AutoEventWireup="true" CodeBehind="AddPayRate.aspx.cs" Inherits="GroupProject.Sources.ManageStaff.Functions.PayRate.AddPayRate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lb_PRID" runat="server" Text="Pay Rate ID:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_PRID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lb_PRN" runat="server" Text="Pay Rate Name:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_PRN" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lb_Value" runat="server" Text="Value:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_Value" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lb_TP" runat="server" Text="Tax Percentage:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_TP" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lb_PayType" runat="server" Text="Pay Type:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_PayType" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lb_PA" runat="server" Text="Pay Amount:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_P" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lb_PTLC" runat="server" Text="PT - Level C:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_PTLC" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="bt_Add" runat="server" Text="Add" />
            </td>
        </tr>
    </table>
</asp:Content>
