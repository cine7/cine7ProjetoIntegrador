<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastrarFilme.aspx.cs" Inherits="ProjetoGrupo6.CadastrarFilme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </div>
        <asp:TextBox ID="TextBoxFilmeName" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBoxAno" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBoxSinopse" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBoxDiretor" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBoxProdutora" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBoxDuracao" runat="server" OnTextChanged="TextBoxDuracao_TextChanged"></asp:TextBox>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/UsuarioAdministrador/UsuárioAdministrador.aspx">Voltar</asp:HyperLink>
    </form>
</body>
</html>
