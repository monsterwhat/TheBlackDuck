using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheBlackDuck.Services
{
    public class Connection
    {
        private static String connectionString = "Server=192.99.35.36;Database=tlp_database;Uid=Proy3;Pwd=Asdf@1234;SslMode=Preferred";
        private static Connection singleton;
        private static MySqlConnection connection;

        public Connection()
        {
            connection = new MySqlConnection(connectionString);
        }

        public void CloseConnection()
        {
            connection.Close();
        }

        public MySqlConnection getConnection()
        {
           return connection;
        }

        public void Dispose()
        {
            connection.Dispose();
        }




    }
}
