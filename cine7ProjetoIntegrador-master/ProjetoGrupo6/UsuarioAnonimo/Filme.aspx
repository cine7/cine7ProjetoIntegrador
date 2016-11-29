﻿<%@ Page Language="C#" MasterPageFile="~/Cine7Anonimo.Master" AutoEventWireup="true" CodeBehind="Filme.aspx.cs" Inherits="ProjetoGrupo6.UsuarioAnonimo.Filme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-3"></div>
            <div class="col-md-3"></div>
            <div class="col-md-4" style="position: relative; left: 500px; width:300px; top: 0px;">
        <asp:Label ID="LabelFilme" runat="server" Text="Label"></asp:Label>
            <b><asp:Label ID="LabelFilme_id" runat="server" Text="Label" Visible="False"></asp:Label></b>
            <br />
            <br />
            Ano:&nbsp<asp:Label ID="LabelAno" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            Sinopse:&nbsp<asp:Label ID="LabelSinopse" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            Diretor:&nbsp<asp:Label ID="LabelDiretor" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            Produtora:&nbsp<asp:Label ID="LabelProdutora" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            Duração:&nbsp<asp:Label ID="LabelDuracao" runat="server" Text="Label"></asp:Label>
            <br />
            </div>
        </div>
                    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" RepeatColumns="1">
                        <ItemTemplate>
                            <br />
                            <asp:Label ID="usuarioLabel" runat="server" Text='<%# Eval("usuario") %>' />
                            <br />
                            <asp:Label ID="descricaoLabel" runat="server" Text='<%# Eval("descricao") %>' />
                            <br />
                            <asp:Label ID="dataLabel" runat="server" Text='<%# Eval("data") %>' />
                            <br />
                        </ItemTemplate>
           
                  </asp:DataList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:2016TiiGrupo6ConnectionString %>" SelectCommand="SELECT [descricao], [usuario], [data] FROM [Comentario] WHERE filme_id = @filme_id">
                <SelectParameters>
                    <asp:SessionParameter Name="filme_id" SessionField="filme_id" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Voltar</asp:LinkButton>
    </div>
</asp:Content>
