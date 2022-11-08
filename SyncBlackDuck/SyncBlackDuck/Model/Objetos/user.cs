using System;
using System.ComponentModel;

namespace SyncBlackDuck.Model.Objetos
{
    public class user : INotifyPropertyChanged
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
                this.user_id = value;
                Console.WriteLine(value);
                RaisePropertyChanged("user_id");
            }
        }
        public string User_name
        {
            get { return user_name; }
            set
            {
                user_name = value;
                Console.WriteLine(value);
                RaisePropertyChanged("user_name");
            }
        }
        public string User_password
        {
            get { return user_password; }
            set {
                user_password = value;
                Console.WriteLine(value);
                RaisePropertyChanged("user_password");
            }
        }

        public DateTime User_time {
            get { return user_time; }
            set {
                user_time = value;
                Console.WriteLine(value);
                RaisePropertyChanged("user_time");
            }
        }
        public int User_telefono
        {
            get { return user_telefono; }
            set
            {
                user_telefono = value;
                Console.WriteLine(value);
                RaisePropertyChanged("user_telefono");
            }
        }
        public string User_rol
        {
            get { return user_rol; }
            set
            {
                user_rol = value;
                Console.WriteLine(value);
                RaisePropertyChanged("user_rol");
            }
        }
    }
}
