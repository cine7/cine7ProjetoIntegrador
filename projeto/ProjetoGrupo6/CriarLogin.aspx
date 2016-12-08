<%@ Page Language="C#" MasterPageFile="~/Cine7Anonimo.Master" AutoEventWireup="true" CodeBehind="CriarLogin.aspx.cs" Inherits="ProjetoGrupo6.CriarLogin.CriarLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="clearfix" style="position: relative; left: 540px; width:403px; top: 0px;"><br /><p id="cadastro"><b>Cadastro</b></p><br />
      <asp:Label ID="Label2" runat="server" Text="Usuário"></asp:Label>
        :
        <br /><asp:TextBox ID="TextBoxUsuario" runat="server" Width="250px" Height="25px"></asp:TextBox><br />
        <br />
        Senha:
        <br /><asp:TextBox ID="TextBoxSenha" runat="server" TextMode="Password" Width="250px" Height="25px"></asp:TextBox>
        <br /><br />
        <asp:Label ID="Label4" runat="server" Text="Confirmar Senha"></asp:Label>
        :
        <br /><asp:TextBox ID="TextBoxConfirmarSenha" runat="server" TextMode="Password" OnTextChanged="TextBox3_TextChanged" Width="250px" Height="25px"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="TextBoxSenha" ControlToValidate="TextBoxConfirmarSenha" ErrorMessage="Senhas não correspondem"></asp:CompareValidator>
        <br />
        Nome:
        <br /><asp:TextBox ID="TextBoxNome" runat="server" Width="250px" Height="25px"></asp:TextBox>
        <br /><br />
        E-mail:
        <br /><asp:TextBox ID="TextBoxEmail" runat="server" TextMode="Email" Width="250px" Height="25px"></asp:TextBox>
        <br /><br />
        País:
        <br /><asp:TextBox ID="TextBoxPais" runat="server" Width="250px" Height="25px"></asp:TextBox>
        <br /><br />
        Sexo:
        <br /><asp:TextBox ID="TextBoxSexo" runat="server" Width="250px" Height="25px"></asp:TextBox>
        <asp:FileUpload ID="FileUploadImagem" runat="server" />
        <br />
        <asp:TextBox ID="TextBoxCodigoAdministrador" runat="server"></asp:TextBox>
        <br /><br />
&nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="Cadastrar" BackColor="#A30F1D" BorderStyle="None" ForeColor="White" Height="30px" Width="110px" />
   </div>
    </asp:Content>
