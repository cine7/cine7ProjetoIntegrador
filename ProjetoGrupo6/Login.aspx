<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjetoGrupo6.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Login ID="Login1" runat="server">
        </asp:Login>
    
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/CriarLogin/CriarLogin.aspx">Criar novo usuário</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>
