using System;
using System.Collections.Generic;
using System.Text;

namespace TheBlackDuck.Models.Objects
{
    public class clientesPagos
    {
        public int idClientePagos;
        public double montoPagos;
        public DateTime fechaPago;
        public int estadoPago;

        public clientesPagos(int idClientePagos, double montoPagos, DateTime fechaPago, int estadoPago)
        {
            this.idClientePagos = idClientePagos;
            this.montoPagos = montoPagos;
            this.fechaPago = fechaPago;
            this.estadoPago = estadoPago;
        }

        public clientesPagos()
        {
        }

        public int IdClientePagos
        {
            get => idClientePagos; set => idClientePagos = value;
        }

        public double MontoPagos
        {
            get => montoPagos; set => montoPagos = value;
        }

        public DateTime FechaPago
        {
            get => fechaPago; set => fechaPago = value;
        }

        public int EstadoPago
        {
            get => estadoPago; set => estadoPago = value;
        }

    }
}
