<%@ Page Language="C#" MasterPageFile="~/Cine7Anonimo.Master" AutoEventWireup="true" CodeBehind="ResultadoPesquisa.aspx.cs" Inherits="ProjetoGrupo6.UsuarioAnonimo.ResultadoPesquisa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowSorting="True" Width="80px" OnRowCommand="GridView1_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="filme_name" HeaderText="filme_name" SortExpression="filme_name" />
                <asp:ButtonField CommandName="Acessar" Text="Acessar" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:2016TiiGrupo6ConnectionString %>" SelectCommand="select filme_name from Filme
where filme_name like '%' + @filme_name + '%'">
            <SelectParameters>
                <asp:SessionParameter Name="filme_name" SessionField="filme_name" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/UsuarioAnonimo/Home.aspx">Voltar</asp:HyperLink>
</asp:Content>
