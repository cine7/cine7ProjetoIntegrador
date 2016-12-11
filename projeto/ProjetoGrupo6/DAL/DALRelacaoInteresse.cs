using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoGrupo6.DAL
{
    public class DALRelacaoInteresse
    {
        string connectionString = "";

        public DALRelacaoInteresse()
        {
            connectionString = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;
        }

        //INSERT UM FILME NA LISTA DE FAVORITOS DE UM USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.RelacaoInteresse obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("INSERT INTO RelacaoInteresse(filme_id, usuario) VALUES (@filme_id, @usuario)", conn);
            cmd.Parameters.AddWithValue("@filme_id", obj.filme_id);
            cmd.Parameters.AddWithValue("@usuario", obj.usuario);

            cmd.ExecuteNonQuery();

        }


        //DELETAR UM FILME DA LISTA DE FAVORITOS DE UM USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.RelacaoInteresse obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("DELETE FROM RelacaoInteresse WHERE filme_id = @filme_id and usuario = @usuario", conn);
            cmd.Parameters.AddWithValue("@filme_id", obj.filme_id);
            cmd.Parameters.AddWithValue("@usuario", obj.usuario);

            cmd.ExecuteNonQuery();
        }

        //SELECT PARA CONFERIR SE HÁ UM REGISTRO
        [DataObjectMethod(DataObjectMethodType.Select)]
        public bool Select(Modelo.RelacaoInteresse obj)
        {
            bool validar = true;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("Select dataHora FROM RelacaoInteresse where filme_id = @filme_id and usuario = @usuario", conn);
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
        // SELECT NA QUANTIDADE DE INTERESSES DE UM FILME
        [DataObjectMethod(DataObjectMethodType.Select)]
        public int SelectQuantidadeInteresse(Modelo.RelacaoInteresse obj)
        {
            int quantidade = 0;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM RelacaoInteresse where filme_id = @filme_id";
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

        // SELECT NOS INTERESSES DE UM USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.RelacaoInteresse> SelectListaInteresse(string perfil)
        {
            Modelo.RelacaoInteresse aFavorito;
            List<Modelo.RelacaoInteresse> aListFavorito = new List<Modelo.RelacaoInteresse>();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "exec sp_SelectInteressesUsuario @perfil";
            cmd.Parameters.AddWithValue("@perfil", perfil);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    aFavorito = new Modelo.RelacaoInteresse(dr["caminhoImagem"].ToString());
                    aListFavorito.Add(aFavorito);
                }
            }
            dr.Close();
            conn.Close();
            return aListFavorito;
        }

        // SELECT EM TODOS OS INTERESSES DE UM USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.RelacaoFavorito> SelectListaFavoritoTodos(string perfil)
        {
            Modelo.RelacaoFavorito aFavorito;
            List<Modelo.RelacaoFavorito> aListFavorito = new List<Modelo.RelacaoFavorito>();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "exec sp_SelectInteressesUsuarioTodos @perfil";
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
    }
}