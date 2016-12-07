using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoGrupo6.UsuarioAdministrador
{
    public partial class CRUDFilme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonInserir_Click(object sender, EventArgs e)
        {
            DAL.DALFilme DALFilme = new DAL.DALFilme();
            Modelo.Filme filme = new Modelo.Filme(TextBoxFilme_name.Text, int.Parse(TextBoxAno.Text), TextBoxSinopse.Text, TextBoxDiretor.Text, TextBoxProdutora.Text, int.Parse(TextBoxDuracao.Text), FileUploadImagem.FileName);
            DALFilme.Insert(filme);
            UploadImagem();
        }

        public void UploadImagem()
        {
            string directory = Request.PhysicalApplicationPath;
            FileUploadImagem.SaveAs(directory + "/Imagens/Filmes/" + FileUploadImagem.FileName);
        }
    }
}