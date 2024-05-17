<%@ Page Title="" Language="C#" MasterPageFile="~/Sources/MainPage.Master" AutoEventWireup="true" CodeBehind="EditStaff.aspx.cs" Inherits="GroupProject.Sources.ManageStaff.Functions.EditStaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:DataList ID="dl_Staff" runat="server">
            <ItemTemplate>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Personal ID"></asp:Label>
                            <br />
                            <asp:Label runat="server" Text="First name" ID="Label1"></asp:Label>
                            <br />
                            <asp:Label runat="server" Text="Last name"></asp:Label>
                            <br />
                            <asp:Label runat="server" Text="Middle name"></asp:Label>
                            <br />
                            <asp:Label runat="server" Text="Date of birth"></asp:Label>
                            <br />
                            <asp:Label runat="server" Text="SSN"></asp:Label>
                            <br />
                            <asp:Label runat="server" Text="Drivers lisence"></asp:Label>
                            <br />
                            <asp:Label runat="server" Text="Address 1"></asp:Label>
                            <br />
                            <asp:Label runat="server" Text="Address 2"></asp:Label>
                            <br />
                            <asp:Label runat="server" Text="City"></asp:Label>
                            <br />
                            <asp:Label runat="server" Text="Country"></asp:Label>
                            <br />
                            <asp:Label runat="server" Text="Zip"></asp:Label>
                            <br />
                            <asp:Label runat="server" Text="Gender"></asp:Label>
                            <br />
                            <asp:Label runat="server" Text="Phone number"></asp:Label>
                            <br />
                            <asp:Label runat="server" Text="Email"></asp:Label>
                            <br />
                            <asp:Label runat="server" Text="Marital status"></asp:Label>
                            <br />
                            <asp:Label runat="server" Text="Ethnicity"></asp:Label>
                            <br />
                            <asp:Label runat="server" Text="Shareholder status"></asp:Label>
                            <br />
                            <asp:Label runat="server" Text="Benefit plan id"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txt_pID" TextMode="Number" Style="width: 168px" Text='<%# Eval("PERSONAL_ID") %>'></asp:TextBox><br />
                            <asp:TextBox runat="server" ID="txt_FN" Text='<%# Eval("CURRENT_FIRST_NAME") %>'></asp:TextBox><br />
                            <asp:TextBox runat="server" ID="txt_LN" Text='<%# Eval("CURRENT_LAST_NAME") %>'></asp:TextBox><br />
                            <asp:TextBox runat="server" ID="txt_MN" Text='<%# Eval("CURRENT_MIDDLE_NAME") %>'></asp:TextBox><br />
                            <asp:TextBox ID="datePicker" runat="server" TextMode="Date" Text='<%# Eval("BIRTH_DATE") %>'></asp:TextBox><br />
                            <asp:TextBox runat="server" ID="txt_SSN" Text='<%# Eval("SOCIAL_SECURITY_NUMBER") %>'></asp:TextBox><br />
                            <asp:TextBox runat="server" ID="txt_DL" Text='<%# Eval("DRIVERS_LICENSE") %>'></asp:TextBox><br />
                            <asp:TextBox runat="server" ID="txt_Adr1" Text='<%# Eval("CURRENT_ADDRESS_1") %>'></asp:TextBox><br />
                            <asp:TextBox runat="server" ID="txt_Adr2" Text='<%# Eval("CURRENT_ADDRESS_2") %>'></asp:TextBox><br />
                            <asp:TextBox runat="server" ID="txt_City" Text='<%# Eval("CURRENT_CITY") %>'></asp:TextBox><br />
                            <asp:TextBox runat="server" ID="txt_Country" Text='<%# Eval("CURRENT_COUNTRY") %>'></asp:TextBox><br />
                            <asp:TextBox runat="server" ID="txt_Zip" Text='<%# Eval("CURRENT_ZIP") %>'></asp:TextBox><br />
                            <asp:TextBox runat="server" ID="txt_Gender" Text='<%# Eval("CURRENT_GENDER") %>'></asp:TextBox><br />
                            <asp:TextBox runat="server" ID="txt_Phone" Text='<%# Eval("CURRENT_PHONE_NUMBER") %>'></asp:TextBox><br />
                            <asp:TextBox runat="server" ID="txt_Email" Text='<%# Eval("CURRENT_PERSONAL_EMAIL") %>'></asp:TextBox><br />
                            <asp:TextBox runat="server" ID="txt_MS" Text='<%# Eval("CURRENT_MARITAL_STATUS") %>'></asp:TextBox><br />
                            <asp:TextBox runat="server" ID="txt_Ethnicity" Text='<%# Eval("ETHNICITY") %>'></asp:TextBox><br />
                            <asp:TextBox runat="server" ID="txt_Shareholder" Text='<%# Eval("SHAREHOLDER_STATUS") %>'></asp:TextBox><br />
                            <asp:TextBox runat="server" ID="txt_Benefit" Text='<%# Eval("BENEFIT_PLAN_ID") %>'></asp:TextBox><br />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
