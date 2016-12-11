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
    public partial class Home1 : System.Web.UI.Page
    {
        string caminhoImagem, post_id, comentarioFeed;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            Session["perfil"] = Session["usuario"];

            DAL.DALUsuario DALUsuario = new DAL.DALUsuario();
            Modelo.Usuario usuario = new Modelo.Usuario(Session["usuario"].ToString());
            caminhoImagem = DALUsuario.SelectCaminhoImagem(usuario);


            ImagePerfil.ImageUrl = caminhoImagem;
        }

        protected void LinkButtonUsuarioFeed_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UsuarioNormal/Usuario.aspx?Usuario=" + (sender as LinkButton).Text);
        }

        protected void LinkButtonFilme_nameFeed_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UsuarioNormal/Filme.aspx?Filme=" + (sender as LinkButton).Text);
        }

        protected void post_idLabel_PreRender(object sender, EventArgs e)
        {
            (sender as Label).Visible = true;
            post_id = (sender as Label).Text;
            (sender as Label).Visible = false;
        }

        protected void ImageButtonPositivarFeed_PreRender(object sender, EventArgs e)
        {
            (sender as ImageButton).CommandName = post_id;
        }

        protected void ImageButtonNegativarFeed_PreRender(object sender, EventArgs e)
        {
            (sender as ImageButton).CommandName = post_id;
        }

        protected void ImageButtonPositivarFeed_Click(object sender, ImageClickEventArgs e)
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
            Response.Redirect("~/UsuarioNormal/Home.aspx");
        }

        protected void ImageButtonNegativarFeed_Click(object sender, ImageClickEventArgs e)
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
            Response.Redirect("~/UsuarioNormal/Home.aspx");
        }

        protected void LabelPostivosFeed_PreRender(object sender, EventArgs e)
        {
            DAL.DALAvaliacaoPost DALAvaliacaoPost = new DAL.DALAvaliacaoPost();
            int x = DALAvaliacaoPost.SelectQuantidadeAvaliacao(1, int.Parse(post_id));
            (sender as Label).Text = x.ToString();
        }

        protected void LabelNegativosFeed_PreRender(object sender, EventArgs e)
        {
            DAL.DALAvaliacaoPost DALAvaliacaoPost = new DAL.DALAvaliacaoPost();
            int x = DALAvaliacaoPost.SelectQuantidadeAvaliacao(0, int.Parse(post_id));
            (sender as Label).Text = x.ToString();

        }

        protected void ButtonComentarioPost_Click(object sender, EventArgs e)
        {
            DAL.DALComentarioPost DALComentarioPost = new DAL.DALComentarioPost();
            string usuarioComentarioFeed = Session["usuario"].ToString();
            Modelo.ComentarioPost comentariopost = new Modelo.ComentarioPost(comentarioFeed, int.Parse((sender as Button).CommandName), usuarioComentarioFeed);
            DALComentarioPost.Insert(comentariopost);

            Response.Redirect("~/UsuarioNormal/Home.aspx");
        }

        protected void TextBoxComentarioFeed_PreRender(object sender, EventArgs e)
        {
        }

        protected void ButtonComentarioPost_PreRender(object sender, EventArgs e)
        {
            (sender as Button).CommandName = post_id;
        }

        protected void TextBoxComentarioFeed_TextChanged(object sender, EventArgs e)
        {
            comentarioFeed = (sender as TextBox).Text;
        }

        protected void DataList1_Load(object sender, EventArgs e)
        {
            Session["post_id"] = post_id;
        }
    }
}