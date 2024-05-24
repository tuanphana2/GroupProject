<%@ Page Title="" Language="C#" MasterPageFile="~/Sources/MainPage.Master" AutoEventWireup="true" CodeBehind="ViewPerson.aspx.cs" Inherits="GroupProject.Sources.ManageStaff.Functions.ViewStaff" %>

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
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txt_pID" TextMode="Number" Style="width: 168px" Text='<%# Eval("PERSONAL_ID") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="First name"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txt_FN" Text='<%# Eval("CURRENT_FIRST_NAME") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Last name"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txt_LN" Text='<%# Eval("CURRENT_LAST_NAME") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Middle name"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txt_MN" Text='<%# Eval("CURRENT_MIDDLE_NAME") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Date of birth"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="datePicker" runat="server" TextMode="Date" Text='<%# Eval("BIRTH_DATE") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="SSN"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txt_SSN" Text='<%# Eval("SOCIAL_SECURITY_NUMBER") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Drivers lisence"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txt_DL" Text='<%# Eval("DRIVERS_LICENSE") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Address 1"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txt_Adr1" Text='<%# Eval("CURRENT_ADDRESS_1") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Address 2"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txt_Adr2" Text='<%# Eval("CURRENT_ADDRESS_2") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="City"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txt_City" Text='<%# Eval("CURRENT_CITY") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Country"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txt_Country" Text='<%# Eval("CURRENT_COUNTRY") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Zip"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txt_Zip" Text='<%# Eval("CURRENT_ZIP") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Gender"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txt_Gender" Text='<%# Eval("CURRENT_GENDER") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Phone number"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txt_Phone" Text='<%# Eval("CURRENT_PHONE_NUMBER") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Email"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txt_Email" Text='<%# Eval("CURRENT_PERSONAL_EMAIL") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Marital status"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txt_MS" Text='<%# Eval("CURRENT_MARITAL_STATUS") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Ethnicity"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txt_Ethnicity" Text='<%# Eval("ETHNICITY") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Shareholder status"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txt_Shareholder" Text='<%# Eval("SHAREHOLDER_STATUS") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Benefit plan id"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txt_Benefit" Text='<%# Eval("BENEFIT_PLAN_ID") %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
