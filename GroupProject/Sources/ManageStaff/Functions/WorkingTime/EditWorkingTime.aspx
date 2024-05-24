<%@ Page Title="" Language="C#" MasterPageFile="~/Sources/MainPage.Master" AutoEventWireup="true" CodeBehind="EditWorkingTime.aspx.cs" Inherits="GroupProject.Sources.ManageStaff.Functions.WorkingTime.EditWorkingTime" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="lb_EWTID" runat="server" Text="Employment Working Time ID:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbtb_EWTID" runat="server" TextMode="Number"></asp:Label>
                </td>
            </tr>
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
                    <asp:Label ID="lb_YW" runat="server" Text="Year Working:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txt_YW" runat="server" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lb_MW" runat="server" Text="Month Working:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txt_MW" runat="server" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lb_NDAOWPM" runat="server" Text="Number Days Actual Of Working Per Month:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txt_NDAOWPM" runat="server" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lb_TNVWDPM" runat="server" Text="Total Number Vacation Working Days Per Month:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txt_TNVWDPM" runat="server" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="bt_Update" runat="server" Text="Update" OnClick="bt_Update_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
