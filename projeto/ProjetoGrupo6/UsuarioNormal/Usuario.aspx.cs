using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoGrupo6.UsuarioNormal
{
    public partial class Usuario : System.Web.UI.Page
    {
        string usuario, post_id;
        bool validarSegue;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            DAL.DALaspnet_UsersInRoles DALaspnet_UsersInRoles = new DAL.DALaspnet_UsersInRoles();
            string roleUsuario = DALaspnet_UsersInRoles.SelectUserRole(Session["usuario"].ToString());
            if (roleUsuario == "e941bc42-522f-4cb3-9ce6-92b349af7b3a")
            //if (roleUsuario == "33b63735-44f1-4c8e-aa15-86586ffa3411")
            {
                LinkButtonCRUDFilme.Visible = true;
            }
            else LinkButtonCRUDFilme.Visible = false;
            LabelUsuario.Text = Request.QueryString["Usuario"];

            Session["perfil"] = LabelUsuario.Text;

            usuario = Session["usuario"].ToString();

            if (usuario == Request.QueryString["Usuario"])
            {
                LinkButtonSeguirEditar.Text = "Editar Perfil";
            }
            else
            {
                DAL.DALSegue DALSegue = new DAL.DALSegue();
                Modelo.Segue segue = new Modelo.Segue(LabelUsuario.Text, usuario);
                validarSegue = DALSegue.SelectValidar(segue);
                if (validarSegue == true)
                    LinkButtonSeguirEditar.Text = "Seguindo";
            }

            DAL.DALUsuario DALUsuario = new DAL.DALUsuario();
            Modelo.Usuario usuario1 = new Modelo.Usuario(Session["usuario"].ToString());
            string caminhoImagem = DALUsuario.SelectCaminhoImagem(usuario1);


            ImagePerfil.ImageUrl = caminhoImagem;
        }
            

        protected void LinkButtonSeguirEditar_Click(object sender, EventArgs e)
        {
            if (LinkButtonSeguirEditar.Text == "Editar Perfil")
            {
                Response.Redirect("~/UsuarioNormal/EditarPerfil.aspx");
            }
            else if (LinkButtonSeguirEditar.Text == "Seguir")
            {
                DAL.DALSegue DALSegue = new DAL.DALSegue();
                Modelo.Segue segue = new Modelo.Segue(Request.QueryString["Usuario"].ToString(), Session["usuario"].ToString());
                DALSegue.Insert(segue);

                LinkButtonSeguirEditar.Text = "Seguindo";
            }
            else if (LinkButtonSeguirEditar.Text == "Seguindo")
            {
                DAL.DALSegue DALSegue = new DAL.DALSegue();
                Modelo.Segue segue = new Modelo.Segue(Request.QueryString["Usuario"].ToString(), Session["usuario"].ToString());
                DALSegue.Delete(segue);

                LinkButtonSeguirEditar.Text = "Seguir";
            }
        }

        protected void ImageButtonFavorito_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void LinkButtonCRUDFilme_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UsuarioNormal/CRUDFilme.aspx");
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

        protected void LinkButtonUsuarioPost_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UsuarioNormal/Usuario.aspx?Usuario=" + Session["usuario"].ToString());
        }

        protected void LinkButtonUsuarioPost_PreRender(object sender, EventArgs e)
        {
            string usuarioSession = Session["usuario"].ToString();
            string usuario = (sender as LinkButton).Text;
            if (usuario == usuarioSession) (sender as LinkButton).Text = "Você";
        }

        protected void LinkButtonFilme_namePost_Click(object sender, EventArgs e)
        {
            Session["filme_name"] = (sender as LinkButton).Text;
            Response.Redirect("~/UsuarioNormal/Filme.aspx?Filme=" + (sender as LinkButton).Text);
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
            Response.Redirect("~/UsuarioNormal/ListaInteresses.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            DAL.DALAvaliacaoPost DALAvaliacaoPost = new DAL.DALAvaliacaoPost();
            bool validar = DALAvaliacaoPost.SelectValidarAvaliacaoPost(int.Parse((sender as ImageButton).CommandName), Session["usuario"].ToString());
            int avaliacao = DALAvaliacaoPost.SelectAvaliacaoPost(int.Parse((sender as ImageButton).CommandName), Session["usuario"].ToString());

            if (validar == true)
            {
                if (avaliacao == 1)
                {
                    DALAvaliacaoPost.Delete(int.Parse((sender as ImageButton).CommandName), Session["usuario"].ToString());
                }
                else
                {
                    DALAvaliacaoPost.Update(1, int.Parse((sender as ImageButton).CommandName), Session["usuario"].ToString());
                }
            }
            else DALAvaliacaoPost.Insert(1, int.Parse((sender as ImageButton).CommandName), Session["usuario"].ToString());
            Response.Redirect("~/UsuarioNormal/Usuario.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            DAL.DALAvaliacaoPost DALAvaliacaoPost = new DAL.DALAvaliacaoPost();
            bool validar = DALAvaliacaoPost.SelectValidarAvaliacaoPost(int.Parse((sender as ImageButton).CommandName), Session["usuario"].ToString());
            int avaliacao = DALAvaliacaoPost.SelectAvaliacaoPost(int.Parse((sender as ImageButton).CommandName), Session["usuario"].ToString());

            if (validar == true)
            {
                if (avaliacao == 0)
                {
                    DALAvaliacaoPost.Delete(int.Parse((sender as ImageButton).CommandName), Session["usuario"].ToString());
                }
                else
                {
                    DALAvaliacaoPost.Update(0, int.Parse((sender as ImageButton).CommandName), Session["usuario"].ToString());
                }
            }
            else DALAvaliacaoPost.Insert(0, int.Parse((sender as ImageButton).CommandName), Session["usuario"].ToString());
            Response.Redirect("~/UsuarioNormal/Usuario.aspx");
        }

        protected void Label2_PreRender(object sender, EventArgs e)
        {
            DAL.DALAvaliacaoPost DALAvaliacaoPost = new DAL.DALAvaliacaoPost();
            int x = DALAvaliacaoPost.SelectQuantidadeAvaliacao(1, int.Parse(post_id));
            (sender as Label).Text = x.ToString();
        }

        protected void Label1_PreRender(object sender, EventArgs e)
        {
            DAL.DALAvaliacaoPost DALAvaliacaoPost = new DAL.DALAvaliacaoPost();
            int x = DALAvaliacaoPost.SelectQuantidadeAvaliacao(0, int.Parse(post_id));
            (sender as Label).Text = x.ToString();
        }

        protected void Label3_PreRender(object sender, EventArgs e)
        {
            (sender as Label).Visible = true;
            post_id = (sender as Label).Text;
            (sender as Label).Visible = false;
        }

        protected void ImageButton1_PreRender(object sender, EventArgs e)
        {
            (sender as ImageButton).CommandName = post_id;
        }

        protected void ImageButton2_PreRender(object sender, EventArgs e)
        {
            (sender as ImageButton).CommandName = post_id;
        }
    }
}