using System;
using System.Collections.Generic;
using System.Text;
using TheBlackDuck.Models.Objects;

namespace TheBlackDuck.Models.Interfaces
{
    internal interface IClientesPagosDAO
    {
        Boolean UpdateByID(int idClientePagos, double montoPagos, DateTime fechaPago, int estadoPago);
        List<clientesPagos> ListAll();
        Boolean DeleteByID(int idClientePago);
        clientesPagos GetByID(int idClientePago);
    }
}
