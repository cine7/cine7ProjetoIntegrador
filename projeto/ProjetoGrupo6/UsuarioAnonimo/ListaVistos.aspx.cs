using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoGrupo6.UsuarioAnonimo
{
    public partial class ListaVistos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["perfil"] = Request.QueryString["Usuario"];
        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ImageButtonAnonimoVistosTodos_Click(object sender, ImageClickEventArgs e)
        {
            DAL.DALFilme DALFilme = new DAL.DALFilme();
            string filme_name = DALFilme.SelectFilmeNamePorImagem((sender as ImageButton).ImageUrl);
            Session["filme_name"] = filme_name;
            Response.Redirect("~/UsuarioNormal/Filme.aspx?Filme=" + filme_name);
        }
    }
}