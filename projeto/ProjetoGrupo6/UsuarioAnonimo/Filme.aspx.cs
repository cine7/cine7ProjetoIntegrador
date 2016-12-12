using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoGrupo6.UsuarioAnonimo
{
    public partial class Filme : System.Web.UI.Page
    {
        string comentario_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Conferindo se o usuário da Sessão não é Normal
            if (Session["usuario"] != null)
            {
                Response.Redirect("~/UsuarioNormal/Filme.aspx");
            }

            LabelFilme.Text = Request.QueryString["Filme"];

            DAL.DALFilme DALFilme = new DAL.DALFilme();
            Modelo.Filme filme = DALFilme.SelectFilme(LabelFilme.Text);
            LabelFilme_id.Text = filme.filme_id.ToString();
            LabelAno.Text = filme.ano.ToString();
            LabelSinopse.Text = filme.sinopse.ToString();
            LabelDiretor.Text = filme.diretor.ToString();
            LabelProdutora.Text = filme.produtora.ToString();
            LabelDuracao.Text = filme.duracao.ToString();
            ImageFilme.ImageUrl = filme.caminhoImagem.ToString();


            Session["filme_id"] = int.Parse(LabelFilme_id.Text);


            //BotãoFavorito
            ImageButtonFavorito.Attributes.Add("onmouseover", "ContentPlaceHolder1_ImageButtonFavorito.src = '/Imagens/desfavoritarButton.png';");
            ImageButtonFavorito.Attributes.Add("onmouseout", "ContentPlaceHolder1_ImageButtonFavorito.src = '/Imagens/favoritarButton.png';");

            DAL.DALRelacaoFavorito DALRelacaoFavorito = new DAL.DALRelacaoFavorito();
            Modelo.RelacaoFavorito relacaofavorito2 = new Modelo.RelacaoFavorito(int.Parse(LabelFilme_id.Text));
            LabelQuantidadeFavorito.Text = DALRelacaoFavorito.SelectQuantidadeFavorito(relacaofavorito2).ToString();

            //BotãoInteresse
            ImageButtonInteresse.Attributes.Add("onmouseover", "ContentPlaceHolder1_ImageButtonInteresse.src = '/Imagens/tvInteresseButton.png';");
            ImageButtonInteresse.Attributes.Add("onmouseout", "ContentPlaceHolder1_ImageButtonInteresse.src = '/Imagens/cancelarInteresseButton.png';");

            DAL.DALRelacaoInteresse DALRelacaoInteresse = new DAL.DALRelacaoInteresse();
            Modelo.RelacaoInteresse relacaointeresse2 = new Modelo.RelacaoInteresse(int.Parse(LabelFilme_id.Text));
            LabelQuantidadeInteresse.Text = DALRelacaoInteresse.SelectQuantidadeInteresse(relacaointeresse2).ToString();

            //BotãoVisto
            ImageButtonVisto.Attributes.Add("onmouseover", "ContentPlaceHolder1_ImageButtonVisto.src = '/Imagens/cancelarVisto.png';");
            ImageButtonVisto.Attributes.Add("onmouseout", "ContentPlaceHolder1_ImageButtonVisto.src = '/Imagens/vistoButton.png';");

            DAL.DALRelacaoVisto DALRelacaoVisto = new DAL.DALRelacaoVisto();
            Modelo.RelacaoVisto relacaovisto2 = new Modelo.RelacaoVisto(int.Parse(LabelFilme_id.Text));
            LabelQuantidadeVisto.Text = DALRelacaoVisto.SelectQuantidadeVisto(relacaovisto2).ToString();

            /*ESTRELA ACESA CASO O FILME ESTEJA AVALIADO*/
            ImageButtonEstrela1.Attributes.Add("onmouseover", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaAcesa.png");
            ImageButtonEstrela1.Attributes.Add("onmouseout", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaApagada.png'");

            ImageButtonEstrela2.Attributes.Add("onmouseover", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaAcesa.png'; ContentPlaceHolder1_ImageButtonEstrela2.src = '/Imagens/estrelaAcesa.png';");
            ImageButtonEstrela2.Attributes.Add("onmouseout", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaApagada.png'; ContentPlaceHolder1_ImageButtonEstrela2.src = '/Imagens/estrelaApagada.png';");

            ImageButtonEstrela3.Attributes.Add("onmouseover", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaAcesa.png'; ContentPlaceHolder1_ImageButtonEstrela2.src = '/Imagens/estrelaAcesa.png'; ContentPlaceHolder1_ImageButtonEstrela3.src = '/Imagens/estrelaAcesa.png';");
            ImageButtonEstrela3.Attributes.Add("onmouseout", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaApagada.png'; ContentPlaceHolder1_ImageButtonEstrela2.src = '/Imagens/estrelaApagada.png'; ContentPlaceHolder1_ImageButtonEstrela3.src = '/Imagens/estrelaApagada.png';");

            ImageButtonEstrela4.Attributes.Add("onmouseover", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaAcesa.png'; ContentPlaceHolder1_ImageButtonEstrela2.src = '/Imagens/estrelaAcesa.png'; ContentPlaceHolder1_ImageButtonEstrela3.src = '/Imagens/estrelaAcesa.png'; ContentPlaceHolder1_ImageButtonEstrela4.src = '/Imagens/estrelaAcesa.png';");
            ImageButtonEstrela4.Attributes.Add("onmouseout", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaApagada.png'; ContentPlaceHolder1_ImageButtonEstrela2.src = '/Imagens/estrelaApagada.png'; ContentPlaceHolder1_ImageButtonEstrela3.src = '/Imagens/estrelaApagada.png'; ContentPlaceHolder1_ImageButtonEstrela4.src = '/Imagens/estrelaApagada.png';");

            ImageButtonEstrela5.Attributes.Add("onmouseover", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaAcesa.png'; ContentPlaceHolder1_ImageButtonEstrela2.src = '/Imagens/estrelaAcesa.png'; ContentPlaceHolder1_ImageButtonEstrela3.src = '/Imagens/estrelaAcesa.png'; ContentPlaceHolder1_ImageButtonEstrela4.src = '/Imagens/estrelaAcesa.png'; ContentPlaceHolder1_ImageButtonEstrela5.src = '/Imagens/estrelaAcesa.png';");
            ImageButtonEstrela5.Attributes.Add("onmouseout", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaApagada.png'; ContentPlaceHolder1_ImageButtonEstrela2.src = '/Imagens/estrelaApagada.png'; ContentPlaceHolder1_ImageButtonEstrela3.src = '/Imagens/estrelaApagada.png'; ContentPlaceHolder1_ImageButtonEstrela4.src = '/Imagens/estrelaApagada.png'; ContentPlaceHolder1_ImageButtonEstrela5.src = '/Imagens/estrelaApagada.png';");

            ImageButtonEstrela6.Attributes.Add("onmouseover", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaAcesa.png'; ContentPlaceHolder1_ImageButtonEstrela2.src = '/Imagens/estrelaAcesa.png'; ContentPlaceHolder1_ImageButtonEstrela3.src = '/Imagens/estrelaAcesa.png'; ContentPlaceHolder1_ImageButtonEstrela4.src = '/Imagens/estrelaAcesa.png'; ContentPlaceHolder1_ImageButtonEstrela5.src = '/Imagens/estrelaAcesa.png'; ContentPlaceHolder1_ImageButtonEstrela6.src = '/Imagens/estrelaAcesa.png'; ContentPlaceHolder1_ImageButtonEstrela2.src = '/Imagens/estrelaAcesa.png';");
            ImageButtonEstrela6.Attributes.Add("onmouseout", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaApagada.png'; ContentPlaceHolder1_ImageButtonEstrela2.src = '/Imagens/estrelaApagada.png'; ContentPlaceHolder1_ImageButtonEstrela3.src = '/Imagens/estrelaApagada.png'; ContentPlaceHolder1_ImageButtonEstrela4.src = '/Imagens/estrelaApagada.png'; ContentPlaceHolder1_ImageButtonEstrela5.src = '/Imagens/estrelaApagada.png'; ContentPlaceHolder1_ImageButtonEstrela6.src = '/Imagens/estrelaApagada.png';");

            ImageButtonEstrela7.Attributes.Add("onmouseover", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaAcesa.png'; ContentPlaceHolder1_ImageButtonEstrela2.src = '/Imagens/estrelaAcesa.png'; ContentPlaceHolder1_ImageButtonEstrela3.src = '/Imagens/estrelaAcesa.png'; ContentPlaceHolder1_ImageButtonEstrela4.src = '/Imagens/estrelaAcesa.png'; ContentPlaceHolder1_ImageButtonEstrela5.src = '/Imagens/estrelaAcesa.png'; ContentPlaceHolder1_ImageButtonEstrela6.src = '/Imagens/estrelaAcesa.png'; ContentPlaceHolder1_ImageButtonEstrela7.src = '/Imagens/estrelaAcesa.png';");
            ImageButtonEstrela7.Attributes.Add("onmouseout", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaApagada.png'; ContentPlaceHolder1_ImageButtonEstrela2.src = '/Imagens/estrelaApagada.png'; ContentPlaceHolder1_ImageButtonEstrela3.src = '/Imagens/estrelaApagada.png'; ContentPlaceHolder1_ImageButtonEstrela4.src = '/Imagens/estrelaApagada.png'; ContentPlaceHolder1_ImageButtonEstrela5.src = '/Imagens/estrelaApagada.png'; ContentPlaceHolder1_ImageButtonEstrela6.src = '/Imagens/estrelaApagada.png'; ContentPlaceHolder1_ImageButtonEstrela7.src = '/Imagens/estrelaApagada.png';");

            DAL.DALRelacaoAvaliacao DALRelacaoAvaliacao = new DAL.DALRelacaoAvaliacao();
            Modelo.RelacaoAvaliacao relacaoavaliacao3 = new Modelo.RelacaoAvaliacao(int.Parse(LabelFilme_id.Text));
            LabelQuantidadeAvaliacao.Text = DALRelacaoAvaliacao.SelectQuantidadeAvaliacao(relacaoavaliacao3).ToString();
            if (LabelQuantidadeAvaliacao.Text != "0") LabelMediaAvaliacao.Text = DALFilme.SelectMediaFilme(relacaoavaliacao3).ToString();
            else LabelMediaAvaliacao.Text = "";
            
        }

        protected void comentario_idLabel_PreRender(object sender, EventArgs e)
        {
            (sender as Label).Visible = true;
            comentario_id = (sender as Label).Text;
            (sender as Label).Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Para ter acesso a essa funcionalidade, você precisa estar cadastrado');</script>");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UsuarioAnonimo/ResultadoPesquisa.aspx?Filme=" + LabelFilme.Text);
        }

        protected void AnonimoClick_Click(object sender, ImageClickEventArgs e)
        {
            Response.Write("<script>alert('Para ter acesso a essa funcionalidade, você precisa estar cadastrado');</script>");
        }

        protected void ImageButtonVisto_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void LinkButtonUsuario_Click(object sender, EventArgs e)
        {
            String usuario = (sender as LinkButton).Text;
            Response.Redirect("~/UsuarioAnonimo/Usuario.aspx?Usuario=" + usuario);
        }

        protected void LabelPostivos_PreRender(object sender, EventArgs e)
        {
            DAL.DALAvaliacaoComentario DALAvaliacaoComentario = new DAL.DALAvaliacaoComentario();
            int x = DALAvaliacaoComentario.SelectQuantidadeAvaliacao(1, int.Parse(comentario_id));
            (sender as Label).Text = x.ToString();
        }

        protected void LabelNegativos_PreRender(object sender, EventArgs e)
        {
            DAL.DALAvaliacaoComentario DALAvaliacaoComentario = new DAL.DALAvaliacaoComentario();
            int x = DALAvaliacaoComentario.SelectQuantidadeAvaliacao(1, int.Parse(comentario_id));
            (sender as Label).Text = x.ToString();
        }


    }
}