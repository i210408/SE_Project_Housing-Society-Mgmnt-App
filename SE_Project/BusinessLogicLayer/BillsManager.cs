using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer;

namespace BusinessLogicLayer
{
    internal class BillsManager
    {
        public static void IssueBill(string userName, decimal amount, int days, string reason)
        {
            DateTime issueDate = DateTime.Now;
            DateTime dueDate = issueDate.AddDays(days);
            DB.IssueBillToHomeowner(userName, amount, issueDate, dueDate, reason);
        }

        public static bool PayBills(string userName)
        {
            return DB.PayBillOnline(userName);
        }

        public static List<string> RetrieveBills(string userName)
        {
            return DB.ViewBills(userName);
        }
    }
}
