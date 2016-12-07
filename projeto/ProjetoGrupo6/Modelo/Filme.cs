using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoGrupo6.Modelo
{
    public class Filme
    {
        public int filme_id { get; set; }
        public string filme_name { get; set; }
        public int ano { get; set; }
        public string sinopse { get; set; } 
        public string diretor { get; set; }
        public string produtora { get; set; }
        public int duracao { get; set; }
        public string caminhoImagem { get; set; }

        public Filme() 
        {
            this.filme_id = 0;
            this.filme_name = "";
            this.ano = 0;
            this.sinopse = "";
            this.diretor = "";
            this.produtora = "";
            this.duracao = 0;
            this.caminhoImagem = "";
        }
        public Filme(int afilme_id, string afilme_name, int aano, string asinopse, string adiretor, string aprodutora, int aduracao, string acaminhoImagem)
        {
            this.filme_id = afilme_id;
            this.filme_name = afilme_name;
            this.ano = aano;
            this.sinopse = asinopse;
            this.diretor = adiretor;
            this.produtora = aprodutora;
            this.duracao = aduracao;
            this.caminhoImagem = acaminhoImagem;
        }
        public Filme(int afilme_id, string afilme_name, int aano, string asinopse, string adiretor, string aprodutora, int aduracao)
        {
            this.filme_id = afilme_id;
            this.filme_name = afilme_name;
            this.ano = aano;
            this.sinopse = asinopse;
            this.diretor = adiretor;
            this.produtora = aprodutora;
            this.duracao = aduracao;
        }
        public Filme(string afilme_name, int aano, string asinopse, string adiretor, string aprodutora, int aduracao, string acaminhoImagem)
        {
            this.filme_name = afilme_name;
            this.ano = aano;
            this.sinopse = asinopse;
            this.diretor = adiretor;
            this.produtora = aprodutora;
            this.duracao = aduracao;
            this.caminhoImagem = acaminhoImagem;
        }
    }
}