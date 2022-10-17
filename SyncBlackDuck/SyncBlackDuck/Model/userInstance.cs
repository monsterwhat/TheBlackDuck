using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SyncBlackDuck.Model
{
    public class userInstance
    {
        static public userInstance singleton = null;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

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
    }
}
