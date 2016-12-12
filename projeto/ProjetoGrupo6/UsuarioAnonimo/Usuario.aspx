<%@ Page Title="" Language="C#" MasterPageFile="~/Cine7Anonimo.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="ProjetoGrupo6.UsuarioAnonimo.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container-fluid">
        <div class="row">
            <div class="col-md-3">
            <br /> 
            <b>
                <asp:Image ID="ImagePerfil" runat="server" Height="40px" Width="40px" />
                <asp:Label ID="LabelUsuario" runat="server" Text="Label" CssClass="labelUsuario"></asp:Label></b>
            &nbsp;&nbsp;
            <asp:LinkButton ID="LinkButtonSeguirEditar" runat="server" ForeColor="Black" OnClick="AnonimoClick_Click">Seguir</asp:LinkButton>
            &nbsp;<br />
                </div>
         </div>
        <br />
        <div class="row">
            <div class="col-md-6">
                <div id="filmes">
                Filmes Favoritos<asp:DataList ID="DataListFavoritos" runat="server" DataSourceID="ObjectDataSource1" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButtonFilmeFavoritoTop" runat="server" Height="150px" ImageUrl='<%# Eval("caminhoImagem") %>' OnClick="ImageButtonFilmeFavoritoTop_Click" Width="100px" />
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SelectListaFavorito" TypeName="ProjetoGrupo6.DAL.DALRelacaoFavorito">
                    <SelectParameters>
                        <asp:SessionParameter Name="perfil" SessionField="perfil" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                    <asp:LinkButton ID="LinkButtonVerMaisFavoritos" runat="server" ForeColor="#333333" OnClick="LinkButtonVerMaisFavoritos_Click">Ver mais</asp:LinkButton>
                <br />
                Filmes Vistos<asp:DataList ID="DataListVistos" runat="server" DataSourceID="ObjectDataSource2" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        &nbsp;<asp:ImageButton ID="ImageButtonFilmeVistoTop" runat="server" ImageUrl='<%# Eval("caminhoImagem") %>' width="100px" height="150px" OnClick="ImageButtonFilmeVistoTop_Click" />
                    </ItemTemplate>
                </asp:DataList>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="SelectListaVisto" TypeName="ProjetoGrupo6.DAL.DALRelacaoVisto">
                    <SelectParameters>
                        <asp:SessionParameter Name="perfil" SessionField="perfil" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                    <asp:LinkButton ID="LinkButtonVerMaisVistos" runat="server" ForeColor="#333333" OnClick="LinkButtonVerMaisVistos_Click">Ver mais</asp:LinkButton>
                <br />
                Filmes que quero assistir<asp:DataList ID="DataListInteresses" runat="server" DataSourceID="ObjectDataSource3" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButtonFilmeInteresseTop" runat="server" ImageUrl='<%# Eval("caminhoImagem") %>' width="100px" height="150px" OnClick="ImageButtonFilmeInteresseTop_Click" />
                    </ItemTemplate>
                </asp:DataList>
                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="SelectListaInteresse" TypeName="ProjetoGrupo6.DAL.DALRelacaoInteresse">
                    <SelectParameters>
                        <asp:SessionParameter Name="perfil" SessionField="perfil" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                    <asp:LinkButton ID="LinkButtonVerMaisInteresses" runat="server" ForeColor="#333333" OnClick="LinkButtonVerMaisInteresses_Click">Ver mais</asp:LinkButton>
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
                <asp:DataList ID="DataList1_Feed" runat="server" DataSourceID="ObjectDataSource4">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonUsuarioPost" runat="server" ForeColor="#333333" OnClick="LinkButtonUsuarioPost_Click" Text='<%# Eval("usuario") %>'></asp:LinkButton>
                        <asp:Label ID="descricaoLabel" runat="server" Text='<%# Eval("descricao") %>' />
                        &nbsp;<br />
                        <asp:LinkButton ID="LinkButtonFilme_namePost" runat="server" ForeColor="#333333" OnClick="LinkButtonFilme_namePost_Click" Text='<%# Eval("filme_name") %>'></asp:LinkButton>
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                    <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="SelectAll" TypeName="ProjetoGrupo6.DAL.DALPost">
                        <SelectParameters>
                            <asp:SessionParameter Name="perfil" SessionField="perfil" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    </div>
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
</asp:Content>
