<<<<<<< HEAD
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Sources/MainPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GroupProject.Sources.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">
    <div>
        <h2 style="display: flex; justify-content: center; align-items: center; min-height: 50px">LOGIN</h2>
        <table style="width: 100%;">
            <tr style="width: 100%">
                <td>Username:</td>
                <td>
                    <asp:TextBox ID="txtTDN" runat="server" Height="20px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Label ID="lbtbNhapTDN" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="width: 100%">
                <td>Password:</td>
                <td>
                    <asp:TextBox ID="txtMK" runat="server" TextMode="Password" Height="20px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Label ID="lbtbMK" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lbthongbao" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btDangNhap" runat="server" Text="Login" OnClick="btDangNhap_Click" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:LinkButton ID="lnkForgotPassword" runat="server" Text="Forgot Password?" OnClick="lnkForgotPassword_Click"></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:LinkButton ID="lnkCreateAccount" runat="server" Text="Create Account" OnClick="lnkCreateAccount_Click"></asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

=======
﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GroupProject.Sources.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Login</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .login-container {
            background-color: #fff;
            padding: 40px;
            border-radius: 8px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
            text-align: center;
        }

            .login-container h2 {
                margin-bottom: 20px;
                color: #333;
            }

            .login-container label {
                display: block;
                margin-bottom: 10px;
                text-align: left;
                color: #555;
            }

            .login-container input[type="text"],
            .login-container input[type="password"] {
                width: 100%;
                padding: 10px;
                margin-bottom: 20px;
                border: 1px solid #ccc;
                border-radius: 4px;
                box-sizing: border-box;
            }

            .login-container #lbthongbao {
                display: block;
                margin-bottom: 20px;
                color: red;
            }

            .login-container button,
            .login-container a {
                display: inline-block;
                padding: 10px 20px;
                background-color: #007bff;
                color: #fff;
                border: none;
                border-radius: 4px;
                text-decoration: none;
                cursor: pointer;
            }

                .login-container button:hover,
                .login-container a:hover {
                    background-color: #0056b3;
                }

            .login-container .link-buttons {
                margin-top: 20px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Login</h2>
            <div>
                <label for="txtTDN">Username:</label>
                <asp:TextBox ID="txtTDN" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtMK">Password:</label>
                <asp:TextBox ID="txtMK" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <asp:Label ID="lbthongbao" runat="server"></asp:Label>
            <asp:Button ID="btDangNhap" runat="server" Text="Login" OnClick="btDangNhap_Click" />
        </div>
    </form>
</body>
</html>
>>>>>>> GỐC
