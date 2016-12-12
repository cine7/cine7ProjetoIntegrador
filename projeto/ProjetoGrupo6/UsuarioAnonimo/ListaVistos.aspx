<%@ Page Title="" Language="C#" MasterPageFile="~/Cine7Anonimo.Master" AutoEventWireup="true" CodeBehind="ListaVistos.aspx.cs" Inherits="ProjetoGrupo6.UsuarioAnonimo.ListaVistos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    FILMES VISTOS
    <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1" RepeatColumns="4" OnSelectedIndexChanged="DataList1_SelectedIndexChanged">
        <ItemTemplate>
            <asp:ImageButton ID="ImageButtonAnonimoVistosTodos" runat="server" Height="300px" ImageUrl='<%# Eval("caminhoImagem") %>' Width="200px" OnClick="ImageButtonAnonimoVistosTodos_Click" />
        </ItemTemplate>
    </asp:DataList>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SelectListaVistoTodos" TypeName="ProjetoGrupo6.DAL.DALRelacaoVisto">
        <SelectParameters>
            <asp:SessionParameter Name="perfil" SessionField="perfil" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
