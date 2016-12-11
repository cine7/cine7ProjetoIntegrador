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
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("INSERT INTO Post(tipo, descricao, filme_id, usuario) VALUES (@tipo, @descricao, @filme_id, @usuario)", conn);
            cmd.Parameters.AddWithValue("@tipo", obj.tipo);
            cmd.Parameters.AddWithValue("@descricao", obj.descricao);
            cmd.Parameters.AddWithValue("@filme_id", obj.filme_id);
            cmd.Parameters.AddWithValue("@usuario", obj.usuario);

            cmd.ExecuteNonQuery();
        }

        //INSERT UM FILME NA LISTA DE FAVORITOS DE UM USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(Modelo.Post obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("UPDATE Post set descricao = @descricao  WHERE filme_id = @filme_id and usuario = @usuario and tipo = @tipo", conn);
            cmd.Parameters.AddWithValue("@descricao", obj.descricao);
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
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("DELETE FROM Post WHERE filme_id = @filme_id and usuario = @usuario and tipo = @tipo", conn);
            cmd.Parameters.AddWithValue("@filme_id", obj.filme_id);
            cmd.Parameters.AddWithValue("@usuario", obj.usuario);
            cmd.Parameters.AddWithValue("@tipo", obj.tipo);

            cmd.ExecuteNonQuery();
        }

        //SELECT NOS POST DE UM USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Post> SelectAll(string perfil)
        {
            Modelo.Post aPost = new Modelo.Post();
            List<Modelo.Post> aListPost = new List<Modelo.Post>();
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
                    aPost = new Modelo.Post(Convert.ToInt32(dr["post_id"]),
                              dr["usuario"].ToString(),
                              dr["descricao"].ToString(),
                              dr["filme_name"].ToString());
                }
            }
            dr.Close();
            conn.Close();

            return aListPost;
        }


        //SELECT NOS POSTS DO FEED DE UM USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Post> SelectFeed(string perfil)
        {
            Modelo.Post aPost = new Modelo.Post();
            List<Modelo.Post> aListPost = new List<Modelo.Post>();
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
                    aPost = new Modelo.Post(Convert.ToInt32(dr["post_id"]),
                              dr["usuario"].ToString(),
                              dr["descricao"].ToString(),
                              dr["filme_name"].ToString());
                    aListPost.Add(aPost);
                }
            }
            dr.Close();
            conn.Close();

            return aListPost;
        }
    }
}