using System;

namespace SyncBlackDuck.Model.Objetos
{
    public class pagos
    {

        private int pagos_id;
        private DateTime pagos_fecha;
        private int pagos_estado;

        public pagos(int pagos_id, DateTime pagos_fecha, int pagos_estado)
        {
            this.pagos_id = pagos_id;
            this.pagos_fecha = pagos_fecha;
            this.pagos_estado = pagos_estado;
        }

        public pagos()
        {
        }

        public int Pagos_id { get => pagos_id; set => pagos_id = value; }
        public DateTime Pagos_fecha { get => pagos_fecha; set => pagos_fecha = value; }
        public int Pagos_estado { get => pagos_estado; set => pagos_estado = value; }



    }
}
