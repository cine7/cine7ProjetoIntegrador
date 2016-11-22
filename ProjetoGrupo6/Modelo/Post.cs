using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoGrupo6.Modelo
{
    public class Post
    {
        public int post_id { get; set; }
        public int tipo { get; set; }
        public int filme_id { get; set; }
        public string usuario { get; set; }

        // Construtor
        public Post()
        {
            this.post_id = 0;
            this.tipo = 0;
            this.filme_id = 0;
            this.usuario = "";
        }
        public Post(int apost_id, int atipo, int afilme_id, string ausuario)
        {
            this.post_id = apost_id;
            this.tipo = atipo;
            this.filme_id = afilme_id;
            this.usuario = ausuario;
        }
    }
}