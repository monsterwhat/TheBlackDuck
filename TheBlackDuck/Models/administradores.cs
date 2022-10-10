using System;
using System.Collections.Generic;
using System.Text;

namespace TheBlackDuck.Models
{
    internal class administradores
    {
        public int idAdministrador;
        public string administradorescol;
        public string adminUsuario;
        public string adminContrasena;

        public administradores(int idAdministrador, string administradorescol, string adminUsuario, string adminContrasena)
        {
            this.idAdministrador = idAdministrador;
            this.administradorescol = administradorescol;
            this.adminUsuario = adminUsuario;
            this.adminContrasena = adminContrasena;
        }

        public int IdAdministrador { get => idAdministrador; set => idAdministrador = value; }

        public string AdministradoresCol { get => administradorescol; set => administradorescol = value; }

        public string AdminUsuario { get => adminUsuario; set => adminUsuario = value; }

        public string AdminContrasena { get => adminContrasena; set => adminContrasena = value; }

    }
}
