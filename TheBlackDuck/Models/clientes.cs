using System;
using System.Collections.Generic;
using System.Text;

namespace TheBlackDuck.Models
{
    internal class clientes
    {
        public int idCliente;
        public string clienteHijo;
        public string clientePadre;
        public int idClientePago;
        public int clienteNumero;
        public string clienteContrasena;

        public clientes(int idCliente, string clienteHijo, string clientePadre, int idClientePago, int clienteNumero, string clienteContrasena)
        {
            this.idCliente = idCliente;
            this.clienteHijo = clienteHijo;
            this.clientePadre = clientePadre;
            this.idClientePago = idClientePago;
            this.clienteNumero = clienteNumero;
            this.clienteContrasena = clienteContrasena;
        }

        public int IdCliente { get => idCliente; set => idCliente = value; }

        public string ClienteHijo { get => clienteHijo; set => clienteHijo = value; }

        public string ClientePadre { get => clientePadre; set => clientePadre = value; }

        public int IdClientePago { get => idClientePago; set => idClientePago = value; }

        public int ClienteNumero { get => clienteNumero; set => clienteNumero = value; }

        public string ClienteContrasena { get => clienteContrasena; set => clienteContrasena = value; }



    }
}
