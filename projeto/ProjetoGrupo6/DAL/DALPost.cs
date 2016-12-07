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
        public List<string> SelectAll(string perfil)
        {
            string aPost, usuario, filme_name;
            List<string> aListPost = new List<string>();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "exec sp_SelectPost @perfil";
            cmd.Parameters.AddWithValue("@perfil", perfil);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                        if (Convert.ToInt32(dr["tipo"]) == 1)
                        {
                            usuario = dr["usuario"].ToString();
                            filme_name = dr["filme_name"].ToString();
                            aPost = usuario + "favoritou" + filme_name;
                            aListPost.Add(aPost);
                        }
                }
            }
            dr.Close();
            conn.Close();

            return aListPost;
        }


        //SELECT NOS POSTS DO FEED DE UM USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<string> SelectFeed(string perfil)
        {
            string aPost, usuario, filme_name;
            List<string> aListPost = new List<string>();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "exec sp_SelectFeed @perfil";
            cmd.Parameters.AddWithValue("@perfil", perfil);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["tipo"]) == 1)
                    {
                        usuario = dr["usuario"].ToString();
                        filme_name = dr["filme_name"].ToString();
                        aPost = usuario + " favoritou " + filme_name;
                        aListPost.Add(aPost);
                    }
                    if (Convert.ToInt32(dr["tipo"]) == 2)
                    {
                        usuario = dr["usuario"].ToString();
                        filme_name = dr["filme_name"].ToString();
                        aPost = usuario + " adicionou " + filme_name + " à lista de interesses";
                        aListPost.Add(aPost);
                    }
                    if (Convert.ToInt32(dr["tipo"]) == 3)
                    {
                        usuario = dr["usuario"].ToString();
                        filme_name = dr["filme_name"].ToString();
                        aPost = usuario + " marcou " + filme_name + " como visto";
                        aListPost.Add(aPost);
                    }
                }
            }
            dr.Close();
            conn.Close();

            return aListPost;
        }
    }
}