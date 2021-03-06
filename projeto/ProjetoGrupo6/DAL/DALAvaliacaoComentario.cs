﻿using System;
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
            List<int> aListQuantidadeAvaliacao = new List<int>();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT avaliacao FROM AvaliacaoComentario where avaliacao = @avaliacao and comentario_id = @comentario_id";
            cmd.Parameters.AddWithValue("@avaliacao", avaliacao);
            cmd.Parameters.AddWithValue("@comentario_id", comentario_id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    aAvaliacao = Convert.ToInt32(dr["avaliacao"]);
                    aListQuantidadeAvaliacao.Add(aAvaliacao);
                    quantidade++;
                }
            }
            dr.Close();
            conn.Close();
            return quantidade;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public bool SelectValidarAvaliacaoComentario(int comentario_id, string usuarioAvaliador)
        {
            bool validar = false;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT dataHora FROM AvaliacaoComentario where comentario_id = @comentario_id and usuarioAvaliador = @usuarioAvaliador";
            cmd.Parameters.AddWithValue("@comentario_id", comentario_id);
            cmd.Parameters.AddWithValue("@usuarioAvaliador", usuarioAvaliador);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read()) 
                {
                    if (dr["dataHora"] != null) validar = true;
                }
            }
            dr.Close();
            conn.Close();
            return validar;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public int SelectAvaliacaoComentario(int comentario_id, string usuarioAvaliador)
        {
            int avaliacao = 0;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT avaliacao FROM AvaliacaoComentario where comentario_id = @comentario_id and usuarioAvaliador = @usuarioAvaliador";
            cmd.Parameters.AddWithValue("@comentario_id", comentario_id);
            cmd.Parameters.AddWithValue("@usuarioAvaliador", usuarioAvaliador);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    avaliacao = Convert.ToInt32(dr["avaliacao"]);
                }
            }
            dr.Close();
            conn.Close();
            return avaliacao;
        }

        //INSERT DE UMA AVALIAÇÃO
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(int avaliacao, int comentario_id, string usuarioAvaliador)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("INSERT INTO AvaliacaoComentario(avaliacao, comentario_id, usuarioAvaliador) VALUES(@avaliacao, @comentario_id, @usuarioAvaliador)", conn);
            cmd.Parameters.AddWithValue("@avaliacao", avaliacao);
            cmd.Parameters.AddWithValue("@comentario_id", comentario_id);
            cmd.Parameters.AddWithValue("@usuarioAvaliador", usuarioAvaliador);

            cmd.ExecuteNonQuery();

        }

        //DELETAR UMA AVALIAÇÃO COMENTÁRIO
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(int comentario_id, string usuarioAvaliador)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("DELETE FROM AvaliacaoComentario where comentario_id = @comentario_id and usuarioAvaliador = @usuarioAvaliador", conn);
            cmd.Parameters.AddWithValue("@comentario_id", comentario_id);
            cmd.Parameters.AddWithValue("@usuarioAvaliador", usuarioAvaliador);

            cmd.ExecuteNonQuery();
        }

        //UPDATE NUMA AVALIAÇÃO COMENTÁRIO
        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(int avaliacao, int comentario_id, string usuarioAvaliador)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("UPDATE AvaliacaoComentario set avaliacao = @avaliacao where comentario_id = @comentario_id and usuarioAvaliador = @usuarioAvaliador", conn);
            cmd.Parameters.AddWithValue("@avaliacao", avaliacao);
            cmd.Parameters.AddWithValue("@comentario_id", comentario_id);
            cmd.Parameters.AddWithValue("@usuarioAvaliador", usuarioAvaliador);

            cmd.ExecuteNonQuery();
        }
    }
}