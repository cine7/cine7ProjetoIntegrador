using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoGrupo6.Modelo
{
    public class aspnet_UsersInRoles
    {
        public string roleId { get; set; }

        public aspnet_UsersInRoles()
        {
            this.roleId = "";
        }

        public aspnet_UsersInRoles(string aroleId)
        {
            this.roleId = aroleId;
        }
    }
}