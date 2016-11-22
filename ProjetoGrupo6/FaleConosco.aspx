<%@ Page Title="" Language="C#" MasterPageFile="~/Cine7Anonimo.Master" AutoEventWireup="true" CodeBehind="FaleConosco.aspx.cs" Inherits="ProjetoGrupo6.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="clearfix" style="position: relative; left: 540px; width:403px; top: 0px;"><br /><p id="cadastro"><b>Fale Conosco</b></p><br />
        Nome:
        <br />
        <asp:TextBox ID="TextBoxNome" runat="server" Width="250px" Height="25px"></asp:TextBox>
        <br /><br />
        E-mail:
        <br />
        <asp:TextBox ID="TextBoxEmail" runat="server" TextMode="Email" Width="250px" Height="25px"></asp:TextBox>
        <br /><br />
        Mensagem:
         <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="100px" Width="250px" TextMode="MultiLine"></asp:TextBox>
         
        <br /><br />
        <asp:Button ID="Button1" runat="server" Text="Enviar" BackColor="#A30F1D" BorderStyle="None" ForeColor="White" Height="30px" Width="100px"/>
        <br />
&nbsp;
   </div>
    </asp:Content>
