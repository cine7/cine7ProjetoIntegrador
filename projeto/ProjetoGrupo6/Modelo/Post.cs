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
        public DateTime dataHora { get; set; }
        public int filme_id { get; set; }
        public string usuario { get; set; }
        public string filme_name { get; set; }
        public string usuarioNome { get; set; }

        // Construtor
        public Post()
        {
            this.post_id = 0;
            this.tipo = 0;
            this.dataHora = DateTime.Now;
            this.filme_id = 0;
            this.usuario = "";
            this.filme_name = "";
        }
        public Post(int atipo, int afilme_id, string ausuario)
        {
            this.tipo = atipo;
            this.filme_id = afilme_id;
            this.usuario = ausuario;
        }
        public Post(int atipo, string afilme_name, string ausuario)
        {
            this.tipo = atipo;
            this.filme_name = afilme_name;
            this.usuario = ausuario;
        }
    }
}