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

        public menu()
        {
            menager = new menager();
        }

        public string MenuLogin()
        {
            Prints.ShowStartUsers();

            string pseudonym = Console.ReadLine();
            string status = menager.CheckExistingUser(pseudonym);
            if (status.Length == 0)
            {
                return menager.CreatUser();
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

        public void startNemu()
        {
            bool run = true;
            int choice;

            string pseudonym = MenuLogin();
            while (run)
            {
                Prints.ShowMenuLogin();

                string choiceStr;

                while (true)
                {
                    choiceStr = Console.ReadLine();
                    try
                    {
                        choice = int.Parse(choiceStr);
                        break;
                    }
                    catch
                    {
                        Prints.ShowRequestEnterNumber();
                    }
                }

                switch (choice)
                {
                    case 1:
                        menager.AddRepoert(pseudonym);
                        break;
                    case 2:
                        menager.PrintPseudonym();
                        break;
                    case 3:
                        pseudonym = MenuLogin();
                        break;
                    case 4:
                        run = false;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("✔ Exiting the system. Stay safe!");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("ℹ Please choose a number between 1 and 4.");
                        Console.ResetColor();
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

                Prints.ShowMenuAgent();

                string choiceStr = Console.ReadLine();

                while (true)
                {
                    try
                    {
                        choice = int.Parse(choiceStr);
                        break;
                    }
                    catch
                    {
                        Prints.ShowRequestEnterNumber();
                    }
                }

                switch (choice)
                {
                    case 1:
                        menager.PrintResophns();
                        break;
                    case 2:
                        menager.PrintCandidateEligibility();
                        MenuCandidateEligibility();
                        break;
                    case 3:
                        menager.PrintDangerousTargets();
                        break;
                    case 4:
                        menager.PrintPseudonym();
                        break;
                    case 5:
                        run = false;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("✔ Exiting Agent Mode. Logged out.");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("ℹ Please choose a number between 1 and 4.");
                        Console.ResetColor();
                        break;
                }
            }
        }

        public void MenuCandidateEligibility()
        {
            Prints.ShowMenuCandidateEligibility();

            int choice;
            string choiceStr = Console.ReadLine();

            while (true)
            {
                try
                {
                    choice = int.Parse(choiceStr);
                    break;
                }
                catch
                {
                    Prints.ShowRequestEnterNumber();
                }
            }

            switch (choice)
            {
                case 1:
                    menager.UpdeteCandidateEligibility();
                    break;
                case 2:
                    menager.UpdeteStatusToAgent();
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("↩ Action cancelled.");
                    Console.ResetColor();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("ℹ Please choose a number between 1 and 3.");
                    Console.ResetColor();
                    break;
            }
        }
    }
}
