<%@ Page Title="" Language="C#" MasterPageFile="~/Cine7Anonimo.Master" AutoEventWireup="true" CodeBehind="ListaInteresses.aspx.cs" Inherits="ProjetoGrupo6.UsuarioAnonimo.ListaInteresses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    FILMES INTERESSES
    <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1" RepeatColumns="4">
        <ItemTemplate>
            <asp:ImageButton ID="ImageButtonAnonimoInteressesTodos" runat="server" Height="300px" ImageUrl='<%# Eval("caminhoImagem") %>' Width="200px" OnClick="ImageButtonAnonimoInteressesTodos_Click" />
        </ItemTemplate>
    </asp:DataList>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SelectListaInteresseTodos" TypeName="ProjetoGrupo6.DAL.DALRelacaoInteresse">
        <SelectParameters>
            <asp:SessionParameter Name="perfil" SessionField="perfil" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
