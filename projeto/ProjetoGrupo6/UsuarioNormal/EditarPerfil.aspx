<%@ Page Title="" Language="C#" MasterPageFile="~/Cine7Normal.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ProjetoGrupo6.UsuarioNormal.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-6">
                 <div id="editarPerfil">
                        <p>
                            <b>Editar Perfil</b></p>
                        <p>
                            Nome
                            <br /><asp:TextBox ID="TextBoxNome" runat="server" Width="200px" Height="25px"></asp:TextBox>
                    &nbsp;
                            </p>
                        <p>
                            E-mail
                            <br /><asp:TextBox ID="TextBoxEmail" runat="server" Width="200px" Height="25px" TextMode="Email"></asp:TextBox>
                    &nbsp;</p>
                        <p>
                            País
                            <br /><asp:TextBox ID="TextBoxPais" runat="server" Width="200px" Height="25px"></asp:TextBox>
                    &nbsp;</p>
                        <p>
                            Sexo<br>
                            <asp:RadioButton ID="RadioButtonEditarMasculino" runat="server" ForeColor="Black" GroupName="EditarSexo" Text="Masculino" />
                            <asp:RadioButton ID="RadioButtonEditarFeminino" runat="server" ForeColor="Black" GroupName="EditarSexo" Text="Feminino" />
                            <br />&nbsp;</p>
                        <p>
                            Foto de Perfil
                            <br /><asp:Image ID="ImagePerfil" runat="server" />
                            <asp:FileUpload ID="FileUploadEditarImagemPerfil" runat="server" Width="200px" Height="25px" /> 
                            <asp:Button ID="ButtonEditarInfosPerfil" runat="server" Text="Editar" OnClick="ButtonEditarInfosPerfil_Click" BackColor="#A30F1D" BorderStyle="None" ForeColor="White" Width="60px" Height="25px" />
                        </p>
                </div>
                <div id="editarSenha">
                    Senha atual<br>
                    <asp:TextBox ID="TextBoxSenhaAtual" runat="server" TextMode="Password"></asp:TextBox><br>
                    Nova senha<br>
                    <asp:TextBox ID="TextBoxNovaSenha" runat="server" TextMode="Password"></asp:TextBox><br>
                    Confirmar nova senha<br>
                    <asp:TextBox ID="TextBoxConfirmarNovaSenha" runat="server" TextMode="Password"></asp:TextBox><br><br>
                    <asp:Button ID="ButtonAlterarSenha" runat="server" Text="Alterar senha" />
                </div>
            </div>
            <div class="col-md-2"></div>
        </div>
    </div>
</asp:Content>

