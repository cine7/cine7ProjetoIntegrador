using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoGrupo6.Modelo
{
    public class RelacaoVisto
    {
        public int comentario_id { get; set; }
        public DateTime dataHora { get; set; }
        public int filme_id { get; set; }
        public string usuario { get; set; }

        // Construtor
        public RelacaoVisto()
        {
            this.comentario_id = 0;
            this.dataHora = DateTime.Now;
            this.filme_id = 0;
            this.usuario = "";
        }
        public RelacaoVisto(int acomentario_id, string adescricao, DateTime adataHora, int afilme_id, string ausuario)
        {
            this.comentario_id = acomentario_id;
            this.dataHora = adataHora;
            this.filme_id = afilme_id;
            this.usuario = ausuario;
        }
    }
}