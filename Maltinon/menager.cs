using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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
                return resphon[0]["status"];
            else
                return "";
        }

        public bool CheckIfAgent(string pseudonym)
        {
            return pseudonym == "agent";
        }

        public void startAgent()
        {
            Console.WriteLine("\n====================");
            Console.WriteLine("🔐 Agent Access");
            Console.WriteLine("====================");
            Console.Write("Enter your username: ");
            string userName = Console.ReadLine();
        }

        public void PrintData(List<Dictionary<string, string>> data)
        {
            if (data.Count > 0)
            {
                Console.WriteLine("\n==================================");
                Console.WriteLine("📊 Data:");
                Console.WriteLine("==================================");

                foreach (string key in data[0].Keys)
                    Console.Write($"{key,-20}");
                Console.WriteLine();

                foreach (Dictionary<string, string> dict in data)
                {
                    foreach (string value in dict.Values)
                        Console.Write($"{value,-20}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("⚠️ No data found.");
            }
        }

        public void PrintResophns()
        {
            Console.WriteLine("\n📥 Fetching Reports...");
            PrintData(dal.GetQuery(builder.GetPromptForReturnRepoerts()));
        }

        public void PrintCandidateEligibility()
        {
            Console.WriteLine("\n📋 Candidate Eligibility List:");
            PrintData(dal.GetQuery(builder.GetCandidateEligibilityQuery()));
        }

        public void UpdeteCandidateEligibility()
        {
            List<Dictionary<string, string>> list = dal.GetQuery(builder.GetCandidateEligibilityQuery());
            foreach (Dictionary<string, string> dict in list)
                dal.SendQuery(builder.UpdeteToAgent(dict["pseudonym"]));
            Console.WriteLine("✅ Candidate eligibility updated.");
        }

        public void AddRepoert(string informerPseudonym)
        {
            Console.WriteLine("\n======================");
            Console.WriteLine("📋 Report Submission");
            Console.WriteLine("======================");
            Console.Write("Enter your report (at least 3 words): ");
            string text = Console.ReadLine();
            while (text.Split().Length < 3)
            {
                Console.WriteLine("❌ Error: The report must include at least 3 words. Try again.");
                Console.Write("Enter your report: ");
                text = Console.ReadLine();
            }
            string lastName = FindLastNameInRepoert(text);
            string firstName = FindFirstNameInRepoert(text);
            string accusedpseudonym = GetPseudonymForName(lastName, firstName);
            dal.SendQuery(builder.GetPromptForAddReport(informerPseudonym, accusedpseudonym, text));
            Console.WriteLine("✅ Report submitted successfully. Thank you!");
        }

        public string FindLastNameInRepoert(string report)
        { return report.Split()[0]; }

        public string FindFirstNameInRepoert(string report)
        { return report.Split()[1]; }

        public string GetNameForPseudonym(string pseudonym)
        {
            var data = dal.GetQuery(builder.GetPromtToReturnIdByPseudonym(pseudonym));
            return data[0]["firstName"] + " " + data[0]["lastName"];
        }

        public string GetPseudonymForName(string lastName, string firstName)
        {
            var data = dal.GetQuery(builder.GetPromtToReturnIdByName(lastName, firstName));
            return data.Count > 0 ? data[0]["pseudonym"] : CreatUserWhitName(firstName, lastName);
        }

        public string CreatUser()
        {
            string firstName = EnterFirstName();
            string lastName = EnterLastName();

            var existing = dal.GetQuery(builder.GetPromtToReturnIdByName(firstName, lastName));
            if (existing.Count > 0)
            {
                string pseudonym = GetPseudonymForName(lastName, firstName);
                Console.WriteLine($"🆔 Your pseudonym is: {pseudonym}");
                return pseudonym;
            }

            string newPseudo = GeneratePseudonym(firstName, lastName);
            dal.SendQuery(builder.GetPromptForAddPerson(firstName, lastName, newPseudo, "infomant"));
            Console.WriteLine($"✅ New pseudonym created: {newPseudo}");
            return newPseudo;
        }

        public string CreatUserWhitName(string firstName, string lastName)
        {
            string pseudonym = GeneratePseudonym(firstName, lastName);
            dal.SendQuery(builder.GetPromptForAddPerson(firstName, lastName, pseudonym, "infomant"));
            return pseudonym;
        }

        public string GeneratePseudonym(string firstName, string lastName)
        {
            string fullName = firstName.Trim().ToLower() + " " + lastName.Trim().ToLower();
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(fullName));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 6; i++)
                    sb.Append(hash[i].ToString("x2"));
                return sb.ToString();
            }
        }

        public void UpdeteStatusToAgent()
        {
            Console.WriteLine("\n🔐 Agent Status Update");
            int count = 0;
            while (true)
            {
                Console.Write("Enter pseudonym: ");
                string pseudonym = Console.ReadLine();
                if (CheckIfAgent(pseudonym))
                {
                    dal.SendQuery(builder.UpdeteToAgent(pseudonym));
                    Console.WriteLine("✅ Status updated to agent.");
                    break;
                }
                else if (++count < 4)
                {
                    Console.WriteLine("❌ Incorrect pseudonym. Please try again.");
                }
                else
                {
                    Console.WriteLine("⚠️ Too many attempts. Returning to menu.");
                    break;
                }
            }
        }

        public void PrintPseudonym()
        {
            Console.WriteLine("\n🔎 Find Pseudonym by Name");

            string firstName = EnterFirstName();
            string lastName = EnterLastName();

            var data = dal.GetQuery(builder.GetPromtToReturnIdByName(firstName, lastName));
            if (data.Count == 0)
            {
                Console.WriteLine("❌ Error: Person not found in database.");
            }
            else
            {
                Console.WriteLine($"🆔 Pseudonym: {data[0]["pseudonym"]}");
            }
        }
        public string EnterFirstName()
        {
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();
            return firstName;
        }
        public string EnterLastName()
        {
            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();
            return lastName;
        }

    }
}
