using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoGrupo6.UsuarioNormal
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string nomeAtual = "", emailAtual = "", paisAtual = "", sexoAtual = "", caminhoImagemAtual = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            DAL.DALUsuario DALUsuario = new DAL.DALUsuario();
            Modelo.Usuario usuario = DALUsuario.SelectUsuario(Session["usuario"].ToString());

            nomeAtual = usuario.nome;
            emailAtual = usuario.email;
            paisAtual = usuario.pais;
            sexoAtual = usuario.sexo;
            caminhoImagemAtual = usuario.caminhoImagem;

        }

        protected void ButtonEditarInfosPerfil_Click(object sender, EventArgs e)
        {
            string novoNome = "", novoEmail = "", novoPais= "", novoSexo = "", novoCaminhoImagem = "";

            if (TextBoxNome.Text == "") novoNome = nomeAtual;
            else novoNome = TextBoxNome.Text;

            if (TextBoxEmail.Text == "") novoEmail = emailAtual;
            else novoEmail = TextBoxEmail.Text;

            if (TextBoxPais.Text == "") novoPais = paisAtual;
            else novoPais = TextBoxPais.Text;

            if (RadioButtonEditarFeminino.Checked == false && RadioButtonEditarMasculino.Checked == false) novoSexo = sexoAtual;
            else {
                if (RadioButtonEditarFeminino.Checked == true) novoSexo = "Feminino";
                if (RadioButtonEditarFeminino.Checked == true) novoSexo = "Masculino";
            }

            novoCaminhoImagem = FileUploadEditarImagemPerfil.FileName;
            if (novoCaminhoImagem == "") novoCaminhoImagem = caminhoImagemAtual;
            else { novoCaminhoImagem = "~/Imagens/Perfil/" + FileUploadEditarImagemPerfil.FileName; UploadImagem(); }

            DAL.DALUsuario DALUsuario = new DAL.DALUsuario();
            Modelo.Usuario usuarioEditar = new Modelo.Usuario(novoNome, novoEmail, novoPais, novoSexo, novoCaminhoImagem);
            DALUsuario.UpdateInfosPerfil(usuarioEditar, Session["usuario"].ToString());
            Response.Redirect("~/UsuarioNormal/EditarPerfil.aspx");
        }

        public void UploadImagem()
        {
            string directory = Request.PhysicalApplicationPath;
            FileUploadEditarImagemPerfil.SaveAs(directory + "/Imagens/Perfil/" + FileUploadEditarImagemPerfil.FileName);
        }
    }
}