<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="desafio.Web.login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página de Login</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Login</h2>
            
            <div class="form-group">
                <asp:TextBox ID="txtUsuario" runat="server" placeholder="Usuário"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" placeholder="Senha"></asp:TextBox>
                <br />
                <asp:Button ID="btnEntrar" runat="server" Text="Entrar" OnClick="btnEntrar_Click" CssClass="btn" />
                <br />
                <asp:Button ID="btnCriarSenha" runat="server" Text="Criar Senha" OnClick="btnCriarSenha_Click" CssClass="form-button"/>
                <br />
                <asp:Label ID="lblMensagem" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>