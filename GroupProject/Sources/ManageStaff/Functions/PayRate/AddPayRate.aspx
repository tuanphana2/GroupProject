<%@ Page Title="" Language="C#" MasterPageFile="~/Sources/MainPage.Master" AutoEventWireup="true" CodeBehind="AddPayRate.aspx.cs" Inherits="GroupProject.Sources.ManageStaff.Functions.PayRate.AddPayRate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lb_BPI" runat="server" Text="Benefit Plan ID:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_BPID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lb_PN" runat="server" Text="Plan Name:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_PN" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lb_Deductable" runat="server" Text="Deductable:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_Deductable" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lb_PC" runat="server" Text="Percentage Copay:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_PC" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Percentage Copay:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Percentage Copay:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Percentage Copay:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
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
