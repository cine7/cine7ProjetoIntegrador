using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoGrupo6.DAL
{
    public class DALFilme
    {
        string connectionString = "";

        public DALFilme() 
        {
            connectionString = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;
        }

        //SELECT TODOS FILMES DA PESQUISA
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Filme> SelectAllFilme(string filme) 
        {
            // Variável para armazenar um filme
            Modelo.Filme aFilme;
            // Cria Lista Vazia
            List<Modelo.Filme> aListFilme = new List<Modelo.Filme>();
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "Select filme_name, ano, sinopse, diretor, produtora, duracao, caminhoImagem from Filme where filme_name like '%' + @filme_name + '%'";
            cmd.Parameters.AddWithValue("@filme_name", filme);
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do livro do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {
                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    aFilme = new Modelo.Filme(
                        dr["filme_name"].ToString(),
                        Convert.ToInt32(dr["ano"]),
                        dr["sinopse"].ToString(),
                        dr["diretor"].ToString(),
                        dr["produtora"].ToString(),
                        Convert.ToInt32(dr["duracao"]),
                        dr["caminhoImagem"].ToString()
                        );
                    // Adiciona o livro lido à lista
                    aListFilme.Add(aFilme);
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();
            return aListFilme;
        }

        //SELECT EM INFORMAÇÕES DE UM FILME
        [DataObjectMethod(DataObjectMethodType.Select)]
        public Modelo.Filme SelectFilme(string filme)
        {
            Modelo.Filme aFilme = new Modelo.Filme();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select * from Filme where filme_name = @filme_name";
            cmd.Parameters.AddWithValue("@filme_name", filme);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    aFilme = new Modelo.Filme(
                        Convert.ToInt32(dr["filme_id"]),
                        dr["filme_name"].ToString(),
                        Convert.ToInt32(dr["ano"]),
                        dr["sinopse"].ToString(),
                        dr["diretor"].ToString(),
                        dr["produtora"].ToString(),
                        Convert.ToInt32(dr["duracao"]),
                        dr["caminhoImagem"].ToString()
                        );
                }
            }
            dr.Close();
            conn.Close();
            return aFilme;
        }

        //INSERT EM UM FILME
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.Filme obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("INSERT INTO Filme(filme_name, ano, sinopse, diretor, produtora, duracao, caminhoImagem) VALUES(@filme_name, @ano, @sinopse, @diretor, @produtora, @duracao, @caminhoImagem)", conn);
            cmd.Parameters.AddWithValue("@filme_name", obj.filme_name);
            cmd.Parameters.AddWithValue("@ano", obj.ano);
            cmd.Parameters.AddWithValue("@sinopse", obj.sinopse);
            cmd.Parameters.AddWithValue("@diretor", obj.diretor);
            cmd.Parameters.AddWithValue("@produtora", obj.produtora);
            cmd.Parameters.AddWithValue("@duracao", obj.duracao);
            cmd.Parameters.AddWithValue("@caminhoImagem", "~/Imagens/Filmes/" + obj.caminhoImagem);

            cmd.ExecuteNonQuery();

        }

        //DELETAR UM COMENTÁRIO
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(int comentario_id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("DELETE FROM Comentario WHERE comentario_id = @comentario_id", conn);
            cmd.Parameters.AddWithValue("@comentario_id", comentario_id);

            cmd.ExecuteNonQuery();
        }
    }
}