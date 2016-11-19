<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarFilme.aspx.cs" Inherits="ProjetoGrupo6.EditarFilme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language=javascript>
        function ConfirmaExclusao() {
            return confirm('Deseja realmente excluir este registro?');
        }
</script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="filme_id" DataSourceID="SqlDataSource1" Height="50px" Width="227px" OnPageIndexChanging="DetailsView1_PageIndexChanging">
            <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <Fields>
                <asp:BoundField DataField="filme_id" HeaderText="filme_id" InsertVisible="False" ReadOnly="True" SortExpression="filme_id" />
                <asp:BoundField DataField="filme_name" HeaderText="filme_name" SortExpression="filme_name" />
                <asp:BoundField DataField="ano" HeaderText="ano" SortExpression="ano" />
                <asp:BoundField DataField="sinopse" HeaderText="sinopse" SortExpression="sinopse" />
                <asp:BoundField DataField="diretor" HeaderText="diretor" SortExpression="diretor" />
                <asp:BoundField DataField="produtora" HeaderText="produtora" SortExpression="produtora" />
                <asp:BoundField DataField="duracao" HeaderText="duracao" SortExpression="duracao" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
            </Fields>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        </asp:DetailsView>
    
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:2016TiiGrupo6ConnectionString %>" DeleteCommand="DELETE FROM Filme WHERE (filme_id = @filme_id)" InsertCommand="INSERT INTO Filme(filme_name, ano, sinopse, diretor, produtora, duracao) VALUES (@filme_name, @ano, @sinopse, @diretor, @produtora, @duracao)" SelectCommand="SELECT filme_id, filme_name, ano, sinopse, diretor, produtora, duracao FROM Filme WHERE (filme_id = @filme_id)" UpdateCommand="UPDATE Filme SET filme_name = @filme_name, ano = @ano, sinopse = @sinopse, diretor = @diretor, produtora = @produtora, duracao = @duracao WHERE (filme_id = @filme_id)">
            <DeleteParameters>
                <asp:Parameter Name="filme_id" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="filme_name" />
                <asp:Parameter Name="ano" />
                <asp:Parameter Name="sinopse" />
                <asp:Parameter Name="diretor" />
                <asp:Parameter Name="produtora" />
                <asp:Parameter Name="duracao" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name="filme_id" SessionField="filme_id" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="filme_name" />
                <asp:Parameter Name="ano" />
                <asp:Parameter Name="sinopse" />
                <asp:Parameter Name="diretor" />
                <asp:Parameter Name="produtora" />
                <asp:Parameter Name="duracao" />
                <asp:Parameter Name="filme_id" />
            </UpdateParameters>
        </asp:SqlDataSource>
        &nbsp;<br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/UsuarioAdministrador/UsuárioAdministrador.aspx">Voltar</asp:HyperLink>
    </form>
</body>
</html>
