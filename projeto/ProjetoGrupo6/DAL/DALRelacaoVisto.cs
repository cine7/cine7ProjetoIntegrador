using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoGrupo6.DAL
{
    public class DALRelacaoVisto
    {
        string connectionString = "";

        public DALRelacaoVisto()
        {
            connectionString = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;
        }

        //INSERT UM FILME NA LISTA DE FAVORITOS DE UM USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.RelacaoVisto obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("INSERT INTO RelacaoVisto(filme_id, usuario) VALUES (@filme_id, @usuario)", conn);
            cmd.Parameters.AddWithValue("@filme_id", obj.filme_id);
            cmd.Parameters.AddWithValue("@usuario", obj.usuario);

            cmd.ExecuteNonQuery();

        }

        //DELETAR UM FILME DA LISTA DE FAVORITOS DE UM USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.RelacaoVisto obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("DELETE FROM RelacaoVisto WHERE filme_id = @filme_id and usuario = @usuario", conn);
            cmd.Parameters.AddWithValue("@filme_id", obj.filme_id);
            cmd.Parameters.AddWithValue("@usuario", obj.usuario);

            cmd.ExecuteNonQuery();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public bool Select(Modelo.RelacaoVisto obj)
        {
            bool validar = true;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("Select dataHora FROM RelacaoVisto where filme_id = @filme_id and usuario = @usuario", conn);
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
        // SELECT NA QUANTIDADE DE VISTOS DE UM FILME
        [DataObjectMethod(DataObjectMethodType.Select)]
        public int SelectQuantidadeVisto(Modelo.RelacaoVisto obj)
        {
            int quantidade = 0;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM RelacaoVisto where filme_id = @filme_id";
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

        // SELECT NOS VISTO DE UM USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.RelacaoVisto> SelectListaVisto(string perfil)
        {
            Modelo.RelacaoVisto aFavorito;
            List<Modelo.RelacaoVisto> aListFavorito = new List<Modelo.RelacaoVisto>();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "exec sp_SelectVistosUsuario @perfil";
            cmd.Parameters.AddWithValue("@perfil", perfil);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    aFavorito = new Modelo.RelacaoVisto(dr["caminhoImagem"].ToString());
                    aListFavorito.Add(aFavorito);
                }
            }
            dr.Close();
            conn.Close();
            return aListFavorito;
        }

        // SELECT EM TODOS OS VISTOS DE UM USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.RelacaoFavorito> SelectListaFavoritoTodos(string perfil)
        {
            Modelo.RelacaoFavorito aFavorito;
            List<Modelo.RelacaoFavorito> aListFavorito = new List<Modelo.RelacaoFavorito>();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "exec sp_SelectVistosUsuarioTodos @perfil";
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