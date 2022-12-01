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
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            catch
            { // Metodo para devolver el stacktrace en caso de un error
                System.Diagnostics.StackTrace t = new System.Diagnostics.StackTrace();
                Console.WriteLine("Error " + t.ToString());
            }

        }

        public void Disconnect()
        {
            try
            {
                connection.Close();
                connection = null;
            }
            catch
            { // Metodo para devolver el stacktrace en caso de un error
                System.Diagnostics.StackTrace t = new System.Diagnostics.StackTrace();
                Console.WriteLine("Error" + t.ToString());
            }

        }

        public MySqlConnection GetConnection()
        {
            if (connection == null)
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            else
            {
                Disconnect();
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }

            return connection;
        }

    }
}
