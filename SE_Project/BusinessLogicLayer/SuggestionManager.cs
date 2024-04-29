using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer;

namespace BusinessLogicLayer
{
    internal class SuggestionManager
    {
        public static List<string> RetrieveAllSuggestions()
        {
            return null;
        }

        public static List<string> RetrieveSuggestionsByUser(string userName)
        {
            return DB.GetSuggestionsByUsername(userName);
        }

        public static void InsertSuggestions(int userID, string suggestionText)
        {
            DB.InsertSuggestion(userID, suggestionText);
        }

    }
}
