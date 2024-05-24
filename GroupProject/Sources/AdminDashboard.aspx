<%@ Page Title="Admin Dashboard" Language="C#" MasterPageFile="~/Sources/MainPage.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="GroupProject.Sources.AdminDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Display/css/AdminDashboard.css") %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <section class="admin-dashboard">
            <h2>Dashboard Quản Trị và Tổng Quan</h2>
            <div class="overview-dashboard">
                <h3>Dashboard Tổng Quan</h3>
                <!-- Add details here -->
            </div>
            <div class="detailed-report">
                <h3>Chi Tiết Báo Cáo</h3>
                <!-- Add details here -->
            </div>
        </section>
    </div>
</asp:Content>
