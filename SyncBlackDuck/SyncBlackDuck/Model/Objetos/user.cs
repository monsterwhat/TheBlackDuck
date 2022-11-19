using System;
using System.ComponentModel;

namespace SyncBlackDuck.Model.Objetos
{
    public class user : pagos, INotifyPropertyChanged
    {

        private int user_id;
        private string user_name;
        private string user_password;
        private DateTime user_time;
        private int user_telefono;
        private string user_rol;

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public user(int user_id, string user_name, string user_password, DateTime user_time, int user_telefono, string user_rol)
        {
            this.user_id = user_id;
            this.user_name = user_name;
            this.user_password = user_password;
            this.user_time = user_time;
            this.user_telefono = user_telefono;
            this.user_rol = user_rol;
        }

        // Constructor para visualizar datos de cliente logueado
        public user(string user_name, DateTime pagos_fecha, int pagos_estado)
        {
            this.user_name = user_name;
            this.Pagos_fecha = pagos_fecha;
            this.Pagos_fecha = pagos_fecha;
        }

        public user()
        {
        }

        public user(int user_id, string user_name, int user_telefono, string user_rol)
        {
            this.user_id = user_id;
            this.user_name = user_name;
            this.user_telefono = user_telefono;
            this.user_rol = user_rol;
        }

        public int User_id
        {
            get { return user_id; }
            set
            {
                if(this.user_id != value)
                {
                    this.user_id = value;
                }
                RaisePropertyChanged("user_id");
            }
        }
        public string User_name
        {
            get { return user_name; }
            set
            {
                if(this.user_name != value) 
                {
                    this.user_name = value;
                }
                RaisePropertyChanged("user_name");
            }
        }
        public string User_password
        {
            get { return user_password; }
            set {
                if(this.user_password != value) 
                {
                    this.user_password = value;
                }
                RaisePropertyChanged("user_password");
            }
        }

        public DateTime User_time {
            get { return user_time; }
            set {
                if(this.user_time != value) 
                {
                    this.user_time = value;
                }
                RaisePropertyChanged("user_time");
            }
        }
        public int User_telefono
        {
            get { return user_telefono; }
            set
            {
                if(this.user_telefono != value)
                {
                    this.user_telefono = value;
                }
                RaisePropertyChanged("user_telefono");
            }
        }
        public string User_rol
        {
            get { return user_rol; }
            set
            {
                if(this.user_rol != value)
                {
                    this.user_rol = value;
                }
                RaisePropertyChanged("user_rol");
            }
        }
    }
}
