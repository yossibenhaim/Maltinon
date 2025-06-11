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

        public string GetPromptForAddReport(string informerPseudonym, string accusedPseudonym, string reportText)
        {
            string query = "INSERT INTO reports (informer_pseudonym , accused_pseudonym , report) " +
                           $"VALUES ('{informerPseudonym}', '{accusedPseudonym}', '{reportText}');";
            return query;
        }

        public string GetPromptForReturnRepoerts()
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
            string query = "SELECT p.pseudonym, AVG(CHAR_LENGTH(r.report)) AS avg_length " +
                           "FROM people p " +
                           "JOIN reports r ON r.informer_pseudonym  = p.id " + 
                           "GROUP BY p.id, p.pseudonym " + 
                           "HAVING avg_length > 20 " +
                           "AND p.status != 'agent' "+
                           "ORDER BY avg_length;";
            return query;
        }

        public string UpdeteToAgent(string pseudonym)
        {
            string query = 
                "UPDATE people\r\n" +
                "SET status = 'agent'\r\n" +
                $"WHERE pseudonym = '{pseudonym}';";
            return query;
        }

        public string GetPromtToReturnIdByPseudonym(string pseudonym)
        {
            string query = $"SELECT * FROM people WHERE pseudonym = '{pseudonym}';";
            return query;
        }
        public string GetPromtToReturnIdByName(string lastName, string firstName)
        {
            string query = $"SELECT pseudonym FROM people WHERE lastName = '{lastName}' AND firstName = '{firstName}';";
            return query;
        }
    }
}
