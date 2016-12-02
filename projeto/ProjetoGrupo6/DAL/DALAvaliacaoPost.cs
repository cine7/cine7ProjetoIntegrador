using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoGrupo6.DAL
{
    public class DALAvaliacaoPost
    {
        string connectionString = "";

        public DALAvaliacaoPost()
        {
            connectionString = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public bool SelectValidarAvaliacaoPost(int comentario_id, string usuario)
        {
            bool validar = false;
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "SELECT dataHora FROM AvaliacaoPost where comentario_id = @comentario_id and usuarioAvaliador = @usuarioAvaliador";
            cmd.Parameters.AddWithValue("@comentario_id", comentario_id);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do livro do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {
                while (dr.Read()) // Le o proximo registro
                {
                    if (dr["dataHora"] != null) validar = true;
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();
            return validar;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public int SelectAvaliacaoPost(int comentario_id, string usuario)
        {
            int avaliacao = 0;
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "SELECT avaliacao FROM AvaliacaoPost where comentario_id = @comentario_id and usuarioAvaliador = @usuarioAvaliador";
            cmd.Parameters.AddWithValue("@comentario_id", comentario_id);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do livro do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {
                while (dr.Read()) // Le o proximo registro
                {
                    avaliacao = Convert.ToInt32(dr["avaliacao"]);
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();
            return avaliacao;
        }

        //INSERT DE UMA AVALIAÇÃO
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.AvaliacaoComentario obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("INSERT INTO AvaliacaoPost(avaliacao, comentario_id, usuarioAvaliador) VALUES(@avaliacao, @comentario_id, @usuarioAvaliador)", conn);
            cmd.Parameters.AddWithValue("@avaliacao", obj.avaliacao);
            cmd.Parameters.AddWithValue("@comentario_id", obj.comentario_id);
            cmd.Parameters.AddWithValue("@usuarioAvaliador", obj.usuarioAvaliador);

            // Executa Comando
            cmd.ExecuteNonQuery();

        }

        //DELETAR UMA AVALIAÇÃO POST
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(int comentario_id, string usuario)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("DELETE FROM AvaliacaoPost where comentario_id = @comentario_id and usuarioAvaliador = @usuarioAvaliador", conn);
            cmd.Parameters.AddWithValue("@comentario_id", comentario_id);
            cmd.Parameters.AddWithValue("@usuario", usuario);

            // Executa Comando
            cmd.ExecuteNonQuery();
        }

        //UPDATE NUMA AVALIAÇÃO COMENTÁRIO
        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(int avaliacao, int comentario_id, string usuario)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("UPDATE AvaliacaoPost set avaliacao = @avaliacao where comentario_id = @comentario_id and usuarioAvaliador = @usuarioAvaliador", conn);
            cmd.Parameters.AddWithValue("@avaliacao", comentario_id);
            cmd.Parameters.AddWithValue("@comentario_id", comentario_id);
            cmd.Parameters.AddWithValue("@usuario", usuario);

            // Executa Comando
            cmd.ExecuteNonQuery();
        }
    }
}