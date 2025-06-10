using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maltinon
{
    internal class SqlQueryBuilder
    {
        public string GetPromptForAddPerson(string firstName, string lastName, string pseudonym, string status)
        {
            string query = "INSERT INTO people (firstName, lastName, pseudonym, status) " +
                           $"VALUES ('{firstName}', '{lastName}', '{pseudonym}', '{status}');";
            return query;
        }

        public string GetPromptForAddReport(int informerId, int accusedId, string reportText)
        {
            string query = "INSERT INTO reports (informer_id, accused_id, report) " +
                           $"VALUES ({informerId}, {accusedId}, '{reportText}');";
            return query;
        }

        public string GetPromptForReturnReports()
        {
            return "SELECT * FROM reports;";
        }

        public string GetPromptCheckExistingUser(string pseudonym)
        {
            string query = $"SELECT * FROM people WHERE pseudonym = '{pseudonym}' LIMIT 1;";
            return query;
        }


        public string GetCandidateEligibilityQuery()
        {
            string query = "SELECT informer_id, AVG(CHAR_LENGTH(report)) AS avg_length " +
                           "FROM reports " +
                           "GROUP BY informer_id " +
                           "HAVING avg_length > 20 " +
                           "ORDER BY avg_length;";
            return query;
        }
    }
}
