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

        public static void InsertFeedback(int userId, int providerId, int serviceId, string feedbackText, int feedbackRating)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string insertFeedbackQuery = "INSERT INTO Feedback (user_id, provider_id, service_id, feedback_text, feedback_rating) VALUES (@UserId, @ProviderId, @ServiceId, @FeedbackText, @FeedbackRating)";
                SqlCommand command = new SqlCommand(insertFeedbackQuery, connection);
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@ProviderId", providerId);
                command.Parameters.AddWithValue("@ServiceId", serviceId); // Add service_id parameter
                command.Parameters.AddWithValue("@FeedbackText", feedbackText);
                command.Parameters.AddWithValue("@FeedbackRating", feedbackRating);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} row(s) inserted into Feedback table.");
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
                        userDetails.Add($"User ID: {reader.GetInt32(0)}");
                        userDetails.Add($"Username: {reader.GetString(1)}");
                        userDetails.Add($"Password: {reader.GetString(2)}");
                        userDetails.Add($"Email: {reader.GetString(3)}");
                        userDetails.Add($"User Type: {reader.GetString(4)}");
                    }
                }
            }

            return userDetails;
        }

        private static int GetHomeownerIdByName(string homeownerName)
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
        public static void IssueBillToHomeowner(string homeownerName, decimal amount, DateTime issueDate, DateTime dueDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int homeownerId = GetHomeownerIdByName(homeownerName);

                if (homeownerId != -1)
                {
                    string insertBillQuery = "INSERT INTO Bills (homeowner_name, amount, issue_date, due_date) VALUES (@HomeownerName, @Amount, @IssueDate, @DueDate)";
                    SqlCommand command = new SqlCommand(insertBillQuery, connection);
                    command.Parameters.AddWithValue("@HomeownerName", homeownerName);
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@IssueDate", issueDate);
                    command.Parameters.AddWithValue("@DueDate", dueDate);

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

     


    }




}

