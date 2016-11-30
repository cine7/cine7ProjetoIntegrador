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
            Session["perfil"] = Session["usuario"];

            // Lendo a conexão de dados do Web.Config
            string aSQLConecStr = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;

            // Abrindo a Conexão com o banco de dados
            SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
            aSQLCon.Open();


            // Cria comando SQL
            SqlCommand cmd = aSQLCon.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "Select caminhoImagem FROM Usuario where usuario = @usuario";
            cmd.Parameters.AddWithValue("@usuario", Session["usuario"]);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read()) // Le o proximo registro
                {
                    caminhoImagem = dr["caminhoImagem"].ToString();
                }
            }

            //dr.Close();
            aSQLCon.Close();

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