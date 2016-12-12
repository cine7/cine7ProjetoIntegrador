using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoGrupo6.UsuarioNormal
{
    public partial class ListaInteresses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButtonListaInteressesTodos_Click(object sender, ImageClickEventArgs e)
        {
            DAL.DALFilme DALFilme = new DAL.DALFilme();
            string filme_name = DALFilme.SelectFilmeNamePorImagem((sender as ImageButton).ImageUrl);
            Session["filme_name"] = filme_name;
            Response.Redirect("~/UsuarioNormal/Filme.aspx?Filme=" + filme_name);
        }

        protected void LinkButtonListaInteressesTodos_Click(object sender, EventArgs e)
        {
            Session["filme_name"] = (sender as LinkButton).Text;
            Response.Redirect("~/UsuarioNormal/Filme.aspx?Filme=" + (sender as LinkButton).Text);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}