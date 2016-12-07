using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoGrupo6.UsuarioNormal
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            DAL.DALUsuario DALUsuario = new DAL.DALUsuario();
            Modelo.Usuario usuario = DALUsuario.SelectUsuario(Session["usuario"].ToString());

            /*TextBoxNome.Text = usuario.nome;
            TextBoxEmail.Text = usuario.email;
            TextBoxPais.Text = usuario.pais;
            TextBoxSexo.Text = usuario.sexo;
            ImagePerfil.ImageUrl = usuario.caminhoImagem;*/

        }

        protected void ButtonEditarNome_Click(object sender, EventArgs e)
        {
            DAL.DALUsuario DALUsuario = new DAL.DALUsuario();
            DALUsuario.UpdateNome(TextBoxNome.Text, Session["usuario"].ToString());
            Response.Redirect("~/UsuarioNormal/EditarPerfil.aspx");
        }

        protected void ButtonEditarEmail_Click(object sender, EventArgs e)
        {
            DAL.DALUsuario DALUsuario = new DAL.DALUsuario();
            DALUsuario.UpdateEmail(TextBoxEmail.Text, Session["usuario"].ToString());
            Response.Redirect("~/UsuarioNormal/EditarPerfil.aspx");
        }

        protected void ButtonEditarPais_Click(object sender, EventArgs e)
        {
            DAL.DALUsuario DALUsuario = new DAL.DALUsuario();
            DALUsuario.UpdatePais(TextBoxPais.Text, Session["usuario"].ToString());
            Response.Redirect("~/UsuarioNormal/EditarPerfil.aspx");
        }

        protected void ButtonEditarSexo_Click(object sender, EventArgs e)
        {
            DAL.DALUsuario DALUsuario = new DAL.DALUsuario();
            DALUsuario.UpdateSexo(TextBoxSexo.Text, Session["usuario"].ToString());
            Response.Redirect("~/UsuarioNormal/EditarPerfil.aspx");
        }

        protected void ButtonEditarCaminhoImagem_Click(object sender, EventArgs e)
        {
            DAL.DALUsuario DALUsuario = new DAL.DALUsuario();
            DALUsuario.UpdateCaminhoImagem(FileUploadEditarImagemPerfil.FileName, Session["usuario"].ToString());
            Response.Redirect("~/UsuarioNormal/EditarPerfil.aspx");
        }
    }
}