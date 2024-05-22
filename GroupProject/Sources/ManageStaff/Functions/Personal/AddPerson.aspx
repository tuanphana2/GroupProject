﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Sources/MainPage.Master" AutoEventWireup="true" CodeBehind="AddPerson.aspx.cs" Inherits="GroupProject.Sources.ManageStaff.Functions.AddStaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table style="width: 100%; position:center">
            <tr>
                <td>
                    <asp:Label runat="server" Text="Personal ID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_pID" TextMode="Number" Style="width: 168px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="First name" ID="Label1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_FN"></asp:TextBox><br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Last name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_LN"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Middle name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_MN"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Date of birth"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="datePicker" runat="server" TextMode="Date" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="SSN"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_SSN"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Drivers lisence"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_DL"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Address 1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_Adr1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Address 2"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_Adr2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="City"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_City"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Country"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_Country"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Zip"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_Zip"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Gender"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_Gender"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Phone number"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_Phone"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Email"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_Email"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Marital status"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_MS"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Ethnicity"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_Ethnicity"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Shareholder status"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_Shareholder"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Benefit plan id"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_Benefit"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="bt_Add" runat="server" Text="Add" OnClick="bt_Add_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>