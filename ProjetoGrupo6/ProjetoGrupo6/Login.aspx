<%@ Page Language="C#" MasterPageFile="~/Cine7Anonimo.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjetoGrupo6.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"><br />
    <div class="clearfix" style="position: relative; left: 500px; width:261px; top: 0px;">
    
        <asp:Login ID="Login1" runat="server" DestinationPageUrl="~//UsuarioNormal/Home.aspx" OnLoggedIn="Login1_LoggedIn" BorderStyle="None">
            <LayoutTemplate>
                <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                    <tr>
                        <td>
                            <table cellpadding="0">
                                <tr>
                                    <td align="center" colspan="2" style="font-size: 20px; font-style: normal; font-weight: bold;">Login</td>
                                </tr>
                                <caption>
                                    <br />
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuário:</asp:Label>
                                        </td>
                                        <td style="position: relative; bottom: -4px">
                                            <asp:TextBox ID="UserName" runat="server" Height="20px" Width="165px"></asp:TextBox><br />
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                       
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Senha:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Password" runat="server" Height="20px" TextMode="Password" Width="165px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <br /><asp:CheckBox ID="RememberMe" runat="server" Font-Size="14px" Text="Lembrar-me." />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="color:Red;">
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2">
                                            <asp:Button ID="LoginButton" runat="server" BackColor="#A30F1D" BorderStyle="None" CommandName="Login" ForeColor="White" Height="25px" Text="Login" ValidationGroup="Login1" Width="50px" CssClass="loginbutton" />
                                        </td>
                                    </tr>
                                </caption>
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:Login>
    
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/CriarLogin.aspx">Criar novo usuário</asp:HyperLink>
    
    </div>
</asp:Content>
