using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class Controller
    {
        AccountManager accountManager;
     
        public Controller()
        {
            accountManager = new AccountManager();
        }

        // Login to the application.
        public bool Login(string userName, string password)
        {
            if(AccountManager.IfUserExists(userName, password))
            {
                accountManager.AddCurrentUser(userName);
                return true;
            }
            else return false;

        }

        // Create a new account.
        public bool SignUp(string userName, string password, string email, string type)
        {
            
            if(AccountManager.ValidateUsername(userName))
            {
                return false;
            }
            AccountManager.InsertUser(userName, password, email, type);
            return true;
        }

        // Insert Feedback.

        public void InsertFeedback(int providerID, string serviceName, string feedbackText, int feedbackRating)
        {
            int currentUser = accountManager.currentUser.GetUserID();
            FeedbackManager.InsertFeedback(currentUser, providerID, serviceName, feedbackText, feedbackRating);
        }
        

        // View feedback provided by all users for all services.
        public static List<string> ViewFeedback()
        {
            return FeedbackManager.RetrieveAllFeedbacks();
        }
        // View feedback provided by a specific user.
        public static List<string> ViewFeedbackByUser(string username)
        {
            return FeedbackManager.RetrieveFeedbackByUser(username);
        }

        // Insert Suggestion.

        public void InsertSuggestion(string suggestion)
        {
            int currentUser = accountManager.currentUser.GetUserID();
            SuggestionManager.InsertSuggestions(currentUser, suggestion);
        }

        // View suggestions provided by users.
        public static List<string> ViewSuggestions()
        {
            return SuggestionManager.RetrieveAllSuggestions();
        }

        // Get suggestions by a specific user.

        public static List<string> ViewSuggestionsByUser(string userName)
        {
            return SuggestionManager.RetrieveSuggestionsByUser(userName);
        }
    }
}
