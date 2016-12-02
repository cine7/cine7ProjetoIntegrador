using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoGrupo6.Modelo
{
    public class AvaliacaoComentario
    {
        public int avaliacaocomentario_id { get; set; }
	    public int avaliacao { get; set; }
	    public DateTime dataHora { get; set; }
	    public int comentario_id { get; set; }
        public string usuarioAvaliador { get; set; }

        public AvaliacaoComentario() 
        {
            this.avaliacaocomentario_id = 0;
            this.avaliacao = 0;
            this.dataHora = DateTime.Now;
            this.comentario_id = 0;
            this.usuarioAvaliador = "";
        }

        public AvaliacaoComentario(int aavaliacao, int acomentario_id, string ausuarioAvaliador) 
        {
            this.avaliacao = aavaliacao;
            this.comentario_id = acomentario_id;
            this.usuarioAvaliador = ausuarioAvaliador;
        }
    }
}