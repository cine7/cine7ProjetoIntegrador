using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoGrupo6
{
    public partial class Cine7Administrador : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            LinkButtonSessao.Text = Session["usuario"].ToString();

        }

        protected void ImageButtonPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/UsuarioAdministrador/ResultadoPesquisa.aspx?Filme=" + TextBoxPesquisar.Text);
        }

        protected void ImageButtonSair_Click(object sender, ImageClickEventArgs e)
        {
            Session["usuario"] = null;
            Response.Redirect("~/UsuarioAdministrador/Home.aspx");
        }

        protected void ImageButtonLogo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/UsuarioAdministrador/Home.aspx");
        }

        protected void LinkButtonSessao_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UsuarioAdministrador/Usuario.aspx?Usuario=" + LinkButtonSessao.Text);
        }

        protected void TextBoxPesquisar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}