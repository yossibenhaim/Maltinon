using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            string query = "SELECT p.pseudonym, AVG(CHAR_LENGTH(r.report)) AS avg_length, p.status , COUNT(report) countr " +
                "FROM reports r " +
                " JOIN people p ON r.informer_pseudonym = p.pseudonym " +
                " GROUP BY p.pseudonym " +
                " HAVING avg_length > 100 " +
                " AND p.status != 'agent' " +
                "  AND countr > 20 " +
                "  ORDER BY avg_length; ";
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
        public string GetPromtReturnDangerousTargets()
        {
            string query = "SELECT p.lastName, p.firstName, r1.accused_pseudonym, r1.created_at, COUNT(*) AS a " +
                "FROM reports r1 JOIN reports r2 ON r2.accused_pseudonym = r1.accused_pseudonym " +
                "AND r2.created_at BETWEEN r1.created_at - INTERVAL 15 MINUTE AND r1.created_at " +
                "JOIN people p ON p.pseudonym = r1.accused_pseudonym " +
                "GROUP BY r1.accused_pseudonym, r1.created_at, p.lastName, p.firstName " +
                "HAVING a >= 3 " +
                "ORDER BY r1.created_at; ";
            return query;
        }
    }
}
