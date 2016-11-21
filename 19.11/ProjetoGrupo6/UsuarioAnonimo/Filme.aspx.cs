using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoGrupo6.UsuarioAnonimo
{
    public partial class Filme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Conferindo se o usuário da Sessão não é Normal
            if (Session["usuario"] != null)
            {
                Response.Redirect("~/UsuarioNormal/Filme.aspx");
            }

            // Atribuindo o nome da filme a label
            LabelFilme.Text = Request.QueryString["Filme"];

            Session["filme_name"] = LabelFilme.Text;

            
            // Lendo o restante das informações dos filmes
            string aSQLConecStr;

            // Lendo a conexão de dados do Web.Config
            aSQLConecStr = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;

            // Abrindo a Conexão com o banco de dados
            SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
            aSQLCon.Open();


            // Cria comando SQL
            SqlCommand cmd = aSQLCon.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "Select * FROM Filme where filme_name = @filme_name";

            cmd.Parameters.AddWithValue("@filme_name", LabelFilme.Text);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    LabelFilme_id.Text = dr["filme_id"].ToString();
                    LabelAno.Text = dr["ano"].ToString();
                    LabelSinopse.Text = dr["sinopse"].ToString();
                    LabelDiretor.Text = dr["diretor"].ToString();
                    LabelProdutora.Text = dr["produtora"].ToString();
                    LabelDuracao.Text = dr["duracao"].ToString();
                    // Adiciona o livro lido à lista
                }
            }

            dr.Close();
            aSQLCon.Close();
            Session["filme_id"] = int.Parse(LabelFilme_id.Text);
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UsuarioAnonimo/ResultadoPesquisa.aspx?Filme=" + LabelFilme.Text);
        }


    }
}