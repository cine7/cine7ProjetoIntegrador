using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoGrupo6.DAL
{
    public class DALPost
    {
        string connectionString = "";

        public DALPost()
        {
            connectionString = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;
        }

        //INSERT UM FILME NA LISTA DE FAVORITOS DE UM USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.Post obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("INSERT INTO Post(tipo, filme_id, usuario) VALUES (@tipo, @filme_id, @usuario)", conn);
            cmd.Parameters.AddWithValue("@tipo", obj.tipo);
            cmd.Parameters.AddWithValue("@filme_id", obj.filme_id);
            cmd.Parameters.AddWithValue("@usuario", obj.usuario);

            // Executa Comando
            cmd.ExecuteNonQuery();

        }


        //DELETAR UM POST
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.Post obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("DELETE FROM Post WHERE filme_id = @filme_id and usuario = @usuario and tipo = @tipo", conn);
            cmd.Parameters.AddWithValue("@filme_id", obj.filme_id);
            cmd.Parameters.AddWithValue("@usuario", obj.usuario);
            cmd.Parameters.AddWithValue("@tipo", obj.tipo);

            // Executa Comando
            cmd.ExecuteNonQuery();
        }

        //SELECT NOS POST DE UM USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Post> SelectAll(string perfil)
        {
            // Variavel para armazenar um livro
            Modelo.Post aPost;
            // Cria Lista Vazia
            List<Modelo.Post> aListPost = new List<Modelo.Post>();
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "exec sp_SelectPost @perfil";
            cmd.Parameters.AddWithValue("@perfil", perfil);
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do livro do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {
                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    aPost = new Modelo.Post(
                        Convert.ToInt32(dr["tipo"]),
                        Convert.ToInt32(dr["filme_id"]),
                        dr["usuario"].ToString()
                        );
                    // Adiciona o livro lido à lista
                    aListPost.Add(aPost);
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();

            return aListPost;
        }


        //SELECT NOS POSTS DO FEED DE UM USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Post> SelectFeed(string perfil)
        {
            // Variavel para armazenar um livro
            Modelo.Post aPost;
            // Cria Lista Vazia
            List<Modelo.Post> aListPost = new List<Modelo.Post>();
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "exec sp_SelectFeed @perfil";
            cmd.Parameters.AddWithValue("@perfil", perfil);
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do livro do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {

                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    aPost = new Modelo.Post(
                        Convert.ToInt32(dr["tipo"]),
                        Convert.ToInt32(dr["Filme.filme_name"]),
                        dr["Usuario.nome"].ToString()
                        );
                    // Adiciona o livro lido à lista
                    aListPost.Add(aPost);
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();

            return aListPost;
        }
    }
}