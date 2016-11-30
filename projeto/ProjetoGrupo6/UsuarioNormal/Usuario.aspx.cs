using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoGrupo6.UsuarioNormal
{
    public partial class Usuario : System.Web.UI.Page
    {
        string usuario;
        bool validarSegue;
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelUsuario.Text = Request.QueryString["Usuario"];

            Session["perfil"] = Request.QueryString["Usuario"];

            usuario = Session["usuario"].ToString();

            if (usuario == Request.QueryString["Usuario"])
            {
                LinkButtonSeguirEditar.Text = "Editar Perfil";
            }
                DAL.DALSegue DALSegue = new DAL.DALSegue();
                Modelo.Segue segue = new Modelo.Segue(Request.QueryString["Usuario"].ToString(), Session["usuario"].ToString());
                validarSegue = DALSegue.SelectValidar(segue);
                if (validarSegue == true)
                    LinkButtonSeguirEditar.Text = "Seguindo";
        }
            

        protected void LinkButtonSeguirEditar_Click(object sender, EventArgs e)
        {
            if (LinkButtonSeguirEditar.Text == "Editar Perfil")
            {

            }
            else if (LinkButtonSeguirEditar.Text == "Seguir")
            {
                DAL.DALSegue DALSegue = new DAL.DALSegue();
                Modelo.Segue segue = new Modelo.Segue(Request.QueryString["Usuario"].ToString(), Session["usuario"].ToString());
                DALSegue.Insert(segue);

                LinkButtonSeguirEditar.Text = "Seguindo";
            }
            else if (LinkButtonSeguirEditar.Text == "Seguindo")
            {
                DAL.DALSegue DALSegue = new DAL.DALSegue();
                Modelo.Segue segue = new Modelo.Segue(Request.QueryString["Usuario"].ToString(), Session["usuario"].ToString());
                DALSegue.Delete(segue);

                LinkButtonSeguirEditar.Text = "Seguir";
            }
        }
    }
}