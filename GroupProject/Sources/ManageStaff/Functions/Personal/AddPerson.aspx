<%@ Page Title="" Language="C#" MasterPageFile="~/Sources/MainPage.Master" AutoEventWireup="true" CodeBehind="AddPerson.aspx.cs" Inherits="GroupProject.Sources.ManageStaff.Functions.AddStaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-container {
            max-width: 800px;
            margin: auto;
            padding: 20px;
            background-color: #ffffff;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

            .form-container table {
                width: 100%;
                border-collapse: collapse;
            }

            .form-container td {
                padding: 10px;
                vertical-align: top;
            }

            .form-container label {
                font-weight: bold;
                display: block;
                margin-bottom: 5px;
            }

            .form-container input, .form-container select, .form-container button {
                width: calc(100% - 20px);
                padding: 10px;
                margin-bottom: 10px;
                border: 1px solid #ccc;
                border-radius: 4px;
            }

            .form-container button {
                background-color: #007bff;
                color: white;
                border: none;
                cursor: pointer;
            }

                .form-container button:hover {
                    background-color: #0056b3;
                }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-container">
        <table>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Personal ID"></asp:Label></td>
                <td>
                    <asp:TextBox runat="server" ID="txt_pID" TextMode="Number"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Employee number" ID="Label2"></asp:Label></td>
                <td>
                    <asp:TextBox runat="server" ID="txt_EN"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="First name" ID="Label1"></asp:Label></td>
                <td>
                    <asp:TextBox runat="server" ID="txt_FN"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Last name"></asp:Label></td>
                <td>
                    <asp:TextBox runat="server" ID="txt_LN"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Middle name"></asp:Label></td>
                <td>
                    <asp:TextBox runat="server" ID="txt_MN"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Date of birth"></asp:Label></td>
                <td>
                    <asp:TextBox ID="datePicker" runat="server" TextMode="Date"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="SSN"></asp:Label></td>
                <td>
                    <asp:TextBox runat="server" ID="txt_SSN"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Drivers license"></asp:Label></td>
                <td>
                    <asp:TextBox runat="server" ID="txt_DL"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Address 1"></asp:Label></td>
                <td>
                    <asp:TextBox runat="server" ID="txt_Adr1"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Address 2"></asp:Label></td>
                <td>
                    <asp:TextBox runat="server" ID="txt_Adr2"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="City"></asp:Label></td>
                <td>
                    <asp:TextBox runat="server" ID="txt_City"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Country"></asp:Label></td>
                <td>
                    <asp:TextBox runat="server" ID="txt_Country"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Zip"></asp:Label></td>
                <td>
                    <asp:TextBox runat="server" ID="txt_Zip"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Gender"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddl_Gentle" runat="server">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Phone number"></asp:Label></td>
                <td>
                    <asp:TextBox runat="server" ID="txt_Phone"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Email"></asp:Label></td>
                <td>
                    <asp:TextBox runat="server" ID="txt_Email"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Marital status"></asp:Label></td>
                <td>
                    <asp:TextBox runat="server" ID="txt_MS"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Ethnicity"></asp:Label></td>
                <td>
                    <asp:TextBox runat="server" ID="txt_Ethnicity"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Shareholder status"></asp:Label></td>
                <td>
                    <asp:TextBox runat="server" ID="txt_Shareholder"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Benefit plan id"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddl_Benefit" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Pay rate"></asp:Label></td>
                <td>
                    <asp:TextBox runat="server" ID="txt_PR"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Pay rate ID"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddl_PRID" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Vacation days"></asp:Label></td>
                <td>
                    <asp:TextBox runat="server" ID="txt_VD"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Paid to date"></asp:Label></td>
                <td>
                    <asp:TextBox runat="server" ID="txt_PTD"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Paid last year"></asp:Label></td>
                <td>
                    <asp:TextBox runat="server" ID="txt_PLY"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="bt_Add" runat="server" Text="Add" OnClick="bt_Add_Click" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
