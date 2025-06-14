﻿using System;
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
            Logs.SendLog($"Entering the menu.", "info", "menu.startMenu");
            Logs.SendLog($"Entering the menu loop.", "info", "menu.startNemu");
            while (run)
            {
                Prints.ShowMenuLogin();

                string choiceStr;
                Logs.SendLog($"Enters an input checking loop for the menu.", "info", "menu.startNemu");

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
                        Logs.SendLog($"Invalid input received.", "warning", "menu.startNemu");
                    }
                }
                Logs.SendLog($"Input OK - exits the loop.", "info", "menu.startNemu");

                switch (choice)
                {
                    case 1:
                        Logs.SendLog($"Select Add Report.", "info", "menu.startNemu");
                        menager.AddRepoert(pseudonym);
                        break;
                    case 2:
                        Logs.SendLog($"Selected Print code name by name.", "info", "menu.startNemu");
                        menager.PrintPseudonym();
                        break;
                    case 3:
                        Logs.SendLog($"User change selected.", "info", "menu.startNemu");
                        pseudonym = MenuLogin();
                        break;
                    case 4:
                        Logs.SendLog($"Exit menu selected.", "info", "menu.startNemu");
                        run = false;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("✔ Exiting the system. Stay safe!");
                        Console.ResetColor();
                        break;
                    default:
                        Logs.SendLog($"Invalid input received.", "warning", "menu.startNemu");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("ℹ Please choose a number between 1 and 4.");
                        Console.ResetColor();
                        break;
                }
            }
            Logs.SendLog($"You have exited the menu loop..", "info", "menu.startNemu");
        }
        public string MenuLogin()
        {
            Logs.SendLog($"Entering the menuLogin.", "info", "menu.MenuLogin");
            Prints.ShowStartUsers();

            string pseudonym = Console.ReadLine();
            Logs.SendLog($"User entered a secret code ({pseudonym}).", "info", "menu.MenuLogin");

            string status = menager.CheckExistingUser(pseudonym);
            if (status.Length == 0)
            {
                Logs.SendLog($"Code name not found. Goes to search by name ({pseudonym}).", "info", "menu.MenuLogin");
                return menager.CreatUser();
            }
            else
            {
                Logs.SendLog($"User ({pseudonym}) found. Goes to menu.", "info", "menu.MenuLogin");
                if (menager.CheckIfAgent(status))
                {
                    Logs.SendLog($"The user ({pseudonym}) is an agent. Goes to the agents menu.", "info", "menu.MenuLogin");
                    menuAgent();
                }
                return pseudonym;
            }
        }

        

        public void menuAgent()
        {
            bool run = true;
            int choice;
            Logs.SendLog($"Entering the menu loop.", "info", "menu.MenuAgent");
            while (run)
            {

                Prints.ShowMenuAgent();

                string choiceStr = Console.ReadLine();
                Logs.SendLog($"Enters an input checking loop for the menu.", "info", "menu.MenuAgent");
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
                        Logs.SendLog($"Invalid input received.", "warning", "menu.MenuAgent");


                    }
                }
                Logs.SendLog($"Input OK - exits the loop.", "info", "menu.MenuAgent");

                switch (choice)
                {
                    case 1:
                        Logs.SendLog($"Selected Print Reports.", "info", "menu.MenuAgent");
                        menager.PrintResophns();
                        break;
                    case 2:
                        Logs.SendLog($"Selected for printing candidates for recruitment.", "info", "menu.MenuAgent");
                        menager.PrintCandidateEligibility();
                        Logs.SendLog($"Enter the recruitment candidates menu.", "info", "menu.MenuAgent");
                        MenuCandidateEligibility();
                        break;
                    case 3:
                        Logs.SendLog($"Prints dangerous people.", "info", "menu.MenuAgent");
                        menager.PrintDangerousTargets();
                        break;
                    case 4:
                        Logs.SendLog($"Select Print personal code.", "info", "menu.MenuAgent");
                        menager.PrintPseudonym();
                        break;
                    case 5:
                        Logs.SendLog($"User exit selected.", "info", "menu.MenuAgent");
                        run = false;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("✔ Exiting Agent Mode. Logged out.");
                        Console.ResetColor();
                        break;
                    default:
                        Logs.SendLog($"Invalid input received.", "warning", "menu.MenuAgent");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("ℹ Please choose a number between 1 and 4.");
                        Console.ResetColor();
                        break;
                }
            }
            Logs.SendLog($"You have exited the menu loop..", "info", "menu.MenuAgent");

        }

        public void MenuCandidateEligibility()
        {
            Logs.SendLog($"Entering MenuCandidateEligibility.", "info", "menu.MenuCandidateEligibility");

            Prints.ShowMenuCandidateEligibility();

            int choice;
            string choiceStr = Console.ReadLine();
            Logs.SendLog($"Enters an input checking loop for the menu.", "info", "menu.MenuCandidateEligibility");
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
                    Logs.SendLog($"Invalid input received.", "warning", "menu.MenuCandidateEligibility");

                }
            }
            Logs.SendLog($"Input OK - exits the loop.", "info", "menu.MenuCandidateEligibility");


            switch (choice)
            {
                case 1:
                    Logs.SendLog($"Elected promotion of all candidates..", "info", "menu.MenuAgent");
                    menager.UpdeteCandidateEligibility();
                    break;
                case 2:
                    Logs.SendLog($"Selected Promotion of a specific candidate for selection..", "info", "menu.MenuAgent");
                    menager.UpdeteStatusToAgent();
                    break;
                case 3:
                    Logs.SendLog($"Cancel and exit selected..", "info", "menu.MenuAgent");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("↩ Action cancelled.");
                    Console.ResetColor();
                    break;
                default:
                    Logs.SendLog($"Invalid input received.", "warning", "menu.MenuCandidateEligibility");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("ℹ Please choose a number between 1 and 3.");
                    Console.ResetColor();
                    break;
            }
        }
    }
}
