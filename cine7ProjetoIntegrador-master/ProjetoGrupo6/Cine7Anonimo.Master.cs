using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoGrupo6
{
    public partial class Cine7 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Response.Redirect("~/UsuarioNormal/Home.aspx");
            }
        }

        protected void ImageButtonPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/UsuarioAnonimo/ResultadoPesquisa.aspx?Filme=" + TextBoxPesquisar.Text);
        }
    }
}