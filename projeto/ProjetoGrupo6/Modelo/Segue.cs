using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoGrupo6.Modelo
{
    public class Segue
    {
        public int segue_id { get; set; }
        public string usuarioSeguido { get; set; }
        public string usuarioSeguidor { get; set; }

        public Segue() 
        {
            this.segue_id = 0;
            this.usuarioSeguido = "";
            this.usuarioSeguidor = "";
        }

        public Segue(string ausuarioSeguido, string ausuarioSeguidor) 
        {
            this.usuarioSeguido = ausuarioSeguido;
            this.usuarioSeguidor = ausuarioSeguidor;
        }
    }
}