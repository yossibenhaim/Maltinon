using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maltinon
{
    internal class menager
    {
        DAL DAL = new DAL();
        public bool CheckExistingUser(string userName, string teble)
        {
            if (DAL.GetQuery(DAL.CheckExistingUser(userName,teble)).Count > 0)
            {
                return true;
            }
            else { return false; }
        }

        public bool CheckUserAgent(string userName)
        {
            if (DAL.GetQuery(DAL.CheckUserAgnt(userName)).Count > 0)
            {
                return true;
            }
            else { return false; }
        }
        public void startAgent()
        {
            Console.WriteLine("send user name");
            string userName = Console.ReadLine();
            if (CheckUserAgent(userName))
            {

            }
        }
        
    }
}
