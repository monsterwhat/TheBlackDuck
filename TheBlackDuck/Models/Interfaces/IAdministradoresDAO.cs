using System;
using System.Collections.Generic;
using System.Text;
using TheBlackDuck.Models.Objects;

namespace TheBlackDuck.Models.Interfaces
{
    internal interface IAdministradoresDAO
    {
        Boolean UpdateByID(int idAdministrador, string administradorescol, string adminUsuario, string adminContrasena);
        List<administradores> ListAll();
        Boolean DeleteByID(int idAdministrador);
        administradores GetByID(int idAdministrador);
    }
}
