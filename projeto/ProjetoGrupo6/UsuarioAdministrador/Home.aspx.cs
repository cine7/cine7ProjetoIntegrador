using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoGrupo6.UsuarioAdministrador
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string caminhoImagem = "";
            Session["perfil"] = Session["usuario"];

            DAL.DALUsuario DALUsuario = new DAL.DALUsuario();
            Modelo.Usuario usuario = new Modelo.Usuario(Session["usuario"].ToString());
            caminhoImagem = DALUsuario.SelectCaminhoImagem(usuario);

            ImagePerfil.ImageUrl = caminhoImagem;
        }
    }
}