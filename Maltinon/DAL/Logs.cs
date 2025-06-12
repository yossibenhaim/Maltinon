using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maltinon
{
    internal static class Logs
    {
        public static string connStr = "server=localhost;userName=root;password=;database=Malsinon";
        static MySqlConnection conn;
        public static void SendLog(string log, string level, string location)
        {
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                try
                {
                    string query = "INSERT INTO logs (log, level, location_log) VALUES (@log, @level, @location)";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    command.Parameters.AddWithValue("@log", log);
                    command.Parameters.AddWithValue("@level", level);
                    command.Parameters.AddWithValue("@location", location);
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

    }
}
