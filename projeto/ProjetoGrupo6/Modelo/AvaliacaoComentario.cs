using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoGrupo6.Modelo
{
    public class AvaliacaoComentario
    {
        public int avaliacaopost_id { get; set; }
	    public int avaliacao { get; set; }
	    public DateTime dataHora { get; set; }
	    public int comentario_id { get; set; }
        public string usuarioAvaliador { get; set; }

        public AvaliacaoComentario() 
        {
            this.avaliacaopost_id = 0;
            this.avaliacao = 0;
            this.dataHora = DateTime.Now;
            this.comentario_id = 0;
            this.usuarioAvaliador = "";
        }

        public AvaliacaoComentario(int aavaliacao, int aavaliacaopost_id, string ausuarioAvaliador) 
        {
            this.avaliacao = aavaliacao;
            this.avaliacaopost_id = aavaliacaopost_id;
            this.usuarioAvaliador = ausuarioAvaliador;
        }
    }
}