using MySqlConnector;
using SyncBlackDuck.Model;
using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SyncBlackDuck.Services.Implementaciones
{
    internal class userImpl : Connection, ICRUD<user>
    {
        public bool eliminar(user item)
        {
            try
                {
                    Connection conn = new Connection();
                    MySqlConnection mysql = conn.getConnection();
                    mysql.Open();
                    MySqlCommand command = new MySqlCommand("DELETE FROM user WHERE idUser = @idUser", mysql);
                    command.Parameters.AddWithValue("@idUser", item.User_id);
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

        public bool insertar(user item)
        {
            throw new NotImplementedException();
        }

        public bool modificar(user item, char T)
        {
            throw new NotImplementedException();
        }

        public ArrayList verTodo()
        {
            throw new NotImplementedException();
        }
    }
}
