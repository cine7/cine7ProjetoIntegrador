<%@ Page Title="" Language="C#" MasterPageFile="~/Cine7Normal.Master" AutoEventWireup="true" CodeBehind="ListaFavoritos.aspx.cs" Inherits="ProjetoGrupo6.UsuarioNormal.ListaFavoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="LabelFilmesFavoritosTitleTodos" runat="server" Text="FILMES FAVORITOS"></asp:Label>
    <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1" RepeatColumns="4">
        <ItemTemplate>
            <asp:ImageButton ID="ImageButtonListaFavoritosTodos" runat="server" Height="225px" ImageUrl='<%# Eval("caminhoImagem") %>' OnClick="ImageButtonListaFavoritosTodos_Click" Width="150px" />
            <br />
            <asp:LinkButton ID="LinkButtonListaFavoritosTodos" runat="server" ForeColor="#333333" OnClick="LinkButtonListaFavoritosTodos_Click" Text='<%# Eval("filme_name") %>'></asp:LinkButton>
        </ItemTemplate>
    </asp:DataList>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SelectListaFavoritoTodos" TypeName="ProjetoGrupo6.DAL.DALRelacaoFavorito">
        <SelectParameters>
            <asp:SessionParameter Name="perfil" SessionField="perfil" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
