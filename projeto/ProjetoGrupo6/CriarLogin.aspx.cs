using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoGrupo6.CriarLogin
{
    public partial class CriarLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string usuario = TextBoxUsuario.Text, senha = TextBoxSenha.Text, email = TextBoxEmail.Text;

            DAL.DALUsuario DALUsuario = new DAL.DALUsuario();
            Modelo.Usuario usuariodal = new Modelo.Usuario(usuario, senha, TextBoxNome.Text, email, TextBoxPais.Text, TextBoxSexo.Text, FileUploadImagem.FileName);
            DALUsuario.Insert(usuariodal);
            UploadImagem();
            Membership.CreateUser(usuario, senha, email);
            DAL.DALaspnet_UsersInRoles DALaspnet_UsersInRoles = new DAL.DALaspnet_UsersInRoles();
            if (TextBoxCodigoAdministrador.Text == "adm123")
            {
                DALaspnet_UsersInRoles.InsertAdministrador(usuario);
            }
            else 
            {
                DALaspnet_UsersInRoles.InsertNormal(usuario);
            }
            //Roles.AddUserToRole(usuario, "Normal");
            Response.Redirect("~/Login.aspx");
        }

        public void UploadImagem() 
        {
            string directory = Request.PhysicalApplicationPath;
            FileUploadImagem.SaveAs(directory + "/Imagens/Perfil/" + FileUploadImagem.FileName);
        }

        

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}