<%@ Page Title="" Language="C#" MasterPageFile="~/Cine7Normal.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ProjetoGrupo6.UsuarioNormal.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Editar Perfil</p>
    <p>
        Nome:
        <asp:TextBox ID="TextBoxNome" runat="server"></asp:TextBox>
&nbsp;
        <asp:Button ID="ButtonEditarNome" runat="server" Text="Editar" OnClick="ButtonEditarNome_Click" />
    </p>
    <p>
        E-mail:
        <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="ButtonEditarEmail" runat="server" Text="Editar" OnClick="ButtonEditarEmail_Click" />
    </p>
    <p>
        País:
        <asp:TextBox ID="TextBoxPais" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="ButtonEditarPais" runat="server" Text="Editar" OnClick="ButtonEditarPais_Click" />
    </p>
    <p>
        Sexo:
        <asp:TextBox ID="TextBoxSexo" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="ButtonEditarSexo" runat="server" Text="Editar" OnClick="ButtonEditarSexo_Click" />
    </p>
    <p>
        Foto de Perfil
        <asp:Image ID="ImagePerfil" runat="server" />
        <asp:FileUpload ID="FileUploadEditarImagemPerfil" runat="server" />
        <asp:Button ID="ButtonEditarCaminhoImagem" runat="server" Text="Editar" OnClick="ButtonEditarCaminhoImagem_Click" />
    </p>
</asp:Content>
