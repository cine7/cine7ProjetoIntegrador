using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoGrupo6.DAL
{
    public class DALRelacaoAvaliacao
    {
        string connectionString = "";

        public DALRelacaoAvaliacao()
        {
            connectionString = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;
        }

        //INSERT UM FILME NA LISTA DE FAVORITOS DE UM USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.RelacaoAvaliacao obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("INSERT INTO RelacaoAvaliacao(avaliacao, filme_id, usuario) VALUES (@avaliacao, @filme_id, @usuario)", conn);
            cmd.Parameters.AddWithValue("@avaliacao", obj.avaliacao);
            cmd.Parameters.AddWithValue("@filme_id", obj.filme_id);
            cmd.Parameters.AddWithValue("@usuario", obj.usuario);

            // Executa Comando
            cmd.ExecuteNonQuery();

        }


        //DELETAR UM FILME DA LISTA DE FAVORITOS DE UM USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(Modelo.RelacaoAvaliacao obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("UPDATE RelacaoAvaliacao set avaliacao = @avaliacao WHERE filme_id = @filme_id and usuario = @usuario", conn);
            cmd.Parameters.AddWithValue("@avaliacao", obj.avaliacao);
            cmd.Parameters.AddWithValue("@filme_id", obj.filme_id);
            cmd.Parameters.AddWithValue("@usuario", obj.usuario);

            // Executa Comando
            cmd.ExecuteNonQuery();
        }

        //SELECT AVALIACAO
        [DataObjectMethod(DataObjectMethodType.Select)]
        public int SelectAvaliacao(Modelo.RelacaoAvaliacao obj)
        {
            int avaliacao = 0;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("Select avaliacao FROM RelacaoAvaliacao WHERE usuario = @usuario and filme_id = @filme_id", conn);
            cmd.Parameters.AddWithValue("@usuario", obj.usuario);
            cmd.Parameters.AddWithValue("@filme_id", obj.filme_id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows) 
            {
                while (dr.Read()) 
                {
                    avaliacao = Convert.ToInt32(dr["avaliacao"]);
                }
            }
            return avaliacao;
        }

        //SELECT VALIDAÇÃO
        [DataObjectMethod(DataObjectMethodType.Select)]
        public bool SelectValidar(Modelo.RelacaoAvaliacao obj)
        {
            bool validar = false;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("Select dataHora FROM RelacaoAvaliacao WHERE usuario = @usuario and filme_id = @filme_id ", conn);
            cmd.Parameters.AddWithValue("@usuario", obj.usuario);
            cmd.Parameters.AddWithValue("@filme_id", obj.filme_id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr["dataHora"] != null)
                    {
                        validar = true;
                    }
                }
            }
            dr.Close();
            conn.Close();
            return validar;
        }
    }
}