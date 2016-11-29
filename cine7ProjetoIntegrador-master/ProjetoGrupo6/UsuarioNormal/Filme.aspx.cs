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
            string aSQLConecStr;

            // Lendo a conexão de dados do Web.Config
            aSQLConecStr = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;

            // Abrindo a Conexão com o banco de dados
            SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
            

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
                ImageButtonVisto.ImageUrl = "~/Imagens/vistoButon.png";
            }

            /*ESTRELAS DE AVALIAÇÃO*/
            ImageButtonEstrela1.Attributes.Add("onmouseover", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaAcesa.png'");
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
            // Executando o comando
            // Cria comando SQL
            aSQLCon.Open();
            SqlCommand cmd5 = aSQLCon.CreateCommand();
            // define SQL do comando
            cmd5.CommandText = "Select avaliacao FROM RelacaoAvaliacao where filme_id = @filme_id and usuario = @usuario";
            cmd5.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
            cmd5.Parameters.AddWithValue("@usuario", Session["usuario"]);

            SqlDataReader dr5 = cmd5.ExecuteReader();
            if (dr5.HasRows)
            {
                while (dr5.Read()) // Le o proximo registro
                {
                    avaliacaoInt = Convert.ToInt32(dr5["avaliacao"]);
                }
            }

            dr5.Close();

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

            dr5.Close();

            aSQLCon.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string aSQLConecStr;

            // Lendo a conexão de dados do Web.Config
            aSQLConecStr = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;

            // Abrindo a Conexão com o banco de dados
            SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
            aSQLCon.Open();

            // Executando o comando
            // Executando o comando
            SqlCommand aSQL = new SqlCommand("INSERT INTO Comentario(descricao, usuario, filme_id) VALUES (@descricao, @usuario, @filme_id)", aSQLCon);
            aSQL.Parameters.AddWithValue("@descricao", TextBoxComentario.Text);
            aSQL.Parameters.AddWithValue("@usuario", Session["usuario"].ToString());
            aSQL.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
            aSQL.ExecuteNonQuery();
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
            string aSQLConecStr;

            // Lendo a conexão de dados do Web.Config
            aSQLConecStr = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;

            // Abrindo a Conexão com o banco de dados
            SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
            aSQLCon.Open();

            SqlCommand aSQL = new SqlCommand("DELETE FROM Comentario WHERE comentario_id = @comentario_id", aSQLCon);
            aSQL.Parameters.AddWithValue("@comentario_id", int.Parse((sender as LinkButton).CommandName));

            aSQL.ExecuteNonQuery();
            Response.Redirect("~/UsuarioNormal/Filme.aspx?Filme=" + Session["filme_name"]);
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
            string aSQLConecStr;

            // Lendo a conexão de dados do Web.Config
            aSQLConecStr = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;

            // Abrindo a Conexão com o banco de dados
            SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
            aSQLCon.Open();

            // Executando o comando
            SqlCommand aSQL = aSQLCon.CreateCommand();;
            aSQL.CommandText = "SELECT dataHora FROM RelacaoAvaliacao where filme_id = @filme_id and usuario = @usuario";
            aSQL.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
            aSQL.Parameters.AddWithValue("@usuario", Session["usuario"]);

            SqlDataReader dr = aSQL.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    if (dr["dataHora"] != null)
                    {
                        avaliacao = true;
                    }
                    else
                    {
                        avaliacao = false;
                    }
                }
            }

            dr.Close();

            if (avaliacao == false)
            {
                SqlCommand aSQL1 = new SqlCommand("INSERT INTO RelacaoAvaliacao(filme_id, usuario, avaliacao) VALUES (@filme_id, @usuario, 1)", aSQLCon);
                aSQL1.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
                aSQL1.Parameters.AddWithValue("@usuario", Session["usuario"].ToString());
                aSQL1.ExecuteNonQuery();
            }
            else
            {
                SqlCommand aSQL2 = new SqlCommand("UPDATE RelacaoAvaliacao set avaliacao = 1 where filme_id = @filme_id and usuario = @usuario", aSQLCon);
                aSQL2.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
                aSQL2.Parameters.AddWithValue("@usuario", Session["usuario"].ToString());
                aSQL2.ExecuteNonQuery();
            }

        }

        protected void ImageButtonEstrela2_Click(object sender, ImageClickEventArgs e)
        {
            string aSQLConecStr;

            // Lendo a conexão de dados do Web.Config
            aSQLConecStr = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;

            // Abrindo a Conexão com o banco de dados
            SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
            aSQLCon.Open();

            // Executando o comando
            SqlCommand aSQL = aSQLCon.CreateCommand();
            aSQL.CommandText = "SELECT dataHora FROM RelacaoAvaliacao where filme_id = @filme_id and usuario = @usuario";
            aSQL.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
            aSQL.Parameters.AddWithValue("@usuario", Session["usuario"]);

            SqlDataReader dr = aSQL.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    if (dr["dataHora"] != null)
                    {
                        avaliacao = true;
                    }
                    else
                    {
                        avaliacao = false;
                    }
                }
            }

            dr.Close();

            if (avaliacao == false)
            {
                SqlCommand aSQL1 = new SqlCommand("INSERT INTO RelacaoAvaliacao(filme_id, usuario, avaliacao) VALUES (@filme_id, @usuario, 2)", aSQLCon);
                aSQL1.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
                aSQL1.Parameters.AddWithValue("@usuario", Session["usuario"].ToString());
                aSQL1.ExecuteNonQuery();
            }
            else
            {
                SqlCommand aSQL2 = new SqlCommand("UPDATE RelacaoAvaliacao set avaliacao = 2 where filme_id = @filme_id and usuario = @usuario", aSQLCon);
                aSQL2.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
                aSQL2.Parameters.AddWithValue("@usuario", Session["usuario"].ToString());
                aSQL2.ExecuteNonQuery();
            }
        }

        protected void ImageButtonEstrela3_Click(object sender, ImageClickEventArgs e)
        {
            string aSQLConecStr;

            // Lendo a conexão de dados do Web.Config
            aSQLConecStr = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;

            // Abrindo a Conexão com o banco de dados
            SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
            aSQLCon.Open();

            // Executando o comando
            SqlCommand aSQL = aSQLCon.CreateCommand(); ;
            aSQL.CommandText = "SELECT dataHora FROM RelacaoAvaliacao where filme_id = @filme_id and usuario = @usuario";
            aSQL.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
            aSQL.Parameters.AddWithValue("@usuario", Session["usuario"]);

            SqlDataReader dr = aSQL.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    if (dr["dataHora"] != null)
                    {
                        avaliacao = true;
                    }
                    else
                    {
                        avaliacao = false;
                    }
                }
            }

            dr.Close();

            if (avaliacao == false)
            {
                SqlCommand aSQL1 = new SqlCommand("INSERT INTO RelacaoAvaliacao(filme_id, usuario, avaliacao) VALUES (@filme_id, @usuario, 3)", aSQLCon);
                aSQL1.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
                aSQL1.Parameters.AddWithValue("@usuario", Session["usuario"].ToString());
                aSQL1.ExecuteNonQuery();
            }
            else
            {
                SqlCommand aSQL2 = new SqlCommand("UPDATE RelacaoAvaliacao set avaliacao = 3 where filme_id = @filme_id and usuario = @usuario", aSQLCon);
                aSQL2.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
                aSQL2.Parameters.AddWithValue("@usuario", Session["usuario"].ToString());
                aSQL2.ExecuteNonQuery();
            }
        }

        protected void ImageButtonEstrela4_Click(object sender, ImageClickEventArgs e)
        {
            string aSQLConecStr;

            // Lendo a conexão de dados do Web.Config
            aSQLConecStr = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;

            // Abrindo a Conexão com o banco de dados
            SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
            aSQLCon.Open();

            // Executando o comando
            SqlCommand aSQL = aSQLCon.CreateCommand(); ;
            aSQL.CommandText = "SELECT dataHora FROM RelacaoAvaliacao where filme_id = @filme_id and usuario = @usuario";
            aSQL.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
            aSQL.Parameters.AddWithValue("@usuario", Session["usuario"]);

            SqlDataReader dr = aSQL.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    if (dr["dataHora"] != null)
                    {
                        avaliacao = true;
                    }
                    else
                    {
                        avaliacao = false;
                    }
                }
            }

            dr.Close();

            if (avaliacao == false)
            {
                SqlCommand aSQL1 = new SqlCommand("INSERT INTO RelacaoAvaliacao(filme_id, usuario, avaliacao) VALUES (@filme_id, @usuario, 4)", aSQLCon);
                aSQL1.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
                aSQL1.Parameters.AddWithValue("@usuario", Session["usuario"].ToString());
                aSQL1.ExecuteNonQuery();
            }
            else
            {
                SqlCommand aSQL2 = new SqlCommand("UPDATE RelacaoAvaliacao set avaliacao = 4 where filme_id = @filme_id and usuario = @usuario", aSQLCon);
                aSQL2.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
                aSQL2.Parameters.AddWithValue("@usuario", Session["usuario"].ToString());
                aSQL2.ExecuteNonQuery();
            }
        }

        protected void ImageButtonEstrela5_Click(object sender, ImageClickEventArgs e)
        {
            string aSQLConecStr;

            // Lendo a conexão de dados do Web.Config
            aSQLConecStr = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;

            // Abrindo a Conexão com o banco de dados
            SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
            aSQLCon.Open();

            // Executando o comando
            SqlCommand aSQL = aSQLCon.CreateCommand(); ;
            aSQL.CommandText = "SELECT dataHora FROM RelacaoAvaliacao where filme_id = @filme_id and usuario = @usuario";
            aSQL.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
            aSQL.Parameters.AddWithValue("@usuario", Session["usuario"]);

            SqlDataReader dr = aSQL.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    if (dr["dataHora"] != null)
                    {
                        avaliacao = true;
                    }
                    else
                    {
                        avaliacao = false;
                    }
                }
            }

            dr.Close();

            if (avaliacao == false)
            {
                SqlCommand aSQL1 = new SqlCommand("INSERT INTO RelacaoAvaliacao(filme_id, usuario, avaliacao) VALUES (@filme_id, @usuario, 5)", aSQLCon);
                aSQL1.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
                aSQL1.Parameters.AddWithValue("@usuario", Session["usuario"].ToString());
                aSQL1.ExecuteNonQuery();
            }
            else
            {
                SqlCommand aSQL2 = new SqlCommand("UPDATE RelacaoAvaliacao set avaliacao = 5 where filme_id = @filme_id and usuario = @usuario", aSQLCon);
                aSQL2.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
                aSQL2.Parameters.AddWithValue("@usuario", Session["usuario"].ToString());
                aSQL2.ExecuteNonQuery();
            }
        }

        protected void ImageButtonEstrela6_Click(object sender, ImageClickEventArgs e)
        {
            string aSQLConecStr;

            // Lendo a conexão de dados do Web.Config
            aSQLConecStr = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;

            // Abrindo a Conexão com o banco de dados
            SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
            aSQLCon.Open();

            // Executando o comando
            SqlCommand aSQL = aSQLCon.CreateCommand(); ;
            aSQL.CommandText = "SELECT dataHora FROM RelacaoAvaliacao where filme_id = @filme_id and usuario = @usuario";
            aSQL.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
            aSQL.Parameters.AddWithValue("@usuario", Session["usuario"]);

            SqlDataReader dr = aSQL.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    if (dr["dataHora"] != null)
                    {
                        avaliacao = true;
                    }
                    else
                    {
                        avaliacao = false;
                    }
                }
            }

            dr.Close();

            if (avaliacao == false)
            {
                SqlCommand aSQL1 = new SqlCommand("INSERT INTO RelacaoAvaliacao(filme_id, usuario, avaliacao) VALUES (@filme_id, @usuario, 6)", aSQLCon);
                aSQL1.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
                aSQL1.Parameters.AddWithValue("@usuario", Session["usuario"].ToString());
                aSQL1.ExecuteNonQuery();
            }
            else
            {
                SqlCommand aSQL2 = new SqlCommand("UPDATE RelacaoAvaliacao set avaliacao = 6 where filme_id = @filme_id and usuario = @usuario", aSQLCon);
                aSQL2.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
                aSQL2.Parameters.AddWithValue("@usuario", Session["usuario"].ToString());
                aSQL2.ExecuteNonQuery();
            }
        }

        protected void ImageButtonEstrela7_Click(object sender, ImageClickEventArgs e)
        {
            string aSQLConecStr;

            // Lendo a conexão de dados do Web.Config
            aSQLConecStr = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;

            // Abrindo a Conexão com o banco de dados
            SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
            aSQLCon.Open();

            // Executando o comando
            SqlCommand aSQL = aSQLCon.CreateCommand(); ;
            aSQL.CommandText = "SELECT dataHora FROM RelacaoAvaliacao where filme_id = @filme_id and usuario = @usuario";
            aSQL.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
            aSQL.Parameters.AddWithValue("@usuario", Session["usuario"]);

            SqlDataReader dr = aSQL.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    if (dr["dataHora"] != null)
                    {
                        avaliacao = true;
                    }
                    else
                    {
                        avaliacao = false;
                    }
                }
            }

            dr.Close();

            if (avaliacao == false)
            {
                SqlCommand aSQL1 = new SqlCommand("INSERT INTO RelacaoAvaliacao(filme_id, usuario, avaliacao) VALUES (@filme_id, @usuario, 7)", aSQLCon);
                aSQL1.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
                aSQL1.Parameters.AddWithValue("@usuario", Session["usuario"].ToString());
                aSQL1.ExecuteNonQuery();
            }
            else
            {
                SqlCommand aSQL2 = new SqlCommand("UPDATE RelacaoAvaliacao set avaliacao = 7 where filme_id = @filme_id and usuario = @usuario", aSQLCon);
                aSQL2.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
                aSQL2.Parameters.AddWithValue("@usuario", Session["usuario"].ToString());
                aSQL2.ExecuteNonQuery();
            }
        }

    }
}