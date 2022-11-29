using MySqlConnector;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SyncBlackDuck.Model.Objetos
{
    public class Pagos : INotifyPropertyChanged
    {

        private int pagos_id;
        private DateTime pagos_fecha;
        private int pagos_estado;

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public Pagos(int pagos_id, DateTime pagos_fecha, int pagos_estado)
        {
            this.pagos_id = pagos_id;
            this.pagos_fecha = pagos_fecha;
            this.pagos_estado = pagos_estado;
        }

        public Pagos()
        {

        }
        
        public int Pagos_id
        {
            get { return pagos_id; }
            set
            {
                if(this.pagos_id != value)
                {
                    this.pagos_id = value;
                }
                RaisePropertyChanged();
            }
        }

        public DateTime Pagos_fecha
        {
            get { return pagos_fecha; }
            set
            {
                if (this.pagos_fecha != value)
                {
                    this.pagos_fecha = value;
                }
                RaisePropertyChanged();
            }
        }

        public int Pagos_estado
        {
            get { return pagos_estado; }
            set
            {
                if (this.pagos_estado != value)
                {
                    this.pagos_estado = value;
                }
                RaisePropertyChanged();
            }
        }
    }
}
