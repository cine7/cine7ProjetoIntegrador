using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoGrupo6.DAL
{
    public class DALFilme
    {
        string connectionString = "";

        public DALFilme() 
        {
            connectionString = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;
        }

        //SELECT FILME
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Filme> SelectFilme(Modelo.Filme obj) 
        {
            // Variável para armazenar um filme
            Modelo.Filme aFilme;
            // Cria Lista Vazia
            List<Modelo.Filme> aListFilme = new List<Modelo.Filme>();
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "SELECT filme_name, ano, sinopse, diretor, produtora, duracao FROM Filme where filme_id = @filme_id";
            cmd.Parameters.AddWithValue("@filme_id", obj.filme_id);
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do livro do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {
                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    aFilme = new Modelo.Filme(
                        Convert.ToInt32(dr["filme_id"]),
                        dr["filme_name"].ToString(),
                        Convert.ToInt32(dr["filme_id"]),
                        dr["filme_name"].ToString(),
                        dr["filme_name"].ToString(),
                        dr["filme_name"].ToString(),
                        Convert.ToInt32(dr["filme_id"])
                        );
                    // Adiciona o livro lido à lista
                    aListFilme.Add(aFilme);
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();
            return aListFilme;
        }
    }
}