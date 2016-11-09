using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoGrupo6.CriarLogin
{
    public partial class CriarLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string usuario = TextBoxUsuario.Text, senha = TextBoxSenha.Text, email = TextBoxEmail.Text;
            Membership.CreateUser(usuario, senha, email);
            Roles.AddUserToRole(usuario, "Normal");
            string aSQLConecStr;

            // Lendo a conexão de dados do Web.Config
            aSQLConecStr = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;

            // Abrindo a Conexão com o banco de dados
            SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
            aSQLCon.Open();

            // Executando o comando
            SqlCommand aSQL = new SqlCommand("INSERT INTO Usuario(usuario, senha, nome, email, dataNascimento, pais, sexo) VALUES(@usuario, @senha, @nome, @email, @dataNascimento, @pais, @sexo)", aSQLCon);
            aSQL.Parameters.AddWithValue("@usuario", usuario);
            aSQL.Parameters.AddWithValue("@senha", senha);
            aSQL.Parameters.AddWithValue("@nome", TextBoxNome.Text);
            aSQL.Parameters.AddWithValue("@email", email);
            aSQL.Parameters.AddWithValue("@dataNascimento", TextBoxDataNascimento.Text);
            aSQL.Parameters.AddWithValue("@pais", TextBoxPais.Text);
            aSQL.Parameters.AddWithValue("@sexo", TextBoxSexo.Text);
            aSQL.ExecuteNonQuery();
            Response.Redirect("~/Login.aspx");
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}