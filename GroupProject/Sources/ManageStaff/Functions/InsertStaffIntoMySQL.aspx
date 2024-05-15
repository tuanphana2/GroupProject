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
        <asp:DataList ID="dl_Staff" runat="server">
            <ItemTemplate>
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
                            <asp:TextBox runat="server" ID="txt_pID" TextMode="Number" Style="width: 168px" Text='<%# Eval("idEmployee") %>'></asp:TextBox><br />
                            <asp:TextBox runat="server" ID="txt_EN" Text='<%# Eval("Employee Number") %>'></asp:TextBox><br />
                            <asp:TextBox runat="server" ID="txt_LN" Text='<%# Eval("Last Name") %>'></asp:TextBox><br />
                            <asp:TextBox runat="server" ID="txt_FN" Text='<%# Eval("First Name") %>'></asp:TextBox><br />
                            <asp:TextBox runat="server" ID="txt_SSN" Text='<%# Eval("SSN") %>'></asp:TextBox><br />
                            <asp:TextBox runat="server" ID="txt_PR" Text='<%# Eval("Pay Rate") %>'></asp:TextBox><br />
                            <asp:TextBox runat="server" ID="txt_PRID" Text='<%# Eval("Pay Rates_idPay Rates") %>'></asp:TextBox><br />
                            <asp:TextBox runat="server" ID="txt_VD" Text='<%# Eval("Vacation Days") %>'></asp:TextBox><br />
                            <asp:TextBox runat="server" ID="txt_PTD" Text='<%# Eval("Paid To Date") %>'></asp:TextBox><br />
                            <asp:TextBox runat="server" ID="txt_PLY" Text='<%# Eval("Paid Last Year") %>'></asp:TextBox><br />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
