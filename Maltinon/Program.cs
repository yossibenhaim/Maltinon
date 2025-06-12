using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace Maltinon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            DAL dal = new DAL();
            dal.SendQuery(SqlQueryBuilder.ReadLog($"The software started running.", "info", "Program.Main"));
            menu menu = new menu();
            menu.startNemu();
            dal.SendQuery(SqlQueryBuilder.ReadLog($"The software has finished running..", "info", "Program.Main"));

        }
    }
}
