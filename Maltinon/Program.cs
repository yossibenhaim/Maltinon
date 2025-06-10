using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maltinon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DAL dal = new DAL();
            menager menager = new menager();
            menu menu = new menu();
            menu.startNemu();

            Console.WriteLine(menager.CheckExistingUser("wasg", "informants"));
        }
    }
}
