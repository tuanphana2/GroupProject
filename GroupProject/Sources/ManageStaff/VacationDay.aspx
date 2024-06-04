<%@ Page Title="" Language="C#" MasterPageFile="~/Sources/MainPage.Master" AutoEventWireup="true" CodeBehind="VacationDay.aspx.cs" Inherits="GroupProject.Sources.ManageStaff.VacationDay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table style="width: 100%;">
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="Bt_Add" runat="server" Text="+ Add new staff" OnClick="Bt_Add_Click" />
                </td>
                <td class="auto-style2">
                    <asp:Button ID="Bt_Delete" runat="server" Text="Delete" OnClick="Bt_Delete_Click" />
                </td>
            </tr>
            <tr>
                <td>Shareholder:
                    <asp:DropDownList ID="ddl_Shareholder" runat="server"></asp:DropDownList>
                    <asp:Button ID="bt_submitS" runat="server" Text="Submit" OnClick="bt_submitS_Click" />
                </td>
                <td>Gender:
                    <asp:DropDownList ID="ddl_Gender" runat="server"></asp:DropDownList>
                    <asp:Button ID="bt_submitG" runat="server" Text="Submit" OnClick="bt_submitG_Click" />
                </td>
                <td>Ethnicity:
                    <asp:DropDownList ID="ddl_Ethnicity" runat="server"></asp:DropDownList>
                    <asp:Button ID="bt_submitE" runat="server" Text="Submit" OnClick="bt_submitE_Click" />
                </td>
                <td>Type of work:
                    <asp:DropDownList ID="ddl_TypeOfWork" runat="server"></asp:DropDownList>
                    <asp:Button ID="bt_TOW" runat="server" Text="Submit" OnClick="bt_TOW_Click" />
                </td>
            </tr>
        </table>
        <!-- Cấu hình cột cho DataGridView 1 -->
        <h3>Vacation Overview</h3>
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
                <asp:BoundField DataField="ETHNICITY" HeaderText="ETHNICITY" />
                <asp:BoundField DataField="CURRENT_PERSONAL_EMAIL" HeaderText="EMAIL" />
                <asp:BoundField DataField="SHAREHOLDER_STATUS" HeaderText="SHAREHOLDER STATUS" />
                <asp:BoundField DataField="BENEFIT_PLAN_ID" HeaderText="PLAN ID" />
                <asp:BoundField DataField="DEPARTMENT" HeaderText="DEPARTMENT" />
                <asp:BoundField DataField="TYPE_OF_WORK" HeaderText="TYPE_OF_WORK" />
                <asp:BoundField DataField="TOTAL_NUMBER_VACATION_WORKING_DAYS_PER_MONTH" HeaderText="TOTAL NUMBER VACATION WORKING DAYS PER MONTH" />
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

        <script type="text/javascript">
            function checkAll(ele) {
                var checkboxes = document.getElementsByTagName('input');
                if (ele.checked) {
                    for (var i = 0; i < checkboxes.length; i++) {
                        if (checkboxes[i].type == 'checkbox') {
                            checkboxes[i].checked = true;
                        }
                    }
                } else {
                    for (var i = 0; i < checkboxes.length; i++) {
                        if (checkboxes[i].type == 'checkbox') {
                            checkboxes[i].checked = false;
                        }
                    }
                }
            }
        </script>
    </div>
</asp:Content>

