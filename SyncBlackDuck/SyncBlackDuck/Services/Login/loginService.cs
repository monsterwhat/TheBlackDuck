using MySqlConnector;
using SyncBlackDuck.Model.Objetos;
using System;

namespace SyncBlackDuck.Services.Login
{

    public class LoginService : Connection
    {

        public LoginService() { }
        
        public User LoginByRank(int t, string p)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.GetConnection();
                MySqlCommand command = new MySqlCommand("SELECT * FROM user WHERE user_telefono = @val1 AND user_password = @val2;", mysql);
                command.Parameters.AddWithValue("@val1", t);
                command.Parameters.AddWithValue("@val2", p);
                MySqlDataReader reader = command.ExecuteReader();
                //Si se puede leer encontro resultados = si existe el usuario...
                while (reader.Read())
                {
                    User loggedInUser = new User
                    {
                        User_id = reader.GetInt32(0),
                        User_telefono = reader.GetInt32(1),
                        User_name = reader.GetString(2),
                        User_rol = reader.GetString(5)
                    };
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

        public User LoginByPhone(int t)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.GetConnection();
                MySqlCommand command = new MySqlCommand("SELECT * FROM user WHERE user_telefono = @val1;", mysql);
                command.Parameters.AddWithValue("@val1", t);
                MySqlDataReader reader = command.ExecuteReader();
                //Si se puede leer encontro resultados = si existe el usuario...
                while (reader.Read())
                {
                    User loggedInUser = new User
                    {
                        User_id = reader.GetInt32(0),
                        User_telefono = reader.GetInt32(1),
                        User_name = reader.GetString(2),
                        User_rol = reader.GetString(5)
                    };
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

