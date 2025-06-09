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
        public void startNemu()
        {
            bool run = true;
            int choice;

            while (run)
            {
                Console.WriteLine("send a number");
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
                        break;
                    case 2:
                        break;
                }

            }
        }
    }
}
