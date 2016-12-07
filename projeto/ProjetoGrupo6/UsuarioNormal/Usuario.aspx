<%@ Page Title="" Language="C#" MasterPageFile="~/Cine7Normal.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="ProjetoGrupo6.UsuarioNormal.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div id ="filmes">
            <br /> 
            <asp:Label ID="LabelUsuario" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:LinkButton ID="LinkButtonSeguirEditar" runat="server" ForeColor="Black" OnClick="LinkButtonSeguirEditar_Click">Seguir</asp:LinkButton>
            <br />
         </div>
        <div class="row">
            <div class="col-md-6">
                Filmes Favoritos<asp:DataList ID="DataListFavoritos" runat="server" DataSourceID="SqlDataSource1" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        filme_name: <asp:Label ID="filme_nameLabel" runat="server" Text='<%# Eval("filme_name") %>' />
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:2016TiiGrupo6ConnectionString %>" SelectCommand="Select Filme.filme_name from RelacaoFavorito 
                INNER JOIN Filme on Filme.filme_id = RelacaoFavorito.filme_id
                where usuario = @perfil">
                    <SelectParameters>
                        <asp:SessionParameter Name="perfil" SessionField="perfil" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
                Filmes Vistos<asp:DataList ID="DataListVistos" runat="server" DataSourceID="SqlDataSource2" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        filme_name: <asp:Label ID="filme_nameLabel" runat="server" Text='<%# Eval("filme_name") %>' />
                        <br />
                    <br />
                    </ItemTemplate>
                </asp:DataList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:2016TiiGrupo6ConnectionString %>" SelectCommand="Select Filme.filme_name from RelacaoVisto
                INNER JOIN Filme on Filme.filme_id = RelacaoVisto.filme_id
                where usuario = @perfil">
                    <SelectParameters>
                        <asp:SessionParameter Name="perfil" SessionField="perfil" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
                Filmes que quero assistir<asp:DataList ID="DataListInteresses" runat="server" DataSourceID="SqlDataSource3" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        filme_name: <asp:Label ID="filme_nameLabel" runat="server" Text='<%# Eval("filme_name") %>' />
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:2016TiiGrupo6ConnectionString %>" SelectCommand="  Select Filme.filme_name from RelacaoInteresse
                INNER JOIN Filme on Filme.filme_id = RelacaoInteresse.filme_id
                where usuario = @perfil">
                    <SelectParameters>
                        <asp:SessionParameter Name="perfil" SessionField="perfil" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
                <br/>
                <br/>
                </div>
                </div>
                </div>
            </div>
            <div class="row">
            <div class="col-md-6">
                <div id="feedUsuario">
                <asp:DataList ID="DataList1_Feed" runat="server" DataSourceID="SqlDataSource4">
                    <ItemTemplate>
                        tipo:
                        <asp:Label ID="tipoLabel" runat="server" Text='<%# Eval("tipo") %>' />
                        <br />
                        filme_name:
                        <asp:Label ID="filme_nameLabel" runat="server" Text='<%# Eval("filme_name") %>' />
                        <br />
                        nome:
                        <asp:Label ID="nomeLabel" runat="server" Text='<%# Eval("nome") %>' />
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                    </div>
                </div>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:2016TiiGrupo6ConnectionString %>" SelectCommand="SELECT tipo,
	                Filme.filme_name,
	                Usuario.nome
                    from Post

                    INNER JOIN Usuario on Usuario.usuario = Post.usuario
                    INNER JOIN Filme on Filme.filme_id = Post.filme_id

                    WHERE Usuario.usuario = @perfil">
                    <SelectParameters>
                        <asp:SessionParameter Name="perfil" SessionField="perfil" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
            </div>
        </div>
    </div>
</asp:Content>
