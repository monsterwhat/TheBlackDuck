using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SyncBlackDuck.Model
{
    public class userInstance
    {
        static public userInstance singleton = null;

        private int user_group;
        private int user_id;
        
        public static userInstance getSingleton() 
        {
            if (singleton == null)
            {
                singleton = new userInstance();
                Console.WriteLine("Sesion instanciada\n");
            } else {
                Console.WriteLine("Sesion ya instanciada\n");
            }
            return singleton;
        }

        public int User_group { get => user_group; set => user_group = value; }
        public int User_id { get => user_id; set => user_id = value; }
        

    }
}
