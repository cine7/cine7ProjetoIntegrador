using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoGrupo6.DAL
{
    public class DALUsuario
    {
        string connectionString = "";

        public DALUsuario()
        {
            connectionString = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;
        }


        //INSERT EM UM COMENTÁRIO
        [DataObjectMethod(DataObjectMethodType.Select)]
        public string SelectCaminhoImagem(Modelo.Usuario obj)
        {
            string caminhoImagem = "";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select caminhoImagem from Usuario where usuario = @usuario";
            cmd.Parameters.AddWithValue("@usuario", obj.usuario);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    caminhoImagem = dr["caminhoImagem"].ToString();
                }
            }
            dr.Close();
            conn.Close();
            return caminhoImagem;

        }

        //INSERT EM UM COMENTÁRIO
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.Usuario obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Usuario(usuario, senha, nome, email, pais, caminhoImagem) VALUES (@usuario, @nome, @email, @pais, @senha, @caminhoImagem)", conn);
            cmd.Parameters.AddWithValue("@usuario", obj.usuario);
            cmd.Parameters.AddWithValue("@senha", obj.senha);
            cmd.Parameters.AddWithValue("@nome", obj.nome);
            cmd.Parameters.AddWithValue("@email", obj.email);
            cmd.Parameters.AddWithValue("@pais", obj.pais);
            cmd.Parameters.AddWithValue("@sexo", obj.sexo);
            cmd.Parameters.AddWithValue("@caminhoImagem", "~/Imagens/Perfil/" + obj.caminhoImagem);
            cmd.ExecuteNonQuery();

        }


        //DELETAR UM COMENTÁRIO
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.Comentario obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("DELETE FROM Comentario WHERE comentario_id = @comentario_id", conn);
            cmd.Parameters.AddWithValue("@comentario_id", obj.comentario_id);
            cmd.ExecuteNonQuery();
        }
    }
}