<%@ Page Title="" Language="C#" MasterPageFile="~/Cine7Normal.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ProjetoGrupo6.UsuarioNormal.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
             <div class="col-md-6">
                 <br />
                 <div id="editarPerfil">
    <p>
        <b>Editar Perfil</b></p>
    <p>
        Nome:
        <br /><asp:TextBox ID="TextBoxNome" runat="server" Width="200px" Height="25px"></asp:TextBox>
&nbsp;
        <asp:Button ID="ButtonEditarNome" runat="server" Text="Editar" OnClick="ButtonEditarNome_Click" BackColor="#A30F1D" BorderStyle="None" ForeColor="White" Width="60px" Height="25px" />
    </p>
    <p>
        E-mail:
        <br /><asp:TextBox ID="TextBoxEmail" runat="server" Width="200px" Height="25px"></asp:TextBox>
&nbsp;<asp:Button ID="ButtonEditarEmail" runat="server" Text="Editar" OnClick="ButtonEditarEmail_Click" BackColor="#A30F1D" BorderStyle="None" ForeColor="White" Width="60px" Height="25px" />
    </p>
    <p>
        País:
        <br /><asp:TextBox ID="TextBoxPais" runat="server" Width="200px" Height="25px"></asp:TextBox>
&nbsp;<asp:Button ID="ButtonEditarPais" runat="server" Text="Editar" OnClick="ButtonEditarPais_Click" BackColor="#A30F1D" BorderStyle="None" ForeColor="White" Width="60px" Height="25px" />
    </p>
    <p>
        Sexo:
        <br /><asp:TextBox ID="TextBoxSexo" runat="server" Width="200px" Height="25px"></asp:TextBox>
&nbsp;<asp:Button ID="ButtonEditarSexo" runat="server" Text="Editar" OnClick="ButtonEditarSexo_Click" BackColor="#A30F1D" BorderStyle="None" ForeColor="White" Width="60px" Height="25px" />
    </p>
    <p>
        Foto de Perfil
        <br /><asp:Image ID="ImagePerfil" runat="server" />
        <asp:FileUpload ID="FileUploadEditarImagemPerfil" runat="server" Width="200px" Height="25px" /> 
        <asp:Button ID="ButtonEditarCaminhoImagem" runat="server" Text="Editar" OnClick="ButtonEditarCaminhoImagem_Click" BackColor="#A30F1D" BorderStyle="None" ForeColor="White" Width="60px" Height="25px" />
    </p>
                     </div>
                 </div>
            </div>
        </div>
</asp:Content>

