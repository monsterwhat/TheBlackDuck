using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SyncBlackDuck.Model.Objetos
{
    public class User : Pagos, INotifyPropertyChanged
    {

        private int user_id;
        private string user_name;
        private string user_password;
        private DateTime user_time;
        private int user_telefono;
        private string user_rol;
        private Boolean user_estado;

        public event PropertyChangedEventHandler PropertyChanged;

        public new void RaisePropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public User()
        {
        }

        public User(int user_id, string user_name, string user_password, DateTime user_time, int user_telefono, string user_rol, Boolean user_estado)
        {
            this.user_id = user_id;
            this.user_name = user_name;
            this.user_password = user_password;
            this.user_time = user_time;
            this.user_telefono = user_telefono;
            this.user_rol = user_rol;
            this.user_estado = user_estado;
        }

        // Constructor para View Cliente => user + pagos
        public User(string user_name, DateTime pagos_fecha, int pagos_estado)
        {
            this.user_name = user_name;
            Pagos_fecha = pagos_fecha;
            Pagos_estado = pagos_estado;
        }

        // Constructor para View Admin => users (todos)
        public User(int user_id, string user_name, int user_telefono, string user_rol)
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
                RaisePropertyChanged();
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
                RaisePropertyChanged();
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
                RaisePropertyChanged();
            }
        }

        public DateTime User_time {
            get { return user_time; }
            set {
                if(this.user_time != value) 
                {
                    this.user_time = value;
                }
                RaisePropertyChanged();
            }
        }
        public int User_telefono
        {
            get { return user_telefono; }
            set {
                if(this.user_telefono != value)
                {
                    this.user_telefono = value;
                }
                RaisePropertyChanged();
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
                RaisePropertyChanged();
            }
        }

        public Boolean User_estado
        {
            get { return user_estado; }
            set
            {
                if (this.user_estado != value)
                {
                    this.user_estado = value;
                }
                RaisePropertyChanged();
            }
        }
    }
}
