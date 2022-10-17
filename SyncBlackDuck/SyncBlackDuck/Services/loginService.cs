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
        public Boolean validacionLogin(userInstance u)
        {
            Connection conn = new Connection();
            MySqlConnection mysql = conn.getConnection();
            mysql.Open();
            try 
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM test.usuarios WHERE nameUser = @val1 AND passUser = @val2;", mysql);
                command.Parameters.AddWithValue("@val1", u.Name);
                command.Parameters.AddWithValue("@val2", u.Password);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
                return false;

            } finally
            {
                conn.Disconnect();
            }
        }
        public string loginByRank(int t, string p)
        {
            try
            {
                Connection conn = new Connection();
                MySqlConnection mysql = conn.getConnection();
                mysql.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM test.usuarios WHERE telefono = @val1 AND password = @val2;", mysql);
                command.Parameters.AddWithValue("@val1", t);
                command.Parameters.AddWithValue("@val2", p);
                MySqlDataReader reader = command.ExecuteReader();

                string rank = null;

                return rank;
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
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
