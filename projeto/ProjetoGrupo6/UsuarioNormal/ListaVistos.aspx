<%@ Page Title="" Language="C#" MasterPageFile="~/Cine7Normal.Master" AutoEventWireup="true" CodeBehind="ListaVistos.aspx.cs" Inherits="ProjetoGrupo6.UsuarioNormal.ListaVistos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="LabelFilmesVistosTitlesTodos" runat="server" Text="FILMES VISTOS"></asp:Label>
    <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1"></asp:DataList>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>
</asp:Content>
