<%@ Page Language="C#" MasterPageFile="~/Cine7Normal.Master" AutoEventWireup="true" CodeBehind="ResultadoPesquisa.aspx.cs" Inherits="ProjetoGrupo6.UsuarioNormal.ResultadoPesquisa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource2">
        <ItemTemplate>
            <asp:Image ID="Image5" runat="server" ImageUrl='<%# Eval("caminhoImagem") %>' Width="16px" />
            <br />
            <asp:LinkButton ID="LinkButtonFilme_name" runat="server" ForeColor="Black" OnClick="LinkButtonfilme_name_Click1">LinkButton</asp:LinkButton>
            &nbsp;(<asp:Label ID="anoLabel" runat="server" Text='<%# Eval("ano") %>' />
            )<br />
            <asp:Label ID="sinopseLabel" runat="server" Text='<%# Eval("sinopse") %>' />
            <br />
<br />
        </ItemTemplate>
    </asp:DataList>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="SelectAllFilme" TypeName="ProjetoGrupo6.DAL.DALFilme">
            <SelectParameters>
                <asp:SessionParameter Name="filme" SessionField="filme_name" Type="String" />
            </SelectParameters>
    </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SelectAllFilme" TypeName="ProjetoGrupo6.DAL.DALFilme">
            <SelectParameters>
                <asp:SessionParameter Name="filme" SessionField="filme_name" Type="String" />
            </SelectParameters>
    </asp:ObjectDataSource>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/UsuarioNormal/Home.aspx">Voltar</asp:HyperLink>
</asp:Content>
