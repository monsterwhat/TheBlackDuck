using MySqlConnector;
using SyncBlackDuck.Model.Objetos;
using System;

namespace SyncBlackDuck.Services.Login
{

    public class loginService : Connection
    {

        public loginService() { }
        
        public user loginByRank(int t, string p)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.getConnection();
                MySqlCommand command = new MySqlCommand("SELECT * FROM user WHERE user_telefono = @val1 AND user_password = @val2;", mysql);
                command.Parameters.AddWithValue("@val1", t);
                command.Parameters.AddWithValue("@val2", p);
                MySqlDataReader reader = command.ExecuteReader();
                //Si se puede leer encontro resultados = si existe el usuario...
                while (reader.Read())
                {
                    user loggedInUser = new user();
                    loggedInUser.User_id = reader.GetInt32(0);
                    loggedInUser.User_name = reader.GetString(1);
                    loggedInUser.User_rol = reader.GetString(5);
                    loggedInUser.User_telefono = reader.GetInt32(4);
                    //Devolver entidad usuario.
                    return loggedInUser;
                }
                //Si no se encontro un usuario retornar null
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Error en el servicio de login");
                return null;
            }
        }

        public user loginByPhone(int t)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.getConnection();
                MySqlCommand command = new MySqlCommand("SELECT * FROM user WHERE user_telefono = @val1;", mysql);
                command.Parameters.AddWithValue("@val1", t);
                MySqlDataReader reader = command.ExecuteReader();
                //Si se puede leer encontro resultados = si existe el usuario...
                while (reader.Read())
                {
                    user loggedInUser = new user();
                    loggedInUser.User_id = reader.GetInt32(0);
                    loggedInUser.User_name = reader.GetString(1);
                    loggedInUser.User_rol = reader.GetString(5);
                    loggedInUser.User_telefono = reader.GetInt32(4);
                    //Devolver entidad usuario.
                    return loggedInUser;
                }
                //Si no se encontro un usuario retornar null
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Error en el servicio de login");
                return null;
            }
        }
    }
}

