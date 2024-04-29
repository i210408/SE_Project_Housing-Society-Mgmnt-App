using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer;

namespace BusinessLogicLayer
{
    internal class FeedbackManager
    {
        public static List<string> RetrieveAllFeedbacks()
        {
            return DB.GetAllSuggestions();
        }
    }
}
