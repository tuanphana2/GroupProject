<%@ Page Title="Alerts Management" Language="C#" MasterPageFile="~/Sources/MainPage.Master" AutoEventWireup="true" CodeBehind="AlertsManagement.aspx.cs" Inherits="GroupProject.Sources.AlertsManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Display/css/AlertsManagement.css") %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <section class="alerts-management">
            <h2>Chức Năng Cảnh Báo và Quản Lý Ngoại Lệ</h2>
            <div class="work-anniversary-alert">
                <h3>Cảnh Báo Ngày Kỷ Niệm Làm Việc</h3>
                <asp:Label ID="workAnniversaryAlert" runat="server" Text=""></asp:Label>
            </div>
            <div class="leave-accumulation-alert">
                <h3>Cảnh Báo Ngày Nghỉ Tích Lũy</h3>
                <asp:Label ID="leaveAccumulationAlert" runat="server" Text=""></asp:Label>
            </div>
            <div class="benefit-plan-alert">
                <h3>Cảnh Báo Thay Đổi Kế Hoạch Phúc Lợi</h3>
                <asp:Label ID="benefitPlanAlert" runat="server" Text=""></asp:Label>
            </div>
            <div class="birthday-alert">
                <h3>Cảnh Báo Sinh Nhật</h3>
                <asp:Label ID="birthdayAlert" runat="server" Text=""></asp:Label>
            </div>
        </section>
    </div>
</asp:Content>
