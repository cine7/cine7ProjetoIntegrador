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

        /*// SELECT NOS COMENTÁRIOS DE UM FILME
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Comentario> SelectComentario(int filme_id)
        {
            // Variavel para armazenar um comentário
            Modelo.Comentario aComentario;
            // Cria Lista Vazia
            List<Modelo.Comentario> aListComentario = new List<Modelo.Comentario>();
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "SELECT comentario_id, data, descricao, filme_id, usuario FROM Comentario where filme_id = @filme_id";
            cmd.Parameters.AddWithValue("@filme_id", filme_id);
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
                        Convert.ToDateTime(dr["data"]),
                        dr["descricao"].ToString(),
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
        }*/

        [DataObjectMethod(DataObjectMethodType.Select)]
        public bool SelectValidarAvaliacaoPost(int comentario_id, string usuarioAvaliador)
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
            cmd.Parameters.AddWithValue("@usuarioAvaliador", usuarioAvaliador);
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do livro do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {
                while (dr.Read()) // Le o proximo registro
                {
                    if (dr["dataHora"] != null) validar = true;
                    // Adiciona o livro lido à lista
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();
            return validar;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public int SelectAvaliacaoPost(int comentario_id, string usuarioAvaliador)
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
            cmd.Parameters.AddWithValue("@usuarioAvaliador", usuarioAvaliador);
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
        public void Insert(int avaliacao, int comentario_id, string usuarioAvaliador)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("INSERT INTO AvaliacaoPost(avaliacao, comentario_id, usuarioAvaliador) VALUES(@avaliacao, @comentario_id, @usuarioAvaliador)", conn);
            cmd.Parameters.AddWithValue("@avaliacao", avaliacao);
            cmd.Parameters.AddWithValue("@comentario_id", comentario_id);
            cmd.Parameters.AddWithValue("@usuarioAvaliador", usuarioAvaliador);

            // Executa Comando
            cmd.ExecuteNonQuery();

        }

        //DELETAR UMA AVALIAÇÃO COMENTÁRIO
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(int comentario_id, string usuarioAvaliador)
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
            cmd.Parameters.AddWithValue("@usuarioAvaliador", usuarioAvaliador);

            // Executa Comando
            cmd.ExecuteNonQuery();
        }

        //UPDATE NUMA AVALIAÇÃO COMENTÁRIO
        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(int avaliacao, int comentario_id, string usuarioAvaliador)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("UPDATE AvaliacaoPost set avaliacao = @avaliacao where comentario_id = @comentario_id and usuarioAvaliador = @usuarioAvaliador", conn);
            cmd.Parameters.AddWithValue("@avaliacao", avaliacao);
            cmd.Parameters.AddWithValue("@comentario_id", comentario_id);
            cmd.Parameters.AddWithValue("@usuarioAvaliador", usuarioAvaliador);

            // Executa Comando
            cmd.ExecuteNonQuery();
        }
    }
}