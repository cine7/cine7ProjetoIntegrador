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
        public List<Modelo.Comentario> SelectComentario(Modelo.Comentario obj)
        {
            // Variavel para armazenar um comentário
            Modelo.Comentario aComentario;
            // Cria Lista Vazia
            List<Modelo.Comentario> aListComentario = new List<Modelo.Comentario> ();
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "SELECT comentario_id, descricao, data, filme_id, usuario FROM Comentario where filme_id = @filme_id";
            cmd.Parameters.AddWithValue("@filme_id", obj.filme_id);
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do livro do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {
                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    aComentario = new Modelo.Comentario(
                        Convert.ToInt32(dr["comentario_id"]),
                        dr["descricao"].ToString(),
                        Convert.ToDateTime(dr["data"].ToString()),
                        Convert.ToInt32(dr["filme_id"].ToString()),
                        dr["usuario"].ToString()
                        );
                    // Adiciona o livro lido à lista
                    aListComentario.Add(aComentario);
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();
            return aListComentario;
        }

        //INSERT EM UM COMENTÁRIO
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.Comentario obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("INSERT INTO Comentario (descricao, filme_id, usuario) VALUES (@descricao, @filme_id, @usuario)", conn);
            cmd.Parameters.AddWithValue("@descricao", obj.descricao);
            cmd.Parameters.AddWithValue("@filme_id", obj.filme_id);
            cmd.Parameters.AddWithValue("@usuario", obj.usuario);

            // Executa Comando
            cmd.ExecuteNonQuery();

        }


        //DELETAR UM COMENTÁRIO
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.Comentario obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("DELETE FROM Comentario WHERE comentario_id = @comentario_id", conn);
            cmd.Parameters.AddWithValue("@comentario_id", obj.comentario_id);

            // Executa Comando
            cmd.ExecuteNonQuery();
        }

    }
}