using System;
using MySql;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Reflection.Emit;

namespace Maltinon
{
    internal class DAL
    {

        public void connection(string query)
        {
            string connStr = "server=localhost;userName=root;password=;database=Malsinon";
            MySqlConnection conn = new MySqlConnection(connStr);

            conn.Open();

            MySqlCommand command = new MySqlCommand(query, conn);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.WriteLine(reader.GetName(i));
                    Console.WriteLine(reader.GetValue(i));

                }
            }
        }

        public string getPromtForAddTerorrist()
        {
            string query = "INSERT INTO terorrists " +
                "(name, QuantityIntelligenceReports)" +
                " VALUES ('Ali Ahmad', 3);";
            return query;
        }
        public string getPromtForAddInformants()
        {
            string query = "INSERT INTO informants " +
                "(userName, name, amountWhistleblowing)" +
                "VALUES ('informant01', 'David Cohen', 5);";
            return query;
        }
        public string getPromtForAddReports()
        {
            string query = "INSERT INTO reports (informantsId, terorristsId, report)" +
                "VALUES (1, 1, 'The suspect is planning a major operation next week.');";
            return query;
        }
        public string getPromtForReturnReports()
        {
            string query = "SELECT  i.name AS informantName, " +
                "t.name AS terroristName, r.report," +
                "r.collectionDate FROM reports r" +
                "JOIN informants i ON r.informantsId = i.id" +
                "JOIN terorrists t ON r.terorristsId = t.id;";
            return query;
        }
    }
}
