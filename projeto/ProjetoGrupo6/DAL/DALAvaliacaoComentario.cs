using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoGrupo6.DAL
{
    public class DALAvaliacaoComentario
    {
        string connectionString = "";

        public DALAvaliacaoComentario()
        {
            connectionString = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;
        }

        // SELECT NOS COMENTÁRIOS DE UM FILME
        [DataObjectMethod(DataObjectMethodType.Select)]
        public int SelectQuantidadeAvaliacao(int avaliacao, int comentario_id)
        {
            int quantidade = 0, aAvaliacao = 0;
            // Cria Lista Vazia
            List<int> aListQuantidadeAvaliacao = new List<int>();
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "SELECT avaliacao FROM AvaliacaoComentario where avaliacao = @avaliacao and comentario_id = @comentario_id";
            cmd.Parameters.AddWithValue("@avaliacao", avaliacao);
            cmd.Parameters.AddWithValue("@comentario_id", comentario_id);
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do livro do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {
                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    aAvaliacao = Convert.ToInt32(dr["avaliacao"]);
                    // Adiciona o livro lido à lista
                    aListQuantidadeAvaliacao.Add(aAvaliacao);
                    quantidade++;
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();
            return quantidade;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public bool SelectValidarAvaliacaoComentario(int comentario_id, string usuarioAvaliador)
        {
            bool validar = false;
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "SELECT dataHora FROM AvaliacaoComentario where comentario_id = @comentario_id and usuarioAvaliador = @usuarioAvaliador";
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
        public int SelectAvaliacaoComentario(int comentario_id, string usuarioAvaliador)
        {
            int avaliacao = 0;
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "SELECT avaliacao FROM AvaliacaoComentario where comentario_id = @comentario_id and usuarioAvaliador = @usuarioAvaliador";
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
            SqlCommand cmd = new SqlCommand("INSERT INTO AvaliacaoComentario(avaliacao, comentario_id, usuarioAvaliador) VALUES(@avaliacao, @comentario_id, @usuarioAvaliador)", conn);
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
            SqlCommand cmd = new SqlCommand("DELETE FROM AvaliacaoComentario where comentario_id = @comentario_id and usuarioAvaliador = @usuarioAvaliador", conn);
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
            SqlCommand cmd = new SqlCommand("UPDATE AvaliacaoComentario set avaliacao = @avaliacao where comentario_id = @comentario_id and usuarioAvaliador = @usuarioAvaliador", conn);
            cmd.Parameters.AddWithValue("@avaliacao", avaliacao);
            cmd.Parameters.AddWithValue("@comentario_id", comentario_id);
            cmd.Parameters.AddWithValue("@usuarioAvaliador", usuarioAvaliador);

            // Executa Comando
            cmd.ExecuteNonQuery();
        }
    }
}