<%@ Page Title="" Language="C#" MasterPageFile="~/Sources/MainPage.Master" AutoEventWireup="true" CodeBehind="AlertsManagement.aspx.cs" Inherits="GroupProject.Sources.ManageStaff.AlertsManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            padding: 20px;
            background-color: #f8f9fa;
        }

        .alerts-management {
            background-color: #ffffff;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

            .alerts-management h2 {
                margin-bottom: 20px;
                font-size: 24px;
                color: #333;
            }

            .alerts-management .dropdown {
                margin-bottom: 20px;
            }

            .alerts-management .gridview {
                margin-top: 20px;
            }

        .gridview th, .gridview td {
            padding: 8px;
            text-align: left;
            border-bottom: 1px solid #ddd;
        }

        .gridview th {
            background-color: #f2f2f2;
        }

        .gridview tr:hover {
            background-color: #f1f1f1;
        }

        .gridview .checkbox-header, .gridview .checkbox-row {
            text-align: center;
        }

        .gridview .actions {
            text-align: center;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <section class="alerts-management">
            <h2>Alert Functionality</h2>
            <asp:DropDownList ID="alertsDropDown" runat="server" AutoPostBack="True" OnSelectedIndexChanged="alertsDropDown_SelectedIndexChanged" CssClass="dropdown form-control">
                <asp:ListItem Text="Select an Alert" Value=""></asp:ListItem>
                <asp:ListItem Text="Work Anniversary Alert" Value="WorkAnniversary"></asp:ListItem>
                <asp:ListItem Text="Leave Accumulation Alert" Value="LeaveAccumulation"></asp:ListItem>
                <asp:ListItem Text="Benefit Plan Change Alert" Value="BenefitPlanChange"></asp:ListItem>
                <asp:ListItem Text="Birthday Alert" Value="Birthday"></asp:ListItem>
            </asp:DropDownList>
            <asp:GridView ID="alertGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView_RowCommand" CssClass="gridview table table-striped table-bordered" Width="100%">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkHeader" runat="server" onclick="checkAll(this)" CssClass="checkbox-header" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkRow" runat="server" CssClass="checkbox-row" />
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
                    <asp:BoundField DataField="FROM_DATE" HeaderText="FROM DATE" />
                    <asp:BoundField DataField="TOTAL_NUMBER_VACATION_WORKING_DAYS_PER_MONTH" HeaderText="Vacation Day" />
                    <asp:BoundField DataField="BENEFIT_PLAN_ID" HeaderText="PLAN ID" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="link_Edit" runat="server" Text="Edit" CommandName="EditRow" CommandArgument='<%# Eval("PERSONAL_ID") %>' CssClass="actions" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="link_Delete" runat="server" Text="Delete" CommandName="DeleteRow" CommandArgument='<%# Eval("PERSONAL_ID") %>' CssClass="actions" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </section>
    </div>
    <script type="text/javascript">
        function checkAll(ele) {
            var checkboxes = document.querySelectorAll('.checkbox-row');
            checkboxes.forEach(function (checkbox) {
                checkbox.checked = ele.checked;
            });
        }
    </script>
</asp:Content>
