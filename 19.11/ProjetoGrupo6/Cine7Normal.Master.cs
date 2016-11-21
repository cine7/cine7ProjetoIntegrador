using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoGrupo6
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            HyperLinkUsuario.Text = Session["usuario"].ToString();

        }

        protected void ImageButtonPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/UsuarioNormal/ResultadoPesquisa.aspx?Filme=" + TextBoxPesquisar.Text);
        }

        protected void ImageButtonSair_Click(object sender, ImageClickEventArgs e)
        {
            Session["usuario"] = null;
            Response.Redirect("~/UsuarioAnonimo/Home.aspx");
        }
    }
}