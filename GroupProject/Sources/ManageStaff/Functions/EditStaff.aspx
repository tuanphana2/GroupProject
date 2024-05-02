<%@ Page Title="" Language="C#" MasterPageFile="~/Sources/MainPage.Master" AutoEventWireup="true" CodeBehind="EditStaff.aspx.cs" Inherits="GroupProject.Sources.ManageStaff.Functions.EditStaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label runat="server" Text="Personal ID"></asp:Label>
                <asp:TextBox runat="server" ID="txt_pID"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="First name" ID="Label1"></asp:Label>
                <asp:TextBox runat="server" ID="txt_FN"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Last name"></asp:Label>
                <asp:TextBox runat="server" ID="txt_LN"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Middle name"></asp:Label>
                <asp:TextBox runat="server" ID="txt_MN"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Date of birth"></asp:Label>
                <asp:TextBox ID="datePicker" runat="server" TextMode="Date" />
                <br />
                <asp:Label runat="server" Text="SSN"></asp:Label>
                <asp:TextBox runat="server" ID="txt_SSN"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Drivers lisence"></asp:Label>
                <asp:TextBox runat="server" ID="txt_DL"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Address 1"></asp:Label>
                <asp:TextBox runat="server" ID="txt_Adr1"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Address 2"></asp:Label>
                <asp:TextBox runat="server" ID="txt_Adr2"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="City"></asp:Label>
                <asp:TextBox runat="server" ID="txt_City"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Country"></asp:Label>
                <asp:TextBox runat="server" ID="txt_Country"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Zip"></asp:Label>
                <asp:TextBox runat="server" ID="txt_Zip"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Gender"></asp:Label>
                <asp:TextBox runat="server" ID="txt_Gender"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Phone number"></asp:Label>
                <asp:TextBox runat="server" ID="txt_Phone"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Email"></asp:Label>
                <asp:TextBox runat="server" ID="txt_Email"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Marital status"></asp:Label>
                <asp:TextBox runat="server" ID="txt_MS"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Ethnicity"></asp:Label>
                <asp:TextBox runat="server" ID="txt_Ethnicity"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="bt_Edit" runat="server" Text="Edit" OnClick="bt_Edit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
