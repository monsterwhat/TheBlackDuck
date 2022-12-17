using MySqlConnector;
using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace SyncBlackDuck.Services.Implementaciones
{
    internal class UserImpl : Connection, ICRUD<User>
    {
        // Crea una nueva instancia de la clase Connection
        public UserImpl()
        {
        }

        // Elimina un usuario de la tabla user
        public bool Eliminar(User item)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.GetConnection();
                MySqlCommand command = new MySqlCommand("DELETE FROM user WHERE User_id = @idUser", mysql);
                command.Parameters.AddWithValue("@idUser", item.User_id);
                command.ExecuteNonQuery();
                conn.Disconnect();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en DeleteByID de Administradores");
                Console.WriteLine(e);
                return false;
            }
        }

        // Inserta un usuario a la tabla user
        public bool Insertar(User item)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.GetConnection();
                MySqlCommand command = new MySqlCommand("INSERT INTO user (User_id, User_name, User_password, User_time, User_telefono, User_rol, User_Estado) VALUES (@idUser, @userName, @userPassword, @userTime, @userTelefono, @userRol, @userEstado)", mysql);
                command.Parameters.AddWithValue("@idUser", item.User_id);
                command.Parameters.AddWithValue("@userName", item.User_name);
                command.Parameters.AddWithValue("@userPassword", item.User_password);
                command.Parameters.AddWithValue("@userTime", item.User_time);
                command.Parameters.AddWithValue("@userTelefono", item.User_telefono);
                command.Parameters.AddWithValue("@userRol", item.User_rol);
                command.Parameters.AddWithValue("@userEstado", "Activo");
                command.ExecuteNonQuery();
                conn.Disconnect();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en Insertar Administradores");
                Console.WriteLine(e);
                return false;
            }
        }

        // Inserta un nuevo usuario cliente a la tabla user
        public bool InsertarNuevoC(User item)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.GetConnection();
                MySqlCommand command = new MySqlCommand("INSERT INTO user (User_name, User_password, User_time, User_telefono, User_rol, User_estado) VALUES (@userName, @userPassword, @userTime, @userTelefono, @userRol, @userEstado)", mysql);
                command.Parameters.AddWithValue("@userName", item.User_name);
                command.Parameters.AddWithValue("@userPassword", item.User_password);
                command.Parameters.AddWithValue("@userTime", DateTime.Now);
                command.Parameters.AddWithValue("@userTelefono", item.User_telefono);
                command.Parameters.AddWithValue("@userRol", "Cliente");
                command.Parameters.AddWithValue("@userEstado", "Activo");
                command.ExecuteNonQuery();
                conn.Disconnect();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en Insertar Nuevo Usuario");
                Console.WriteLine(e);
                return false;
            }
        }

        // Inserta un nuevo usuario administrador a la tabla user
        public bool InsertarNuevoAD(User item)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.GetConnection();
                MySqlCommand command = new MySqlCommand("INSERT INTO user (User_name, User_password, User_time, User_telefono, User_rol, User_estado) VALUES (@userName, @userPassword, @userTime, @userTelefono, @userRol, @userEstado)", mysql);
                command.Parameters.AddWithValue("@userName", item.User_name);
                command.Parameters.AddWithValue("@userPassword", item.User_password);
                command.Parameters.AddWithValue("@userTime", DateTime.Now);
                command.Parameters.AddWithValue("@userTelefono", item.User_telefono);
                command.Parameters.AddWithValue("@userRol", item.User_rol);
                command.Parameters.AddWithValue("@userEstado", "Activo");
                command.ExecuteNonQuery();
                conn.Disconnect();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en Insertar Nuevo Usuario");
                Console.WriteLine(e);
                return false;
            }
        }

        // Actualiza un usuario en la tabla user
        public bool Modificar(User item)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.GetConnection();
                MySqlCommand command = new MySqlCommand("UPDATE user SET User_name = @userName, User_password = @userPassword, User_time = @userTime, User_telefono = @userTelefono, User_rol = @userRol, User_estado = @userEstado WHERE user_id = @idUser", mysql);
                command.Parameters.AddWithValue("@idUser", item.User_id);
                command.Parameters.AddWithValue("@userName", item.User_name);
                command.Parameters.AddWithValue("@userPassword", item.User_password);
                command.Parameters.AddWithValue("@userTime", item.User_time);
                command.Parameters.AddWithValue("@userTelefono", item.User_telefono);
                command.Parameters.AddWithValue("@userRol", item.User_rol);
                command.Parameters.AddWithValue("@userEstado", item.User_estado);
                command.ExecuteNonQuery();
                conn.Disconnect();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error en Update de Usuario - Administradores");
                Console.WriteLine(e);
                return false;
            }
        }

        // Carga todos los usuarios de la tabla user
        public List<User> VerTodo()
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.GetConnection();
                MySqlCommand command = new MySqlCommand("SELECT * FROM user", mysql);
                MySqlDataReader reader = command.ExecuteReader();
                List<User> list = new List<User>();
                while (reader.Read())
                {
                    User user = new User
                    {
                        User_id = reader.GetInt32(0),
                        User_telefono = reader.GetInt32(2),
                        User_name = reader.GetString(3),
                        User_password = reader.GetString(4),
                        User_time = reader.GetDateTime(5),
                        User_rol = reader.GetString(6),
                        User_estado = reader.GetString(7)
                    };
                    list.Add(user);
                }
                conn.Disconnect();
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en SelectAll de Administradores");
                Console.WriteLine(e);
                return null;
            }
        }

        // Carga todos los usuario de tipo cliente de la tabla user
        public List<User> VerClientes()
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.GetConnection();
                MySqlCommand command = new MySqlCommand("SELECT * FROM user WHERE user_rol = 'Cliente'", mysql);
                MySqlDataReader reader = command.ExecuteReader();
                List<User> list = new List<User>();
                while (reader.Read())
                {
                    User user = new User
                    {
                        User_id = reader.GetInt32(0),
                        User_telefono = reader.GetInt32(1),
                        User_name = reader.GetString(2),
                        User_password = reader.GetString(3),
                        User_time = reader.GetDateTime(4),
                        User_rol = reader.GetString(5),
                        User_estado = reader.GetString(6)
                    };
                    list.Add(user);
                }
                conn.Disconnect();
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en SelectAll de Clientes");
                Console.WriteLine(e);
                return null;
            }
        }

        // Carga todos los administradores de la tabla user
        public List<User> VerAdministradores()
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.GetConnection();
                MySqlCommand command = new MySqlCommand("SELECT * FROM user WHERE user_rol = 'Admin'", mysql);
                MySqlDataReader reader = command.ExecuteReader();
                List<User> list = new List<User>();
                while (reader.Read())
                {
                    User user = new User
                    {
                        User_id = reader.GetInt32(0),
                        User_telefono = reader.GetInt32(1),
                        User_name = reader.GetString(2),
                        User_password = reader.GetString(3),
                        User_time = reader.GetDateTime(4),
                        User_rol = reader.GetString(5),
                        User_estado = reader.GetString(6)
                    };
                    list.Add(user);
                }
                conn.Disconnect();
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en SelectAll de Administradores");
                Console.WriteLine(e);
                return null;
            }
        }

        // Carga un cliente especifico de la tabla user
        public List<User> VerClienteEspecifico(int cel)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.GetConnection();
                MySqlCommand command = new MySqlCommand("SELECT u.user_name, p.pagos_mes_cobro, p.pagos_estado FROM user u, pagos p WHERE u.user_telefono = @tel AND u.user_id = p.user_id;", mysql);
                command.Parameters.AddWithValue("@tel", cel);
                Console.WriteLine(command);
                MySqlDataReader reader = command.ExecuteReader();
                List<User> list = new List<User>();
                while (reader.Read())
                {
                    User user = new User();
                    {
                        user.User_name = reader.GetString(0);
                        user.Pagos_mes_cobro = reader.GetString(1);
                        user.Pagos_estado = reader.GetString(2);
                    };
                    list.Add(user);
                }
                conn.Disconnect();
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en devolver datos del usuario");
                Console.WriteLine(e);
                return null;
            }
        }
    }
}