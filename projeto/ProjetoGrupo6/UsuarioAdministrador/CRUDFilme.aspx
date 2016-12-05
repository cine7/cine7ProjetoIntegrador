<%@ Page Title="" Language="C#" MasterPageFile="~/Cine7Administrador.Master" AutoEventWireup="true" CodeBehind="CRUDFilme.aspx.cs" Inherits="ProjetoGrupo6.UsuarioAdministrador.CRUDFilme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="LabelInserir" runat="server" Text="Inserir"></asp:Label> <br>
    Nome<br />
&nbsp;<asp:TextBox ID="TextBoxFilme_name" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox> <br>
    Ano 
    <br />
    <asp:TextBox ID="TextBoxAno" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox><br>
    Sinopse<br />
    <asp:TextBox ID="TextBoxSinopse" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox><br>
    Diretor<br />
    <asp:TextBox ID="TextBoxDiretor" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox><br>
    Produtora 
    <br />
    <asp:TextBox ID="TextBoxProdutora" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox><br>
    Duracao<br />
    <asp:TextBox ID="TextBoxDuracao" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
    <br />
    Image<asp:FileUpload ID="FileUploadImagem" runat="server" />
    <br>
    <asp:Button ID="Button1" runat="server" Text="Inserir" />
    <br>
</asp:Content>
