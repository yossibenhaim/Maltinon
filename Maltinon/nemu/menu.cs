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

        public menu()
        {
            menager = new menager();
            dal = new DAL();
        }
        public void startNemu()
        {
            bool run = true;
            int choice;
            string pseudonym = MenuLogin();
            Logs.SendLog(SqlQueryBuilder.ReadLog($"Entering the menu.", "info", "menu.startMenu"));
            Logs.SendLog(SqlQueryBuilder.ReadLog($"Entering the menu loop.", "info", "menu.startNemu"));
            while (run)
            {
                Prints.ShowMenuLogin();

                string choiceStr;
                Logs.SendLog(SqlQueryBuilder.ReadLog($"Enters an input checking loop for the menu.", "info", "menu.startNemu"));

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
                        Logs.SendLog(SqlQueryBuilder.ReadLog($"Invalid input received.", "warning", "menu.startNemu"));
                    }
                }
                Logs.SendLog(SqlQueryBuilder.ReadLog($"Input OK - exits the loop.", "info", "menu.startNemu"));

                switch (choice)
                {
                    case 1:
                        Logs.SendLog(SqlQueryBuilder.ReadLog($"Select Add Report.", "info", "menu.startNemu"));
                        menager.AddRepoert(pseudonym);
                        break;
                    case 2:
                        Logs.SendLog(SqlQueryBuilder.ReadLog($"Selected Print code name by name.", "info", "menu.startNemu"));
                        menager.PrintPseudonym();
                        break;
                    case 3:
                        Logs.SendLog(SqlQueryBuilder.ReadLog($"User change selected.", "info", "menu.startNemu"));
                        pseudonym = MenuLogin();
                        break;
                    case 4:
                        Logs.SendLog(SqlQueryBuilder.ReadLog($"Exit menu selected.", "info", "menu.startNemu"));
                        run = false;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("✔ Exiting the system. Stay safe!");
                        Console.ResetColor();
                        break;
                    default:
                        Logs.SendLog(SqlQueryBuilder.ReadLog($"Invalid input received.", "warning", "menu.startNemu"));
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("ℹ Please choose a number between 1 and 4.");
                        Console.ResetColor();
                        break;
                }
            }
            Logs.SendLog(SqlQueryBuilder.ReadLog($"You have exited the menu loop..", "info", "menu.startNemu"));
        }
        public string MenuLogin()
        {
            Logs.SendLog(SqlQueryBuilder.ReadLog($"Entering the menuLogin.", "info", "menu.MenuLogin"));
            Prints.ShowStartUsers();

            string pseudonym = Console.ReadLine();
            Logs.SendLog(SqlQueryBuilder.ReadLog($"User entered a secret code ({pseudonym}).", "info", "menu.MenuLogin"));

            string status = menager.CheckExistingUser(pseudonym);
            if (status.Length == 0)
            {
                Logs.SendLog(SqlQueryBuilder.ReadLog($"Code name not found. Goes to search by name ({pseudonym}).", "info", "menu.MenuLogin"));
                return menager.CreatUser();
            }
            else
            {
                Logs.SendLog(SqlQueryBuilder.ReadLog($"User ({pseudonym}) found. Goes to menu.", "info", "menu.MenuLogin"));
                if (menager.CheckIfAgent(status))
                {
                    Logs.SendLog(SqlQueryBuilder.ReadLog($"The user ({pseudonym}) is an agent. Goes to the agents menu.", "info", "menu.MenuLogin"));
                    menuAgent();
                }
                return pseudonym;
            }
        }

        

        public void menuAgent()
        {
            bool run = true;
            int choice;
            Logs.SendLog(SqlQueryBuilder.ReadLog($"Entering the menu loop.", "info", "menu.MenuAgent"));
            while (run)
            {

                Prints.ShowMenuAgent();

                string choiceStr = Console.ReadLine();
                Logs.SendLog(SqlQueryBuilder.ReadLog($"Enters an input checking loop for the menu.", "info", "menu.MenuAgent"));
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
                        Logs.SendLog(SqlQueryBuilder.ReadLog($"Invalid input received.", "warning", "menu.MenuAgent"));


                    }
                }
                Logs.SendLog(SqlQueryBuilder.ReadLog($"Input OK - exits the loop.", "info", "menu.MenuAgent"));

                switch (choice)
                {
                    case 1:
                        Logs.SendLog(SqlQueryBuilder.ReadLog($"Selected Print Reports.", "info", "menu.MenuAgent"));
                        menager.PrintResophns();
                        break;
                    case 2:
                        Logs.SendLog(SqlQueryBuilder.ReadLog($"Selected for printing candidates for recruitment.", "info", "menu.MenuAgent"));
                        menager.PrintCandidateEligibility();
                        Logs.SendLog(SqlQueryBuilder.ReadLog($"Enter the recruitment candidates menu.", "info", "menu.MenuAgent"));
                        MenuCandidateEligibility();
                        break;
                    case 3:
                        Logs.SendLog(SqlQueryBuilder.ReadLog($"Prints dangerous people.", "info", "menu.MenuAgent"));
                        menager.PrintDangerousTargets();
                        break;
                    case 4:
                        Logs.SendLog(SqlQueryBuilder.ReadLog($"Select Print personal code.", "info", "menu.MenuAgent"));
                        menager.PrintPseudonym();
                        break;
                    case 5:
                        Logs.SendLog(SqlQueryBuilder.ReadLog($"User exit selected.", "info", "menu.MenuAgent"));
                        run = false;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("✔ Exiting Agent Mode. Logged out.");
                        Console.ResetColor();
                        break;
                    default:
                        Logs.SendLog(SqlQueryBuilder.ReadLog($"Invalid input received.", "warning", "menu.MenuAgent"));
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("ℹ Please choose a number between 1 and 4.");
                        Console.ResetColor();
                        break;
                }
            }
            Logs.SendLog(SqlQueryBuilder.ReadLog($"You have exited the menu loop..", "info", "menu.MenuAgent"));

        }

        public void MenuCandidateEligibility()
        {
            Logs.SendLog(SqlQueryBuilder.ReadLog($"Entering MenuCandidateEligibility.", "info", "menu.MenuCandidateEligibility"));

            Prints.ShowMenuCandidateEligibility();

            int choice;
            string choiceStr = Console.ReadLine();
            Logs.SendLog(SqlQueryBuilder.ReadLog($"Enters an input checking loop for the menu.", "info", "menu.MenuCandidateEligibility"));
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
                    Logs.SendLog(SqlQueryBuilder.ReadLog($"Invalid input received.", "warning", "menu.MenuCandidateEligibility"));

                }
            }
            Logs.SendLog(SqlQueryBuilder.ReadLog($"Input OK - exits the loop.", "info", "menu.MenuCandidateEligibility"));


            switch (choice)
            {
                case 1:
                    Logs.SendLog(SqlQueryBuilder.ReadLog($"Elected promotion of all candidates..", "info", "menu.MenuAgent"));
                    menager.UpdeteCandidateEligibility();
                    break;
                case 2:
                    Logs.SendLog(SqlQueryBuilder.ReadLog($"Selected Promotion of a specific candidate for selection..", "info", "menu.MenuAgent"));
                    menager.UpdeteStatusToAgent();
                    break;
                case 3:
                    Logs.SendLog(SqlQueryBuilder.ReadLog($"Cancel and exit selected..", "info", "menu.MenuAgent"));
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("↩ Action cancelled.");
                    Console.ResetColor();
                    break;
                default:
                    Logs.SendLog(SqlQueryBuilder.ReadLog($"Invalid input received.", "warning", "menu.MenuCandidateEligibility"));
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("ℹ Please choose a number between 1 and 3.");
                    Console.ResetColor();
                    break;
            }
        }
    }
}
