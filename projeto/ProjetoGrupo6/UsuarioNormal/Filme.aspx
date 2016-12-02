<%@ Page Language="C#" MasterPageFile="~/Cine7Normal.Master" AutoEventWireup="true" CodeBehind="Filme.aspx.cs" Inherits="ProjetoGrupo6.UsuarioNormal.Filme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #estrela {
            width: 317px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-3">
                <asp:Image ID="Image1" runat="server" />
                <asp:ImageButton ID="ImageButtonFavorito" runat="server" Height="45px" ImageUrl="~/Imagens/favoritarButton.png" OnClick="ImageButton1_Click" Width="45px" />
                <asp:ImageButton ID="ImageButtonVisto" runat="server" Height="45px" ImageUrl="~/Imagens/vistoButton.png" OnClick="ImageButtonVisto_Click" />
                <asp:ImageButton ID="ImageButtonInteresse" runat="server" Height="45px" ImageUrl="~/Imagens/tvInteresseButton.png" OnClick="ImageButtonInteresse_Click" Width="45px" />
            </div>
            <div class="col-md-6">
                <div id="sobreFilme">
                <b><asp:Label ID="LabelFilme" runat="server" Text="Label"></asp:Label></b>
                <asp:Label ID="LabelFilme_id" runat="server" Text="Label" Visible="False"></asp:Label>
       
                <br />
                <br />
                Ano:&nbsp<asp:Label ID="LabelAno" runat="server" Text="Label"></asp:Label>
                <br />
                <br />
                Sinopse:&nbsp<asp:Label ID="LabelSinopse" runat="server" Text="Label"></asp:Label>
                <br />
                <br />
                Diretor:&nbsp<asp:Label ID="LabelDiretor" runat="server" Text="Label"></asp:Label>
                <br />
                <br />
                Produtora:&nbsp<asp:Label ID="LabelProdutora" runat="server" Text="Label"></asp:Label>
                <br />
                <br />
                Duração:&nbsp<asp:Label ID="LabelDuracao" runat="server" Text="Label"></asp:Label>
                <div id="estrela" style="position: relative; top: 34px; left: 357px; width: 325px;">
            <asp:ImageButton ID="ImageButtonEstrela1" runat="server" ImageUrl="~/Imagens/estrelaApagada.png" onmouseover="acenderImagem()" Width="45px" OnClick="ImageButtonEstrela1_Click" />
                <asp:ImageButton ID="ImageButtonEstrela2" runat="server" ImageUrl="~/Imagens/estrelaApagada.png" Width="45px" OnClick="ImageButtonEstrela2_Click" />
                <asp:ImageButton ID="ImageButtonEstrela3" runat="server" ImageUrl="~/Imagens/estrelaApagada.png" Width="45px" OnClick="ImageButtonEstrela3_Click" />
                <asp:ImageButton ID="ImageButtonEstrela4" runat="server" ImageUrl="~/Imagens/estrelaApagada.png" Width="45px" OnClick="ImageButtonEstrela4_Click" />
                <asp:ImageButton ID="ImageButtonEstrela5" runat="server" ImageUrl="~/Imagens/estrelaApagada.png" Width="45px" OnClick="ImageButtonEstrela5_Click" />
                <asp:ImageButton ID="ImageButtonEstrela6" runat="server" ImageUrl="~/Imagens/estrelaApagada.png" Width="45px" OnClick="ImageButtonEstrela6_Click" />
                <asp:ImageButton ID="ImageButtonEstrela7" runat="server" ImageUrl="~/Imagens/estrelaApagada.png" Width="45px" OnClick="ImageButtonEstrela7_Click" />
                </div>
                <br />
                <br />
                </div>
            </div>
            <div class="col-md-3">
            </div>
        </div>
    
        <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1" RepeatColumns="1" RepeatLayout="Flow" OnSelectedIndexChanged="DataList1_SelectedIndexChanged">
            <ItemTemplate>
                <asp:Label ID="comentario_idLabel" runat="server" OnPreRender="comentario_idLabel_PreRender" Text='<%# Eval("comentario_id") %>' />
                <asp:LinkButton ID="LinkButtonUsuario" runat="server" ForeColor="Black" OnClick="LinkButtonUsuario_Click" OnPreRender="LinkButtonUsuario_PreRender1" Text='<%# Eval("usuario") %>'></asp:LinkButton>
                <br />
                <asp:Label ID="descricaoLabel" runat="server" Text='<%# Eval("descricao") %>' />
                <asp:LinkButton ID="LinkButtonApagar" runat="server" CommandName="comentario_id" ForeColor="#CC0000" OnClick="LinkButtonApagar_Click1" OnPreRender="LinkButtonApagar_PreRender1">X</asp:LinkButton>
                <br />
                <asp:Label ID="dataLabel" runat="server" Text='<%# Eval("data") %>' />
                <br />
                <asp:ImageButton ID="ImageButtonPositivar" runat="server" CommandName="comentario_id" ImageUrl="~/Imagens/positivar.jpg" OnClick="ImageButtonPositivar_Click" OnPreRender="ImageButtonPositivar_PreRender" Width="20px" />
                &nbsp;
                <asp:ImageButton ID="ImageButtonNegativar" runat="server" CommandName="comentario_id" ImageUrl="~/Imagens/negativar.png" OnClick="ImageButtonNegativar_Click" OnPreRender="ImageButtonNegativar_PreRender" Width="20px" />
                <br />
            </ItemTemplate>   
        </asp:DataList>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SelectComentario" TypeName="ProjetoGrupo6.DAL.DALComentario">
            <SelectParameters>
                <asp:SessionParameter Name="filme_id" SessionField="filme_id" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
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
        
    </div>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Voltar</asp:LinkButton>
</asp:Content>
