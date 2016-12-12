using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoGrupo6.DAL
{
    public class DALaspnet_UsersInRoles
    {
        string connectionString = "";

        public DALaspnet_UsersInRoles()
        {
            connectionString = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;
        }


        //INSERT EM UM ROLE USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void InsertNormal(string userName)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            DAL.DALaspnet_Users DALaspnet_Users = new DAL.DALaspnet_Users();
            Modelo.aspnet_Users aspnet_Users = new Modelo.aspnet_Users(userName);
            string userID = DALaspnet_Users.SelectUserID(aspnet_Users);

            //SqlCommand cmd = new SqlCommand("insert into aspnet_UsersInRoles(userid, roleid) VALUES(@userid, 'DA74AF0F-0403-45DC-BB77-D75AE63599DA')", conn);
            SqlCommand cmd = new SqlCommand("insert into aspnet_UsersInRoles(userid, roleid) VALUES(@userid, '5693C758-FB46-4974-BD9C-59A56B54673D')", conn);
            
            cmd.Parameters.AddWithValue("@userid", userID);

            cmd.ExecuteNonQuery();
        }

        //INSERT EM UM ROLE USUÁRIO
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void InsertAdministrador(string userName)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            DAL.DALaspnet_Users DALaspnet_Users = new DAL.DALaspnet_Users();
            Modelo.aspnet_Users aspnet_Users = new Modelo.aspnet_Users(userName);
            string userID = DALaspnet_Users.SelectUserID(aspnet_Users);

            //SqlCommand cmd = new SqlCommand("insert into aspnet_UsersInRoles(userid, roleid) VALUES(@userid, 'E941BC42-522F-4CB3-9CE6-92B349AF7B3A')", conn);
            SqlCommand cmd = new SqlCommand("insert into aspnet_UsersInRoles(userid, roleid) VALUES(@userid, '33B63735-44F1-4C8E-AA15-86586FFA3411')", conn);
            cmd.Parameters.AddWithValue("@userid", userID);

            cmd.ExecuteNonQuery();
        }

        //SELECT ROLE
        [DataObjectMethod(DataObjectMethodType.Select)]
        public string SelectUserRole(string userName)
        {
            string roleId = "";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            DAL.DALaspnet_Users DALaspnet_Users = new DAL.DALaspnet_Users();
            Modelo.aspnet_Users aspnet_Users = new Modelo.aspnet_Users(userName);
            string userID = DALaspnet_Users.SelectUserID(aspnet_Users);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select roleId from aspnet_UsersInRoles where userID = @userID";
            cmd.Parameters.AddWithValue("@userID", userID);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    roleId = dr["roleId"].ToString();
                }
            }
            dr.Close();
            conn.Close();
            return roleId;
        }
    }
}