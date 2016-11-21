using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoGrupo6
{
    public partial class CRUDUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string aSQLConecStr;

            if (!IsPostBack)
            {

                // Lendo a conexão de dados do Web.Config
                aSQLConecStr = ConfigurationManager.ConnectionStrings["aspnetdbConnectionString"].ConnectionString;

                // Abrindo a Conexão com o banco de dados
                SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
                aSQLCon.Open();

                // Executando o comando
                SqlCommand aSQL = new SqlCommand("SELECT * FROM Usuario WHERE Username = @Username", aSQLCon);

                aSQL.Parameters.AddWithValue("@Username", User.Identity.Name);

                // Executa comando, gerando objeto DbDataReader
                SqlDataReader dr = aSQL.ExecuteReader();

                // Le titulo do livro do resultado e apresenta no segundo rótulo
                if (dr.HasRows)
                {
                    // Le o registrodo usuario
                    dr.Read();
                    // Atribui os dados ao TextoBox
                    TextBoxLogin.Text = dr["UserName"].ToString();
                    TextBoxNome.Text = dr["Nome"].ToString();
                    TextBoxSobrenome.Text = dr["Sobrenome"].ToString();
                    TextBoxPais.Text = dr["Pais"].ToString();
                    TextBoxSexo.Text = dr["Sexo"].ToString();
                }
                else
                    TextBoxLogin.Text = "";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string aSQLConecStr;

            // Lendo a conexão de dados do Web.Config
            aSQLConecStr = ConfigurationManager.ConnectionStrings["aspnetdbConnectionString"].ConnectionString;

            // Abrindo a Conexão com o banco de dados
            SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
            aSQLCon.Open();

            // Executando o comando
            SqlCommand aSQL;
            if(TextBoxLogin.Text == "")
                aSQL = new SqlCommand("INSERT INTO Usuario(Username, Nome, Sobrenome, Pais, Sexo) VALUES (@Username, @Nome, @Sobrenome, @Pais, @Sexo)", aSQLCon);
            else
                aSQL = new SqlCommand("UPDATE Usuario SET Username = @Username, Nome = @Nome, Sobrenome = @Sobrenome, Pais = @Pais, Sexo = @Sexo WHERE Username = @Username", aSQLCon);
            
            aSQL.Parameters.AddWithValue("@Username", User.Identity.Name);
            aSQL.Parameters.AddWithValue("@Nome", TextBoxNome.Text);
            aSQL.Parameters.AddWithValue("@Sobrenome", TextBoxSobrenome.Text);
            aSQL.Parameters.AddWithValue("@Pais", TextBoxPais.Text);
            aSQL.Parameters.AddWithValue("@Sexo", TextBoxSexo.Text);
            aSQL.ExecuteNonQuery();

            Response.Redirect("~/Login.aspx");
        }

    }
}