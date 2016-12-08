using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoGrupo6.Modelo
{
    public class aspnet_Users
    {
        public string userName { get; set; }

        public aspnet_Users()
        {
            this.userName = "";
        }

        public aspnet_Users(string auserName)
        {
            this.userName = auserName;
        }
    }
}
