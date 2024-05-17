<%@ Page Title="" Language="C#" MasterPageFile="~/Sources/MainPage.Master" AutoEventWireup="true" CodeBehind="InsertStaffIntoMySQL.aspx.cs" Inherits="GroupProject.Sources.ManageStaff.Functions.InsertStaffIntoMySQL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #dl_Staff {
            display: block; /* Đảm bảo rằng DataList được hiển thị */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Label runat="server" Text="Employee ID"></asp:Label><br />
                    <asp:Label runat="server" Text="Employee number" ID="Label1"></asp:Label><br />
                    <asp:Label runat="server" Text="Last name"></asp:Label><br />
                    <asp:Label runat="server" Text="First name"></asp:Label><br />
                    <asp:Label runat="server" Text="SSN"></asp:Label><br />
                    <asp:Label runat="server" Text="Pay rate"></asp:Label><br />
                    <asp:Label runat="server" Text="Pay rate ID"></asp:Label><br />
                    <asp:Label runat="server" Text="Vacation days"></asp:Label><br />
                    <asp:Label runat="server" Text="Paid to date"></asp:Label><br />
                    <asp:Label runat="server" Text="Paid last year"></asp:Label><br />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_pID" TextMode="Number"></asp:TextBox><br />
                    <asp:TextBox runat="server" ID="txt_EN"></asp:TextBox><br />
                    <asp:TextBox runat="server" ID="txt_LN"></asp:TextBox><br />
                    <asp:TextBox runat="server" ID="txt_FN"></asp:TextBox><br />
                    <asp:TextBox runat="server" ID="txt_SSN"></asp:TextBox><br />
                    <asp:DropDownList ID="ddl_PR" runat="server"></asp:DropDownList><br />
                    <asp:TextBox runat="server" ID="txt_PRID"></asp:TextBox><br />
                    <asp:TextBox runat="server" ID="txt_VD"></asp:TextBox><br />
                    <asp:TextBox runat="server" ID="txt_PTD"></asp:TextBox><br />
                    <asp:TextBox runat="server" ID="txt_PLY"></asp:TextBox><br />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:Button ID="bt_add" runat="server" Text="ADD" OnClick="bt_add_Click" />
    </div>
</asp:Content>
