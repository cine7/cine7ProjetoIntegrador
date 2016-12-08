<%@ Page Title="" Language="C#" MasterPageFile="~/Cine7Normal.Master" AutoEventWireup="true" CodeBehind="CRUDFilme.aspx.cs" Inherits="ProjetoGrupo6.UsuarioNormal.CRUDFilme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-4"></div>
        <div class="col-md-4">
            <asp:LinkButton ID="LinkButtonCreate" runat="server" ForeColor="Black" OnClick="LinkButtonCreate_Click">Inserir</asp:LinkButton>
        &nbsp;<asp:LinkButton ID="LinkButtonUpdate" runat="server" ForeColor="Black" OnClick="LinkButtonUpdate_Click">Atualizar</asp:LinkButton>
        &nbsp;<asp:LinkButton ID="LinkButtonDelete" runat="server" ForeColor="Black">Deletar</asp:LinkButton>
        </div>
        <div class="col-md-4"></div>
    </div>
    <div class="row">
        <div class="col-md-3"></div>
        <div class="col-md-6">
            <div id="formInserir" runat="server">
                Nome<br />
                <asp:TextBox ID="TextBoxFilme_name" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox> <br>
                Ano 
                <br />
                <asp:TextBox ID="TextBoxAno" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox><br>
                Sinopse<br />
                <asp:TextBox ID="TextBoxSinopse" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox><br>
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
                <br>
            </div>
            <div id="formAtualizar" runat="server">
                <asp:TextBox ID="TextBoxFilme_nameDelete" runat="server" Height="23px" Width="144px"></asp:TextBox>
                &nbsp;<asp:ImageButton ID="ImageButtonLupaCRUDDelete" runat="server" ImageUrl="~/Imagens/lupaPesquisar.png" OnClick="ImageButtonLupaCRUDDelete_Click" Width="17px" />
                <br>
                <br>
                Id do filme<br>
                <asp:TextBox ID="TextBoxFilme_idDelete" runat="server"></asp:TextBox>
                <br>
                <asp:Button ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" Text="Deletar" />
                <br>
            </div>
            <div id="formDeletar" runat="server">
            </div>
        </div>
        <div class="col-md-3"></div>
    </div>
</asp:Content>
