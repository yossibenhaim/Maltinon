using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maltinon
{
    internal class Prints
    {
        public static void ShowStartUsers()
        {
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║     Welcome to the Whistleblowing Hub    ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");
            Console.WriteLine("║ Please enter your secret code name below ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
        }
        public static void ShowStartMenu()
        {
            Console.WriteLine("\n╔═══════════════════════════════════╗");
            Console.WriteLine("║       Main Menu – Choose Option   ║");
            Console.WriteLine("╠═══════════════════════════════════╣");
            Console.WriteLine("║ 1 → Add an intelligence report    ║");
            Console.WriteLine("║ 2 → Get your secret name          ║");
            Console.WriteLine("║ 3 → Switch user                   ║");
            Console.WriteLine("║ 4 → Exit                          ║");
            Console.WriteLine("╚═══════════════════════════════════╝");
        }
        public static void ShowMenuAgent()
        {
            Console.WriteLine("\n╔══════════════════════════════════════╗");
            Console.WriteLine("║       Agent Menu – Classified Zone   ║");
            Console.WriteLine("╠══════════════════════════════════════╣");
            Console.WriteLine("║ 1 → View potential recruits          ║");
            Console.WriteLine("║ 2 → View suspected agents            ║");
            Console.WriteLine("║ 3 → Show dangerous targets           ║");
            Console.WriteLine("║ 4 → Show my secret code name         ║");
            Console.WriteLine("║ 5 → Exit                             ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
        }
        public static void ShowMenuCandidateEligibility()
        {
            Console.WriteLine("\n╔════════════════════════════════════════════╗");
            Console.WriteLine("║   Candidate Promotion – Select Action      ║");
            Console.WriteLine("╠════════════════════════════════════════════╣");
            Console.WriteLine("║ 1 → Promote all candidates to Agent        ║");
            Console.WriteLine("║ 2 → Promote a specific candidate           ║");
            Console.WriteLine("║ 3 → Cancel                                 ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
        }
        public static void ShowRequestEnterNumber()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("⚠ Error: Please enter a valid number.");
            Console.ResetColor();
            Console.Write("↺ Try again: ");
        }
    }
}
