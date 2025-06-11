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

        public string StartUsers()
        {
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║     Welcome to the Whistleblowing Hub    ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");
            Console.WriteLine("║ Please enter your secret code name below ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");

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

            string pseudonym = StartUsers();
            while (run)
            {
                Console.WriteLine("\n╔═══════════════════════════════════╗");
                Console.WriteLine("║       Main Menu – Choose Option   ║");
                Console.WriteLine("╠═══════════════════════════════════╣");
                Console.WriteLine("║ 1 → Add an intelligence report    ║");
                Console.WriteLine("║ 2 → Get your secret name          ║");
                Console.WriteLine("║ 3 → Switch user                   ║");
                Console.WriteLine("║ 4 → Exit                          ║");
                Console.WriteLine("╚═══════════════════════════════════╝");

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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("⚠ Error: Please enter a valid number.");
                        Console.ResetColor();
                        Console.Write("↺ Try again: ");
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
                        pseudonym = StartUsers();
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
                Console.WriteLine("\n╔══════════════════════════════════════╗");
                Console.WriteLine("║       Agent Menu – Classified Zone   ║");
                Console.WriteLine("╠══════════════════════════════════════╣");
                Console.WriteLine("║ 1 → View potential recruits          ║");
                Console.WriteLine("║ 2 → View suspected agents            ║");
                Console.WriteLine("║ 3 → Show my secret code name         ║");
                Console.WriteLine("║ 4 → Exit                             ║");
                Console.WriteLine("╚══════════════════════════════════════╝");

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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("⚠ Error: Please enter a valid number.");
                        Console.ResetColor();
                        Console.Write("↺ Try again: ");
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
                        menager.PrintPseudonym();
                        break;
                    case 4:
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
            Console.WriteLine("\n╔════════════════════════════════════════════╗");
            Console.WriteLine("║   Candidate Promotion – Select Action      ║");
            Console.WriteLine("╠════════════════════════════════════════════╣");
            Console.WriteLine("║ 1 → Promote all candidates to Agent        ║");
            Console.WriteLine("║ 2 → Promote a specific candidate           ║");
            Console.WriteLine("║ 3 → Cancel                                 ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");

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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("⚠ Error: Please enter a valid number.");
                    Console.ResetColor();
                    Console.Write("↺ Try again: ");
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
