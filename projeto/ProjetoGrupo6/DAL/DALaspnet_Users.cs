using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoGrupo6.DAL
{
    public class DALaspnet_Users
    {
        string connectionString = "";

        public DALaspnet_Users()
        {
            connectionString = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public string SelectUserID(Modelo.aspnet_Users obj)
        {
            string userID = "";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select userID from aspnet_Users where userName = @userName";
            cmd.Parameters.AddWithValue("@userName", obj.userName);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    userID = dr["userID"].ToString();
                }
            }
            dr.Close();
            conn.Close();
            return userID;
        }
    }
}
