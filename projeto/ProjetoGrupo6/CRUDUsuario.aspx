<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRUDUsuario.aspx.cs" Inherits="ProjetoGrupo6.CRUDUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 194px;
        }
        .auto-style2 {
            width: 194px;
            height: 23px;
        }
        .auto-style3 {
            height: 23px;
        }
        .auto-style4 {
            width: 194px;
            height: 21px;
        }
        .auto-style5 {
            height: 21px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        Cadastro de Usuário<br />
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">Login</td>
                <td>
                    <asp:TextBox ID="TextBoxLogin" runat="server" BackColor="Gray" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Nome</td>
                <td>
                    <asp:TextBox ID="TextBoxNome" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Sobrenome</td>
                <td>
                    <asp:TextBox ID="TextBoxSobrenome" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">País</td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBoxPais" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Sexo</td>
                <td>
                    <asp:TextBox ID="TextBoxSexo" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        
    </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </form>
</body>
</html>
