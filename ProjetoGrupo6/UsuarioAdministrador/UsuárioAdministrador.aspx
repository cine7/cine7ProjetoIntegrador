<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuárioAdministrador.aspx.cs" Inherits="ProjetoGrupo6.Administrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/CadastrarFilme.aspx">Cadastrar Filme</asp:HyperLink>
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="filme_id" DataSourceID="SqlDataSource1" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="filme_id" HeaderText="Código" InsertVisible="False" ReadOnly="True" SortExpression="filme_id" />
                <asp:BoundField DataField="filme_name" HeaderText="Nome do Filme" SortExpression="filme_name" />
                <asp:BoundField DataField="ano" HeaderText="Ano de Lançamento" SortExpression="ano" />
                <asp:BoundField DataField="sinopse" HeaderText="Sinopse" SortExpression="sinopse" />
                <asp:BoundField DataField="diretor" HeaderText="Diretor" SortExpression="diretor" />
                <asp:BoundField DataField="produtora" HeaderText="Produtora" SortExpression="produtora" />
                <asp:BoundField DataField="duracao" HeaderText="Duração" SortExpression="duracao" />
                <asp:ButtonField CommandName="Editar" Text="Editar" />
            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:2016TiiGrupo6ConnectionString %>" SelectCommand="SELECT * FROM [filme]"></asp:SqlDataSource>
    </form>
</body>
</html>
