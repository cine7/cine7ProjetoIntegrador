<%@ Page Title="" Language="C#" MasterPageFile="~/Cine7Normal.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="ProjetoGrupo6.UsuarioNormal.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-3">
            <br /> 
            <b><asp:Label ID="LabelUsuario" runat="server" Text="Label" CssClass="labelUsuario"></asp:Label></b>
            &nbsp;&nbsp;
            <asp:LinkButton ID="LinkButtonSeguirEditar" runat="server" ForeColor="Black" OnClick="LinkButtonSeguirEditar_Click">Seguir</asp:LinkButton>
            <br />
                </div>
         </div>
        <br />
        <div class="row">
            <div class="col-md-6">
                <div id="filmes">
                Filmes Favoritos<asp:DataList ID="DataListFavoritos" runat="server" DataSourceID="ObjectDataSource1" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButtonFavorito" runat="server" ImageUrl='<%# Eval("caminhoImagem") %>' width="100px" height="150px"/>
                    </ItemTemplate>
                </asp:DataList>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SelectListaFavorito" TypeName="ProjetoGrupo6.DAL.DALRelacaoFavorito">
                    <SelectParameters>
                        <asp:SessionParameter Name="perfil" SessionField="perfil" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <br />
                Filmes Vistos<asp:DataList ID="DataListVistos" runat="server" DataSourceID="ObjectDataSource2" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("caminhoImagem") %>' width="100px" height="150px" />
                    </ItemTemplate>
                </asp:DataList>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="SelectListaVisto" TypeName="ProjetoGrupo6.DAL.DALRelacaoVisto">
                    <SelectParameters>
                        <asp:SessionParameter Name="perfil" SessionField="perfil" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <br />
                Filmes que quero assistir<asp:DataList ID="DataListInteresses" runat="server" DataSourceID="ObjectDataSource3" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl='<%# Eval("caminhoImagem") %>' width="100px" height="150px" />
                    </ItemTemplate>
                </asp:DataList>
                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="SelectListaInteresse" TypeName="ProjetoGrupo6.DAL.DALRelacaoInteresse">
                    <SelectParameters>
                        <asp:SessionParameter Name="perfil" SessionField="perfil" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
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
