using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ProjetoGrupo6.UsuarioAnonimo
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButtonFilmeHome_Click(object sender, ImageClickEventArgs e)
        {
            DAL.DALFilme DALFilme = new DAL.DALFilme();
            string filme_name = DALFilme.SelectFilmeNamePorImagem((sender as ImageButton).ImageUrl);
            Session["filme_name"] = filme_name;
            Response.Redirect("~/UsuarioAnonimo/Filme.aspx?Filme=" + filme_name);
        }

        protected void LinkButtonFilme_nameHome_Click(object sender, EventArgs e)
        {
            String filme_name = (sender as LinkButton).Text;
            Session["filme_name"] = filme_name;
            Response.Redirect("~/UsuarioAnonimo/Filme.aspx?Filme=" + filme_name);   
        }
    }
}