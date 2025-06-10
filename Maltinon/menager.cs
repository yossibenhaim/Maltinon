using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maltinon
{
    internal class menager
    {
        SqlQueryBuilder builder;
        DAL dal;

        public menager()
        {
            dal = new DAL();
            builder = new SqlQueryBuilder();
        }


        public string CheckExistingUser(string pseudonym)
        {
            List<Dictionary<string, string>> resphon = dal.GetQuery(builder.GetPromptCheckExistingUser(pseudonym));
            if (resphon.Count > 0)
            {
                Console.WriteLine(resphon[0]["status"]);
                return resphon[0]["status"];
            }
            else { return ""; }
        }

        public bool CheckIfAgent(string pseudonym)
        {
            switch (pseudonym)
            {
                case "agent":
                    return true;
                default:
                    return false;
            }
        }



        public void startAgent()
        {
            Console.WriteLine("send user name");
            string userName = Console.ReadLine();

        }




        public void printResophns()
        {

            List<Dictionary<string, string>> a = dal.GetQuery(builder.GetPromptForReturnReports());

            if (a.Count > 0)
            {
                foreach (string key in a[0].Keys)
                {
                    Console.Write(key + "                   ");
                }
                Console.WriteLine();
                foreach (Dictionary<string, string> dict in a)
                {
                    foreach (string value in dict.Values)
                    {
                        Console.Write(value + "                   ");

                    }
                    Console.WriteLine();
                }

            }
        }

        public void UpdeteCandidateEligibility(string pseudonym)
        {
            List<Dictionary<string, string>> CandidateEligibility = dal.GetQuery(builder.GetCandidateEligibilityQuery());
            foreach(Dictionary<string,string> dict in CandidateEligibility)
            {
                dal.SendQuery(builder.UpdeteToAgent(pseudonym));
            }
        } 

    }
}
