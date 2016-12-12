<%@ Page Title="" Language="C#" MasterPageFile="~/Cine7Normal.Master" AutoEventWireup="true" CodeBehind="ListaInteresses.aspx.cs" Inherits="ProjetoGrupo6.UsuarioNormal.ListaInteresses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="LabelFilmesInteressesTitleTodos" runat="server" Text="FILMES INTERESSES"></asp:Label>
<asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1" RepeatColumns="4">
    <ItemTemplate>
        <asp:ImageButton ID="ImageButtonListaInteressesTodos" runat="server" Height="225px" ImageUrl='<%# Eval("caminhoImagem") %>' OnClick="ImageButtonListaInteressesTodos_Click" Width="150px" />
        <br />
        <asp:LinkButton ID="LinkButtonListaInteressesTodos" runat="server" ForeColor="#333333" OnClick="LinkButtonListaInteressesTodos_Click" Text='<%# Eval("filme_name") %>'></asp:LinkButton>
        <br />
<br />
    </ItemTemplate>
</asp:DataList>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SelectListaFavoritoTodos" TypeName="ProjetoGrupo6.DAL.DALRelacaoInteresse">
    <SelectParameters>
        <asp:SessionParameter Name="perfil" SessionField="perfil" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
</asp:Content>
