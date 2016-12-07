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
        string caminhoImagem;
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

        protected void LinkButtonUsuarioPre(object sender, EventArgs e)
        {

        }

        protected void LinkButtonUsuario_PreRender(object sender, EventArgs e)
        {

        }
    }
}