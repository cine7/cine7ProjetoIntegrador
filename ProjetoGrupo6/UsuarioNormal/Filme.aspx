<%@ Page Language="C#" MasterPageFile="~/Cine7Normal.Master" AutoEventWireup="true" CodeBehind="Filme.aspx.cs" Inherits="ProjetoGrupo6.UsuarioNormal.Filme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="LabelFilme" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="LabelFilme_id" runat="server" Text="Label" Visible="False"></asp:Label>
        &nbsp;<asp:ImageButton ID="ImageButtonFavorito" runat="server" Height="46px" ImageUrl="~/Imagens/favoritarButton.png" OnClick="ImageButton1_Click" Width="69px" />
        <asp:ImageButton ID="ImageButtonVisto" runat="server" Height="43px" ImageUrl="~/Imagens/vistoButton.png" OnClick="ImageButtonVisto_Click" />
&nbsp;
    <asp:ImageButton ID="ImageButtonInteresse" runat="server" Height="45px" ImageUrl="~/Imagens/tvInteresseButton.png" OnClick="ImageButtonInteresse_Click" Width="48px" />
        <br />
        <br />
        <asp:Label ID="LabelAno" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:Label ID="LabelSinopse" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:Label ID="LabelDiretor" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:Label ID="LabelProdutora" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:Label ID="LabelDuracao" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:ImageButton ID="ImageButtonEstrela1" runat="server" ImageUrl="~/Imagens/estrelaApagada.jpg" onmouseover="acenderImagem()" Width="100px" OnClick="ImageButtonEstrela1_Click" />
        <asp:ImageButton ID="ImageButtonEstrela2" runat="server" ImageUrl="~/Imagens/estrelaApagada.jpg" Width="100px" OnClick="ImageButtonEstrela2_Click" />
        <asp:ImageButton ID="ImageButtonEstrela3" runat="server" ImageUrl="~/Imagens/estrelaApagada.jpg" Width="100px" OnClick="ImageButtonEstrela3_Click" />
        <asp:ImageButton ID="ImageButtonEstrela4" runat="server" ImageUrl="~/Imagens/estrelaApagada.jpg" Width="100px" OnClick="ImageButtonEstrela4_Click" />
        <asp:ImageButton ID="ImageButtonEstrela5" runat="server" ImageUrl="~/Imagens/estrelaApagada.jpg" Width="100px" OnClick="ImageButtonEstrela5_Click" />
        <asp:ImageButton ID="ImageButtonEstrela6" runat="server" ImageUrl="~/Imagens/estrelaApagada.jpg" Width="100px" OnClick="ImageButtonEstrela6_Click" />
        <asp:ImageButton ID="ImageButtonEstrela7" runat="server" ImageUrl="~/Imagens/estrelaApagada.jpg" Width="100px" OnClick="ImageButtonEstrela7_Click" />
        <br />
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" RepeatColumns="1" DataKeyField="comentario_id" RepeatLayout="Flow" OnSelectedIndexChanged="DataList1_SelectedIndexChanged">
            <ItemTemplate>
                <asp:Label ID="comentario_idLabel" runat="server" OnPreRender="comentario_idLabel_PreRender" Text='<%# Eval("comentario_id") %>' />
                <br />
                <asp:LinkButton ID="LinkButtonUsuario" runat="server" ForeColor="Black" OnClick="LinkButtonUsuario_Click" OnPreRender="LinkButtonUsuario_PreRender" Text='<%# Eval("usuario") %>'></asp:LinkButton>
                <br />
                <asp:Label ID="descricaoLabel" runat="server" Text='<%# Eval("descricao") %>' />
                <asp:LinkButton ID="LinkButtonApagar" runat="server" ForeColor="#CC0000" OnClick="LinkButtonApagar_Click1" OnCommand="LinkButtonApagar_Command" OnPreRender="LinkButtonApagar_PreRender1">X</asp:LinkButton>
                <br />
                <asp:Label ID="dataLabel" runat="server" Text='<%# Eval("data") %>' />
                <br />
                <br />
            </ItemTemplate>   
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:2016TiiGrupo6ConnectionString %>" SelectCommand="SELECT [comentario_id], [descricao], [usuario], [data] FROM [Comentario] where filme_id = @filme_id">
            <SelectParameters>
                <asp:SessionParameter Name="filme_id" SessionField="filme_id" />
            </SelectParameters>
    </asp:SqlDataSource>
         <asp:TextBox ID="TextBoxComentario" runat="server" Height="88px" TextMode="MultiLine" Width="201px"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Enviar" />
        <br />
    <br />
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Voltar</asp:LinkButton>
</asp:Content>
