using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoGrupo6.Modelo
{
    public class RelacaoInteresse
    {
        public int relacaointeresse_id { get; set; }
        public DateTime dataHora { get; set; }
        public int filme_id { get; set; }
        public string usuario { get; set; }
        public string caminhoImagem { get; set; }
        public string filme_name { get; set; }

        // Construtor
        public RelacaoInteresse()
        {
            this.relacaointeresse_id = 0;
            this.dataHora = DateTime.Now;
            this.filme_id = 0;
            this.usuario = "";
            this.caminhoImagem = "";
            this.filme_name = "";
        }
        public RelacaoInteresse(int afilme_id, string ausuario)
        {
            this.filme_id = afilme_id;
            this.usuario = ausuario;
        }
        public RelacaoInteresse(int afilme_id)
        {
            this.filme_id = afilme_id;
        }
        public RelacaoInteresse(string acaminhoImagem)
        {
            this.caminhoImagem = acaminhoImagem;
        }
        public RelacaoInteresse(string afilme_name, string acaminhoImagem)
        {
            this.filme_name = afilme_name;
            this.caminhoImagem = acaminhoImagem;
        }
    }
}