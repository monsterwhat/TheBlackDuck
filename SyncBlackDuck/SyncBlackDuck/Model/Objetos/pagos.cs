using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SyncBlackDuck.Model.Objetos
{
    public class Pagos : INotifyPropertyChanged
    {

        private int pagos_id;
        private int user_id;
        private String pagos_mes_cobro;
        private DateTime pagos_fecha_pago;
        private string pagos_estado;

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public Pagos() { }

        // Constuctor para todos los objetos de pagos
        public Pagos(int pagos_id,int user_id, String pagos_mes_cobro, DateTime pagos_fecha_pago, string pagos_estado)
        {
            this.pagos_id = pagos_id;
            this.user_id = user_id;
            this.pagos_mes_cobro = pagos_mes_cobro;
            this.pagos_fecha_pago = pagos_fecha_pago;
            this.pagos_estado = pagos_estado;
        }

        // Constructor para mostrar a cliente informacion de sus pagos => ClienteGestUPage
        public Pagos(int pagos_id, String pagos_mes_cobro, string pagos_estado)
        {
            this.pagos_id = pagos_id;
            this.pagos_mes_cobro = pagos_mes_cobro;
            this.pagos_estado = pagos_estado;
        }

        #region Getters & Setters

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

        public int User_id
        {
            get { return user_id; }
            set
            {
                if (this.user_id != value)
                {
                    this.user_id = value;
                }
                RaisePropertyChanged();
            }
        }

        public String Pagos_mes_cobro
        {
            get { return pagos_mes_cobro; }
            set
            {
                if (this.pagos_mes_cobro != value)
                {
                    this.pagos_mes_cobro = value;
                }
                RaisePropertyChanged();
            }
        }

        public DateTime Pagos_fecha_pago
        {
            get { return pagos_fecha_pago; }
            set
            {
                if (this.pagos_fecha_pago != value)
                {
                    this.pagos_fecha_pago = value;
                }
                RaisePropertyChanged();
            }
        }

        public string Pagos_estado
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

        #endregion
    }
}
