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

        // View Homeowner data.

        public static List<(int userId, string username, string email)> GetAllResidentData()
        {
            return AccountManager.GetAllResidentData();
        }

        // Delete Homeowner account.

        public bool DeleteHomeowner(string userName)
        {
            // Returns true if the account existed and has been deleted.
            // Returns false if the account didn't exist.

            return AccountManager.DeleteUser(userName);
        }

        // Change Password.

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            // Returns true if password was successfully changed.
            // Rteurns false if the oldPassword did not match the password set.

            return accountManager.ChangePassword(oldPassword, newPassword);
        }

        // Logout

        public void Logout()
        {
            accountManager.Logout();
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

        // Issue Bills to a user.

        public static void IssueBill(string userName, decimal amount, int days, string reason)
        {
            // Amount: Money to be paid.
            // Days: Number of days till due date from the issue date.

            BillsManager.IssueBill(userName, amount, days, reason);
        }

        // Broadcast Notification.

        public void BroadcastNotifications(string notificationText)
        {
            int userID = accountManager.currentUser.GetUserID();
            NotificationManager.InsertNotification(userID, notificationText);
        }

        // View Notifications.

        public static List<(string notificationText, DateTime notificationDate)> ViewNotifications()
        {
            // Returns null if no notifications found in the database.

            return NotificationManager.RetrieveNotifications();
        }

        // Add Advertisement.

        public void AddAdvertisement(string advertisementText)
        {
            int currentUser = accountManager.currentUser.GetUserID();
            AdManager.AddAdvertisement(currentUser, advertisementText);
        }

        // Broadcast Advertisements.

        public List<string> BroadcastAdvertisement()
        {
            return AdManager.RetrieveAdvertisements();
        }

        // Add Event to Calender.

        public bool AddEventToCalender(string eventTitle, string eventDescription, DateTime eventDate)
        {
            // Returns true if successfully added.
            // Returns false if another event already existed on the same day.

            return EventManager.AddEventToCalendar(eventTitle, eventDescription, eventDate);
        }

        // Pay Bills.

        public void PayBills()
        {
            string userName = accountManager.currentUser.GetUserName();
            BillsManager.PayBills(userName);
        }

        // Register Service.

        public static void RegisterService(string serviceName, string serviceDescription, decimal serviceCost)
        {
            ServiceManager.RegisterService(serviceName, serviceDescription, serviceCost);
        }

        // Assign Worker.

        public static void AssignWorker(string problem, string workerType)
        {
            ServiceManager.AssignWorker(problem, workerType);
        }

    }
}
