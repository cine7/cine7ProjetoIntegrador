﻿<%@ Page Language="C#" MasterPageFile="~/Cine7Anonimo.Master" AutoEventWireup="true" CodeBehind="CriarLogin.aspx.cs" Inherits="ProjetoGrupo6.CriarLogin.CriarLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-6">
    <div id="criarLogin"><br /><p id="cadastro"><b>Cadastro</b></p><br />
      <asp:Label ID="Label2" runat="server" Text="Usuário"></asp:Label>
        <br /><asp:TextBox ID="TextBoxUsuario" runat="server" Width="250px" Height="25px"></asp:TextBox><br />
        <br />
        Senha
        <br /><asp:TextBox ID="TextBoxSenha" runat="server" TextMode="Password" Width="250px" Height="25px"></asp:TextBox>
        <br /><br />
        <asp:Label ID="Label4" runat="server" Text="Confirmar Senha"></asp:Label>
        &nbsp;<br /><asp:TextBox ID="TextBoxConfirmarSenha" runat="server" TextMode="Password" OnTextChanged="TextBox3_TextChanged" Width="250px" Height="25px"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="TextBoxSenha" ControlToValidate="TextBoxConfirmarSenha" ErrorMessage="Senhas não correspondem"></asp:CompareValidator>
        <br />
        Nome
        <br /><asp:TextBox ID="TextBoxNome" runat="server" Width="250px" Height="25px"></asp:TextBox>
        <br /><br />
        E-mail
        <br /><asp:TextBox ID="TextBoxEmail" runat="server" TextMode="Email" Width="250px" Height="25px"></asp:TextBox>
        <br /><br />
        País
        <br /><asp:TextBox ID="TextBoxPais" runat="server" Width="250px" Height="25px"></asp:TextBox>
        <br /><br />
        Sexo <br>
        <asp:RadioButton ID="RadioButtonMasculino" runat="server" GroupName="Sexo" Text="Masculino" Font-Italic="False" ForeColor="Black" />
        <asp:RadioButton ID="RadioButtonFeminino" runat="server" GroupName="Sexo" Text="Feminino" Font-Bold="False" ForeColor="Black" /> <br><br>
        Imagem de perfil <br>
        <asp:FileUpload ID="FileUploadImagem" runat="server" />
        <br />
        Código administrador<br />
        <asp:TextBox ID="TextBoxCodigoAdministrador" runat="server"></asp:TextBox>
        <br /><br />
&nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="Cadastrar" BackColor="#A30F1D" BorderStyle="None" ForeColor="White" Height="30px" Width="110px" />
   </div>
                </div>
            </div>
        </div>
    </asp:Content>
