using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoGrupo6.UsuarioAnonimo
{
    public partial class ResultadoPesquisa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Response.Redirect("~/UsuarioNormal/ResultadoPesquisa.aspx");
            }
            Session["filme_name"] = Request.QueryString["Filme"];
        }

        protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButtonFilme_namePesquisa_Click(object sender, EventArgs e)
        {
            String filme_name = (sender as LinkButton).Text;
            Session["filme_name"] = filme_name;
            Response.Redirect("~/UsuarioAnonimo/Filme.aspx?Filme=" + filme_name);            
        }
    }
}