using MySql;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Maltinon
{
    internal class DAL
    {
        public string connStr = "server=localhost;userName=root;password=;database=Malsinon";
        MySqlConnection conn;

        public List<Dictionary<string, string>> GetQuery(string query)
        {
            conn = new MySqlConnection(connStr);

            conn.Open();
            Logs.SendLog(SqlQueryBuilder.ReadLog("The database file opens.", "info", "DAL"));


            try
            {
                MySqlCommand command = new MySqlCommand(query, conn);
                Logs.SendLog(SqlQueryBuilder.ReadLog($"Creating an SQL command({query}) to connect to a database.", "info", "DAL.GetQuery"));


                MySqlDataReader reader = command.ExecuteReader();
                Logs.SendLog(SqlQueryBuilder.ReadLog($"The query ({query}) has been sent to the database.", "info", "DAL.GetQuery"));

                List<Dictionary<string, string>> respose = new List<Dictionary<string, string>>();

                
                while (reader.Read())
                {
                    Dictionary<string, string> dict = new Dictionary<string, string>();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        dict[reader.GetName(i)] = reader.GetValue(i).ToString();
                    }
                    respose.Add(dict);
                }
                Logs.SendLog(SqlQueryBuilder.ReadLog("The database file closes.", "info", "DAL"));

                return respose;
            }catch (Exception e)
            {
                Logs.SendLog(SqlQueryBuilder.ReadLog($"You are getting an error..({e.Message})", "error", "DAL.GetQuery"));
                Console.WriteLine(e.Message);
                Logs.SendLog(SqlQueryBuilder.ReadLog("The database file closes.", "info", "DAL"));
                return new List<Dictionary<string, string>>();
            }
            finally
            {
                conn.Close();
            }
        }

        public void SendQuery(string query)
        {
            conn = new MySqlConnection(connStr);

            conn.Open();
            Logs.SendLog(SqlQueryBuilder.ReadLog("The database file opens.", "info", "DAL"));

            try
            {
                MySqlCommand command = new MySqlCommand(query, conn);
                Logs.SendLog(SqlQueryBuilder.ReadLog($"Creating an SQL command({query}) to connect to a database.", "info", "DAL.SendQuery"));
                command.ExecuteNonQuery();
                Logs.SendLog(SqlQueryBuilder.ReadLog($"The query ({query}) has been sent to the database.", "info", "DAL.SendQuery"));
                Logs.SendLog(SqlQueryBuilder.ReadLog("The database file closes.", "info", "DAL"));


            }
            catch (Exception e)
            {
                Logs.SendLog(SqlQueryBuilder.ReadLog($"You are getting an error..({e.Message})", "error", "DAL.SendQuery"));
                Console.WriteLine(e.Message);
                Logs.SendLog(SqlQueryBuilder.ReadLog("The database file closes.", "info", "DAL"));
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
