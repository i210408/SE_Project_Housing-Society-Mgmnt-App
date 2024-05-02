using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer;

namespace BusinessLogicLayer
{
    internal class PollManager
    {
        public static void CreatePoll(string pollQuestion, DateTime startDate, DateTime endDate, string[] options)
        {
            DB.CreatePoll(pollQuestion, startDate, endDate, options);
        }
    }
}
