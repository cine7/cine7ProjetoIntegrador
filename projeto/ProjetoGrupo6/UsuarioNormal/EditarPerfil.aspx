<%@ Page Title="" Language="C#" MasterPageFile="~/Cine7Normal.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ProjetoGrupo6.UsuarioNormal.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Editar Perfil</p>
    <p>
        Nome:
        <asp:TextBox ID="TextBoxNome" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Button" />
    </p>
    <p>
        E-mail:
        <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Button3" runat="server" Text="Button" />
    </p>
    <p>
        País:
        <asp:TextBox ID="TextBoxPais" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Button4" runat="server" Text="Button" />
    </p>
    <p>
        Sexo:
        <asp:TextBox ID="TextBoxSexo" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Button5" runat="server" Text="Button" />
    </p>
    <p>
        Foto de Perfil
        <asp:Image ID="ImagePerfil" runat="server" />
        <asp:FileUpload ID="FileUpload1" runat="server" />
    </p>
</asp:Content>
