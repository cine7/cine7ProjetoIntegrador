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
    public partial class CadastrarFilme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string aSQLConecStr;

            // Lendo a conexão de dados do Web.Config
            aSQLConecStr = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;

            // Abrindo a Conexão com o banco de dados
            SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
            aSQLCon.Open();

            // Executando o comando
            SqlCommand aSQL = new SqlCommand("INSERT INTO Filme(filme_name, ano, sinopse, diretor, produtora, duracao) VALUES (@filme_name, @ano, @sinopse, @diretor, @produtora, @duracao)", aSQLCon);
            aSQL.Parameters.AddWithValue("@filme_name", TextBoxFilmeName.Text);
            aSQL.Parameters.AddWithValue("@ano", TextBoxAno.Text);
            aSQL.Parameters.AddWithValue("@sinopse", TextBoxSinopse.Text);
            aSQL.Parameters.AddWithValue("@diretor", TextBoxDiretor.Text);
            aSQL.Parameters.AddWithValue("@produtora", TextBoxProdutora.Text);
            aSQL.Parameters.AddWithValue("@duracao", TextBoxDuracao.Text);
            aSQL.ExecuteNonQuery();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBoxDuracao_TextChanged(object sender, EventArgs e)
        {

        }
    }
}