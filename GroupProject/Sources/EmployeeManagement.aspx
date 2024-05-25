<%@ Page Title="Employee Management" Language="C#" MasterPageFile="~/Sources/MainPage.Master" AutoEventWireup="true" CodeBehind="EmployeeManagement.aspx.cs" Inherits="GroupProject.Sources.EmployeeManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Display/css/EmployeeManagement.css") %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
     <table style="width: 100%;">
         <h2>Quản Lý Thông Tin Nhân Viên và Bảng Lương</h2>
         <!-- Thêm hàng lọc -->
         <tr>
             <td colspan="6">
                 <asp:CheckBox ID="chkShareholder" runat="server" Text="Shareholder" />
                 <asp:CheckBox ID="chkNoShareholder" runat="server" Text="No Shareholder" />
                 <asp:TextBox ID="txtGenderFilter" runat="server" placeholder="Enter gender (e.g., Male, Female)" Text="Gender" />
                 <asp:CheckBox ID="chkEthnicity" runat="server" Text="Ethnicity" />
                 <asp:CheckBox ID="chkPartTime" runat="server" Text="Part-time" />
                 <asp:CheckBox ID="chkFullTime" runat="server" Text="Full-time" />
                 <asp:Button ID="Bt_Filter" runat="server" Text="Filter" OnClick="Bt_Filter_Click" />
             </td>
         </tr>
     </table>
     <asp:DropDownList ID="ddlReportSelector" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlReportSelector_SelectedIndexChanged">
         <asp:ListItem Text="Tổng Quan Thu Nhập" Value="1"></asp:ListItem>
         <asp:ListItem Text="Tổng Quan Ngày Nghỉ" Value="2"></asp:ListItem>
         <asp:ListItem Text="Trung Bình Chi Phí Phúc Lợi" Value="3"></asp:ListItem>
     </asp:DropDownList>

         <h3>Tổng Quan Thu Nhập</h3>
     <!-- Cấu hình cột cho DataGridView 1 -->
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
         <Columns>
             <asp:TemplateField>
                 <HeaderTemplate>
                     <asp:CheckBox ID="chkHeader" runat="server" onclick="checkAll(this)" />
                 </HeaderTemplate>
                 <ItemTemplate>
                     <asp:CheckBox ID="chkRow" runat="server" />
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:BoundField DataField="PERSONAL_ID" HeaderText="PERSONAL ID" />
             <asp:BoundField DataField="CURRENT_FIRST_NAME" HeaderText="FIRST NAME" />
             <asp:BoundField DataField="CURRENT_LAST_NAME" HeaderText="LAST NAME" />
             <asp:BoundField DataField="BIRTH_DATE" HeaderText="BIRTH DATE" />
             <asp:BoundField DataField="CURRENT_COUNTRY" HeaderText="COUNTRY" />
             <asp:BoundField DataField="CURRENT_GENDER" HeaderText="GENDER" />
             <asp:BoundField DataField="CURRENT_PHONE_NUMBER" HeaderText="PHONE NUMBER" />
             <asp:BoundField DataField="CURRENT_PERSONAL_EMAIL" HeaderText="EMAIL" />
             <asp:BoundField DataField="BENEFIT_PLAN_ID" HeaderText="PLAN ID" />
             <asp:TemplateField>
                 <ItemTemplate>
                     <asp:LinkButton ID="link_Edit" runat="server" Text="Edit" CommandName="EditRow" CommandArgument='<%# Eval("PERSONAL_ID") %>' />
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField>
                 <ItemTemplate>
                     <asp:LinkButton ID="link_Delete" runat="server" Text="Delete" CommandName="DeleteRow" CommandArgument='<%# Eval("PERSONAL_ID") %>' />
                 </ItemTemplate>
             </asp:TemplateField>
         </Columns>
     </asp:GridView>

          <h3>Tổng Quan Ngày Nghỉ</h3>
     <!-- Cấu hình cột cho DataGridView 2 -->
     <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
         <Columns>
             <asp:TemplateField>
                 <HeaderTemplate>
                     <asp:CheckBox ID="chkHeader" runat="server" onclick="checkAll(this)" />
                 </HeaderTemplate>
                 <ItemTemplate>
                     <asp:CheckBox ID="chkRow" runat="server" />
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:BoundField DataField="PERSONAL_ID" HeaderText="PERSONAL ID" />
             <asp:BoundField DataField="CURRENT_FIRST_NAME" HeaderText="FIRST NAME" />
             <asp:BoundField DataField="CURRENT_LAST_NAME" HeaderText="LAST NAME" />
             <asp:BoundField DataField="BIRTH_DATE" HeaderText="BIRTH DATE" />
             <asp:BoundField DataField="CURRENT_COUNTRY" HeaderText="COUNTRY" />
             <asp:BoundField DataField="CURRENT_GENDER" HeaderText="GENDER" />
             <asp:BoundField DataField="CURRENT_PHONE_NUMBER" HeaderText="PHONE NUMBER" />
             <asp:BoundField DataField="CURRENT_PERSONAL_EMAIL" HeaderText="EMAIL" />
             <asp:BoundField DataField="BENEFIT_PLAN_ID" HeaderText="PLAN ID" />
             <asp:TemplateField>
                 <ItemTemplate>
                     <asp:LinkButton ID="link_Edit" runat="server" Text="Edit" CommandName="EditRow" CommandArgument='<%# Eval("PERSONAL_ID") %>' />
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField>
                 <ItemTemplate>
                     <asp:LinkButton ID="link_Delete" runat="server" Text="Delete" CommandName="DeleteRow" CommandArgument='<%# Eval("PERSONAL_ID") %>' />
                 </ItemTemplate>
             </asp:TemplateField>
         </Columns>
     </asp:GridView>

         <h3>Trung Bình Chi Phí Phúc Lợi</h3>
      <!-- Cấu hình cột cho DataGridView 3 -->
     <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
         <Columns>
             <asp:TemplateField>
                 <HeaderTemplate>
                     <asp:CheckBox ID="chkHeader" runat="server" onclick="checkAll(this)" />
                 </HeaderTemplate>
                 <ItemTemplate>
                     <asp:CheckBox ID="chkRow" runat="server" />
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:BoundField DataField="PERSONAL_ID" HeaderText="PERSONAL ID" />
             <asp:BoundField DataField="CURRENT_FIRST_NAME" HeaderText="FIRST NAME" />
             <asp:BoundField DataField="CURRENT_LAST_NAME" HeaderText="LAST NAME" />
             <asp:BoundField DataField="BIRTH_DATE" HeaderText="BIRTH DATE" />
             <asp:BoundField DataField="CURRENT_COUNTRY" HeaderText="COUNTRY" />
             <asp:BoundField DataField="CURRENT_GENDER" HeaderText="GENDER" />
             <asp:BoundField DataField="CURRENT_PHONE_NUMBER" HeaderText="PHONE NUMBER" />
             <asp:BoundField DataField="CURRENT_PERSONAL_EMAIL" HeaderText="EMAIL" />
             <asp:BoundField DataField="BENEFIT_PLAN_ID" HeaderText="PLAN ID" />
             <asp:TemplateField>
                 <ItemTemplate>
                     <asp:LinkButton ID="link_Edit" runat="server" Text="Edit" CommandName="EditRow" CommandArgument='<%# Eval("PERSONAL_ID") %>' />
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField>
                 <ItemTemplate>
                     <asp:LinkButton ID="link_Delete" runat="server" Text="Delete" CommandName="DeleteRow" CommandArgument='<%# Eval("PERSONAL_ID") %>' />
                 </ItemTemplate>
             </asp:TemplateField>
         </Columns>
     </asp:GridView>
         </div>
</asp:Content>
