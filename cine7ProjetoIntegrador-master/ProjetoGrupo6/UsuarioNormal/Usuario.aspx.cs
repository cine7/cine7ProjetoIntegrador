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
        string usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelUsuario.Text = Request.QueryString["Usuario"];

            Session["perfil"] = Request.QueryString["Usuario"];

            usuario = Session["usuario"].ToString();

            if (usuario == Request.QueryString["Usuario"])
            {
                LinkButtonSeguirEditar.Text = "Editar Perfil";
            }

            string aSQLConecStr;

            // Lendo a conexão de dados do Web.Config
            aSQLConecStr = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;

            // Abrindo a Conexão com o banco de dados
            SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
            aSQLCon.Open();

            // Cria comando SQL
            SqlCommand cmd4 = aSQLCon.CreateCommand();
            // define SQL do comando
            cmd4.CommandText = "Select usuarioSeguido FROM Segue where usuarioSeguidor = @usuarioSeguidor and usuarioSeguido = @usuarioSeguido";
            cmd4.Parameters.AddWithValue("@usuarioSeguido", Request.QueryString["usuario"].ToString());
            cmd4.Parameters.AddWithValue("@usuarioSeguidor", usuario);

            SqlDataReader dr4 = cmd4.ExecuteReader();
            if (dr4.HasRows)
            {
                while (dr4.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    if (dr4["usuarioSeguido"] != null)
                    {
                        LinkButtonSeguirEditar.Text = "Seguindo";
                    }
                }
            }

            dr4.Close();
        }
            

        protected void LinkButtonSeguirEditar_Click(object sender, EventArgs e)
        {
            if (LinkButtonSeguirEditar.Text == "Editar Perfil")
            {

            }
            else if (LinkButtonSeguirEditar.Text == "Seguir")
            {
                string aSQLConecStr;

                // Lendo a conexão de dados do Web.Config
                aSQLConecStr = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;

                // Abrindo a Conexão com o banco de dados
                SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
                aSQLCon.Open();

                // Executando o comando
                SqlCommand aSQL = new SqlCommand("INSERT INTO Segue(usuarioSeguido, usuarioSeguidor) VALUES(@usuarioSeguido, @usuarioSeguidor)", aSQLCon);
                aSQL.Parameters.AddWithValue("@usuarioSeguido", Request.QueryString["Usuario"].ToString());
                aSQL.Parameters.AddWithValue("@usuarioSeguidor", usuario);
                aSQL.ExecuteNonQuery();
                aSQLCon.Close();

                LinkButtonSeguirEditar.Text = "Seguindo";
            }
            else if (LinkButtonSeguirEditar.Text == "Seguindo")
            {
                string aSQLConecStr;

                // Lendo a conexão de dados do Web.Config
                aSQLConecStr = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;

                // Abrindo a Conexão com o banco de dados
                SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
                aSQLCon.Open();

                // Executando o comando
                SqlCommand aSQL = new SqlCommand("DELETE FROM Segue where usuarioSeguido = @usuarioSeguido and usuarioSeguidor = @usuarioSeguidor", aSQLCon);
                aSQL.Parameters.AddWithValue("@usuarioSeguido", Request.QueryString["Usuario"].ToString());
                aSQL.Parameters.AddWithValue("@usuarioSeguidor", usuario);
                aSQL.ExecuteNonQuery();
                aSQLCon.Close();

                LinkButtonSeguirEditar.Text = "Seguir";
            }
        }
    }
}