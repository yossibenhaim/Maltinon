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
        public DAL()
        {
            conn = new MySqlConnection(connStr);
        }

        public List<Dictionary<string, string>> GetQuery(string query)
        {

            conn.Open();

            try
            {
                MySqlCommand command = new MySqlCommand(query, conn);

                MySqlDataReader reader = command.ExecuteReader();

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
                conn.Close();
                return respose;
            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
                return new List<Dictionary<string, string>>();
            }
        }

        public void SendQuery(string query)
        {

            conn.Open();
            try
            {
                MySqlCommand command = new MySqlCommand(query, conn);

                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
        }
    }
}
