
using MySqlConnector;
using SyncBlackDuck.Services;
using SyncBlackDuck.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using TheBlackDuck.Models.Objects;


namespace TheBlackDuck.Models.Implementations
{
    public class clientesPagosImpl : Connection, ICRUD<clientesPagos>
    {
        public bool DeleteByID(int idClientePago)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.getConnection();
                mysql.Open();
                MySqlCommand command = new MySqlCommand("DELETE FROM clientesPagos WHERE idClientePago = @idClientePago", mysql);
                command.Parameters.AddWithValue("@idClientePago", idClientePago);
                command.ExecuteNonQuery();

                mysql.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en DeleteByID de ClientePago");
                Console.WriteLine(e);
                return false;
            }
        }

        public bool eliminar(clientesPagos item)
        {
            throw new NotImplementedException();
        }

        public clientesPagos GetByID(int idClientePago)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.getConnection();
                mysql.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM clientesPagos WHERE idClientePago = @idClientePago", mysql);
                command.Parameters.AddWithValue("@idClientePago", idClientePago);
                MySqlDataReader reader = command.ExecuteReader();
                clientesPagos clientePago = new clientesPagos();
                while (reader.Read())
                {
                    clientePago.idClientePagos = reader.GetInt32(0);
                    clientePago.montoPagos = reader.GetDouble(1);
                    clientePago.fechaPago = reader.GetDateTime(2);
                    clientePago.estadoPago = reader.GetInt32(3);
                }
                reader.Close();
                mysql.Close();
                return clientePago;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en GetByID de ClientePago");
                Console.WriteLine(e);
                return null;
            }
        }

        public bool insertar(clientesPagos item)
        {
            throw new NotImplementedException();
        }

        public List<clientesPagos> ListAll()
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.getConnection();
                mysql.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM clientesPagos", mysql);
                MySqlDataReader reader = command.ExecuteReader();
                List<clientesPagos> clientesPagos = new List<clientesPagos>();
                while (reader.Read())
                {
                    clientesPagos clientePago = new clientesPagos();
                    clientePago.idClientePagos = reader.GetInt32(0);
                    clientePago.montoPagos = reader.GetDouble(1);
                    clientePago.fechaPago = reader.GetDateTime(2);
                    clientePago.estadoPago = reader.GetInt32(3);
                    clientesPagos.Add(clientePago);
                }
                reader.Close();
                mysql.Close();
                return clientesPagos;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en ListAll de ClientePago");
                Console.WriteLine(e);
                return null;
            }
        }

        public bool modificar(clientesPagos item)
        {
            throw new NotImplementedException();
        }

        public bool UpdateByID(int idClientePago, double montoPagos, DateTime fechaPago, int estadoPago)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.getConnection();
                mysql.Open();
                MySqlCommand command = new MySqlCommand("UPDATE clientesPagos SET montoPagos = @montoPagos, fechaPago = @fechaPago, estadoPago = @estadoPago WHERE idClientePago = @idClientePago", mysql);
                command.Parameters.AddWithValue("@idClientePago", idClientePago);
                command.Parameters.AddWithValue("@montoPagos", montoPagos);
                command.Parameters.AddWithValue("@fechaPago", fechaPago);
                command.Parameters.AddWithValue("@estadoPago", estadoPago);
                command.ExecuteNonQuery();
                mysql.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en UpdateByID de ClientePago");
                Console.WriteLine(e);
                return false;
            }
        }

        public ArrayList verTodo()
        {
            throw new NotImplementedException();
        }
    }
}
