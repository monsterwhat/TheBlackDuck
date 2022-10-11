using System;
using System.Collections.Generic;
using System.Text;
using TheBlackDuck.Models.Objects;

namespace TheBlackDuck.Models.Interfaces
{
    internal interface IClientesPagosDAO : ICRUD<clientesPagos>
    {
        Boolean UpdateByID();
        List<clientesPagos> ListAll();
        Boolean DeleteByID(int idClientePago);
        clientesPagos GetByID(int idClientePago);
    }
}
