<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <style>
        body {
            background-color: #f8f9fa;
        }

        .container {
            margin-top: 100px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-header">
                            <h2>İndirim Kuponu İçin Giriş Yap</h2>
                        </div>
                        <div class="card-body">
                            <asp:Label runat="server" ID="lblMessage" Text="" ForeColor="" />
                            <div class="form-group">
                                <label for="username">Kullanıcı Adı:</label>
                                <asp:TextBox runat="server" ID="username" CssClass="form-control" Required="true" OnTextChanged="username_TextChanged" />
                            </div>
                            <div class="form-group">
                                <label for="password">Şifre:</label>
                                <asp:TextBox runat="server" ID="password" TextMode="Password" CssClass="form-control" Required="true" />
                            </div>
                            <asp:Button runat="server" ID="btnLogin" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn-primary" />
                            <asp:Button runat="server" ID="btnRegister" Text="Register" OnClick="btnRegister_Click" CssClass="btn btn-secondary" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
