using MySqlConnector;
using System;

namespace SyncBlackDuck.Services
{
    public class Connection
    {
        private static string connectionString = "Server=192.99.35.36;Database=tlp_database;Uid=Proy3;Pwd=Asdf@1234;SslMode=Preferred";
        private static MySqlConnection connection;

        public Connection()
        {
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();

            }
            catch
            { // Metodo para devolver el stacktrace en caso de un error
                System.Diagnostics.StackTrace t = new System.Diagnostics.StackTrace();
                Console.WriteLine(t.ToString());
            }

        }

        public void Disconnect()
        {
            try
            {
                connection.Close();

            }
            catch
            { // Metodo para devolver el stacktrace en caso de un error
                System.Diagnostics.StackTrace t = new System.Diagnostics.StackTrace();
                Console.WriteLine(t.ToString());
            }

        }

        public MySqlConnection getConnection()
        {
            if (connection == null)
            {
                connection.Open();
            }
            return connection;
        }

    }
}
