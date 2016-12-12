<%@ Page Language="C#" MasterPageFile="~/Cine7Anonimo.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ProjetoGrupo6.UsuarioAnonimo.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class ="row">
        <div id ="homeAnonimo">
                TOP 10 CINE7<asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1" RepeatColumns="5">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButtonFilmeHome" runat="server" Height="300px" ImageUrl='<%# Eval("caminhoImagem") %>' OnClick="ImageButtonFilmeHome_Click" Width="200px" />
                        <br />
                        <asp:LinkButton ID="LinkButtonFilme_nameHome" runat="server" ForeColor="#333333" OnClick="LinkButtonFilme_nameHome_Click" Text='<%# Eval("filme_name") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:DataList>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SelectFilmeHome" TypeName="ProjetoGrupo6.DAL.DALFilme">
                </asp:ObjectDataSource>
                <br />
             </div>
            </div> 
       </div> 
    </div>
</asp:Content>
