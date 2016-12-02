using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoGrupo6.Modelo
{
    public class ComentarioPost
    {
        public int comentariopost_id { get; set; }
	    public string descricao { get; set; }
	    public DateTime dataHora { get; set; }
	    public int comentario_id { get; set; }
        public string usuarioComentario { get; set; }

        public ComentarioPost() 
        {
            this.comentariopost_id = 0;
            this.descricao = "";
            this.dataHora = DateTime.Now;
            this.comentario_id = 0;
            this.usuarioComentario = "";
        }

        public ComentarioPost(string adescricao, int acomentario_id, string ausuarioComentario) 
        {
            this.descricao = adescricao;
            this.comentario_id = acomentario_id;
            this.usuarioComentario = ausuarioComentario;
        }
    }
}