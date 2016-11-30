<%@ Page Language="C#" MasterPageFile="~/Cine7Normal.Master" AutoEventWireup="true" CodeBehind="ResultadoPesquisa.aspx.cs" Inherits="ProjetoGrupo6.UsuarioNormal.ResultadoPesquisa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1">
        <ItemTemplate>
            &nbsp;<asp:LinkButton ID="LinkButtonfilme_name" runat="server" ForeColor="Black" OnClick="LinkButtonfilme_name_Click1" Text='<%# Eval("filme_name") %>'></asp:LinkButton>
            &nbsp;(<asp:Label ID="anoLabel" runat="server" Text='<%# Eval("ano") %>' />
            )<br />
            sinopse:
            <asp:Label ID="sinopseLabel" runat="server" Text='<%# Eval("sinopse") %>' />
            <br />
            diretor:
            <asp:Label ID="diretorLabel" runat="server" Text='<%# Eval("diretor") %>' />
            <br />
            produtora:
            <asp:Label ID="produtoraLabel" runat="server" Text='<%# Eval("produtora") %>' />
            <br />
            duracao:
            <asp:Label ID="duracaoLabel" runat="server" Text='<%# Eval("duracao") %>' />
            <br />
<br />
        </ItemTemplate>
    </asp:DataList>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SelectAllFilme" TypeName="ProjetoGrupo6.DAL.DALFilme">
            <SelectParameters>
                <asp:SessionParameter Name="filme" SessionField="filme_name" Type="String" />
            </SelectParameters>
    </asp:ObjectDataSource>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/UsuarioNormal/Home.aspx">Voltar</asp:HyperLink>
</asp:Content>
