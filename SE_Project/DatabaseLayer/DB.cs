using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DatabaseLayer
{
    public class DB
    {
        static string connectionString = "Data Source=LAPTOP-R7A4A3IR\\SQLEXPRESS;Initial Catalog=df;Integrated Security=True";

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

        public static void InsertFeedback(int userId, string serviceName, string feedbackText, int feedbackRating)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //// Find service ID based on service name
                //int serviceId = GetServiceIdByName(serviceName);

                //if (serviceId == -1)
                //{
                //    Console.WriteLine("Service not found.");
                //    return;
                //}

                string insertFeedbackQuery = "INSERT INTO Feedback (user_id, service_name, feedback_text, feedback_rating) VALUES (@UserId, @serviceName, @FeedbackText, @FeedbackRating)";
                SqlCommand command = new SqlCommand(insertFeedbackQuery, connection);
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@FeedbackText", feedbackText);
                command.Parameters.AddWithValue("@serviceName", serviceName);
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

                    string insertBillQuery = "INSERT INTO Bills (username, amount, issue_date, due_date, payment_status, bill_type) VALUES (@Username, @Amount, @IssueDate, @DueDate,'unpaid', @Reason)";
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



        public static bool AddEventToCalendar(string eventTitle, string eventDescription, DateTime eventDate)
        {
            // Check if an event already exists for the specified date
            string checkExistingEventQuery = "SELECT COUNT(*) FROM Calendar WHERE event_date = @Date";
            bool eventAdded = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand checkCommand = new SqlCommand(checkExistingEventQuery, connection);
                checkCommand.Parameters.AddWithValue("@Date", eventDate.Date);

                connection.Open();
                int existingEventsCount = (int)checkCommand.ExecuteScalar();

                if (existingEventsCount == 0)
                {
                    // No event exists for the specified date, proceed to add the new event
                    string insertQuery = "INSERT INTO Calendar (event_title, event_description, event_date) VALUES (@Title, @Description, @Date)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Title", eventTitle);
                        command.Parameters.AddWithValue("@Description", eventDescription);
                        command.Parameters.AddWithValue("@Date", eventDate.Date);

                        int rowsAffected = command.ExecuteNonQuery();
                        eventAdded = rowsAffected > 0;
                        Console.WriteLine($"{rowsAffected} event(s) added to the calendar.");
                    }
                }
                else
                {
                    Console.WriteLine("An event already exists for the specified date. No event added.");
                }
            }

            return eventAdded;
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


        public static bool PayBillOnline(string username)
        {

            string updatePaymentStatusQuery = "UPDATE Bills SET payment_status = 'paid' WHERE username = @Username AND payment_status = 'unpaid";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand(updatePaymentStatusQuery, connection))
                {

                    command.Parameters.AddWithValue("@Username", username);

                    // Open the connection
                    connection.Open();

                    try
                    {
                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"Payment status updated to 'paid' for {username}.");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine($"No bills found for the user {username}.");
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        return false;
                    }
                }
            }
        }



        public static bool RegisterVisitor(string visitorName, int userId)
        {
            string insertVisitorQuery = "INSERT INTO Visitors (name, homeowner_id) VALUES (@VisitorName, @UserId)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a SqlCommand object with the query and connection
                using (SqlCommand command = new SqlCommand(insertVisitorQuery, connection))
                {
                    command.Parameters.AddWithValue("@VisitorName", visitorName);
                    command.Parameters.AddWithValue("@UserId", userId);

                    connection.Open();

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Visitor registered successfully.");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Failed to register visitor.");
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        return false;
                    }
                }
            }
        }





        //register facilities
        public static void RegisterService(string username, string serviceName, string serviceDescription, decimal serviceCost)
        {

            string insertServiceQuery = "INSERT INTO Services (service_name, service_description, service_cost, username) VALUES (@ServiceName, @ServiceDescription, @ServiceCost, @Username)";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand(insertServiceQuery, connection))
                {

                    command.Parameters.AddWithValue("@ServiceName", serviceName);
                    command.Parameters.AddWithValue("@ServiceDescription", serviceDescription);
                    command.Parameters.AddWithValue("@ServiceCost", serviceCost);
                    command.Parameters.AddWithValue("@Username", username);


                    connection.Open();

                    try
                    {

                        int rowsAffected = command.ExecuteNonQuery();

                        Console.WriteLine($"{rowsAffected} service(s) registered.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
            }
        }

        //register facilities
        public static bool RegisterRequest(string problem, int hid)
        {

            string insertServiceQuery = "INSERT INTO Requests (problem, homeowner_id, status_problem) VALUES (@Problem, @HomeOwnerID, 'active')";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand(insertServiceQuery, connection))
                {

                    command.Parameters.AddWithValue("@Problem", problem);
                    command.Parameters.AddWithValue("@HomeOwnerID", hid);


                    connection.Open();

                    try
                    {

                        int rowsAffected = command.ExecuteNonQuery();

                        Console.WriteLine($"{rowsAffected} service(s) registered.");
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        return false;
                    }
                }
            }
        }





        public static bool DispatchWorker(string problem, string workerType)
        {
            bool workerDispatched = false;

            string query = "SELECT TOP 1 worker_id FROM Maintenance WHERE worker_type = @WorkerType AND status = 'free'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@WorkerType", workerType);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int workerId = reader.GetInt32(0);
                        reader.Close();

                        string updateQuery = "UPDATE Maintenance SET status = 'assigned' WHERE worker_id = @WorkerId";
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@WorkerId", workerId);
                            int rowsAffected = updateCommand.ExecuteNonQuery();
                            workerDispatched = rowsAffected > 0;
                        }

                        // Delete the corresponding entry from the Request table
                        string deleteRequestQuery = "DELETE FROM Request WHERE problem = @Problem";
                        using (SqlCommand deleteCommand = new SqlCommand(deleteRequestQuery, connection))
                        {
                            deleteCommand.Parameters.AddWithValue("@Problem", problem);
                            deleteCommand.ExecuteNonQuery();
                        }

                        // Console.WriteLine($"Assigned worker with ID {workerId} to solve the problem: {problem}");
                    }
                    else
                    {
                        // Console.WriteLine($"No available worker found for type: {workerType}");
                    }
                }
            }

            return workerDispatched;
        }




        public static List<(string, string, DateTime)> ViewCommunityCalendar()
        {
            List<(string, string, DateTime)> events = new List<(string, string, DateTime)>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string retrieveEventsQuery = "SELECT event_title, event_description, event_date FROM Calendar";

                SqlCommand command = new SqlCommand(retrieveEventsQuery, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string eventTitle = reader.GetString(0);
                        string eventDescription = reader.GetString(1);
                        DateTime eventDate = reader.GetDateTime(2);

                        events.Add((eventTitle, eventDescription, eventDate));
                    }
                }
            }

            return events;
        }



        public static List<string> ViewBills(string username)
        {
            List<string> bills = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string retrieveBillsQuery = @"
            SELECT b.amount, b.issue_date, b.due_date, b.payment_status, b.bill_type
            FROM Bills b
            INNER JOIN Users u ON b.username = u.username
            WHERE u.username = @Username";

                SqlCommand command = new SqlCommand(retrieveBillsQuery, connection);
                command.Parameters.AddWithValue("@username", username);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        decimal amount = reader.GetDecimal(0);
                        DateTime issueDate = reader.GetDateTime(1);
                        DateTime dueDate = reader.GetDateTime(2);
                        string paymentStatus = reader.GetString(3);
                        string billType = reader.GetString(4);

                        string billInfo = $"Amount: {amount}, Issue Date: {issueDate}, Due Date: {dueDate}, Payment Status: {paymentStatus}, Bill Type: {billType}";
                        bills.Add(billInfo);
                    }
                }
                else
                {
                  //  bills.Add("No bills found for this user.");
                }
            }

            return bills;
        }




        public static void RegisterRequest(string problem, string problemType, int homeownerId)
        {

            string insertRequestQuery = "INSERT INTO Request (problem, problem_type, homeowner_id) " +
                                        "VALUES (@Problem, @ProblemType, @HomeownerId)";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand(insertRequestQuery, connection))
                {
        
                    command.Parameters.AddWithValue("@Problem", problem);
                    command.Parameters.AddWithValue("@ProblemType", problemType);
                    command.Parameters.AddWithValue("@HomeownerId", homeownerId);

          
                    connection.Open();

                    try
                    {

                        int rowsAffected = command.ExecuteNonQuery();

      
                        if (rowsAffected > 0)
                        {
                     //       Console.WriteLine("Request registered successfully.");
                        }
                        else
                        {
                        //    Console.WriteLine("Failed to register request.");
                        }
                    }
                    catch (Exception ex)
                    {
                    //    Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
            }
        }


        public static void CreatePoll(string pollQuestion, DateTime startDate, DateTime endDate, string[] options)
        {
            // Insert poll into Polls table
            int pollId = InsertPoll(pollQuestion, startDate, endDate);

            if (pollId != -1)
            {
                // Insert options into PollOptions table
                foreach (string optionText in options)
                {
                    InsertOption(pollId, optionText);
                }
            }
        }

        private static int InsertPoll(string pollQuestion, DateTime startDate, DateTime endDate)
        {
            int pollId = -1;
            string insertQuery = "INSERT INTO Polls (poll_question, poll_start_date, poll_end_date) VALUES (@Question, @StartDate, @EndDate); SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Question", pollQuestion);
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out pollId))
                    {
                        Console.WriteLine("Poll created successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to create poll.");
                    }
                }
            }

            return pollId;
        }

        private static void InsertOption(int pollId, string optionText)
        {
            string insertQuery = "INSERT INTO PollOptions (poll_id, option_text) VALUES (@PollId, @OptionText)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@PollId", pollId);
                    command.Parameters.AddWithValue("@OptionText", optionText);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Option added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to add option.");
                    }
                }
            }
        }



    }

}






