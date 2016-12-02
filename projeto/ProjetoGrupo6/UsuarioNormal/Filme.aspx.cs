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
    public partial class Filme : System.Web.UI.Page
    {
        bool visibilidade, avaliacao;
        int avaliacaoInt;
        string comentario_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
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
            

            Session["filme_id"] = int.Parse(LabelFilme_id.Text);


            //BotãoFavorito
            DAL.DALRelacaoFavorito DALRelacaoFavorito = new DAL.DALRelacaoFavorito();
            Modelo.RelacaoFavorito relacaofavorito = new Modelo.RelacaoFavorito(int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
            bool validarFavorito = DALRelacaoFavorito.Select(relacaofavorito);
            if (validarFavorito == true) 
            {
                ImageButtonFavorito.ImageUrl = "~/Imagens/desfavoritarButton.png";
            }
            else
            {
                ImageButtonFavorito.ImageUrl = "~/Imagens/favoritarButton.png";
            }

            //BotãoInteresse
            DAL.DALRelacaoInteresse DALRelacaoInteresse = new DAL.DALRelacaoInteresse();
            Modelo.RelacaoInteresse relacaointeresse = new Modelo.RelacaoInteresse(int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
            bool validarInteresse = DALRelacaoInteresse.Select(relacaointeresse);
            if (validarInteresse == true)
            {
                ImageButtonInteresse.ImageUrl = "~/Imagens/cancelarInteresseButton.png";
            }
            else
            {
                ImageButtonInteresse.ImageUrl = "~/Imagens/tvInteresseButton.png";
            }

            //BotãoVisto
            DAL.DALRelacaoVisto DALRelacaoVisto = new DAL.DALRelacaoVisto();
            Modelo.RelacaoVisto relacaovisto = new Modelo.RelacaoVisto(int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
            bool validarVisto = DALRelacaoVisto.Select(relacaovisto);
            if (validarVisto == true)
            {
                ImageButtonVisto.ImageUrl = "~/Imagens/cancelarVisto.png";
            }
            else
            {
                ImageButtonVisto.ImageUrl = "~/Imagens/vistoButton.png";
            }

            /*ESTRELAS DE AVALIAÇÃO*/
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

            /*ESTRELA ACESA CASO O FILME ESTEJA AVALIADO*/
            DAL.DALRelacaoAvaliacao DALRelacaoAvaliacao = new DAL.DALRelacaoAvaliacao();
            Modelo.RelacaoAvaliacao relacaoavaliacao = new Modelo.RelacaoAvaliacao(int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
            avaliacaoInt = DALRelacaoAvaliacao.SelectAvaliacao(relacaoavaliacao);

            if (avaliacaoInt == 1)
            {
                ImageButtonEstrela1.ImageUrl = "/Imagens/estrelaAcesa.png";
                ImageButtonEstrela2.ImageUrl = "/Imagens/estrelaApagada.png";
                ImageButtonEstrela3.ImageUrl = "/Imagens/estrelaApagada.png";
                ImageButtonEstrela4.ImageUrl = "/Imagens/estrelaApagada.png";
                ImageButtonEstrela5.ImageUrl = "/Imagens/estrelaApagada.png";
                ImageButtonEstrela6.ImageUrl = "/Imagens/estrelaApagada.png";
                ImageButtonEstrela7.ImageUrl = "/Imagens/estrelaApagada.png";
            }
            if (avaliacaoInt == 2)
            {
                ImageButtonEstrela1.ImageUrl = "/Imagens/estrelaAcesa.png";
                ImageButtonEstrela2.ImageUrl = "/Imagens/estrelaAcesa.png";
                ImageButtonEstrela3.ImageUrl = "/Imagens/estrelaApagada.png";
                ImageButtonEstrela4.ImageUrl = "/Imagens/estrelaApagada.png";
                ImageButtonEstrela5.ImageUrl = "/Imagens/estrelaApagada.png";
                ImageButtonEstrela6.ImageUrl = "/Imagens/estrelaApagada.png";
                ImageButtonEstrela7.ImageUrl = "/Imagens/estrelaApagada.png";
            }
            if (avaliacaoInt == 3)
            {
                ImageButtonEstrela1.ImageUrl = "/Imagens/estrelaAcesa.png";
                ImageButtonEstrela2.ImageUrl = "/Imagens/estrelaAcesa.png";
                ImageButtonEstrela3.ImageUrl = "/Imagens/estrelaAcesa.png";
                ImageButtonEstrela4.ImageUrl = "/Imagens/estrelaApagada.png";
                ImageButtonEstrela5.ImageUrl = "/Imagens/estrelaApagada.png";
                ImageButtonEstrela6.ImageUrl = "/Imagens/estrelaApagada.png";
                ImageButtonEstrela7.ImageUrl = "/Imagens/estrelaApagada.png";
            }
            if (avaliacaoInt == 4)
            {
                ImageButtonEstrela1.ImageUrl = "/Imagens/estrelaAcesa.png";
                ImageButtonEstrela2.ImageUrl = "/Imagens/estrelaAcesa.png";
                ImageButtonEstrela3.ImageUrl = "/Imagens/estrelaAcesa.png";
                ImageButtonEstrela4.ImageUrl = "/Imagens/estrelaAcesa.png";
                ImageButtonEstrela5.ImageUrl = "/Imagens/estrelaApagada.png";
                ImageButtonEstrela6.ImageUrl = "/Imagens/estrelaApagada.png";
                ImageButtonEstrela7.ImageUrl = "/Imagens/estrelaApagada.png";
            }
            if (avaliacaoInt == 5)
            {
                ImageButtonEstrela1.ImageUrl = "/Imagens/estrelaAcesa.png";
                ImageButtonEstrela2.ImageUrl = "/Imagens/estrelaAcesa.png";
                ImageButtonEstrela3.ImageUrl = "/Imagens/estrelaAcesa.png";
                ImageButtonEstrela4.ImageUrl = "/Imagens/estrelaAcesa.png";
                ImageButtonEstrela5.ImageUrl = "/Imagens/estrelaAcesa.png";
                ImageButtonEstrela6.ImageUrl = "/Imagens/estrelaApagada.png";
                ImageButtonEstrela7.ImageUrl = "/Imagens/estrelaApagada.png";
            }
            if (avaliacaoInt == 6)
            {
                ImageButtonEstrela1.ImageUrl = "/Imagens/estrelaAcesa.png";
                ImageButtonEstrela2.ImageUrl = "/Imagens/estrelaAcesa.png";
                ImageButtonEstrela3.ImageUrl = "/Imagens/estrelaAcesa.png";
                ImageButtonEstrela4.ImageUrl = "/Imagens/estrelaAcesa.png";
                ImageButtonEstrela5.ImageUrl = "/Imagens/estrelaAcesa.png";
                ImageButtonEstrela6.ImageUrl = "/Imagens/estrelaAcesa.png";
                ImageButtonEstrela7.ImageUrl = "/Imagens/estrelaApagada.png";
            }
            if (avaliacaoInt == 7)
            {
                ImageButtonEstrela1.ImageUrl = "/Imagens/estrelaAcesa.png";
                ImageButtonEstrela2.ImageUrl = "/Imagens/estrelaAcesa.png";
                ImageButtonEstrela3.ImageUrl = "/Imagens/estrelaAcesa.png";
                ImageButtonEstrela4.ImageUrl = "/Imagens/estrelaAcesa.png";
                ImageButtonEstrela5.ImageUrl = "/Imagens/estrelaAcesa.png";
                ImageButtonEstrela6.ImageUrl = "/Imagens/estrelaAcesa.png";
                ImageButtonEstrela7.ImageUrl = "/Imagens/estrelaAcesa.png";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DAL.DALComentario DALComentario = new DAL.DALComentario();
            Modelo.Comentario comentario = new Modelo.Comentario(TextBoxComentario.Text, int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
            DALComentario.Insert(comentario);

            /*DAL.DALPost DALPost = new DAL.DALPost();
            Modelo.Post post = new Modelo.Post(5, int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
            DALPost.Insert(post);*/

            Response.Redirect("~/UsuarioNormal/Filme.aspx?Filme=" + LabelFilme.Text);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UsuarioNormal/ResultadoPesquisa.aspx?Filme=" + LabelFilme.Text);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButtonFavorito.ImageUrl == "~/Imagens/favoritarButton.png")
            {
                DAL.DALRelacaoFavorito DALRelacaofavorito = new DAL.DALRelacaoFavorito();
                Modelo.RelacaoFavorito relacaofavorito = new Modelo.RelacaoFavorito(int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
                DALRelacaofavorito.Delete(relacaofavorito);
                ImageButtonFavorito.ImageUrl = "~/Imagens/desfavoritarButton.png";

                DAL.DALPost DALPost = new DAL.DALPost();
                Modelo.Post post = new Modelo.Post(1, int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
                DALPost.Delete(post);
            }
            else
            {
                DAL.DALRelacaoFavorito DALRelacaofavorito = new DAL.DALRelacaoFavorito();
                Modelo.RelacaoFavorito relacaofavorito = new Modelo.RelacaoFavorito(int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
                DALRelacaofavorito.Insert(relacaofavorito);
                ImageButtonFavorito.ImageUrl = "~/Imagens/favoritarButton.png";

                DAL.DALPost DALPost = new DAL.DALPost();
                Modelo.Post post = new Modelo.Post(1, int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
                DALPost.Insert(post);

            }
        }

        protected void LinkButtonApagar_Click(object sender, EventArgs e)
        {
        }

        protected void ImageButtonVisto_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButtonVisto.ImageUrl == "~/Imagens/vistoButton.png")
            {
                DAL.DALRelacaoVisto DALRelacaovisto = new DAL.DALRelacaoVisto();
                Modelo.RelacaoVisto relacaovisto = new Modelo.RelacaoVisto(int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
                DALRelacaovisto.Delete(relacaovisto);
                ImageButtonVisto.ImageUrl = "~/Imagens/cancelarVisto.png";

                DAL.DALPost DALPost = new DAL.DALPost();
                Modelo.Post post = new Modelo.Post(3, int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
                DALPost.Delete(post);
            }
            else
            {
                DAL.DALRelacaoVisto DALRelacaovisto = new DAL.DALRelacaoVisto();
                Modelo.RelacaoVisto relacaovisto = new Modelo.RelacaoVisto(int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
                DALRelacaovisto.Insert(relacaovisto);
                ImageButtonVisto.ImageUrl = "~/Imagens/vistoButton.png";

                DAL.DALPost DALPost = new DAL.DALPost();
                Modelo.Post post = new Modelo.Post(3, int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
                DALPost.Insert(post);

            }
        }

        protected void ImageButtonInteresse_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButtonInteresse.ImageUrl == "~/Imagens/tvInteresseButton.png")
            {
                DAL.DALRelacaoInteresse DALRelacaointeresse = new DAL.DALRelacaoInteresse();
                Modelo.RelacaoInteresse relacaointerese = new Modelo.RelacaoInteresse(int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
                DALRelacaointeresse.Delete(relacaointerese);
                ImageButtonInteresse.ImageUrl = "~/Imagens/cancelarInteresseButton.png";

                DAL.DALPost DALPost = new DAL.DALPost();
                Modelo.Post post = new Modelo.Post(2, int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
                DALPost.Delete(post);
            }
            else
            {
                DAL.DALRelacaoInteresse DALRelacaointeresse = new DAL.DALRelacaoInteresse();
                Modelo.RelacaoInteresse relacaointerese = new Modelo.RelacaoInteresse(int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
                DALRelacaointeresse.Insert(relacaointerese);
                ImageButtonInteresse.ImageUrl = "~/Imagens/tvInteresseButton.png";

                DAL.DALPost DALPost = new DAL.DALPost();
                Modelo.Post post = new Modelo.Post(2, int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
                DALPost.Insert(post);

            }
        }

        protected void LinkButtonApagar_DataBinding(object sender, EventArgs e)
        {
            //
        }

        protected void comentario_idLabel_PreRender(object sender, EventArgs e)
        {
            comentario_id = (sender as Label).Text;
        }


        protected void LinkButtonApagar_Click1(object sender, EventArgs e)
        {
            DAL.DALComentario DALComentario = new DAL.DALComentario();
            DALComentario.Delete(int.Parse((sender as LinkButton).CommandName));
            Response.Redirect("~/UsuarioNormal/Filme.aspx?Filme=" + Session["filme_name"]);

            /*DAL.DALPost DALPost = new DAL.DALPost();
            Modelo.Post post = new Modelo.Post(5, int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
            DALPost.Delete(post);*/
        }
        protected void LinkButtonApagar_PreRender1(object sender, EventArgs e)
        {
            (sender as LinkButton).Visible = visibilidade;
            (sender as LinkButton).CommandName = comentario_id;
        }

        protected void usuarioLabel_PreRender1(object sender, EventArgs e)
        {
            String usuarioLabel = (sender as Label).Text;
            String usuarioSession = Session["usuario"].ToString();

            if (usuarioLabel == usuarioSession)
            {
                visibilidade = true;
            }
            else
            {
                visibilidade = false;
            }

        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButtonApagar_Command(object sender, CommandEventArgs e)
        {

        }

        protected void LinkButtonUsuario_PreRender(object sender, EventArgs e)
        {
            String usuarioLinkButton = (sender as LinkButton).Text;
            String usuarioSession = Session["usuario"].ToString();

            if (usuarioLinkButton == usuarioSession)
            {
                visibilidade = true;
            }
            else
            {
                visibilidade = false;
            }
        }

        protected void LinkButtonUsuario_Click(object sender, EventArgs e)
        {
            String usuario = (sender as LinkButton).Text;
            Response.Redirect("~/UsuarioNormal/Usuario.aspx?Usuario=" + usuario);
        }

        protected void comentario_idLabel_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButtonEstrela1_Click(object sender, ImageClickEventArgs e)
        {
            DAL.DALRelacaoAvaliacao DALRelacaoAvaliacao = new DAL.DALRelacaoAvaliacao();
            Modelo.RelacaoAvaliacao relacaoavaliacao = new Modelo.RelacaoAvaliacao(int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
            avaliacao = DALRelacaoAvaliacao.SelectValidar(relacaoavaliacao);

            if (avaliacao == false)
            {
                Modelo.RelacaoAvaliacao relacaoavaliacao2 = new Modelo.RelacaoAvaliacao(1, int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
                DALRelacaoAvaliacao.Insert(relacaoavaliacao2);
            }
            else
            {
                Modelo.RelacaoAvaliacao relacaoavaliacao2 = new Modelo.RelacaoAvaliacao(1, int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
                DALRelacaoAvaliacao.Update(relacaoavaliacao2);
            }

        }

        protected void ImageButtonEstrela2_Click(object sender, ImageClickEventArgs e)
        {
            DAL.DALRelacaoAvaliacao DALRelacaoAvaliacao = new DAL.DALRelacaoAvaliacao();
            Modelo.RelacaoAvaliacao relacaoavaliacao = new Modelo.RelacaoAvaliacao(int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
            avaliacao = DALRelacaoAvaliacao.SelectValidar(relacaoavaliacao);

            if (avaliacao == false)
            {
                Modelo.RelacaoAvaliacao relacaoavaliacao2 = new Modelo.RelacaoAvaliacao(2, int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
                DALRelacaoAvaliacao.Insert(relacaoavaliacao2);
            }
            else
            {
                Modelo.RelacaoAvaliacao relacaoavaliacao2 = new Modelo.RelacaoAvaliacao(2, int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
                DALRelacaoAvaliacao.Update(relacaoavaliacao2);
            }

        }

        protected void ImageButtonEstrela3_Click(object sender, ImageClickEventArgs e)
        {
            DAL.DALRelacaoAvaliacao DALRelacaoAvaliacao = new DAL.DALRelacaoAvaliacao();
            Modelo.RelacaoAvaliacao relacaoavaliacao = new Modelo.RelacaoAvaliacao(int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
            avaliacao = DALRelacaoAvaliacao.SelectValidar(relacaoavaliacao);

            /*DAL.DALPost DALPost = new DAL.DALPost();
            Modelo.Post post = new Modelo.Post(4, int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());*/

            if (avaliacao == false)
            {
                Modelo.RelacaoAvaliacao relacaoavaliacao2 = new Modelo.RelacaoAvaliacao(3, int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
                DALRelacaoAvaliacao.Insert(relacaoavaliacao2);
            }
            else
            {
                Modelo.RelacaoAvaliacao relacaoavaliacao2 = new Modelo.RelacaoAvaliacao(3, int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
                DALRelacaoAvaliacao.Update(relacaoavaliacao2);
            }


        }

        protected void ImageButtonEstrela4_Click(object sender, ImageClickEventArgs e)
        {
            DAL.DALRelacaoAvaliacao DALRelacaoAvaliacao = new DAL.DALRelacaoAvaliacao();
            Modelo.RelacaoAvaliacao relacaoavaliacao = new Modelo.RelacaoAvaliacao(int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
            avaliacao = DALRelacaoAvaliacao.SelectValidar(relacaoavaliacao);

            if (avaliacao == false)
            {
                Modelo.RelacaoAvaliacao relacaoavaliacao2 = new Modelo.RelacaoAvaliacao(4, int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
                DALRelacaoAvaliacao.Insert(relacaoavaliacao2);
            }
            else
            {
                Modelo.RelacaoAvaliacao relacaoavaliacao2 = new Modelo.RelacaoAvaliacao(4, int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
                DALRelacaoAvaliacao.Update(relacaoavaliacao2);
            }
        }

        protected void ImageButtonEstrela5_Click(object sender, ImageClickEventArgs e)
        {
            DAL.DALRelacaoAvaliacao DALRelacaoAvaliacao = new DAL.DALRelacaoAvaliacao();
            Modelo.RelacaoAvaliacao relacaoavaliacao = new Modelo.RelacaoAvaliacao(int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
            avaliacao = DALRelacaoAvaliacao.SelectValidar(relacaoavaliacao);

            if (avaliacao == false)
            {
                Modelo.RelacaoAvaliacao relacaoavaliacao2 = new Modelo.RelacaoAvaliacao(5, int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
                DALRelacaoAvaliacao.Insert(relacaoavaliacao2);
            }
            else
            {
                Modelo.RelacaoAvaliacao relacaoavaliacao2 = new Modelo.RelacaoAvaliacao(5, int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
                DALRelacaoAvaliacao.Update(relacaoavaliacao2);
            }
        }

        protected void ImageButtonEstrela6_Click(object sender, ImageClickEventArgs e)
        {
            DAL.DALRelacaoAvaliacao DALRelacaoAvaliacao = new DAL.DALRelacaoAvaliacao();
            Modelo.RelacaoAvaliacao relacaoavaliacao = new Modelo.RelacaoAvaliacao(int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
            avaliacao = DALRelacaoAvaliacao.SelectValidar(relacaoavaliacao);

            if (avaliacao == false)
            {
                Modelo.RelacaoAvaliacao relacaoavaliacao2 = new Modelo.RelacaoAvaliacao(6, int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
                DALRelacaoAvaliacao.Insert(relacaoavaliacao2);
            }
            else
            {
                Modelo.RelacaoAvaliacao relacaoavaliacao2 = new Modelo.RelacaoAvaliacao(6, int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
                DALRelacaoAvaliacao.Update(relacaoavaliacao2);
            }
        }

        protected void ImageButtonEstrela7_Click(object sender, ImageClickEventArgs e)
        {
            DAL.DALRelacaoAvaliacao DALRelacaoAvaliacao = new DAL.DALRelacaoAvaliacao();
            Modelo.RelacaoAvaliacao relacaoavaliacao = new Modelo.RelacaoAvaliacao(int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
            avaliacao = DALRelacaoAvaliacao.SelectValidar(relacaoavaliacao);

            if (avaliacao == false)
            {
                Modelo.RelacaoAvaliacao relacaoavaliacao2 = new Modelo.RelacaoAvaliacao(7, int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
                DALRelacaoAvaliacao.Insert(relacaoavaliacao2);
            }
            else
            {
                Modelo.RelacaoAvaliacao relacaoavaliacao2 = new Modelo.RelacaoAvaliacao(7, int.Parse(LabelFilme_id.Text), Session["usuario"].ToString());
                DALRelacaoAvaliacao.Update(relacaoavaliacao2);
            }
        }

        protected void LinkButtonUsuario_PreRender1(object sender, EventArgs e)
        {
            String usuarioLinkButton = (sender as LinkButton).Text;
            String usuarioSession = Session["usuario"].ToString();

            if (usuarioLinkButton == usuarioSession)
            {
                visibilidade = true;
            }
            else
            {
                visibilidade = false;
            }
        }

        protected void ImageButtonPositivar_Click(object sender, ImageClickEventArgs e)
        {
            DAL.DALAvaliacaoComentario DALAvaliacaoComentario = new DAL.DALAvaliacaoComentario();
            bool validar = DALAvaliacaoComentario.SelectValidarAvaliacaoComentario(int.Parse((sender as ImageButton).CommandName), Session["usuario"].ToString());
            int avaliacao = DALAvaliacaoComentario.SelectAvaliacaoComentario(int.Parse((sender as ImageButton).CommandName), Session["usuario"].ToString());

            if(validar == true)
            {
                if(avaliacao == 1)
                {
                    DALAvaliacaoComentario.Delete(int.Parse((sender as ImageButton).CommandName), Session["usuario"].ToString());
                }
                else
                {
                    DALAvaliacaoComentario.Update(1, int.Parse((sender as ImageButton).CommandName), Session["usuario"].ToString());
                }
            }
            else DALAvaliacaoComentario.Insert(1, int.Parse((sender as ImageButton).CommandName), Session["usuario"].ToString());
        }

        protected void ImageButtonNegativar_Click(object sender, ImageClickEventArgs e)
        {
            DAL.DALAvaliacaoComentario DALAvaliacaoComentario = new DAL.DALAvaliacaoComentario();
            bool validar = DALAvaliacaoComentario.SelectValidarAvaliacaoComentario(int.Parse((sender as ImageButton).CommandName), Session["usuario"].ToString());
            int avaliacao = DALAvaliacaoComentario.SelectAvaliacaoComentario(int.Parse((sender as ImageButton).CommandName), Session["usuario"].ToString());

            if(validar == true)
            {
                if(avaliacao == 0)
                {
                    DALAvaliacaoComentario.Delete(int.Parse((sender as ImageButton).CommandName), Session["usuario"].ToString());
                }
                else
                {
                    DALAvaliacaoComentario.Update(0, int.Parse((sender as ImageButton).CommandName), Session["usuario"].ToString());
                }
            }
            else DALAvaliacaoComentario.Insert(0, int.Parse((sender as ImageButton).CommandName), Session["usuario"].ToString());
        }

        protected void ImageButtonPositivar_PreRender(object sender, EventArgs e)
        {
            (sender as ImageButton).CommandName = comentario_id;
        }

        protected void ImageButtonNegativar_PreRender(object sender, EventArgs e)
        {
            (sender as ImageButton).CommandName = comentario_id;
        }

    }
}