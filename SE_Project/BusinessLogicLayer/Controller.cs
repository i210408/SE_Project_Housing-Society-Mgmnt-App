﻿using System;
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

        public void InsertFeedback(string serviceName, string feedbackText, int feedbackRating)
        {
            int currentUser = accountManager.currentUser.GetUserID();
            FeedbackManager.InsertFeedback(currentUser, serviceName, feedbackText, feedbackRating);
        }
        
        public bool ReqMaintainence(string problem)
        {
            int hid = accountManager.currentUser.GetUserID();
            return ServiceManager.RegisterRequest(problem, hid);
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

        public bool PayBills()
        {
            string userName = accountManager.currentUser.GetUserName();
            return BillsManager.PayBills(userName);
        }

        // Register Service.

        public void RegisterService(string serviceName, string serviceDescription, decimal serviceCost)
        {
            string currentuser = accountManager.currentUser.GetUserName();
            ServiceManager.RegisterService(currentuser, serviceName, serviceDescription, serviceCost);
        }

        // Assign Worker.

        public static bool AssignWorker(string problem, string workerType)
        {
            return ServiceManager.AssignWorker(problem, workerType);
        }

        // View Bills.

        public List<string> ViewBills()
        {
            string userName = accountManager.currentUser.GetUserName();
            return BillsManager.RetrieveBills(userName);
        }

        public bool RegisterVisitor(string visitorname)
        {
            int uid = accountManager.currentUser.GetUserID();
            return AccountManager.RegisterVisitor(visitorname, uid);
        }

        // View Community Calender.

        public static List<(string, string, DateTime)> ViewCommunityCalendar()
        {
            return EventManager.RetrieveCalendar();
        }

        // Create Poll.

        public static void CreatePoll(string pollQuestion, DateTime startDate, DateTime endDate, string[] options)
        {
            PollManager.CreatePoll(pollQuestion, startDate, endDate, options);
        }
    }
}
