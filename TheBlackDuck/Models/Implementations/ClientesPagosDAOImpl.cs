using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using TheBlackDuck.Models.Interfaces;
using TheBlackDuck.Models.Objects;
using TheBlackDuck.Services;
using Xamarin.Forms;

namespace TheBlackDuck.Models.Implementations
{
    public class ClientesPagosDAOImpl : IClientesPagosDAO
    {
        public bool DeleteByID(int idClientePago)
        {
            try
            {
                Connection con = new Connection();
                MySqlConnection mysql = con.MysqlConnectionFactory;
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

        public bool DeleteByID()
        {
            try
            {
                return false;
            }
            catch (Exception e){
                Console.WriteLine(e);
                return false;
            }
        }

        public clientesPagos GetByID(int idClientePago)
        {
            try
            {
                Connection con = new Connection();
                MySqlConnection mysql = con.MysqlConnectionFactory;
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
            }catch(Exception e)
            {
                Console.WriteLine("Error en GetByID de ClientePago");
                Console.WriteLine(e);
                return null;
            }
        }

        public clientesPagos GetByID()
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

        public List<clientesPagos> ListAll()
        {
            try{
                Connection con = new Connection();
                MySqlConnection mysql = con.MysqlConnectionFactory;
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

        public bool UpdateByID()
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

        public bool UpdateByID(int idClientePago, double montoPagos, DateTime fechaPago, int estadoPago)
        {
            try{
            Connection con = new Connection();
            MySqlConnection mysql = con.MysqlConnectionFactory;
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
    }
        }
