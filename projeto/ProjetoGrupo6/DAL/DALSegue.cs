using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoGrupo6.DAL
{
    public class DALSegue
    {
        string connectionString = "";

        public DALSegue()
        {
            connectionString = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;
        }
        
        //INSERT NUMA RELAÇÃO DE SEGUIR
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.Segue obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("INSERT INTO Segue(usuarioSeguido, usuarioSeguidor) VALUES(@usuarioSeguido, @usuarioSeguidor)", conn);
            cmd.Parameters.AddWithValue("@usuarioSeguido", obj.usuarioSeguido);
            cmd.Parameters.AddWithValue("@usuarioSeguidor", obj.usuarioSeguidor);

            // Executa Comando
            cmd.ExecuteNonQuery();

        }

        //DELETE NUMA RELAÇÃO DE SEGUIR
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.Segue obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("DELETE FROM Segue WHERE usuarioSeguido = @usuarioSeguido and usuarioSeguidor = @usuarioSeguidor", conn);
            cmd.Parameters.AddWithValue("@usuarioSeguido", obj.usuarioSeguido);
            cmd.Parameters.AddWithValue("@usuarioSeguidor", obj.usuarioSeguidor);

            // Executa Comando
            cmd.ExecuteNonQuery();
        }

        //SELECT PARA CONFERIR SE UM USUÁRIO SEGUE OUTRO
        [DataObjectMethod(DataObjectMethodType.Select)]
        public bool SelectValidar(Modelo.Segue obj)
        {
            bool validar = false;
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            // Define comando de exclusão
            SqlCommand cmd = new SqlCommand("Select usuarioSeguido FROM Segue where usuarioSeguidor = @usuarioSeguidor and usuarioSeguido = @usuarioSeguido", conn);
            cmd.Parameters.AddWithValue("@usuarioSeguido", obj.usuarioSeguido);
            cmd.Parameters.AddWithValue("@usuarioSeguidor", obj.usuarioSeguidor);
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do livro do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {
                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    if (dr["usuarioSeguido"] != null)
                    {
                        validar = true;
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
    }
}