using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoGrupo6.UsuarioAnonimo
{
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Response.Redirect("~/UsuarioNormal/Usuario.aspx");
            }
            LabelUsuario.Text = Request.QueryString["Usuario"];

            Session["perfil"] = Request.QueryString["Usuario"];


            DAL.DALUsuario DALUsuario = new DAL.DALUsuario();
            Modelo.Usuario usuario1 = new Modelo.Usuario(LabelUsuario.Text);
            string caminhoImagem = DALUsuario.SelectCaminhoImagem(usuario1);

            ImagePerfil.ImageUrl = caminhoImagem;

        }

        protected void AnonimoClick_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Para ter acesso a essa funcionalidade, você precisa estar cadastrado');</script>");
        }

        protected void ImageButtonFilmeFavoritoTop_Click(object sender, ImageClickEventArgs e)
        {
            DAL.DALFilme DALFilme = new DAL.DALFilme();
            string filme_name = DALFilme.SelectFilmeNamePorImagem((sender as ImageButton).ImageUrl);
            Session["filme_name"] = filme_name;
            Response.Redirect("~/UsuarioNormal/Filme.aspx?Filme=" + filme_name);
        }

        protected void ImageButtonFilmeVistoTop_Click(object sender, ImageClickEventArgs e)
        {
            DAL.DALFilme DALFilme = new DAL.DALFilme();
            string filme_name = DALFilme.SelectFilmeNamePorImagem((sender as ImageButton).ImageUrl);
            Session["filme_name"] = filme_name;
            Response.Redirect("~/UsuarioNormal/Filme.aspx?Filme=" + filme_name);
        }

        protected void ImageButtonFilmeInteresseTop_Click(object sender, ImageClickEventArgs e)
        {
            DAL.DALFilme DALFilme = new DAL.DALFilme();
            string filme_name = DALFilme.SelectFilmeNamePorImagem((sender as ImageButton).ImageUrl);
            Session["filme_name"] = filme_name;
            Response.Redirect("~/UsuarioNormal/Filme.aspx?Filme=" + filme_name);
        }

        protected void LinkButtonVerMaisFavoritos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UsuarioNormal/ListaFavoritos.aspx");
        }

        protected void LinkButtonVerMaisVistos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UsuarioNormal/ListaVistos.aspx");
        }

        protected void LinkButtonVerMaisInteresses_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UsuarioAnonimo/ListaInteresses.aspx");
        }

        protected void LinkButtonUsuarioPost_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UsuarioNormal/Usuario.aspx?Usuario=" + Session["usuario"].ToString());
        }

        protected void LinkButtonFilme_namePost_Click(object sender, EventArgs e)
        {
            Session["filme_name"] = (sender as LinkButton).Text;
            Response.Redirect("~/UsuarioNormal/Filme.aspx?Filme=" + (sender as LinkButton).Text);
        }
    }
}