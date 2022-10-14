using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheBlackDuck.Models.Interfaces;
using TheBlackDuck.Models.Objects;
using TheBlackDuck.Services;

namespace TheBlackDuck.Models.Implementations
{

    public class AdministradoresDAOImpl : IAdministradoresDAO
    {

        public Boolean DeleteByID(int idAdministrador)
        {
            try
            {
                Connection con = new Connection();
                MySqlConnection mysql = con.MysqlConnectionFactory;
                mysql.Open();
                MySqlCommand command = new MySqlCommand("DELETE FROM administradores WHERE idAdministrador = @idAdministrador", mysql);
                command.Parameters.AddWithValue("@idAdministrador", idAdministrador);
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

        public List<administradores> ListAll()
        {
            try
            {
                Connection con = new Connection();
                MySqlConnection mysql = con.MysqlConnectionFactory;
                mysql.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM administradores", mysql);
                MySqlDataReader reader = command.ExecuteReader();
                List<administradores> list = new List<administradores>();
                while (reader.Read())
                {
                    administradores admin = new administradores();
                    admin.idAdministrador = reader.GetInt32(0);
                    admin.administradorescol = reader.GetString(1);
                    admin.adminUsuario = reader.GetString(2);
                    admin.adminContrasena = reader.GetString(3);
                    list.Add(admin);
                }
                reader.Close();
                mysql.Close();

                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en ListAll de Administradores");
                Console.WriteLine(e);
                return null;
            }
        }

        public administradores GetByID(int idAdministrador)
        {
            try
            {
                Connection con = new Connection();
                MySqlConnection mysql = con.MysqlConnectionFactory;
                mysql.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM administradores WHERE idAdministrador = @idAdministrador", mysql);
                command.Parameters.AddWithValue("@idAdministrador", idAdministrador);
                MySqlDataReader reader = command.ExecuteReader();
                administradores admin = new administradores();
                while (reader.Read())
                {
                    admin.idAdministrador = reader.GetInt32(0);
                    admin.administradorescol = reader.GetString(1);
                    admin.adminUsuario = reader.GetString(2);
                    admin.adminContrasena = reader.GetString(3);
                }
                reader.Close();
                mysql.Close();

                return admin;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en GetByID de Administradores");
                Console.WriteLine(e);
                return null;
            }
        }

        public Boolean UpdateByID(int idAdministrador, string administradorescol, string adminUsuario, string adminContrasena)
        {
            try
            {
                Connection con = new Connection();
                MySqlConnection mysql = con.MysqlConnectionFactory;
                mysql.Open();
                MySqlCommand command = new MySqlCommand("UPDATE administradores SET administradorescol = @administradorescol, adminUsuario = @adminUsuario, adminContrasena = @adminContrasena WHERE idAdministrador = @idAdministrador", mysql);
                command.Parameters.AddWithValue("@idAdministrador", idAdministrador);
                command.Parameters.AddWithValue("@administradorescol", administradorescol);
                command.Parameters.AddWithValue("@adminUsuario", adminUsuario);
                command.Parameters.AddWithValue("@adminContrasena", adminContrasena);
                command.ExecuteNonQuery();
                mysql.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en UpdateByID de Administradores");
                Console.WriteLine(e);
                return false;
            }
        }

    }

}
