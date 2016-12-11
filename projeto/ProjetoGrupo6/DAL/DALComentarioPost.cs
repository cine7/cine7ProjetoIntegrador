using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoGrupo6.DAL
{
    public class DALComentarioPost
    {
        
        string connectionString = "";

        public DALComentarioPost()
        {
            connectionString = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;
        }

        // SELECT NOS COMENTÁRIOS DE UM FILME
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Comentario> SelectComentarioPost(int post_id)
        {
            Modelo.Comentario aComentario;
            List<Modelo.Comentario> aListComentario = new List<Modelo.Comentario>();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT comentariopost_id, dataHora, descricao, post_id, usuarioComentario FROM ComentarioPost";
            //cmd.Parameters.AddWithValue("@post_id", post_id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    aComentario = new Modelo.Comentario(
                        Convert.ToInt32(dr["comentariopost_id"]),
                        Convert.ToDateTime(dr["dataHora"]),
                        dr["descricao"].ToString(),
                        Convert.ToInt32(dr["post_id"].ToString()),
                        dr["usuarioComentario"].ToString()
                        );
                    aListComentario.Add(aComentario);
                }
            }
            dr.Close();
            conn.Close();
            return aListComentario;
        }

        //INSERT EM UM COMENTÁRIO
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.ComentarioPost obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("INSERT INTO ComentarioPost (descricao, post_id, usuarioComentario) VALUES (@descricao, @post_id, @usuarioComentario)", conn);
            cmd.Parameters.AddWithValue("@descricao", obj.descricao);
            cmd.Parameters.AddWithValue("@post_id", obj.post_id);
            cmd.Parameters.AddWithValue("@usuarioComentario", obj.usuarioComentario);

            cmd.ExecuteNonQuery();

        }

        //DELETAR UM COMENTÁRIO
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(int comentariopost_id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("DELETE FROM ComentarioPost WHERE comentariopost_id = @comentariopost_id", conn);
            cmd.Parameters.AddWithValue("@comentariopost_id", comentariopost_id);

            cmd.ExecuteNonQuery();
        }
    }
}