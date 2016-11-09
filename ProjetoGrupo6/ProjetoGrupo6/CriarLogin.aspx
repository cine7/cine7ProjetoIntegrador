<%@ Page Language="C#" MasterPageFile="~/Cine7Anonimo.Master" AutoEventWireup="true" CodeBehind="CriarLogin.aspx.cs" Inherits="ProjetoGrupo6.CriarLogin.CriarLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="clearfix" style="position: relative; left: 500px; width:403px; top: 0px;"><br /><p id="cadastro"><b>Cadastro</b></p><br />
      <asp:Label ID="Label2" runat="server" Text="Usuário"></asp:Label>
        :
        <asp:TextBox ID="TextBoxUsuario" runat="server" Width="198px" Height="20px"></asp:TextBox><br />
        <br />
        Senha:
        <asp:TextBox ID="TextBoxSenha" runat="server" TextMode="Password" Width="206px" Height="20px"></asp:TextBox>
        <br /><br />
        <asp:Label ID="Label4" runat="server" Text="Confirmar Senha"></asp:Label>
        :
        <asp:TextBox ID="TextBoxConfirmarSenha" runat="server" TextMode="Password" OnTextChanged="TextBox3_TextChanged" Width="121px" Height="20px"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="TextBoxSenha" ControlToValidate="TextBoxConfirmarSenha" ErrorMessage="Senhas não correspondem"></asp:CompareValidator>
        <br /><br />
        Nome:
        <asp:TextBox ID="TextBoxNome" runat="server" Width="210px" Height="20px"></asp:TextBox>
        <br /><br />
        E-mail:
        <asp:TextBox ID="TextBoxEmail" runat="server" TextMode="Email" Width="212px" Height="20px"></asp:TextBox>
        <br /><br />
        Data Nascimento:
        <asp:TextBox ID="TextBoxDataNascimento" runat="server" TextMode="Date" Width="120px" Height="20px"></asp:TextBox>
        <br /><br />
        País:
        <asp:TextBox ID="TextBoxPais" runat="server" Width="231px" Height="20px"></asp:TextBox>
        <br /><br />
        Sexo:
        <asp:TextBox ID="TextBoxSexo" runat="server" Width="224px" Height="20px"></asp:TextBox>
        <br /><br />
&nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="Cadastrar" BackColor="#A30F1D" BorderStyle="None" ForeColor="White" Height="25px" Width="100px" />
   </div> </asp:Content>
