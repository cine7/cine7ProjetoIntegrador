<%@ Page Title="" Language="C#" MasterPageFile="~/Cine7Normal.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ProjetoGrupo6.UsuarioNormal.Home1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-3">
                <asp:Image ID="ImagePerfil" runat="server" BorderStyle="None" Width="150px" Height="150px" />
            </div>
            <div class="col-md-9">
                <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1" OnLoad="DataList1_Load" OnPreRender="DataList1_PreRender">
                    <ItemTemplate>
                        <asp:Label ID="post_idLabel" runat="server" OnPreRender="post_idLabel_PreRender" Text='<%# Eval("post_id") %>'></asp:Label>
                        <asp:Label ID="descricaoLabel" runat="server" Text='<%# Eval("descricao") %>' />
                        <asp:LinkButton ID="LinkButtonFilme_nameFeed" runat="server" ForeColor="#333333" OnClick="LinkButtonFilme_nameFeed_Click" Text='<%# Eval("filme_name") %>'></asp:LinkButton>
                        <br />
                        <asp:Label ID="LabelPositivosFeed" runat="server" OnPreRender="LabelPostivosFeed_PreRender" Text="Label"></asp:Label>
                        &nbsp;<asp:ImageButton ID="ImageButtonPositivarFeed" runat="server" CommandName="post_id" ImageUrl="~/Imagens/positivar.jpg" OnClick="ImageButtonPositivarFeed_Click" OnPreRender="ImageButtonPositivarFeed_PreRender" Width="20px" />
                        &nbsp;<asp:Label ID="LabelNegativosFeed" runat="server" OnPreRender="LabelNegativosFeed_PreRender" Text="Label"></asp:Label>
                        &nbsp;<asp:ImageButton ID="ImageButtonNegativarFeed" runat="server" CommandName="podt_id" ImageUrl="~/Imagens/negativar.png" OnClick="ImageButtonNegativarFeed_Click" OnPreRender="ImageButtonNegativarFeed_PreRender" Width="20px" />
                        <br />
                        <asp:TextBox ID="TextBoxComentarioFeed" runat="server" Height="38px" TextMode="MultiLine" OnPreRender="TextBoxComentarioFeed_PreRender" OnTextChanged="TextBoxComentarioFeed_TextChanged"></asp:TextBox>
                        <br />
                        <asp:Button ID="ButtonComentarioPost" runat="server" OnClick="ButtonComentarioPost_Click" Text="Button" CommandName="post_id" OnPreRender="ButtonComentarioPost_PreRender" />
                        <asp:DataList ID="DataList2" runat="server" DataSourceID="ObjectDataSource2" OnLoad="DataList2_Load" OnPreRender="DataList2_PreRender">
                            <ItemTemplate>
                                <asp:Label ID="comentariopost_idLabel" runat="server" Text='<%# Eval("comentariopost_id") %>' />
                                <br />
                                <asp:Label ID="descricaoLabel" runat="server" Text='<%# Eval("descricao") %>' />
                                <br />
                                <asp:Label ID="dataLabel" runat="server" Text='<%# Eval("dataHora") %>' />
                                <br />
                                <asp:Label ID="post_idLabel" runat="server" Text='<%# Eval("post_id") %>' />
                                <br />
                                <asp:Label ID="usuarioComentarioLabel" runat="server" Text='<%# Eval("usuarioComentario") %>' />
                                <br />
                                <br />
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="SelectComentarioPost" TypeName="ProjetoGrupo6.DAL.DALComentarioPost">
                            <SelectParameters>
                                <asp:SessionParameter Name="post_id" SessionField="post_id" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </ItemTemplate>
                </asp:DataList>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SelectFeed" TypeName="ProjetoGrupo6.DAL.DALPost">
                    <SelectParameters>
                        <asp:SessionParameter Name="perfil" SessionField="perfil" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
    </div>
</asp:Content>
