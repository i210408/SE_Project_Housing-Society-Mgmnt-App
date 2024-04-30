using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DatabaseLayer
{
    public class DB
    {
        static string connectionString = "Data Source=AZHANSPC\\SQLEXPRESS;Initial Catalog=df;Integrated Security=True";

        static string insertQuery = "INSERT INTO Users (username, password, email, user_type) VALUES (@Username, @Password, @Email, @UserType)";
        static string retrieveQuery = "SELECT username, password, email, user_type FROM Users";

        // New query for inserting suggestions
        static string insertSuggestionQuery = "INSERT INTO Suggestions (user_id, suggestion_text) VALUES (@UserId, @SuggestionText)";

        // New query for retrieving suggestions by user ID
        static string retrieveSuggestionsByUserIdQuery = "SELECT suggestion_text FROM Suggestions WHERE user_id = @UserId";



        public static void InsertUserData(string username, string password, string email, string userType)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@UserType", userType);

                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                Console.WriteLine($"{rowsAffected} row(s) inserted into Users table.");
            }
        }

        public static bool RetrieveAndCheckUserData(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(retrieveQuery, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // If rows are returned, username and password match
                return reader.HasRows;
            }
        }

        public static void InsertFeedback(int userId, int providerId, string serviceName, string feedbackText, int feedbackRating)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Find service ID based on service name
                int serviceId = GetServiceIdByName(serviceName);

                if (serviceId == -1)
                {
                    Console.WriteLine("Service not found.");
                    return;
                }

                string insertFeedbackQuery = "INSERT INTO Feedback (user_id, provider_id, service_id, feedback_text, feedback_rating) VALUES (@UserId, @ProviderId, @ServiceId, @FeedbackText, @FeedbackRating)";
                SqlCommand command = new SqlCommand(insertFeedbackQuery, connection);
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@ProviderId", providerId);
                command.Parameters.AddWithValue("@ServiceId", serviceId);
                command.Parameters.AddWithValue("@FeedbackText", feedbackText);
                command.Parameters.AddWithValue("@FeedbackRating", feedbackRating);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} row(s) inserted into Feedback table.");
            }
        }

        // Helper method to get service ID by service name
        private static int GetServiceIdByName(string serviceName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string retrieveServiceIdQuery = "SELECT service_id FROM Services WHERE service_name = @ServiceName";
                SqlCommand command = new SqlCommand(retrieveServiceIdQuery, connection);
                command.Parameters.AddWithValue("@ServiceName", serviceName);

                connection.Open();
                object result = command.ExecuteScalar();

                // If service exists, return the ID; otherwise, return -1
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }


        public static List<string> GetAllFeedbacks()
        {
            List<string> feedbacks = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string retrieveAllFeedbackQuery = "SELECT f.feedback_text, f.feedback_rating, s.service_name FROM Feedback f INNER JOIN Services s ON f.service_id = s.service_id";

                SqlCommand command = new SqlCommand(retrieveAllFeedbackQuery, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string feedback = $"Service: {reader.GetString(2)}, Rating: {reader.GetInt32(1)}, Feedback: {reader.GetString(0)}";
                        feedbacks.Add(feedback);
                    }
                }
                else
                {
                    feedbacks.Add("No feedback exists.");
                }
            }

            return feedbacks;
        }

        public static List<string> GetFeedbacksByUsername(string username)
        {
            List<string> feedbacks = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string retrieveFeedbackByUsernameQuery = "SELECT f.feedback_text, f.feedback_rating, s.service_name FROM Feedback f INNER JOIN Users u ON f.user_id = u.user_id INNER JOIN Services s ON f.service_id = s.service_id WHERE u.username = @Username";

                SqlCommand command = new SqlCommand(retrieveFeedbackByUsernameQuery, connection);
                command.Parameters.AddWithValue("@Username", username);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string feedback = $"Service: {reader.GetString(2)}, Rating: {reader.GetInt32(1)}, Feedback: {reader.GetString(0)}";
                        feedbacks.Add(feedback);
                    }
                }
                else
                {
                    feedbacks.Add("No feedback exists for this user.");
                }
            }

            return feedbacks;
        }

        public static List<string> GetUserDetailsByUsername(string username)
        {
            List<string> userDetails = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string retrieveUserDetailsQuery = "SELECT * FROM Users WHERE username = @Username";

                SqlCommand command = new SqlCommand(retrieveUserDetailsQuery, connection);
                command.Parameters.AddWithValue("@Username", username);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    userDetails = new List<string>();

                    while (reader.Read())
                    {
                        userDetails.Add($"{reader.GetInt32(0)}");
                        userDetails.Add($"{reader.GetString(1)}");
                        userDetails.Add($"{reader.GetString(2)}");
                        userDetails.Add($"{reader.GetString(3)}");
                        userDetails.Add($"{reader.GetString(4)}");
                    }
                }
            }

            return userDetails;
        }

        public static int GetHomeownerIdByName(string homeownerName)   // Keep this public, I need this to validate delete home owner.
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string retrieveHomeownerIdQuery = "SELECT user_id FROM Users WHERE username = @HomeownerName AND user_type = 'homeowner'";
                SqlCommand command = new SqlCommand(retrieveHomeownerIdQuery, connection);
                command.Parameters.AddWithValue("@HomeownerName", homeownerName);

                connection.Open();
                object result = command.ExecuteScalar();

                // If homeowner exists, return the ID; otherwise, return -1
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }
        public static void IssueBillToHomeowner(string homeownerName, decimal amount, DateTime issueDate, DateTime dueDate, string reason)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int homeownerId = GetHomeownerIdByName(homeownerName);

                if (homeownerId != -1)
                {
                   
                        string insertBillQuery = "INSERT INTO Bills (username, amount, issue_date, due_date, bill_type) VALUES (@Username, @Amount, @IssueDate, @DueDate, @Reason)";
                        SqlCommand command = new SqlCommand(insertBillQuery, connection);
                        command.Parameters.AddWithValue("@Username", homeownerName);
                        command.Parameters.AddWithValue("@Amount", amount);
                        command.Parameters.AddWithValue("@IssueDate", issueDate);
                        command.Parameters.AddWithValue("@DueDate", dueDate);
                        command.Parameters.AddWithValue("@Reason", reason);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"{rowsAffected} row(s) inserted into Bills table.");
                   
                }
                else
                {
                    Console.WriteLine("Homeowner not found.");
                }
            }
        }



        public static void InsertSuggestion(int userId, string suggestionText)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertSuggestionQuery, connection);
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@SuggestionText", suggestionText);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} row(s) inserted into Suggestions table.");
            }
        }


        // Method to get suggestions for a user by username
        public static List<string> GetSuggestionsByUsername(string username)
        {
            List<string> suggestions = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string retrieveSuggestionsByUsernameQuery = @"
            SELECT s.suggestion_text 
            FROM Suggestions s 
            INNER JOIN Users u ON s.user_id = u.user_id 
            WHERE u.username = @Username";

                SqlCommand command = new SqlCommand(retrieveSuggestionsByUsernameQuery, connection);
                command.Parameters.AddWithValue("@Username", username);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        suggestions.Add(reader.GetString(0));
                    }
                }
                else
                {
                    suggestions.Add("No suggestions available for this user.");
                }
            }

            return suggestions;
        }



        public static void DeleteHomeowner(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string deleteQuery = "DELETE FROM Users WHERE username = @Username AND user_type = 'homeowner'";

                SqlCommand command = new SqlCommand(deleteQuery, connection);
                command.Parameters.AddWithValue("@Username", username);

                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                Console.WriteLine($"{rowsAffected} homeowner(s) deleted.");
            }
        }

   

        public static void ChangeHomeownerPassword(string homeownerUsername, string currentPassword, string newPassword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Query to check if the provided username and current password match a homeowner
                string verifyHomeownerQuery = "SELECT COUNT(*) FROM Users WHERE username = @Username AND password = @CurrentPassword AND user_type = 'homeowner'";

                SqlCommand verifyCommand = new SqlCommand(verifyHomeownerQuery, connection);
                verifyCommand.Parameters.AddWithValue("@Username", homeownerUsername);
                verifyCommand.Parameters.AddWithValue("@CurrentPassword", currentPassword);

                connection.Open();

                int homeownerCount = (int)verifyCommand.ExecuteScalar();

                if (homeownerCount > 0)
                {
                    // Update the password for the homeowner
                    string updatePasswordQuery = "UPDATE Users SET password = @NewPassword WHERE username = @Username";

                    SqlCommand updateCommand = new SqlCommand(updatePasswordQuery, connection);
                    updateCommand.Parameters.AddWithValue("@NewPassword", newPassword);
                    updateCommand.Parameters.AddWithValue("@Username", homeownerUsername);

                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    Console.WriteLine($"{rowsAffected} homeowner password(s) updated.");
                }
                else
                {
                    Console.WriteLine("Invalid homeowner username or current password.");
                }
            }
        }


        static string insertNotificationQuery = "INSERT INTO Notifications (user_id, notification_text, notification_date) VALUES (@UserId, @NotificationText, @NotificationDate)";

        public static void SendNotification(int userId, string notificationText)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertNotificationQuery, connection);
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@NotificationText", notificationText);
                command.Parameters.AddWithValue("@NotificationDate", DateTime.Now);

                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                Console.WriteLine($"{rowsAffected} notification(s) sent.");
                Console.WriteLine($"{rowsAffected} notification(s) sent.");
                Console.WriteLine($"{rowsAffected} notification(s) sent.");
            }
        }



        public static List<(string notificationText, DateTime notificationDate)> GetNotifications()
        {
            List<(string notificationText, DateTime notificationDate)> notifications = new List<(string notificationText, DateTime notificationDate)>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string retrieveNotificationsQuery = "SELECT notification_text, notification_date FROM Notifications";

                SqlCommand command = new SqlCommand(retrieveNotificationsQuery, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string notificationText = reader.GetString(0);
                        DateTime notificationDate = reader.GetDateTime(1);

                        notifications.Add((notificationText, notificationDate));
                    }
                }
            }

            return notifications;
        }

        public static void AddAdvertisement(int userId, string advertisementText)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string insertAdvertisementQuery = "INSERT INTO Advertisements (user_id, advertisement_text) VALUES (@UserId, @AdvertisementText)";

                SqlCommand command = new SqlCommand(insertAdvertisementQuery, connection);
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@AdvertisementText", advertisementText);

                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                Console.WriteLine($"{rowsAffected} advertisement(s) added.");
            }
        }

        public static List<string> GetAdvertisements()
        {
            List<string> advertisements = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string retrieveAdvertisementsQuery = "SELECT advertisement_text, advertisement_date FROM Advertisements";

                SqlCommand command = new SqlCommand(retrieveAdvertisementsQuery, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string advertisementText = reader.GetString(0);
                        DateTime advertisementDate = reader.GetDateTime(1);

                        string advertisementMessage = $"Advertisement: {advertisementText}, Date: {advertisementDate}";

                        advertisements.Add(advertisementMessage);
                    }
                }
                else
                {
                    advertisements.Add("No advertisements found.");
                }
            }

            return advertisements;
        }


        public static bool IsEventOnDay(DateTime date)
        {
            string query = "SELECT COUNT(*) FROM Calendar WHERE event_date = @Date";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Date", date.Date);

                connection.Open();
                int eventCount = (int)command.ExecuteScalar();

                return eventCount > 0;
            }
        }



        public static void AddEventToCalendar(string eventTitle, string eventDescription, DateTime eventDate)
        {
            string insertQuery = "INSERT INTO Calendar (event_title, event_description, event_date) VALUES (@Title, @Description, @Date)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@Title", eventTitle);
                command.Parameters.AddWithValue("@Description", eventDescription);
                command.Parameters.AddWithValue("@Date", eventDate.Date);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                Console.WriteLine($"{rowsAffected} event(s) added to the calendar.");
            }
        }



        public static List<(int userId, string username, string email)> GetAllHomeOwnerData()
        {
            List<(int userId, string username, string email)> homeOwnerData = new List<(int userId, string username, string email)>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string retrieveHomeOwnerDataQuery = "SELECT user_id, username, email FROM Users WHERE user_type = 'homeowner'";

                SqlCommand command = new SqlCommand(retrieveHomeOwnerDataQuery, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int userId = reader.GetInt32(0);
                        string username = reader.GetString(1);
                        string email = reader.GetString(2);

                        homeOwnerData.Add((userId, username, email));
                    }
                }
            }

            return homeOwnerData;
        }



        public static void ChangeUserPassword(int userId, string oldPassword, string newPassword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string verifyUserQuery = "SELECT COUNT(*) FROM Users WHERE user_id = @UserId AND password = @OldPassword";

                SqlCommand verifyCommand = new SqlCommand(verifyUserQuery, connection);
                verifyCommand.Parameters.AddWithValue("@UserId", userId);
                verifyCommand.Parameters.AddWithValue("@OldPassword", oldPassword);

                connection.Open();

                int userCount = (int)verifyCommand.ExecuteScalar();

                if (userCount > 0)
                {
         
                    string updatePasswordQuery = "UPDATE Users SET password = @NewPassword WHERE user_id = @UserId";

                    SqlCommand updateCommand = new SqlCommand(updatePasswordQuery, connection);
                    updateCommand.Parameters.AddWithValue("@NewPassword", newPassword);
                    updateCommand.Parameters.AddWithValue("@UserId", userId);

                    int rowsAffected = updateCommand.ExecuteNonQuery();

                   // Console.WriteLine($"{rowsAffected} user password(s) updated.");
                }
                else
                {
                    Console.WriteLine("Invalid user ID or old password.");
                }
            }
        }




    }



}






