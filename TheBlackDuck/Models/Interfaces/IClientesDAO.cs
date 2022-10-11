using System;
using System.Collections.Generic;
using System.Text;
using TheBlackDuck.Models.Objects;

namespace TheBlackDuck.Models.Interfaces
{
    internal interface IClientesDAO : ICRUD<clientes>
    {
        Boolean UpdateByID();
        List<clientes> ListAll();
        Boolean DeleteByID(int idCliente);
        clientes GetByID(int idCliente);
    }
}
