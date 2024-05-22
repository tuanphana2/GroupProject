<%@ Page Title="" Language="C#" MasterPageFile="~/Sources/MainPage.Master" AutoEventWireup="true" CodeBehind="AddJobHistory.aspx.cs" Inherits="GroupProject.Sources.ManageStaff.Functions.JobHistory.AddJobHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lb_JHID" runat="server" Text="Job History ID:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_JGID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lb_EID" runat="server" Text="Employment ID:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_EID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lb_Department" runat="server" Text="Department:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_Department" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lb_Division" runat="server" Text="Division:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_Division" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lb_FD" runat="server" Text="From Date:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_FD" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lb_TD" runat="server" Text="Thru Date:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_TD" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lb_JobTiTle" runat="server" Text="Job Title:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_JobTiTle" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lb_Supervisor" runat="server" Text="Supervisor:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_Supervisor" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lb_Location" runat="server" Text="Location:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_Location" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lb_TOW" runat="server" Text="Type Of Work:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_TOW" runat="server"></asp:TextBox>
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
