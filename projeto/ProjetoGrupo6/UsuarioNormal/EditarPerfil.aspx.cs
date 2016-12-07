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

            TextBoxNome.Text = usuario.nome;
            TextBoxEmail.Text = usuario.email;
            TextBoxPais.Text = usuario.pais;
            TextBoxSexo.Text = usuario.sexo;
            ImagePerfil.ImageUrl = usuario.caminhoImagem;


        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}