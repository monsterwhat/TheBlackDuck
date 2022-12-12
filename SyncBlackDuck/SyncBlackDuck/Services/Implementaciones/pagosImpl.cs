using MySqlConnector;
using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SyncBlackDuck.Services.Implementaciones
{
    internal class PagosImpl : Connection, ICRUD<Pagos>
    {
        public PagosImpl()
        {
            Mensualidad();
        }
        public Task Mensualidad()
        {

            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.GetConnection();
                MySqlCommand command = new MySqlCommand("SELECT * FROM user WHERE user_rol = 'Cliente' AND user_estado = 'Activo' AND user_id NOT IN (SELECT user_id FROM pagos WHERE Pagos_mes_cobro = monthname(now())) LIMIT 10", mysql);
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
                        User_rol = reader.GetString(5)
                    };
                    list.Add(user);
                }
                conn.Disconnect();

                if(list.Count > 0)
                {
                    foreach (User item in list)
                    {
                            bool estado = false;
                            estado = InsertarU(item);
                    }
                }

                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en CobrarMensualidades de Clientes");
                Console.WriteLine(e);

                return Task.CompletedTask;
            }
        }

        public List<Pagos> GetPagosdelMes(User item)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.GetConnection();
                MySqlCommand command = new MySqlCommand("SELECT * FROM pagos WHERE user_id = @idUser AND Pagos_mes_cobro = MONTHNAME(NOW())", mysql);
                command.Parameters.AddWithValue("@idUser", item.User_id);
                MySqlDataReader reader = command.ExecuteReader();
                List<Pagos> listPagos = new List<Pagos>();
                while (reader.Read())
                {
                    Pagos pago = new Pagos
                    {
                        Pagos_id = reader.GetInt32(0),
                        User_id = reader.GetInt32(1),
                        Pagos_mes_cobro = reader.GetString(2),
                        Pagos_fecha_pago = reader.GetDateTime(3),
                        Pagos_estado = reader.GetString(4)
                    };
                    listPagos.Add(pago);
                }
                conn.Disconnect();
                return listPagos;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en Pagos del Mes");
                Console.WriteLine(e);
                return null;
            }
        }

        public bool Eliminar(Pagos item)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.GetConnection();
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
        public bool Insertar(Pagos item)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.GetConnection();
                MySqlCommand command = new MySqlCommand("INSERT INTO pagos (User_id, Pagos_mes_cobro, Pagos_fecha_pago, Pagos_estado) VALUES (@userId, MONTHNAME(NOW()) , NOW(), 'Pendiente')", mysql);
                command.Parameters.AddWithValue("@userId", item.User_id);
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

        public bool InsertarU(User item)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.GetConnection();
                MySqlCommand command = new MySqlCommand("INSERT INTO pagos (User_id, Pagos_mes_cobro, Pagos_fecha_pago, Pagos_estado) VALUES (@userId, MONTHNAME(NOW()) , NOW(), 'Pendiente')", mysql);
                command.Parameters.AddWithValue("@userId", item.User_id);
                command.ExecuteNonQueryAsync();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en InsertarU pagos: " + e.Message);
                Console.WriteLine(e);
                return false;
            }
        }

        //Modifica un pago existente.
        public bool Modificar(Pagos item)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.GetConnection();
                MySqlCommand command2 = new MySqlCommand("UPDATE pagos SET Pagos_estado = @estado WHERE Pagos_id = @idPago", mysql);
                command2.Parameters.AddWithValue("@idPago", item.Pagos_id);
                command2.Parameters.AddWithValue("@estado", item.Pagos_estado);
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
        public List<Pagos> VerTodo()
        {
            try
            {
                List<Pagos> lista = new List<Pagos>();
                Connection conn = new Connection();
                MySqlConnection mysql = conn.GetConnection();
                MySqlCommand command = new MySqlCommand("SELECT * FROM pagos", mysql);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Pagos pago = new Pagos
                    {
                        Pagos_id = reader.GetInt32(0),
                        Pagos_mes_cobro = reader.GetString(1),
                        Pagos_fecha_pago = reader.GetDateTime(2),
                        Pagos_estado = reader.GetString(3)
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

        public List<Pagos> VerClienteSeleccionado(int id)
        {
            try
            {
                List<Pagos> lista = new List<Pagos>();
                Connection conn = new Connection();
                MySqlConnection mysql = conn.GetConnection();
                MySqlCommand command = new MySqlCommand("SELECT pagos_id, pagos_mes_cobro, pagos_fecha_pago, pagos_estado FROM pagos WHERE user_id = @val1", mysql);
                command.Parameters.AddWithValue("@val1", id);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Pagos pago = new Pagos
                    {
                        Pagos_id = reader.GetInt32(0),
                        Pagos_mes_cobro = reader.GetString(1),
                        Pagos_fecha_pago = Convert.ToDateTime(reader.GetDateTime(2)),
                        Pagos_estado = reader.GetString(3)
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
                MySqlConnection mysql = conn.GetConnection();
                MySqlCommand command = new MySqlCommand("SELECT * FROM pagos WHERE pagos_estado = Pagado", mysql);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Pagos pago = new Pagos
                    {
                        Pagos_id = reader.GetInt32(0),
                        Pagos_fecha_pago = reader.GetDateTime(1),
                        Pagos_estado = reader.GetString(2)
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
