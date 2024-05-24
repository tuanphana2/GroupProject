<%@ Page Title="" Language="C#" MasterPageFile="~/Sources/MainPage.Master" AutoEventWireup="true" CodeBehind="AddEmployment.aspx.cs" Inherits="GroupProject.Sources.ManageStaff.Functions.Employment.AddEmployment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lb_EID" runat="server" Text="Employment ID:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_EID" runat="server" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lb_EC" runat="server" Text="Employment Code:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_EC" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lb_ES" runat="server" Text="Employment Status:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_ES" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lb_HDFW" runat="server" Text="Hire Date For Working:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_HDFW" runat="server" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lb_WCC" runat="server" Text="Workers Comp code:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_WCC" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lb_TerDate" runat="server" Text="Termination Date:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_TerDate" runat="server" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lb_RDFW" runat="server" Text="Rehire Date For Working:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_RDFW" runat="server" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lb_LRD" runat="server" Text="Last Review Date:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_LRD" runat="server" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lb_NDROWPRM" runat="server" Text="Number Days Requirement Of Working Per Month:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_NDROWPRM" runat="server" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lb_PID" runat="server" Text="Person ID:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_PID" runat="server" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="bt_Add" runat="server" Text="Add" OnClick="bt_Add_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
