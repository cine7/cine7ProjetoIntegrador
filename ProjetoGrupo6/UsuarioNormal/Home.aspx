<%@ Page Title="" Language="C#" MasterPageFile="~/Cine7Normal.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ProjetoGrupo6.UsuarioNormal.Home1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <p>
        <asp:Image ID="ImagePerfil" runat="server" BorderStyle="Solid" />
</p>
    <p>
    FEED<asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButtonUsuario" runat="server" ForeColor="Black">LinkButton</asp:LinkButton>
                <asp:Label ID="nomeLabel" runat="server" Text='<%# Eval("nome") %>' />
                <br />
                tipo
                <asp:Label ID="tipoLabel" runat="server" Text='<%# Eval("tipo") %>' />
                <br />
                <asp:Label ID="filme_nameLabel" runat="server" Text='<%# Eval("filme_name") %>' />
                <br />
                <br />
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:2016TiiGrupo6ConnectionString %>" SelectCommand="SELECT tipo,
	   Filme.filme_name,
	   Usuario.nome
from Post

INNER JOIN Usuario on Usuario.usuario = Post.usuario
INNER JOIN Segue on Segue.usuarioSeguido = Usuario.usuario 
INNER JOIN Filme on Filme.filme_id = Post.filme_id

WHERE Segue.usuarioSeguidor = @perfil">
            <SelectParameters>
                <asp:SessionParameter Name="perfil" SessionField="perfil" />
            </SelectParameters>
        </asp:SqlDataSource>
</p>

</asp:Content>
