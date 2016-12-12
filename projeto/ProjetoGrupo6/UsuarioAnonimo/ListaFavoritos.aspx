<%@ Page Title="" Language="C#" MasterPageFile="~/Cine7Anonimo.Master" AutoEventWireup="true" CodeBehind="ListaFavoritos.aspx.cs" Inherits="ProjetoGrupo6.UsuarioAnonimo.ListaFavoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    FILMES FAVORITOS
    <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1" RepeatColumns="4">
        <ItemTemplate>
            <asp:ImageButton ID="ImageButtonAnonimoFavoritosTodos" runat="server" Height="300px" ImageUrl='<%# Eval("caminhoImagem") %>' Width="200px" OnClick="ImageButtonAnonimoFavoritosTodos_Click" />
        </ItemTemplate>
    </asp:DataList>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SelectListaFavoritoTodos" TypeName="ProjetoGrupo6.DAL.DALRelacaoFavorito">
        <SelectParameters>
            <asp:SessionParameter Name="perfil" SessionField="perfil" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
