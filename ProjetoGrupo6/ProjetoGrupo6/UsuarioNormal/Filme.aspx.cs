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
        bool visibilidade;
        string comentario_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            LabelFilme.Text = Request.QueryString["Filme"];
            string aSQLConecStr;

            // Lendo a conexão de dados do Web.Config
            aSQLConecStr = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;

            // Abrindo a Conexão com o banco de dados
            SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
            aSQLCon.Open();


            // Cria comando SQL
            SqlCommand cmd = aSQLCon.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "Select * FROM Filme where filme_name = @filme_name";
            cmd.Parameters.AddWithValue("@filme_name", LabelFilme.Text);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    LabelFilme_id.Text = dr["filme_id"].ToString();
                    LabelAno.Text = dr["ano"].ToString();
                    LabelSinopse.Text = dr["sinopse"].ToString();
                    LabelDiretor.Text = dr["diretor"].ToString();
                    LabelProdutora.Text = dr["produtora"].ToString();
                    LabelDuracao.Text = dr["duracao"].ToString();
                    // Adiciona o livro lido à lista
                }
            }

            dr.Close();
            aSQLCon.Close();

            Session["filme_id"] = int.Parse(LabelFilme_id.Text);


            //BotãoFavorito
            aSQLCon.Open();

            // Cria comando SQL
            SqlCommand cmd2 = aSQLCon.CreateCommand();
            // define SQL do comando
            cmd2.CommandText = "Select dataHora FROM RelacaoFavorito where filme_id = @filme_id and usuario = @usuario";
            cmd2.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
            cmd2.Parameters.AddWithValue("@usuario", Session["usuario"]);

            SqlDataReader dr2 = cmd2.ExecuteReader();
            if (dr2.HasRows)
            {
                while (dr2.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    if (dr2["dataHora"] != null)
                    {
                        ImageButtonFavorito.ImageUrl = "~/Imagens/desfavoritarButton.png";
                    }
                    else
                    {
                        ImageButtonFavorito.ImageUrl = "~/Imagens/favoritarButton.png";
                    }
                }
            }

            dr2.Close();
            aSQLCon.Close();


            //BotãoInteresse
            aSQLCon.Open();

            // Cria comando SQL
            SqlCommand cmd3 = aSQLCon.CreateCommand();
            // define SQL do comando
            cmd3.CommandText = "Select dataHora FROM RelacaoInteresse where filme_id = @filme_id and usuario = @usuario";
            cmd3.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
            cmd3.Parameters.AddWithValue("@usuario", Session["usuario"]);

            SqlDataReader dr3 = cmd3.ExecuteReader();
            if (dr3.HasRows)
            {
                while (dr3.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    if (dr3["dataHora"] != null)
                    {
                        ImageButtonInteresse.ImageUrl = "~/Imagens/cancelarInteresseButton.jpg";
                    }
                    else
                    {
                        ImageButtonInteresse.ImageUrl = "~/Imagens/tvInteresseButton.jpg";
                    }
                }
            }

            dr3.Close();
            aSQLCon.Close();


            //BotãoVisto
            aSQLCon.Open();

            // Cria comando SQL
            SqlCommand cmd4 = aSQLCon.CreateCommand();
            // define SQL do comando
            cmd4.CommandText = "Select dataHora FROM RelacaoVisto where filme_id = @filme_id and usuario = @usuario";
            cmd4.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
            cmd4.Parameters.AddWithValue("@usuario", Session["usuario"]);

            SqlDataReader dr4 = cmd4.ExecuteReader();
            if (dr4.HasRows)
            {
                while (dr4.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    if (dr4["dataHora"] != null)
                    {
                        ImageButtonVisto.ImageUrl = "~/Imagens/cancelarVisto.png";
                    }
                    else
                    {
                        ImageButtonVisto.ImageUrl = "~/Imagens/vistoButon.png";
                    }
                }
            }

            dr4.Close();
            aSQLCon.Close();

            /*ESTRELAS DE AVALIAÇÃO*/
            ImageButtonEstrela1.Attributes.Add("onmouseover", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaAcesa.jpg'");
            ImageButtonEstrela1.Attributes.Add("onmouseout", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaApagada.jpg'");

            ImageButtonEstrela2.Attributes.Add("onmouseover", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaAcesa.jpg'; ContentPlaceHolder1_ImageButtonEstrela2.src = '/Imagens/estrelaAcesa.jpg';");
            ImageButtonEstrela2.Attributes.Add("onmouseout", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaApagada.jpg'; ContentPlaceHolder1_ImageButtonEstrela2.src = '/Imagens/estrelaApagada.jpg';");

            ImageButtonEstrela3.Attributes.Add("onmouseover", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaAcesa.jpg'; ContentPlaceHolder1_ImageButtonEstrela2.src = '/Imagens/estrelaAcesa.jpg'; ContentPlaceHolder1_ImageButtonEstrela3.src = '/Imagens/estrelaAcesa.jpg';");
            ImageButtonEstrela3.Attributes.Add("onmouseout", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaApagada.jpg'; ContentPlaceHolder1_ImageButtonEstrela2.src = '/Imagens/estrelaApagada.jpg'; ContentPlaceHolder1_ImageButtonEstrela3.src = '/Imagens/estrelaApagada.jpg';");

            ImageButtonEstrela4.Attributes.Add("onmouseover", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaAcesa.jpg'; ContentPlaceHolder1_ImageButtonEstrela2.src = '/Imagens/estrelaAcesa.jpg'; ContentPlaceHolder1_ImageButtonEstrela3.src = '/Imagens/estrelaAcesa.jpg'; ContentPlaceHolder1_ImageButtonEstrela4.src = '/Imagens/estrelaAcesa.jpg';");
            ImageButtonEstrela4.Attributes.Add("onmouseout", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaApagada.jpg'; ContentPlaceHolder1_ImageButtonEstrela2.src = '/Imagens/estrelaApagada.jpg'; ContentPlaceHolder1_ImageButtonEstrela3.src = '/Imagens/estrelaApagada.jpg'; ContentPlaceHolder1_ImageButtonEstrela4.src = '/Imagens/estrelaApagada.jpg';");

            ImageButtonEstrela5.Attributes.Add("onmouseover", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaAcesa.jpg'; ContentPlaceHolder1_ImageButtonEstrela2.src = '/Imagens/estrelaAcesa.jpg'; ContentPlaceHolder1_ImageButtonEstrela3.src = '/Imagens/estrelaAcesa.jpg'; ContentPlaceHolder1_ImageButtonEstrela4.src = '/Imagens/estrelaAcesa.jpg'; ContentPlaceHolder1_ImageButtonEstrela5.src = '/Imagens/estrelaAcesa.jpg';");
            ImageButtonEstrela5.Attributes.Add("onmouseout", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaApagada.jpg'; ContentPlaceHolder1_ImageButtonEstrela2.src = '/Imagens/estrelaApagada.jpg'; ContentPlaceHolder1_ImageButtonEstrela3.src = '/Imagens/estrelaApagada.jpg'; ContentPlaceHolder1_ImageButtonEstrela4.src = '/Imagens/estrelaApagada.jpg'; ContentPlaceHolder1_ImageButtonEstrela5.src = '/Imagens/estrelaApagada.jpg';");

            ImageButtonEstrela6.Attributes.Add("onmouseover", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaAcesa.jpg'; ContentPlaceHolder1_ImageButtonEstrela2.src = '/Imagens/estrelaAcesa.jpg'; ContentPlaceHolder1_ImageButtonEstrela3.src = '/Imagens/estrelaAcesa.jpg'; ContentPlaceHolder1_ImageButtonEstrela4.src = '/Imagens/estrelaAcesa.jpg'; ContentPlaceHolder1_ImageButtonEstrela5.src = '/Imagens/estrelaAcesa.jpg'; ContentPlaceHolder1_ImageButtonEstrela6.src = '/Imagens/estrelaAcesa.jpg'; ContentPlaceHolder1_ImageButtonEstrela2.src = '/Imagens/estrelaAcesa.jpg';");
            ImageButtonEstrela6.Attributes.Add("onmouseout", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaApagada.jpg'; ContentPlaceHolder1_ImageButtonEstrela2.src = '/Imagens/estrelaApagada.jpg'; ContentPlaceHolder1_ImageButtonEstrela3.src = '/Imagens/estrelaApagada.jpg'; ContentPlaceHolder1_ImageButtonEstrela4.src = '/Imagens/estrelaApagada.jpg'; ContentPlaceHolder1_ImageButtonEstrela5.src = '/Imagens/estrelaApagada.jpg'; ContentPlaceHolder1_ImageButtonEstrela6.src = '/Imagens/estrelaApagada.jpg';");

            ImageButtonEstrela7.Attributes.Add("onmouseover", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaAcesa.jpg'; ContentPlaceHolder1_ImageButtonEstrela2.src = '/Imagens/estrelaAcesa.jpg'; ContentPlaceHolder1_ImageButtonEstrela3.src = '/Imagens/estrelaAcesa.jpg'; ContentPlaceHolder1_ImageButtonEstrela4.src = '/Imagens/estrelaAcesa.jpg'; ContentPlaceHolder1_ImageButtonEstrela5.src = '/Imagens/estrelaAcesa.jpg'; ContentPlaceHolder1_ImageButtonEstrela6.src = '/Imagens/estrelaAcesa.jpg'; ContentPlaceHolder1_ImageButtonEstrela7.src = '/Imagens/estrelaAcesa.jpg';");
            ImageButtonEstrela7.Attributes.Add("onmouseout", "ContentPlaceHolder1_ImageButtonEstrela1.src = '/Imagens/estrelaApagada.jpg'; ContentPlaceHolder1_ImageButtonEstrela2.src = '/Imagens/estrelaApagada.jpg'; ContentPlaceHolder1_ImageButtonEstrela3.src = '/Imagens/estrelaApagada.jpg'; ContentPlaceHolder1_ImageButtonEstrela4.src = '/Imagens/estrelaApagada.jpg'; ContentPlaceHolder1_ImageButtonEstrela5.src = '/Imagens/estrelaApagada.jpg'; ContentPlaceHolder1_ImageButtonEstrela6.src = '/Imagens/estrelaApagada.jpg'; ContentPlaceHolder1_ImageButtonEstrela7.src = '/Imagens/estrelaApagada.jpg';");

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
            if (ImageButtonFavorito.ImageUrl == "~/Imagens/desfavoritarButton.png")
            {
                string aSQLConecStr;

                // Lendo a conexão de dados do Web.Config
                aSQLConecStr = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;

                // Abrindo a Conexão com o banco de dados
                SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
                aSQLCon.Open();

                // Executando o comando
                SqlCommand aSQL = new SqlCommand("DELETE FROM RelacaoFavorito WHERE filme_id = @filme_id and usuario = @usuario", aSQLCon);
                aSQL.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
                aSQL.Parameters.AddWithValue("@usuario", Session["usuario"].ToString());
                aSQL.ExecuteNonQuery();
                ImageButtonFavorito.ImageUrl = "~/Imagens/favoritarButton.png";
            }
            else
            {
                string aSQLConecStr;

                // Lendo a conexão de dados do Web.Config
                aSQLConecStr = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;

                // Abrindo a Conexão com o banco de dados
                SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
                aSQLCon.Open();

                // Executando o comando
                SqlCommand aSQL = new SqlCommand("INSERT INTO RelacaoFavorito(filme_id, usuario) VALUES (@filme_id, @usuario)", aSQLCon);
                aSQL.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
                aSQL.Parameters.AddWithValue("@usuario", Session["usuario"].ToString());
                aSQL.ExecuteNonQuery();
                ImageButtonFavorito.ImageUrl = "~/Imagens/desfavoritarButton.png";

            }
        }

        protected void LinkButtonApagar_Click(object sender, EventArgs e)
        {
        }

        protected void ImageButtonVisto_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButtonVisto.ImageUrl == "~/Imagens/cancelarVisto.png")
            {
                string aSQLConecStr;

                // Lendo a conexão de dados do Web.Config
                aSQLConecStr = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;

                // Abrindo a Conexão com o banco de dados
                SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
                aSQLCon.Open();

                // Executando o comando
                SqlCommand aSQL = new SqlCommand("DELETE FROM RelacaoVisto WHERE filme_id = @filme_id and usuario = @usuario", aSQLCon);
                aSQL.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
                aSQL.Parameters.AddWithValue("@usuario", Session["usuario"].ToString());
                aSQL.ExecuteNonQuery();
                ImageButtonVisto.ImageUrl = "~/Imagens/vistoButton.jpg";
            }
            else
            {
                string aSQLConecStr;

                // Lendo a conexão de dados do Web.Config
                aSQLConecStr = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;

                // Abrindo a Conexão com o banco de dados
                SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
                aSQLCon.Open();

                // Executando o comando
                SqlCommand aSQL = new SqlCommand("INSERT INTO RelacaoVisto(filme_id, usuario) VALUES (@filme_id, @usuario)", aSQLCon);
                aSQL.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
                aSQL.Parameters.AddWithValue("@usuario", Session["usuario"].ToString());
                aSQL.ExecuteNonQuery();
                ImageButtonVisto.ImageUrl = "~/Imagens/cancelarVisto.png";

            }
        }

        protected void ImageButtonInteresse_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButtonInteresse.ImageUrl == "~/Imagens/cancelarInteresseButton.jpg")
            {
                string aSQLConecStr;

                // Lendo a conexão de dados do Web.Config
                aSQLConecStr = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;

                // Abrindo a Conexão com o banco de dados
                SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
                aSQLCon.Open();

                // Executando o comando
                SqlCommand aSQL = new SqlCommand("DELETE FROM RelacaoInteresse WHERE filme_id = @filme_id and usuario = @usuario", aSQLCon);
                aSQL.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
                aSQL.Parameters.AddWithValue("@usuario", Session["usuario"].ToString());
                aSQL.ExecuteNonQuery();
                ImageButtonInteresse.ImageUrl = "~/Imagens/tvInteresseButton.jpg";
            }
            else
            {
                string aSQLConecStr;

                // Lendo a conexão de dados do Web.Config
                aSQLConecStr = ConfigurationManager.ConnectionStrings["2016TiiGrupo6ConnectionString"].ConnectionString;

                // Abrindo a Conexão com o banco de dados
                SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
                aSQLCon.Open();

                // Executando o comando
                SqlCommand aSQL = new SqlCommand("INSERT INTO RelacaoInteresse(filme_id, usuario) VALUES (@filme_id, @usuario)", aSQLCon);
                aSQL.Parameters.AddWithValue("@filme_id", int.Parse(LabelFilme_id.Text));
                aSQL.Parameters.AddWithValue("@usuario", Session["usuario"].ToString());
                aSQL.ExecuteNonQuery();
                ImageButtonInteresse.ImageUrl = "~/Imagens/cancelarInteresseButton.jpg";

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

            /*string comentario_id = "a";
            int index = Convert.ToInt32(comentario_id);*/

            // Copia o conteúdo da primeira célula da linha -> Código do Livro
            //string filme = this.DataList1;
            //Rows[index].Cells[0].Text;


            /*Label comentario = (Label)DataList1.FindControl("comentario_idLabel");
            string comentario_id = comentario.Text;*/

            // Grava código do Livro na sessão
            //Session["filme_name"] = filme;

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

    }
}