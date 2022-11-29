﻿using MySqlConnector;
using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace SyncBlackDuck.Services.Implementaciones
{
    internal class PagosImpl : Connection, ICRUD<Pagos>
    {
        //Elimina un registro de la tabla pagos

        public PagosImpl()
        {

        }

        public bool eliminar(Pagos item)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.getConnection();
                MySqlCommand command = new MySqlCommand("DELETE FROM pagos WHERE Pagos_id = @idPago", mysql);
                command.Parameters.AddWithValue("@idPago", item.Pagos_id);
                command.ExecuteNonQueryAsync();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en Eliminar pagos: " + e.Message);
                Console.WriteLine(e);
                return false;
            }
        }

        //Inserta un pago a una cuenta
        public bool insertar(Pagos item)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.getConnection();
                MySqlCommand command = new MySqlCommand("INSERT INTO pagos (Pagos_id, Pagos_fecha, Pagos_estado) VALUES (@idPago, @fechaPago, @estado)", mysql);
                command.Parameters.AddWithValue("@idPago", item.Pagos_id);
                command.Parameters.AddWithValue("@fechaPago", item.Pagos_fecha);
                command.Parameters.AddWithValue("@estado", item.Pagos_estado);
                command.ExecuteNonQueryAsync();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en Insertar pagos: " + e.Message);
                Console.WriteLine(e);
                return false;
            }
        }

        //Modifica un pago existente.
        public bool modificar(Pagos item)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.getConnection();
                MySqlCommand command2 = new MySqlCommand("UPDATE pagos SET Pagos_fecha = @fechaPago, Pagos_estado = @estado WHERE Pagos_id = @idPago", mysql);
                command2.Parameters.AddWithValue("@idPago", item.Pagos_id);
                command2.Parameters.AddWithValue("@estado", item.Pagos_estado);
                command2.Parameters.AddWithValue("@fechaPago", item.Pagos_fecha);
                command2.ExecuteNonQueryAsync();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en Actualizar pagos: " + e.Message);
                Console.WriteLine(e);
                return false;
            }
        }

        //Carga todos los valores de la tabla en un ArrayList de objetos pago
        public List<Pagos> verTodo()
        {
            try
            {
                List<Pagos> lista = new List<Pagos>();
                Connection conn = new Connection();
                MySqlConnection mysql = conn.getConnection();
                MySqlCommand command = new MySqlCommand("SELECT * FROM pagos", mysql);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Pagos pago = new Pagos
                    {
                        Pagos_id = reader.GetInt32(0),
                        Pagos_fecha = reader.GetDateTime(1),
                        Pagos_estado = reader.GetInt32(2)
                    };
                    lista.Add(pago);
                }
                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en Ver pagos: " + e.Message);
                Console.WriteLine(e);
                return null;
            }
        }

        public List<Pagos> VerPendientes()
        {
            try
            {
                List<Pagos> lista = new List<Pagos>();
                Connection conn = new Connection();
                MySqlConnection mysql = conn.getConnection();
                MySqlCommand command = new MySqlCommand("SELECT pagos_id, pagos_fecha, pagos_estado FROM pagos WHERE pagos_estado = 0", mysql);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Pagos pago = new Pagos
                    {
                        Pagos_id = reader.GetInt32(0),
                        Pagos_fecha = Convert.ToDateTime(reader.GetDateTime(1)),
                        Pagos_estado = reader.GetInt32(2)
                    };
                    lista.Add(pago);
                }
                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en Ver pagos: " + e.Message);
                Console.WriteLine(e);
                return null;
            }
        }

        public List<Pagos> VerPagados()
        {

            try
            {
                List<Pagos> lista = new List<Pagos>();
                Connection conn = new Connection();
                MySqlConnection mysql = conn.getConnection();
                MySqlCommand command = new MySqlCommand("SELECT * FROM pagos WHERE pagos_estado = 1", mysql);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Pagos pago = new Pagos
                    {
                        Pagos_id = reader.GetInt32(0),
                        Pagos_fecha = reader.GetDateTime(1),
                        Pagos_estado = reader.GetInt32(2)
                    };
                    lista.Add(pago);
                }
                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en Ver pagos: " + e.Message);
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
