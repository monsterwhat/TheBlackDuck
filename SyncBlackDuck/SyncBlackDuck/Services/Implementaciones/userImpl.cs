using MySqlConnector;
using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SyncBlackDuck.Services.Implementaciones
{
    internal class userImpl : Connection, ICRUD<user>
    {
        //Elimina un usuario de la tabla user
        public bool eliminar(user item)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.getConnection();
                mysql.Open();
                MySqlCommand command = new MySqlCommand("DELETE FROM user WHERE idUser = @idUser", mysql);
                command.Parameters.AddWithValue("@idUser", item.User_id);
                command.ExecuteNonQuery();

                mysql.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en DeleteByID de Administradores");
                Console.WriteLine(e);
                return false;
            }
        }

        //Inserta un usuario a la tabla user
        public bool insertar(user item)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.getConnection();
                mysql.Open();
                MySqlCommand command = new MySqlCommand("INSERT INTO user (idUser, userName, userPassword, userTime, userTelefono, userRol) VALUES (@idUser, @userName, @userPassword, @userTime, @userTelefono, @userRol)", mysql);
                command.Parameters.AddWithValue("@idUser", item.User_id);
                command.Parameters.AddWithValue("@userName", item.User_name);
                command.Parameters.AddWithValue("@userPassword", item.User_password);
                command.Parameters.AddWithValue("@userTime", item.User_time);
                command.Parameters.AddWithValue("@userTelefono", item.User_telefono);
                command.Parameters.AddWithValue("@userRol", item.User_rol);
                command.ExecuteNonQuery();

                mysql.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en Insertar Administradores");
                Console.WriteLine(e);
                return false;
            }
        }

        //Modifica un usuario existente.
        public bool modificar(user item)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.getConnection();
                mysql.Open();
                MySqlCommand command = new MySqlCommand("UPDATE user SET userName = @userName, userPassword = @userPassword, userTime = @userTime, userTelefono = @userTelefono, userRol = @userRol WHERE idUser = @idUser", mysql);
                command.Parameters.AddWithValue("@userName", item.User_name);
                command.Parameters.AddWithValue("@userPassword", item.User_name);
                command.Parameters.AddWithValue("@userTime", item.User_name);
                command.Parameters.AddWithValue("@userTelefono", item.User_telefono);
                command.Parameters.AddWithValue("@userRol", item.User_rol);
                command.ExecuteNonQuery();

                mysql.Close();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error en Update de Administradores");
                Console.WriteLine(e);
                return false;
            }
        }

        //Carga todos los usuarios de la tabla user
        public List<user> verTodo()
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.getConnection();
                MySqlCommand command = new MySqlCommand("SELECT * FROM user", mysql);
                MySqlDataReader reader = command.ExecuteReader();
                List<user> list = new List<user>();
                while (reader.Read())
                {
                    user user = new user
                    {
                        User_id = reader.GetInt32(0),
                        User_name = reader.GetString(1),
                        User_password = reader.GetString(2),
                        User_time = reader.GetDateTime(3),
                        User_telefono = reader.GetInt32(4),
                        User_rol = reader.GetString(5)
                    };
                    list.Add(user);
                    Console.WriteLine(user.ToString());
                }
                mysql.Close();
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en SelectAll de Administradores");
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
