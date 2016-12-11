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
	    public int post_id { get; set; }
        public string usuarioComentario { get; set; }

        public ComentarioPost() 
        {
            this.comentariopost_id = 0;
            this.descricao = "";
            this.dataHora = DateTime.Now;
            this.post_id = 0;
            this.usuarioComentario = "";
        }

        public ComentarioPost(int acomentariopost_id, DateTime adataHora, string adescricao, int apost_id, string ausuarioComentario)
        {
            this.comentariopost_id = acomentariopost_id;
            this.dataHora = adataHora;
            this.descricao = adescricao;
            this.post_id = apost_id;
            this.usuarioComentario = ausuarioComentario;
        }

        public ComentarioPost(string adescricao, int apost_id, string ausuarioComentario) 
        {
            this.descricao = adescricao;
            this.post_id = apost_id;
            this.usuarioComentario = ausuarioComentario;
        }
    }
}