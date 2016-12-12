<%@ Page Language="C#" MasterPageFile="~/Cine7Anonimo.Master" AutoEventWireup="true" CodeBehind="ResultadoPesquisa.aspx.cs" Inherits="ProjetoGrupo6.UsuarioAnonimo.ResultadoPesquisa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource2">
        <ItemTemplate>
            <asp:LinkButton ID="LinkButtonFilme_namePesquisa" runat="server" ForeColor="#333333" OnClick="LinkButtonFilme_namePesquisa_Click" Text='<%# Eval("filme_name") %>'></asp:LinkButton>
            (<asp:Label ID="anoLabel" runat="server" Text='<%# Eval("ano") %>' />
            )<br />
            <asp:Label ID="sinopseLabel" runat="server" Text='<%# Eval("sinopse") %>' />
            <br />
            <asp:Label ID="diretorLabel" runat="server" Text='<%# Eval("diretor") %>' />
            <br />
            <asp:Label ID="produtoraLabel" runat="server" Text='<%# Eval("produtora") %>' />
            <br />
            <asp:Label ID="duracaoLabel" runat="server" Text='<%# Eval("duracao") %>' />
            &nbsp;minutos<br />
            <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("caminhoImagem") %>' Height="150px" Width="100px" />
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
        </asp:Content>
