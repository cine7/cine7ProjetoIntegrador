<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastrarFilme.aspx.cs" Inherits="ProjetoGrupo6.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 134px;
        }
        .auto-style2 {
            width: 134px;
            height: 23px;
        }
        .auto-style3
        {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Cadastrar Filme<hr />
    
    </div>
    <table style="width:100%;">
        <tr>
            <td class="auto-style1">Nome do filme:</td>
            <td class="auto-style2">
                <asp:TextBox ID="TextBoxFilmeName" runat="server" Width="158px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">Ano de lançamento:</td>
            <td class="auto-style2">
                <asp:TextBox ID="TextBoxAno" runat="server" Width="158px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
                <tr>
            <td class="auto-style2">Sinopse:</td>
            <td class="auto-style2">
                <asp:TextBox ID="TextBoxSinopse" runat="server" Width="457px" Height="113px" TextMode="MultiLine"></asp:TextBox>
                    </td>
            <td class="auto-style3"></td>
        </tr>
                <tr>
            <td class="auto-style1">Diretor:</td>
            <td class="auto-style2">
                <asp:TextBox ID="TextBoxDiretor" runat="server" Width="158px"></asp:TextBox>
                    </td>
            <td>&nbsp;</td>
        </tr>
           <tr>
            <td class="auto-style1">Produtora:</td>
            <td class="auto-style2">
                <asp:TextBox ID="TextBoxProdutora" runat="server" Width="158px"></asp:TextBox>
               </td>
            <td>&nbsp;</td>
        </tr>
           <tr>
            <td class="auto-style1">Duração:</td>
            <td class="auto-style2">
                <asp:TextBox ID="TextBoxDuracao" runat="server" Width="158px"></asp:TextBox>
               </td>
            <td>&nbsp;</td>
        </tr>
    </table>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Salvar" PostBackUrl="~/UsuarioAdministrador/UsuárioAdministrador.aspx" />
    </form>
</body>
</html>
