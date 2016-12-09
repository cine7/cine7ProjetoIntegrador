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
            Modelo.Filme aFilme;
            List<Modelo.Filme> aListFilme = new List<Modelo.Filme>();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select filme_name, ano, sinopse, diretor, produtora, duracao, caminhoImagem from Filme where filme_name like '%' + @filme_name + '%'";
            cmd.Parameters.AddWithValue("@filme_name", filme);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    aFilme = new Modelo.Filme(
                        dr["filme_name"].ToString(),
                        Convert.ToInt32(dr["ano"]),
                        dr["sinopse"].ToString(),
                        dr["diretor"].ToString(),
                        dr["produtora"].ToString(),
                        Convert.ToInt32(dr["duracao"]),
                        dr["caminhoImagem"].ToString()
                        );
                    aListFilme.Add(aFilme);
                }
            }
            dr.Close();
            conn.Close();
            return aListFilme;
        }

        //SELECT NOS FILMES PARA O CRUD
        /*[DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Filme> SelectCRUDFilme(string filme_name)
        {
            Modelo.Filme aFilme;
            List<Modelo.Filme> aListFilme = new List<Modelo.Filme>();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select filme_id, filme_name, caminhoImagem from Filme where filme_name like '%' + @filme_name + '%'";
            cmd.Parameters.AddWithValue("@filme_name", filme_name);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    aFilme = new Modelo.Filme(
                        Convert.ToInt32(dr["filme_id"]),
                        dr["filme_name"].ToString(),
                        dr["caminhoImagem"].ToString()
                        );
                    aListFilme.Add(aFilme);
                }
            }
            dr.Close();
            conn.Close();
            return aListFilme;
        }*/

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

        // SELECT NO NOME PELO CAMINHO DA IMAGEM
        [DataObjectMethod(DataObjectMethodType.Select)]
        public string SelectFilmeNamePorImagem(string caminhoImagem)
        {
            string filme_name = "";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select filme_name from Filme where caminhoImagem = @caminhoImagem";
            cmd.Parameters.AddWithValue("@caminhoImagem", caminhoImagem);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    filme_name = dr["filme_name"].ToString();
                }
            }
            dr.Close();
            conn.Close();
            return filme_name;
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

        //UPDATE NA MÉDIA
        [DataObjectMethod(DataObjectMethodType.Update)]
        public void UpdateMedia(int filme_id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("UPDATE Filme set media = (Select avg(avaliacao) from RelacaoAvaliacao where filme_id = @filme_id) where filme_id = @filme_id", conn);
            cmd.Parameters.AddWithValue("@filme_id", filme_id);

            cmd.ExecuteNonQuery();
        }

        // SELECT NA QUANTIDADE DE AVALIAÇÕES DE UM FILME
        [DataObjectMethod(DataObjectMethodType.Update)]
        public double SelectMediaFilme(Modelo.RelacaoAvaliacao obj)
        {
            double media = 0;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT media FROM Filme where filme_id = @filme_id";
            cmd.Parameters.AddWithValue("@filme_id", obj.filme_id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr["media"] != null) media = Convert.ToDouble(dr["media"]); //ISSO NÃO FAZ SENTIDO
                }
            }
            dr.Close();
            conn.Close();
            return media;
        }


        // SELECT NA QUANTIDADE DE AVALIAÇÕES DE UM FILME
        [DataObjectMethod(DataObjectMethodType.Update)]
        public void DeleteCRUDFilme(int filme_id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Filme where filme_id = @filme_id";
            cmd.Parameters.AddWithValue("@filme_id", filme_id);

            cmd.ExecuteNonQuery();
        }
    }
}