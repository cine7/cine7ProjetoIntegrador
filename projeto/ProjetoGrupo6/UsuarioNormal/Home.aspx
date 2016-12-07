﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Cine7Normal.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ProjetoGrupo6.UsuarioNormal.Home1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-3">
                <asp:Image ID="ImagePerfil" runat="server" BorderStyle="None" Width="100px" />
            </div>
            <div class="col-md-9">
                <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1">
                    <ItemTemplate>
                        tipo:
                        <asp:Label ID="tipoLabel" runat="server" Text='<%# Eval("tipo") %>' />
                        <br />
                        filme_name:
                        <asp:Label ID="filme_nameLabel" runat="server" Text='<%# Eval("filme_name") %>' />
                        <br />
                        nome:
                        <asp:Label ID="nomeLabel" runat="server" Text='<%# Eval("nome") %>' />
                        <br />
<br />
                    </ItemTemplate>
                </asp:DataList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:2016TiiGrupo6ConnectionString %>" SelectCommand="SELECT tipo,
	               Filme.filme_name,
	               Usuario.nome
                    from Post

                    INNER JOIN Usuario on Usuario.usuario = Post.usuario
                    INNER JOIN Segue on Segue.usuarioSeguido = Usuario.usuario 
                    INNER JOIN Filme on Filme.filme_id = Post.filme_id

                    WHERE Segue.usuarioSeguidor = @perfil">
                    <SelectParameters>
                        <asp:SessionParameter Name="perfil" SessionField="perfil" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </div>
    </div>
</asp:Content>