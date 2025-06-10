using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace Maltinon
{
    internal class menu
    {
        menager menager;
        DAL dal;
        SqlQueryBuilder builder;

        public menu()
        {
            menager = new menager();
            dal = new DAL();
            builder = new SqlQueryBuilder();
        }


        public void startNemu()
        {
            
            bool run = true;
            int choice;

            while (run)
            {

                StartUsers();

                Console.WriteLine("Enter ");
                string choiceStr;


                while (true)
                {
                    choiceStr = Console.ReadLine();

                    try
                    {
                        choice = int.Parse(choiceStr);
                        break;
                    }
                    catch { Console.WriteLine("plese send a number!"); }
                }

                switch (choice)
                {
                    case 1:
                        menager.startAgent();
                        break;
                    case 2:
                        run = false;
                        break;
                }

            }
        }

        public void menuAgent()
        {
            bool run = true;
            int choice;

            while (run)
            {

                Console.WriteLine(
                    "Press 1 for a list of potential recruits\r\n" +
                    "Press 2 for a list of suspected agents\r\n" +
                    "Press 3 to exit");

                string choiceStr = Console.ReadLine();

                while (true)
                {
                    try
                    {
                        choice = int.Parse(choiceStr);
                        break;
                    }
                    catch { Console.WriteLine("plese send a number!"); }
                }

                switch (choice)
                {
                    case 1:
                        run = false;
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }

            }
        }

        public string StartUsers()
        {
            Console.WriteLine("Enter a pseudonym");
            string pseudonym = Console.ReadLine();
            string status = menager.CheckExistingUser(pseudonym);
            if (status.Length == 0)
            {
                return CreatUser(); 
            }
            else
            {
                if (menager.CheckIfAgent(status))
                {
                    menuAgent();
                }
                return pseudonym;
            }
        }
        
        public string CreatUser()
        {
            Console.WriteLine("Enter a last name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter a first name");
            string firstName = Console.ReadLine();
            string pseudonym = $"@{lastName[0]}&{firstName[0]}";
            dal.SendQuery(builder.GetPromptForAddPerson(firstName, lastName ,pseudonym, "infomant"));
            return pseudonym;
        }
    }
}
