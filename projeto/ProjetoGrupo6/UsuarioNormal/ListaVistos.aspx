﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Cine7Normal.Master" AutoEventWireup="true" CodeBehind="ListaVistos.aspx.cs" Inherits="ProjetoGrupo6.UsuarioNormal.ListaVistos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="LabelFilmesVistosTitlesTodos" runat="server" Text="FILMES VISTOS"></asp:Label>
    <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1" RepeatColumns="4">
        <ItemTemplate>
            <asp:ImageButton ID="ImageButton1" runat="server" Height="300px" ImageUrl='<%# Eval("caminhoImagem") %>' OnClick="ImageButtonListaInteressesTodos_Click" Width="200px" />
            <br />
            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="#333333" OnClick="LinkButtonListaInteressesTodos_Click" Text='<%# Eval("filme_name") %>'></asp:LinkButton>
<br />
        </ItemTemplate>
</asp:DataList>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SelectListaVistoTodos" TypeName="ProjetoGrupo6.DAL.DALRelacaoVisto">
        <SelectParameters>
            <asp:SessionParameter Name="perfil" SessionField="perfil" Type="String" />
        </SelectParameters>
</asp:ObjectDataSource>
</asp:Content>
