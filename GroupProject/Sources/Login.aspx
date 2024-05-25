<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GroupProject.Sources.Login" %>

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
            <button id="btDangNhap" runat="server" onclick="btDangNhap_Click">Login</button>
        </div>
    </form>
</body>
</html>
