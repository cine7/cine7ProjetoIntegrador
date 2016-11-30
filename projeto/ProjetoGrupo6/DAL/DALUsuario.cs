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
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.Usuario obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("INSERT INTO Usuario(usuario, senha, nome, email, dataNascimento, pais, caminhoImagem) VALUES (@usuario, @nome, @email, @dataNascimento, @pais, @senha, @caminhoImagem)", conn);
            cmd.Parameters.AddWithValue("@usuario", obj.usuario);
            cmd.Parameters.AddWithValue("@senha", obj.senha);
            cmd.Parameters.AddWithValue("@nome", obj.nome);
            cmd.Parameters.AddWithValue("@email", obj.email);
            cmd.Parameters.AddWithValue("@dataNascimento", obj.dataNascimento);
            cmd.Parameters.AddWithValue("@pais", obj.pais);
            cmd.Parameters.AddWithValue("@sexo", obj.sexo);
            cmd.Parameters.AddWithValue("@caminhoImagem", "~/Imagens/Perfil/" + obj.caminhoImagem);

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