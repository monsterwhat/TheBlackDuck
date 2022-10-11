using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using TheBlackDuck.Models.Interfaces;
using TheBlackDuck.Models.Objects;
using TheBlackDuck.Services;

namespace TheBlackDuck.Models.Implementations
{
    public class ClientesDAOImpl : IClientesDAO
    {
        public bool DeleteByID(int idCliente)
        {
            try
            {
                Connection con = new Connection();
                MySqlConnection mysql = con.MysqlConnectionFactory;
                mysql.Open();
                MySqlCommand command = new MySqlCommand("DELETE FROM clientes WHERE idCliente = @idCliente", mysql);
                command.Parameters.AddWithValue("@idCliente", idCliente);
                command.ExecuteNonQuery();

                mysql.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en DeleteByID de Clientes");
                Console.WriteLine(e);
                return false;
            }
        }

        public bool DeleteByID()
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

        public clientes GetByID(int idCliente)
        {
            try
            {
                Connection con = new Connection();
                MySqlConnection mysql = con.MysqlConnectionFactory;
                mysql.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM clientes WHERE idCliente = @idCliente", mysql);
                command.Parameters.AddWithValue("@idCliente", idCliente);
                MySqlDataReader reader = command.ExecuteReader();
                clientes cliente = new clientes();
                while (reader.Read())
                {
                    cliente.idCliente = reader.GetInt32(0);
                    cliente.clienteHijo = reader.GetString(1);
                    cliente.clientePadre = reader.GetString(2);
                    cliente.idClientePago = reader.GetInt32(3);
                    cliente.clienteNumero = reader.GetInt32(4);
                    cliente.clienteContrasena = reader.GetString(5);
                }
                mysql.Close();
                return cliente;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en GetByID de Clientes");
                Console.WriteLine(e);
                return null;
            }
        }

        public clientes GetByID()
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

        public List<clientes> ListAll()
        {
            try
            {
                Connection con = new Connection();
                MySqlConnection mysql = con.MysqlConnectionFactory;
                mysql.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM clientes", mysql);
                MySqlDataReader reader = command.ExecuteReader();
                List<clientes> clientes = new List<clientes>();
                while (reader.Read())
                {
                    clientes cliente = new clientes();
                    cliente.idCliente = reader.GetInt32(0);
                    cliente.clienteHijo = reader.GetString(1);
                    cliente.clientePadre = reader.GetString(2);
                    cliente.idClientePago = reader.GetInt32(3);
                    cliente.clienteNumero = reader.GetInt32(4);
                    cliente.clienteContrasena = reader.GetString(5);
                    clientes.Add(cliente);
                }
                mysql.Close();
                return clientes;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en ListAll de Clientes");
                Console.WriteLine(e);
                return null;
            }
        }

        public bool UpdateByID()
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

        public bool UpdateByID(int idCliente, string clienteHijo, string clientePadre, int idClientePago, int clienteNumero, string clienteContrasena)
        {
            try
            {
                Connection con = new Connection();
                MySqlConnection mysql = con.MysqlConnectionFactory;
                mysql.Open();
                MySqlCommand command = new MySqlCommand("UPDATE clientes SET clienteHijo = @clienteHijo, clientePadre = @clientePadre, idClientePago = @idClientePago, clienteNumero = @clienteNumero, clienteContrasena = @clienteContrasena WHERE idCliente = @idCliente", mysql);
                command.Parameters.AddWithValue("@idCliente", idCliente);
                command.Parameters.AddWithValue("@clienteHijo", clienteHijo);
                command.Parameters.AddWithValue("@clientePadre", clientePadre);
                command.Parameters.AddWithValue("@idClientePago", idClientePago);
                command.Parameters.AddWithValue("@clienteNumero", clienteNumero);
                command.Parameters.AddWithValue("@clienteContrasena", clienteContrasena);
                command.ExecuteNonQuery();

                mysql.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("error en UpdateByID de Clientes");
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
