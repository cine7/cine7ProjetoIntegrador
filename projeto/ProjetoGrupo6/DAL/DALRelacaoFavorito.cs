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
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("INSERT INTO RelacaoFavorito(filme_id, usuario) VALUES (@filme_id, @usuario)", conn);
            cmd.Parameters.AddWithValue("@filme_id", obj.filme_id);
            cmd.Parameters.AddWithValue("@usuario", obj.usuario);

            cmd.ExecuteNonQuery();

        }

        //DELETAR UM FILME DA LISTA DE FAVORITOS DE UM USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.RelacaoFavorito obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("DELETE FROM RelacaoFavorito WHERE filme_id = @filme_id and usuario = @usuario", conn);
            cmd.Parameters.AddWithValue("@filme_id", obj.filme_id);
            cmd.Parameters.AddWithValue("@usuario", obj.usuario);

            cmd.ExecuteNonQuery();
        }


        //SELECT PARA CONFERIR SE HÁ UM REGISTRO
        [DataObjectMethod(DataObjectMethodType.Select)]
        public bool Select(Modelo.RelacaoFavorito obj)
        {
            bool validar = true;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("Select dataHora FROM RelacaoFavorito where filme_id = @filme_id and usuario = @usuario", conn);
            cmd.Parameters.AddWithValue("@filme_id", obj.filme_id);
            cmd.Parameters.AddWithValue("@usuario", obj.usuario);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr["dataHora"] != null)
                    {
                        validar = false;
                    }
                }
            }
            dr.Close();
            conn.Close();
            return validar;
        }
        // SELECT NA QUANTIDADE DE FAVORITOS DE UM FILME
        [DataObjectMethod(DataObjectMethodType.Select)]
        public int SelectQuantidadeFavorito(Modelo.RelacaoFavorito obj)
        {
            int quantidade = 0;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM RelacaoFavorito where filme_id = @filme_id";
            cmd.Parameters.AddWithValue("@filme_id", obj.filme_id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    quantidade++;
                }
            }
            dr.Close();
            conn.Close();
            return quantidade;
        }

        // SELECT NOS FAVORITOS DE UM USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.RelacaoFavorito> SelectListaFavorito(string perfil)
        {
            Modelo.RelacaoFavorito aFavorito;
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

        // SELECT EM TODOS OS FAVORITOS DE UM USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.RelacaoFavorito> SelectListaFavoritoTodos(string perfil)
        {
            Modelo.RelacaoFavorito aFavorito;
            List<Modelo.RelacaoFavorito> aListFavorito = new List<Modelo.RelacaoFavorito>();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "exec sp_SelectFavoritosUsuarioTodos @perfil";
            cmd.Parameters.AddWithValue("@perfil", perfil);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    aFavorito = new Modelo.RelacaoFavorito(dr["filme_name"].ToString(), dr["caminhoImagem"].ToString());
                    aListFavorito.Add(aFavorito);
                }
            }
            dr.Close();
            conn.Close();
            return aListFavorito;
        }



        //DELETAR UM FILME DA LISTA DE FAVORITOS DE UM USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Update)]
        public void DeletePorId(int filme_id)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("DELETE from  RelacaoFavorito WHERE filme_id = @filme_id", conn);
            cmd.Parameters.AddWithValue("@filme_id", filme_id);

            // Executa Comando
            cmd.ExecuteNonQuery();
        }
    }
}