using System;
using System.Collections.Generic;
using System.Text;
using TheBlackDuck.Models.Objects;

namespace TheBlackDuck.Models.Interfaces
{
    internal interface IClientesDAO
    {
        Boolean UpdateByID(int idCliente, string clienteHijo, string clientePadre, int idClientePago, int clienteNumero, string clienteContrasena);
        List<clientes> ListAll();
        Boolean DeleteByID(int idCliente);
        clientes GetByID(int idCliente);
    }
}
