<%@ Page Title="" Language="C#" MasterPageFile="~/Cine7Normal.Master" AutoEventWireup="true" CodeBehind="ListaFavoritos.aspx.cs" Inherits="ProjetoGrupo6.UsuarioNormal.ListaFavoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1">
        <ItemTemplate>
            <asp:ImageButton ID="ImageButtonListaFavoritosTodos" runat="server" ImageUrl='<%# Eval("caminhoImagem") %>' OnClick="ImageButtonListaFavoritosTodos_Click" />
        </ItemTemplate>
    </asp:DataList>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SelectListaFavorito" TypeName="ProjetoGrupo6.DAL.DALRelacaoFavorito">
        <SelectParameters>
            <asp:SessionParameter Name="perfil" SessionField="perfil" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
