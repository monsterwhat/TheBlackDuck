
using MySqlConnector;
using SyncBlackDuck.Services;
using SyncBlackDuck.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

using TheBlackDuck.Models.Objects;


namespace TheBlackDuck.Models.Implementations
{
    public class clientesImpl : Connection, ICRUD<clientes>
    {
        public bool DeleteByID(int idCliente)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.getConnection();
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

        public clientes GetByID(int idCliente)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.getConnection();
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

        public List<clientes> ListAll()
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.getConnection();
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

        public bool UpdateByID(int idCliente, string clienteHijo, string clientePadre, int idClientePago, int clienteNumero, string clienteContrasena)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.getConnection();
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

        public bool Login(int telefono, string password)
        {
            try
            {

                Connection con = new Connection();
                MySqlConnection conx = con.getConnection();
                MySqlCommand command = new MySqlCommand("SELECT * FROM clientes WHERE clienteNumero = @numeroCliente AND clienteContrasena = @clienteContrasena", conx);
                command.Parameters.AddWithValue("@numeroCliente", telefono);
                command.Parameters.AddWithValue("@clienteContrasena", password);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    conx.Close();
                    return true;
                }
                else
                {
                    conx.Close();
                    return false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error en Login de Clientes");
                Console.WriteLine(e);
                return false;
            }
        }

        public bool insertar(clientes item)
        {
            throw new NotImplementedException();
        }

        public bool modificar(clientes item)
        {
            throw new NotImplementedException();
        }

        public bool eliminar(clientes item)
        {
            throw new NotImplementedException();
        }

        public ArrayList verTodo()
        {
            throw new NotImplementedException();
        }
    }
}
