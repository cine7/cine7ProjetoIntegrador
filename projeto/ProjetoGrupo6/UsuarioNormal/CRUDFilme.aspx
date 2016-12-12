<%@ Page Title="" Language="C#" MasterPageFile="~/Cine7Normal.Master" AutoEventWireup="true" CodeBehind="CRUDFilme.aspx.cs" Inherits="ProjetoGrupo6.UsuarioNormal.CRUDFilme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-3"></div>
        <div class="col-md-6">
            <div id="formInserir" runat="server">
                Inserir<br>
                Nome<br />
                <asp:TextBox ID="TextBoxFilme_name" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox> <br>
                Ano 
                <br />
                <asp:TextBox ID="TextBoxAno" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox><br>
                Sinopse<br />
                <asp:TextBox ID="TextBoxSinopse" runat="server" OnTextChanged="TextBox2_TextChanged" TextMode="MultiLine"></asp:TextBox><br>
                Diretor<br />
                <asp:TextBox ID="TextBoxDiretor" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox><br>
                Produtora 
                <br />
                <asp:TextBox ID="TextBoxProdutora" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox><br>
                Duracao<br />
                <asp:TextBox ID="TextBoxDuracao" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                <br />
                <br />
                Cartaz<asp:FileUpload ID="FileUploadImagem" runat="server" />
                <br>
                <asp:Button ID="ButtonInserir" runat="server" Text="Inserir" OnClick="ButtonInserir_Click" />
                <br />
                <br>
            </div>
            <div id="formAtualizar" runat="server">
                Atualizar<br>
                <asp:TextBox ID="TextBoxFilme_nameUpdatePesquisa" runat="server"></asp:TextBox>
                &nbsp;<asp:ImageButton ID="ImageButtonLupaCRUDUpdate" runat="server" ImageUrl="~/Imagens/lupaPesquisar.png" OnClick="ImageButtonLupaCRUDUpdate_Click" Width="17px" />
                <asp:DataList ID="DataList2" runat="server" DataSourceID="ObjectDataSource2">
                    <ItemTemplate>
                        Id:
                        <asp:Label ID="filme_idLabel" runat="server" Text='<%# Eval("filme_id") %>' />
                        <br />
                        Nome:
                        <asp:Label ID="filme_nameLabel" runat="server" Text='<%# Eval("filme_name") %>' />
                        <br />
                        Ano:
                        <asp:Label ID="anoLabel" runat="server" Text='<%# Eval("ano") %>' />
                        <br />
                        Sinopse:
                        <asp:Label ID="sinopseLabel" runat="server" Text='<%# Eval("sinopse") %>' />
                        <br />
                        Direção:
                        <asp:Label ID="diretorLabel" runat="server" Text='<%# Eval("diretor") %>' />
                        <br />
                        Produtora:
                        <asp:Label ID="produtoraLabel" runat="server" Text='<%# Eval("produtora") %>' />
                        <br />
                        Duraçãoo:
                        <asp:Label ID="duracaoLabel" runat="server" Text='<%# Eval("duracao") %>' />
                        <br />
                        <asp:Image ID="ImageListaCRUDUpdate" runat="server" Height="150px" ImageUrl='<%# Eval("caminhoImagem") %>' Width="100px" />
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="SelectAllFilmeCRUD" TypeName="ProjetoGrupo6.DAL.DALFilme">
                    <SelectParameters>
                        <asp:SessionParameter Name="filme" SessionField="filme_nameUpdate" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource><br>
                Id do Filme a ser atualizado<br>
                <asp:TextBox ID="TextBoxFilmeIdUpdate" runat="server"></asp:TextBox><br>
                Nome<br>
                <asp:TextBox ID="TextBoxFilmeFilme_nameUpdate" runat="server"></asp:TextBox><br>
                Ano<br>
                <asp:TextBox ID="TextBoxFilmeAnoUpdate" runat="server"></asp:TextBox><br>
                Sinopse<br>
                <asp:TextBox ID="TextBoxFilmeSinopseUpdate" runat="server" TextMode="MultiLine"></asp:TextBox><br>
                Direção<br>
                <asp:TextBox ID="TextBoxFilmeDiretorUpdate" runat="server"></asp:TextBox><br>
                Produtora<br>
                <asp:TextBox ID="TextBoxFilmeProdutoraUpdate" runat="server"></asp:TextBox><br>
                Duração<br>
                <asp:TextBox ID="TextBoxFilmeDuracaoUpdate" runat="server"></asp:TextBox><br>
                Imagem<br>
                <asp:FileUpload ID="FileUploadImagemFilmeUpdate" runat="server" /><br>
                <asp:Button ID="ButtonFilmeUpdate" runat="server" Text="Atualizar" OnClick="ButtonFilmeUpdate_Click" />

                <br />

                <br>
            </div>
            <div id="formDeletar" runat="server">
                Deletar <br>
                <asp:TextBox ID="TextBoxFilme_nameDelete" runat="server" Height="23px" Width="144px"></asp:TextBox>
                &nbsp;<asp:ImageButton ID="ImageButtonLupaCRUDDelete" runat="server" ImageUrl="~/Imagens/lupaPesquisar.png" OnClick="ImageButtonLupaCRUDDelete_Click" Width="17px" />
                <br />
                <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1">
                    <ItemTemplate>
                        Id:
                        <asp:Label ID="filme_idLabel" runat="server" Text='<%# Eval("filme_id") %>' />
                        <br />
                        Nome:
                        <asp:Label ID="filme_nameLabel" runat="server" Text='<%# Eval("filme_name") %>' />
                        <br />
                        Ano:
                        <asp:Label ID="anoLabel" runat="server" Text='<%# Eval("ano") %>' />
                        <br />
                        Sinopse:
                        <asp:Label ID="sinopseLabel" runat="server" Text='<%# Eval("sinopse") %>' />
                        <br />
                        Direção:
                        <asp:Label ID="diretorLabel" runat="server" Text='<%# Eval("diretor") %>' />
                        <br />
                        Produtora:
                        <asp:Label ID="produtoraLabel" runat="server" Text='<%# Eval("produtora") %>' />
                        <br />
                        Duração:
                        <asp:Label ID="duracaoLabel" runat="server" Text='<%# Eval("duracao") %>' />
                        <br />
                        &nbsp;<asp:Image ID="ImageListaCRUDDelete" runat="server" Height="150px" ImageUrl='<%# Eval("caminhoImagem") %>' Width="100px" />
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SelectAllFilmeCRUD" TypeName="ProjetoGrupo6.DAL.DALFilme">
                    <SelectParameters>
                        <asp:SessionParameter Name="filme" SessionField="filme_nameDelete" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <br>
                Id do filme a ser excluído<br>
                <asp:TextBox ID="TextBoxFilme_idDelete" runat="server"></asp:TextBox>
                <br />
                <br>
                <asp:Button ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" Text="Deletar" />
                <br>
            </div>
        </div>
        <div class="col-md-3"></div>
    </div>
</asp:Content>
