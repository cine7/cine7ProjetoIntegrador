<%@ Page Title="" Language="C#" MasterPageFile="~/Cine7Administrador.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="ProjetoGrupo6.UsuarioAdministrador.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="LabelUsuario" runat="server" Text="Label"></asp:Label>
<br />
<asp:LinkButton ID="LinkButtonSeguirEditar" runat="server" ForeColor="Black" OnClick="LinkButtonSeguirEditar_Click">LinkButton</asp:LinkButton>
    <br />
    <asp:LinkButton ID="LinkButtonCRUDFilme" runat="server" ForeColor="Black" OnClick="LinkButtonCRUDFilme_Click">LinkButton</asp:LinkButton>
    <br />    <br />
</asp:Content>
