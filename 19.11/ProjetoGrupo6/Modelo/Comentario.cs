﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoGrupo6.Modelo
{
    public class Comentario
    {
        public int comentario_id { get; set; }
        public string descricao { get; set; }
        public DateTime data { get; set; }
        public int filme_id { get; set; }
        public string usuario { get; set; }

        // Construtor
        public Comentario()
        {
            this.comentario_id = 0;
            this.descricao = "";
            this.data = DateTime.Now;
            this.filme_id = 0;
            this.usuario = "";
        }
        public Comentario(int acomentario_id, string adescricao, DateTime adata, int afilme_id, string ausuario)
        {
            this.comentario_id = acomentario_id;
            this.descricao = adescricao;
            this.data = adata;
            this.filme_id = afilme_id;
            this.usuario = ausuario;
        }

    }
}