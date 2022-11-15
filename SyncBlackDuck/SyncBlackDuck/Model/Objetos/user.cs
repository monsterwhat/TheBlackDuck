using System;

namespace SyncBlackDuck.Model.Objetos
{
    public class user
    {

        private int user_id;
        private string user_name;
        private string user_password;
        private DateTime user_time;
        private int user_telefono;
        private string user_rol;

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

        public int User_id { get => user_id; set => user_id = value; }
        public string User_name { get => user_name; set => user_name = value; }
        public string User_password { get => user_password; set => user_password = value; }
        public DateTime User_time { get => user_time; set => user_time = value; }
        public int User_telefono { get => user_telefono; set => user_telefono = value; }
        public string User_rol { get => user_rol; set => user_rol = value; }


    }
}
