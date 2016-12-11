using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoGrupo6.DAL
{
    public class DALComentario
    {
        string connectionString = "";

        public DALComentario()
        {
            connectionString = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;
        }

        // SELECT NOS COMENTÁRIOS DE UM FILME
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Comentario> SelectComentario(int filme_id)
        {
            Modelo.Comentario aComentario;
            List<Modelo.Comentario> aListComentario = new List<Modelo.Comentario> ();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT comentario_id, data, descricao, filme_id, usuario FROM Comentario where filme_id = @filme_id";
            cmd.Parameters.AddWithValue("@filme_id", filme_id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    aComentario = new Modelo.Comentario(
                        Convert.ToInt32(dr["comentario_id"]),
                        Convert.ToDateTime(dr["data"]),
                        dr["descricao"].ToString(),
                        Convert.ToInt32(dr["filme_id"].ToString()),
                        dr["usuario"].ToString()
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
        public void Insert(Modelo.Comentario obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("INSERT INTO Comentario (descricao, filme_id, usuario) VALUES (@descricao, @filme_id, @usuario)", conn);
            cmd.Parameters.AddWithValue("@descricao", obj.descricao);
            cmd.Parameters.AddWithValue("@filme_id", obj.filme_id);
            cmd.Parameters.AddWithValue("@usuario", obj.usuario);

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