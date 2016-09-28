<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ProjetoGrupo6.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Bem-Vindo ao nosso site"></asp:Label>
    
        ,
        <asp:LoginName ID="LoginName1" runat="server" /> <br /> <br />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/UsuarioAdministrador/UsuárioAdministrador.aspx">Administrador</asp:HyperLink> <br />
        <br />
        <br />
        <asp:LoginStatus ID="LoginStatus1" runat="server" />
    
    </div>
    </form>
</body>
</html>
