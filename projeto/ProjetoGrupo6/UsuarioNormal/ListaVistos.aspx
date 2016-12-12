<%@ Page Title="" Language="C#" MasterPageFile="~/Cine7Normal.Master" AutoEventWireup="true" CodeBehind="ListaVistos.aspx.cs" Inherits="ProjetoGrupo6.UsuarioNormal.ListaVistos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="LabelFilmesVistosTitlesTodos" runat="server" Text="FILMES VISTOS"></asp:Label>
    <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1" RepeatColumns="4">
        <ItemTemplate>
            <asp:ImageButton ID="ImageButtonListaVistosTodos" runat="server" Height="225px" ImageUrl='<%# Eval("caminhoImagem") %>' OnClick="ImageButtonListaVistosTodos_Click" Width="150px" />
            <br />
            <asp:LinkButton ID="LinkButtonListaVistosTodos" runat="server" ForeColor="#333333" OnClick="LinkButtonListaVistosTodos_Click" Text='<%# Eval("filme_name") %>'></asp:LinkButton>
<br />
        </ItemTemplate>
</asp:DataList>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SelectListaFavoritoTodos" TypeName="ProjetoGrupo6.DAL.DALRelacaoVisto">
        <SelectParameters>
            <asp:SessionParameter Name="perfil" SessionField="perfil" Type="String" />
        </SelectParameters>
</asp:ObjectDataSource>
</asp:Content>
