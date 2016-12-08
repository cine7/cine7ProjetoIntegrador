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


        //CRIAR UM USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.Usuario obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Usuario(usuario, senha, nome, email, pais, caminhoImagem) VALUES (@usuario, @senha, @nome, @email, @pais, @caminhoImagem)", conn);
            cmd.Parameters.AddWithValue("@usuario", obj.usuario);
            cmd.Parameters.AddWithValue("@senha", obj.senha);
            cmd.Parameters.AddWithValue("@nome", obj.nome);
            cmd.Parameters.AddWithValue("@email", obj.email);
            cmd.Parameters.AddWithValue("@pais", obj.pais);
            cmd.Parameters.AddWithValue("@sexo", obj.sexo);
            cmd.Parameters.AddWithValue("@caminhoImagem", "~/Imagens/Perfil/" + obj.caminhoImagem);
            cmd.ExecuteNonQuery();
        }

        //SELECT NO CAMINHO DA IMAGEM
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

        [DataObjectMethod(DataObjectMethodType.Select)]
        public Modelo.Usuario SelectUsuario(string usuario)
        {
            Modelo.Usuario aUsuario = new Modelo.Usuario();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select * from Usuario where usuario = @usuario";
            cmd.Parameters.AddWithValue("@usuario", usuario);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    aUsuario = new Modelo.Usuario(
                        dr["nome"].ToString(),
                        dr["email"].ToString(),
                        dr["pais"].ToString(),
                        dr["sexo"].ToString(),
                        dr["caminhoImagem"].ToString()
                        );
                }
            }
            dr.Close();
            conn.Close();
            return aUsuario;
        }

        //UPDATE NOME DO USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Update)]
        public void UpdateNome(string nome, string usuario)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Usuario set nome = @nome where usuario = @usuario", conn);
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.ExecuteNonQuery();
        }

        //UPDATE EMAIL DO USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Update)]
        public void UpdateEmail(string email, string usuario)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Usuario set email = @email where usuario = @usuario", conn);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.ExecuteNonQuery();
        }

        //UPDATE PAIS DO USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Update)]
        public void UpdatePais(string pais, string usuario)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Usuario set pais = @pais where usuario = @usuario", conn);
            cmd.Parameters.AddWithValue("@pais", pais);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.ExecuteNonQuery();
        }

        //UPDATE SEXO DO USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Update)]
        public void UpdateSexo(string sexo, string usuario)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Usuario set sexo = @sexo where usuario = @usuario", conn);
            cmd.Parameters.AddWithValue("@sexo", sexo);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.ExecuteNonQuery();
        }

        //UPDATE CAMINHO IMAGEM DO USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Update)]
        public void UpdateCaminhoImagem(string caminhoImagem, string usuario)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Usuario set caminhoImagem = @caminhoImagem where usuario = @usuario", conn);
            cmd.Parameters.AddWithValue("@caminhoImagem", "~/Imagens/Perfil/" + caminhoImagem);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.ExecuteNonQuery();
        }

        //UPDATE SENHA DO USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Update)]
        public void UpdateSenha(string senha, string usuario)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Usuario set senha = @senha where usuario = @usuario", conn);
            cmd.Parameters.AddWithValue("@senha", senha);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.ExecuteNonQuery();
        }
    }
}