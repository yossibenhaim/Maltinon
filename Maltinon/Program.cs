using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace Maltinon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DAL dal = new DAL();
            menu menu = new menu();
            menager menager = new menager();
            menu.startNemu();



        }
    }
}
