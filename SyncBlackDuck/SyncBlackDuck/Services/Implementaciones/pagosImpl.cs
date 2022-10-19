using MySqlConnector;
using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Services.Interfaces;
using System;
using System.Collections;

namespace SyncBlackDuck.Services.Implementaciones
{
    internal class pagosImpl : Connection, ICRUD<pagos>
    {
        //Elimina un registro de la tabla pagos
        public bool eliminar(pagos item)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.getConnection();
                mysql.Open();
                MySqlCommand command = new MySqlCommand("DELETE FROM pagos WHERE idPago = @idPago", mysql);
                command.Parameters.AddWithValue("@idPago", item.Pagos_id);
                command.ExecuteNonQuery();

                mysql.Close();
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
        public bool insertar(pagos item)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.getConnection();
                mysql.Open();
                MySqlCommand command = new MySqlCommand("INSERT INTO pagos (idPago, fechaPago, estado) VALUES (@idPago, @fechaPago, @estado)", mysql);
                command.Parameters.AddWithValue("@idPago", item.Pagos_id);
                command.Parameters.AddWithValue("@fechaPago", item.Pagos_fecha);
                command.Parameters.AddWithValue("@estado", item.Pagos_estado);
                command.ExecuteNonQuery();

                mysql.Close();
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
        public bool modificar(pagos item)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.getConnection();
                mysql.Open();
                MySqlCommand command2 = new MySqlCommand("UPDATE pagos SET fechaPago = @fechaPago, estado = @estado WHERE idPago = @idPago", mysql);
                command2.Parameters.AddWithValue("@idPago", item.Pagos_id);
                command2.Parameters.AddWithValue("@estado", item.Pagos_estado);
                command2.Parameters.AddWithValue("@fechaPago", item.Pagos_fecha);
                command2.ExecuteNonQuery();

                mysql.Close();
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
        public ArrayList verTodo()
        {
            try
            {
                ArrayList lista = new ArrayList();
                Connection conn = new Connection();
                MySqlConnection mysql = conn.getConnection();
                mysql.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM pagos", mysql);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    pagos pago = new pagos();
                    pago.Pagos_id = reader.GetInt32(0);
                    pago.Pagos_fecha = reader.GetDateTime(1);
                    pago.Pagos_estado = reader.GetInt32(2);
                    lista.Add(pago);
                }
                mysql.Close();
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
