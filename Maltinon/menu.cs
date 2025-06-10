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


        public void startNemu()
        {
            
            bool run = true;
            int choice;

            while (run)
            {
                Console.WriteLine("send a number");
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
                Console.WriteLine("Press 1 for a list of potential recruits\r\nPress 2 for a list of suspected agents\r\nPress 3 to exit");
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
    }
}
