using MySqlConnector;
using SyncBlackDuck.Model;
using SyncBlackDuck.Services.Interfaces;
using System;
using System.Collections;
using Windows.UI.Xaml;
using Xamarin.Forms;

namespace SyncBlackDuck.Services
{

    public class loginService : Connection, ICRUD<userInstance>
    {
        public string loginByRank(int t, string p)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.getConnection();
                MySqlCommand command = new MySqlCommand("SELECT user_rol FROM user WHERE user_telefono = @val1 AND user_password = @val2;", mysql);
                command.Parameters.AddWithValue("@val1", t);
                command.Parameters.AddWithValue("@val2", p);
                MySqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    if (reader.GetString(0) != null)
                    {
                        
                        return reader.GetString(0);
                    }
                }
                
                return "na";
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "error";
            }

        }


        public ArrayList verTodo()
        {
            throw new NotImplementedException();
        }

        bool ICRUD<userInstance>.eliminar(userInstance user)
        {
            throw new NotImplementedException();
        }

        bool ICRUD<userInstance>.insertar(userInstance user)
        {
            throw new NotImplementedException();
        }

        bool ICRUD<userInstance>.modificar(userInstance user)
        {
            throw new NotImplementedException();
        }
    }
}
