using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoGrupo6.DAL
{
    public class DALRelacaoFavorito
    {
        string connectionString = "";

        public DALRelacaoFavorito()
        {
            connectionString = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;
        }

        //INSERT UM FILME NA LISTA DE FAVORITOS DE UM USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.RelacaoFavorito obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("INSERT INTO RelacaoFavorito(filme_id, usuario) VALUES (@filme_id, @usuario)", conn);
            cmd.Parameters.AddWithValue("@filme_id", obj.filme_id);
            cmd.Parameters.AddWithValue("@usuario", obj.usuario);

            // Executa Comando
            cmd.ExecuteNonQuery();

        }

        //DELETAR UM FILME DA LISTA DE FAVORITOS DE UM USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.RelacaoFavorito obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("DELETE FROM RelacaoFavorito WHERE filme_id = @filme_id and usuario = @usuario", conn);
            cmd.Parameters.AddWithValue("@filme_id", obj.filme_id);
            cmd.Parameters.AddWithValue("@usuario", obj.usuario);

            // Executa Comando
            cmd.ExecuteNonQuery();
        }


        //SELECT PARA CONFERIR SE HÁ UM REGISTRO
        [DataObjectMethod(DataObjectMethodType.Select)]
        public bool Select(Modelo.RelacaoFavorito obj)
        {
            bool validar = true;
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("Select dataHora FROM RelacaoFavorito where filme_id = @filme_id and usuario = @usuario", conn);
            cmd.Parameters.AddWithValue("@filme_id", obj.filme_id);
            cmd.Parameters.AddWithValue("@usuario", obj.usuario);
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do livro do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {
                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    if (dr["dataHora"] != null)
                    {
                        validar = false;
                    }
                    // Adiciona o livro lido à lista
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();
            return validar;
        }
        // SELECT NA QUANTIDADE DE FAVORITOS DE UM FILME
        [DataObjectMethod(DataObjectMethodType.Select)]
        public int SelectQuantidadeFavorito(Modelo.RelacaoFavorito obj)
        {
            int quantidade = 0;
            // Cria Lista Vazia
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "SELECT * FROM RelacaoFavorito where filme_id = @filme_id";
            cmd.Parameters.AddWithValue("@filme_id", obj.filme_id);
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do livro do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {
                while (dr.Read()) // Le o proximo registro
                {
                    quantidade++;
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();
            return quantidade;
        }
        // SELECT NOS FAVORITOS DE UM USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.RelacaoFavorito> SelectListaFavorito(string perfil)
        {
            Modelo.RelacaoFavorito aFavorito;
            // Cria Lista Vazia
            List<Modelo.RelacaoFavorito> aListFavorito = new List<Modelo.RelacaoFavorito>();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "exec sp_SelectFavoritosUsuario @perfil";
            cmd.Parameters.AddWithValue("@perfil", perfil);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    aFavorito = new Modelo.RelacaoFavorito(dr["caminhoImagem"].ToString());
                    aListFavorito.Add(aFavorito);
                }
            }
            dr.Close();
            conn.Close();
            return aListFavorito;
        }
        
    }
}