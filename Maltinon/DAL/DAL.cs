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

            MySqlCommand command = new MySqlCommand(query, conn);

            MySqlDataReader reader = command.ExecuteReader();

            List<Dictionary<string, string>> respose = new List<Dictionary<string, string>>();

            while (reader.Read())
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dict[reader.GetName(i)] = reader.GetValue(i).ToString();
                }respose.Add(dict);
            }
            conn.Close();
            return respose;
        }

        public string GetPromtForAddTerorrist(string name)
        {
            string query = "INSERT INTO terorrists " +
                "(name)" +
                $" VALUES ('{name}');";
            return query;
        }
        public string GetPromtForAddInformants(string userName, string name)
        {
            string query = "INSERT INTO informants" +
                "(userName, name)" +
                $"VALUES ('{userName}', '{name}');";
            return query;
        }
        public string GetPromtForAddReports(string userName, string nameTerorrist, string text)
        {
            string query = $"INSERT INTO reports (informantsId, terorristsId, report)" +
                $"VALUES ('{userName}', '{nameTerorrist}', '{text}');";
            return query;
        }
        public string GetPromtForReturnReports()
        {
            string query = "SELECT  i.name AS informantName, " +
                "t.name AS terroristName, r.report," +
                "r.collectionDate FROM reports r" +
                "JOIN informants i ON r.informantsId = i.id" +
                "JOIN terorrists t ON r.terorristsId = t.id;";
            return query;
        }
        public string GEtCheckExistingUser(string userName, string teble) 
        {
            string query = $"SELECT 1 FROM {teble} WHERE userName = '{userName}' OR id = '{userName}' LIMIT 1;";
            return query;
        }
        public string GetCheckUserAgnt(string userName) 
        {
            string query = $"SELECT 1 FROM agents WHERE userName = '{userName}' LIMIT 1;";
            return query;
        }
        public string GetCandidateEligibilityQuery(string userName)
        {
            string query = "";
            return query;
        }
    }
}
