using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using TheBlackDuck.Models.Interfaces;
using TheBlackDuck.Models.Objects;
using TheBlackDuck.Services;

namespace TheBlackDuck.Models.Implementations
{
    internal class SuperAdministradoresDAOImpl : ISuperAdministradoresDAO
    {
        public Boolean DeleteByID(int idSuperAdministrador)
        {
            try
            {
                Connection con = new Connection();
                MySqlConnection mysql = con.MysqlConnectionFactory;
                mysql.Open();
                MySqlCommand command = new MySqlCommand("DELETE FROM superAdministradores WHERE idSuperAdministrador = @idSuperAdministrador", mysql);
                command.Parameters.AddWithValue("@idSuperAdministrador", idSuperAdministrador);
                command.ExecuteNonQuery();

                mysql.Close();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error en DeleteByID de SuperAdmin");
                Console.WriteLine(e);
                return false;
            }
        }
        public Boolean DeleteByID()
        {
            try
            {
                return false;
            }catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public List<superadministradores> ListAll()
        {
            try
            {
                Connection con = new Connection();
                MySqlConnection mysql = con.MysqlConnectionFactory;
                mysql.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM superAdministradores", mysql);
                MySqlDataReader reader = command.ExecuteReader();
                List<superadministradores> superAdministradores = new List<superadministradores>();
                while (reader.Read())
                {
                    superadministradores superAdministrador = new superadministradores();
                    superAdministrador.idSuperAdmin = reader.GetInt32(0);
                    superAdministrador.superAdminUsuario = reader.GetString(1);
                    superAdministrador.superAdminContrasena = reader.GetString(2);
                    superAdministradores.Add(superAdministrador);
                }
                reader.Close();
                mysql.Close();

                return superAdministradores;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error en Listar todos los SuperAdministradores");
                Console.WriteLine(e);
                return null;
            }
        }
        public superadministradores GetByID(int idSuperAdministrador)
        {
            try
            {
                Connection con = new Connection();
                MySqlConnection mysql = con.MysqlConnectionFactory;
                mysql.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM superAdministradores WHERE idSuperAdministrador = @idSuperAdministrador", mysql);
                command.Parameters.AddWithValue("@idSuperAdministrador", idSuperAdministrador);
                MySqlDataReader reader = command.ExecuteReader();
                superadministradores superAdministrador = new superadministradores();
                while (reader.Read())
                {
                    superAdministrador.idSuperAdmin = reader.GetInt32(0);
                    superAdministrador.superAdminUsuario = reader.GetString(1);
                    superAdministrador.superAdminContrasena = reader.GetString(2);
                }
                reader.Close();
                mysql.Close();

                return superAdministrador;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error en GetByID de SuperAdministradores");
                Console.WriteLine(e);
                return null;
            }
        }
        public superadministradores GetByID()
        {
            try
            {
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public Boolean UpdateByID(int idSuperAdmin, string superAdminUsuario, string superAdminContrasena)
        {
            try
            {
                Connection con = new Connection();
                MySqlConnection mysql = con.MysqlConnectionFactory;
                mysql.Open();
                MySqlCommand command = new MySqlCommand("UPDATE superAdministradores SET superAdminUsuario = @superAdminUsuario, superAdminContrasena = @superAdminContrasena WHERE idSuperAdministrador = @idSuperAdministrador", mysql);
                command.Parameters.AddWithValue("@idSuperAdministrador", idSuperAdmin);
                command.Parameters.AddWithValue("@superAdminUsuario", superAdminUsuario);
                command.Parameters.AddWithValue("@superAdminContrasena", superAdminContrasena);
                command.ExecuteNonQuery();

                mysql.Close();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error en UpdateByID de SuperAdministradores");
                Console.WriteLine(e);
                return false;
            }
        }
        public Boolean UpdateByID()
        {
            try
            {
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
