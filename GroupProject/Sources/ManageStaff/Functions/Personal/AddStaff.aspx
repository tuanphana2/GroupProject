<%@ Page Title="" Language="C#" MasterPageFile="~/Sources/MainPage.Master" AutoEventWireup="true" CodeBehind="AddStaff.aspx.cs" Inherits="GroupProject.Sources.ManageStaff.Functions.AddStaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
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
                    <asp:TextBox runat="server" ID="txt_pID" TextMode="Number" Style="width: 168px"></asp:TextBox><br />
                    <asp:TextBox runat="server" ID="txt_FN"></asp:TextBox><br />
                    <asp:TextBox runat="server" ID="txt_LN"></asp:TextBox><br />
                    <asp:TextBox runat="server" ID="txt_MN"></asp:TextBox><br />
                    <asp:TextBox ID="datePicker" runat="server" TextMode="Date" /><br />
                    <asp:TextBox runat="server" ID="txt_SSN"></asp:TextBox><br />
                    <asp:TextBox runat="server" ID="txt_DL"></asp:TextBox><br />
                    <asp:TextBox runat="server" ID="txt_Adr1"></asp:TextBox><br />
                    <asp:TextBox runat="server" ID="txt_Adr2"></asp:TextBox><br />
                    <asp:TextBox runat="server" ID="txt_City"></asp:TextBox><br />
                    <asp:TextBox runat="server" ID="txt_Country"></asp:TextBox><br />
                    <asp:TextBox runat="server" ID="txt_Zip"></asp:TextBox><br />
                    <asp:TextBox runat="server" ID="txt_Gender"></asp:TextBox><br />
                    <asp:TextBox runat="server" ID="txt_Phone"></asp:TextBox><br />
                    <asp:TextBox runat="server" ID="txt_Email"></asp:TextBox><br />
                    <asp:TextBox runat="server" ID="txt_MS"></asp:TextBox><br />
                    <asp:TextBox runat="server" ID="txt_Ethnicity"></asp:TextBox><br />
                    <asp:TextBox runat="server" ID="txt_Shareholder"></asp:TextBox><br />
                    <asp:TextBox runat="server" ID="txt_Benefit"></asp:TextBox><br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="bt_Add" runat="server" Text="Add" OnClick="bt_Add_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
