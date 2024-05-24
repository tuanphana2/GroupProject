<%@ Page Title="User Management" Language="C#" MasterPageFile="~/Sources/MainPage.Master" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="GroupProject.Sources.UserManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Display/css/UserManagement.css") %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <section class="user-management">
            <h2>Quản Lý Người Dùng và Phân Quyền</h2>
            <div class="user-account-management">
                <h3>Quản Lý Tài Khoản Người Dùng</h3>
                <!-- Add details here -->
            </div>
            <div class="user-role-management">
                <h3>Phân Quyền Người Dùng</h3>
                <!-- Add details here -->
            </div>
        </section>
    </div>
</asp:Content>
