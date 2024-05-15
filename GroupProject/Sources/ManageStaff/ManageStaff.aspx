<%@ Page Title="" Language="C#" MasterPageFile="~/Sources/MainPage.Master" AutoEventWireup="true" CodeBehind="ManageStaff.aspx.cs" Inherits="GroupProject.Sources.ManageStaff.ManageStaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 429px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table style="width: 100%;">
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="Bt_Add" runat="server" Text="+ Add new staff" OnClick="Bt_Add_Click" />
                </td>
                <td>
                    <asp:Button ID="Bt_View" runat="server" Text="View" OnClick="Bt_View_Click" />
                </td>
                <td>
                    <asp:Button ID="Bt_Edit" runat="server" Text="Edit" OnClick="Bt_Edit_Click" />
                </td>
                <td class="auto-style2">
                    <asp:Button ID="Bt_Delete" runat="server" Text="Delete" OnClick="Bt_Delete_Click" />
                </td>
                <td>
                    <asp:Button ID="Bt_Import" runat="server" Text="Import" OnClick="Bt_Import_Click" />
                </td>
                <td>
                    <asp:Button ID="Bt_Export" runat="server" Text="Export" OnClick="Bt_Export_Click" />
                </td>
                <td>
                    <asp:Button ID="Bt_Print" runat="server" Text="Print" OnClick="Bt_Print_Click" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
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
