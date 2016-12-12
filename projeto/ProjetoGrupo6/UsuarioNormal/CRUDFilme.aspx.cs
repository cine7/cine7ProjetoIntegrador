using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoGrupo6.UsuarioNormal
{
    public partial class CRUDFilme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["filme_name"] = "~^~^~^-=-=-=";
            Session["filme_nameUpdate"] = "~^~^~^-=-=-=";
            Session["filme_nameDelete"] = "~^~^~^-=-=-=";
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonInserir_Click(object sender, EventArgs e)
        {
            string caminhoImagemComparador = FileUploadImagem.FileName;
            if (TextBoxFilme_name.Text == "" || TextBoxAno.Text == "" || TextBoxSinopse.Text == "" || TextBoxDiretor.Text == "" || TextBoxProdutora.Text == "" || TextBoxDuracao.Text == "" || caminhoImagemComparador == "")
                Response.Write("<script>alert('Os valores inseridos não podem ser nulos');</script>");
            else
            {
                DAL.DALFilme DALFilme = new DAL.DALFilme();
                Modelo.Filme filme = new Modelo.Filme(TextBoxFilme_name.Text, int.Parse(TextBoxAno.Text), TextBoxSinopse.Text, TextBoxDiretor.Text, TextBoxProdutora.Text, int.Parse(TextBoxDuracao.Text), FileUploadImagem.FileName);
                DALFilme.Insert(filme);
                UploadImagem();
                TextBoxFilme_name.Text = ""; TextBoxAno.Text = ""; TextBoxSinopse.Text = ""; TextBoxDiretor.Text = ""; TextBoxProdutora.Text = ""; TextBoxDuracao.Text = "";
            }
        }

        public void UploadImagem()
        {
            string directory = Request.PhysicalApplicationPath;
            FileUploadImagem.SaveAs(directory + "/Imagens/Filmes/" + FileUploadImagem.FileName);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            DAL.DALFilme DALFilme = new DAL.DALFilme();
            DAL.DALRelacaoAvaliacao DALRelacaoAvaliacao = new DAL.DALRelacaoAvaliacao();
            DAL.DALRelacaoFavorito DALRelacaoFavorito = new DAL.DALRelacaoFavorito();
            DAL.DALRelacaoInteresse DALRelacaoInteresse = new DAL.DALRelacaoInteresse();
            DAL.DALRelacaoVisto DALRelacaoVisto = new DAL.DALRelacaoVisto();

            DALRelacaoAvaliacao.DeletePorId(int.Parse(TextBoxFilme_idDelete.Text));
            DALRelacaoFavorito.DeletePorId(int.Parse(TextBoxFilme_idDelete.Text));
            DALRelacaoInteresse.DeletePorId(int.Parse(TextBoxFilme_idDelete.Text));
            DALRelacaoVisto.DeletePorId(int.Parse(TextBoxFilme_idDelete.Text));


            DALFilme.DeleteCRUDFilme(int.Parse(TextBoxFilme_idDelete.Text));
            TextBoxFilme_idDelete.Text = "";
            Session["filme_nameDelete"] = "~^~^~^-=-=-=";
        }

        protected void ImageButtonLupaCRUDDelete_Click(object sender, ImageClickEventArgs e)
        {
            Session["filme_nameDelete"] = TextBoxFilme_nameDelete.Text;
        }

        protected void ImageButtonLupaCRUDUpdate_Click(object sender, ImageClickEventArgs e)
        {
            Session["filme_nameUpdate"] = TextBoxFilme_nameUpdatePesquisa.Text;

        }

        protected void ButtonFilmeUpdate_Click(object sender, EventArgs e)
        {
            string filme_nameAtual = "", anoAtual = "", sinopseAtual = "", diretorAtual = "", produtoraAtual = "", duracaoAtual = "", caminhoImagemAtual = "";
            string filme_nameNovo = "", anoNovo = "", sinopseNovo = "", diretorNovo = "", produtoraNovo = "", duracaoNovo = "", caminhoImagemNovo = "";
            
            DAL.DALFilme DALFilme = new DAL.DALFilme();
            Modelo.Filme filmeAtual = DALFilme.SelectFilmePorId(int.Parse(TextBoxFilmeIdUpdate.Text));

            filme_nameAtual = filmeAtual.filme_name;
            anoAtual = filmeAtual.ano.ToString();
            sinopseAtual = filmeAtual.sinopse;
            diretorAtual = filmeAtual.diretor;
            produtoraAtual = filmeAtual.produtora;
            duracaoAtual = filmeAtual.duracao.ToString();
            caminhoImagemAtual = filmeAtual.caminhoImagem;

            if (TextBoxFilmeFilme_nameUpdate.Text == "") filme_nameNovo = filme_nameAtual;
            else filme_nameNovo = TextBoxFilmeFilme_nameUpdate.Text;

            if (TextBoxFilmeAnoUpdate.Text == "") anoNovo = anoAtual;
            else anoNovo = TextBoxFilmeAnoUpdate.Text;

            if (TextBoxFilmeSinopseUpdate.Text == "") sinopseNovo = sinopseAtual;
            else sinopseNovo = TextBoxFilmeSinopseUpdate.Text;

            if (TextBoxFilmeDiretorUpdate.Text == "") diretorNovo = diretorAtual;
            else diretorNovo = TextBoxFilmeDiretorUpdate.Text;

            if (TextBoxFilmeProdutoraUpdate.Text == "") produtoraNovo = produtoraAtual;
            else produtoraNovo = TextBoxFilmeProdutoraUpdate.Text;

            if (TextBoxFilmeDuracaoUpdate.Text == "") duracaoNovo = duracaoAtual;
            else duracaoNovo = TextBoxFilmeDuracaoUpdate.Text;

            caminhoImagemNovo = FileUploadImagemFilmeUpdate.FileName;
            if (caminhoImagemNovo == "") caminhoImagemNovo = caminhoImagemAtual;
            else { caminhoImagemNovo = "~/Imagens/Filmes/" + FileUploadImagemFilmeUpdate.FileName; UploadImagemUpdate(); }

            Modelo.Filme filmeUpdate = new Modelo.Filme(filme_nameNovo, int.Parse(anoNovo), sinopseNovo, diretorNovo, produtoraNovo, int.Parse(duracaoNovo), caminhoImagemNovo);
            DALFilme.UpdateFilme(filmeUpdate, int.Parse(TextBoxFilmeIdUpdate.Text));


            TextBoxFilmeFilme_nameUpdate.Text = "";

            TextBoxFilme_nameUpdatePesquisa.Text = "";
            TextBoxFilmeIdUpdate.Text = "";
            TextBoxFilmeFilme_nameUpdate.Text = "";
            TextBoxFilmeAnoUpdate.Text = "";
            TextBoxFilmeSinopseUpdate.Text = "";
            TextBoxFilmeDiretorUpdate.Text = "";
            TextBoxFilmeProdutoraUpdate.Text = "";
            TextBoxFilmeDuracaoUpdate.Text = "";
            //FileUploadImagemFilmeUpdate.FileName = "";

            Session["filme_nameUpdate"] = "~^~^~^-=-=-=";
        }
        

        public void UploadImagemUpdate()
        {
            string directory = Request.PhysicalApplicationPath;
            FileUploadImagemFilmeUpdate.SaveAs(directory + "/Imagens/Filmes/" + FileUploadImagemFilmeUpdate.FileName);
        }
    }
}