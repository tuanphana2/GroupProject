<%@ Page Title="Employee Management" Language="C#" MasterPageFile="~/Sources/MainPage.Master" AutoEventWireup="true" CodeBehind="EmployeeManagement.aspx.cs" Inherits="GroupProject.Sources.EmployeeManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Display/css/EmployeeManagement.css") %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Quản Lý Thông Tin Nhân Viên và Bảng Lương</h2>
        
        <h3>Tổng Quan Thu Nhập</h3>
        <asp:GridView ID="gvIncomeOverview" runat="server" CssClass="table table-bordered" AutoGenerateColumns="true"></asp:GridView>

        <h3>Tổng Quan Ngày Nghỉ</h3>
        <asp:GridView ID="gvLeaveOverview" runat="server" CssClass="table table-bordered" AutoGenerateColumns="true"></asp:GridView>

        <h3>Trung Bình Chi Phí Phúc Lợi</h3>
        <asp:GridView ID="gvBenefitCostOverview" runat="server" CssClass="table table-bordered" AutoGenerateColumns="true"></asp:GridView>
    </div>
</asp:Content>
