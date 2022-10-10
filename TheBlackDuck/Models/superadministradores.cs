using System;
using System.Collections.Generic;
using System.Text;

namespace TheBlackDuck.Models
{
    internal class superadministradores
    {
        public int idSuperAdmin;
        public string superAdminUsuario;
        public string superAdminContrasena;

        public superadministradores(int idSuperAdmin, string superAdminUsuario, string superAdminContrasena)
        {
            this.idSuperAdmin = idSuperAdmin;
            this.superAdminUsuario = superAdminUsuario;
            this.superAdminContrasena = superAdminContrasena;
        }

        public int IdSuperAdmin { get => idSuperAdmin; set => idSuperAdmin = value; }
        public string SuperAdminUsuario { get => superAdminUsuario; set => superAdminUsuario = value; }
        public string SuperAdminContrasena { get => superAdminContrasena; set => superAdminContrasena = value; }


    }
}
