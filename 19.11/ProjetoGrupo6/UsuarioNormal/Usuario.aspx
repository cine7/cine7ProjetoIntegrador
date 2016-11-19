<%@ Page Title="" Language="C#" MasterPageFile="~/Cine7Normal.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="ProjetoGrupo6.UsuarioNormal.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="LabelUsuario" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    Filmes Favoritos<asp:DataList ID="DataListFavoritos" runat="server" DataSourceID="SqlDataSource1" RepeatDirection="Horizontal">
        <ItemTemplate>
            &nbsp;<asp:Label ID="filme_nameLabel" runat="server" ForeColor="Black" Text='<%# Eval("filme_name") %>' />
            <br />
<br />
        </ItemTemplate>
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:2016TiiGrupo6ConnectionString %>" SelectCommand="Select Filme.filme_name from RelacaoFavorito 
INNER JOIN Filme on Filme.filme_id = RelacaoFavorito.filme_id
where usuario = @usuario">
        <SelectParameters>
            <asp:SessionParameter Name="usuario" SessionField="usuario" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    Filmes Vistos<asp:DataList ID="DataListVistos" runat="server" DataSourceID="SqlDataSource2" RepeatDirection="Horizontal">
        <ItemTemplate>
            &nbsp;<asp:Label ID="filme_nameLabel" runat="server" Text='<%# Eval("filme_name") %>' />
            <br />
<br />
        </ItemTemplate>
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:2016TiiGrupo6ConnectionString %>" SelectCommand="Select Filme.filme_name from RelacaoVisto
INNER JOIN Filme on Filme.filme_id = RelacaoVisto.filme_id
where usuario = 'OII'"></asp:SqlDataSource>
    <br />
    Filmes que quero assistir<asp:DataList ID="DataListInteresses" runat="server" DataSourceID="SqlDataSource3" RepeatDirection="Horizontal">
        <ItemTemplate>
            &nbsp;<asp:Label ID="filme_nameLabel" runat="server" Text='<%# Eval("filme_name") %>' />
            <br />
<br />
        </ItemTemplate>
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:2016TiiGrupo6ConnectionString %>" SelectCommand="  Select Filme.filme_name from RelacaoInteresse
INNER JOIN Filme on Filme.filme_id = RelacaoInteresse.filme_id
where usuario = @usuario">
        <SelectParameters>
            <asp:SessionParameter Name="usuario" SessionField="usuario" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
</asp:Content>
