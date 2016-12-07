using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoGrupo6.Modelo
{
    public class RelacaoAvaliacao
    {
        public int relacaoavaliacao_id { get; set; }
        public DateTime dataHora { get; set; }
        public int avaliacao { get; set; }
        public int filme_id { get; set; }
        public string usuario { get; set; }

        // Construtor
        public RelacaoAvaliacao()
        {
            this.relacaoavaliacao_id = 0;
            this.dataHora = DateTime.Now;
            this.avaliacao = 0;
            this.filme_id = 0;
            this.usuario = "";
        }
        public RelacaoAvaliacao(int aavaliacao, int afilme_id, string ausuario)
        {
            this.avaliacao = aavaliacao;
            this.filme_id = afilme_id;
            this.usuario = ausuario;
        }
        public RelacaoAvaliacao(int afilme_id, string ausuario)
        {
            this.filme_id = afilme_id;
            this.usuario = ausuario;
        }
        public RelacaoAvaliacao(int afilme_id)
        {
            this.filme_id = afilme_id;
        }
    }
}