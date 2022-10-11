using System;
using System.Collections.Generic;
using System.Text;
using TheBlackDuck.Models.Objects;

namespace TheBlackDuck.Models.Interfaces
{
    internal interface ISuperAdministradoresDAO : ICRUD<superadministradores>
    {
        Boolean UpdateByID(int idSuperAdmin, string superAdminUsuario, string superAdminContrasena);
        List<superadministradores> ListAll();
        Boolean DeleteByID(int idSuperAdministrador);
        superadministradores GetByID(int idSuperAdministrador);
    }
}
