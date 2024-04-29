using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    public class DB
    {
       
        static string connectionString = "Data Source=LAPTOP-R7A4A3IR\\SQLEXPRESS;Initial Catalog=df;Integrated Security=True";


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
                command.Parameters.AddWithValue("@ServiceId", serviceId);
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
                string retrieveAllFeedbackQuery = "SELECT feedback_text, feedback_rating FROM Feedback";

                SqlCommand command = new SqlCommand(retrieveAllFeedbackQuery, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string feedback = $"Rating: {reader.GetInt32(1)}, Feedback: {reader.GetString(0)}";
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

        public static List<string> GetFeedbacksByUserId(int userId)
        {
            List<string> feedbacks = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string retrieveFeedbackByUserIdQuery = "SELECT feedback_text, feedback_rating FROM Feedback WHERE user_id = @UserId";

                SqlCommand command = new SqlCommand(retrieveFeedbackByUserIdQuery, connection);
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string feedback = $"Rating: {reader.GetInt32(1)}, Feedback: {reader.GetString(0)}";
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


        public static void InsertSuggestion(int userId, string suggestionText)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string insertSuggestionQuery = "INSERT INTO Suggestions (user_id, suggestion_text) VALUES (@UserId, @SuggestionText)";
                SqlCommand command = new SqlCommand(insertSuggestionQuery, connection);
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@SuggestionText", suggestionText);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} row(s) inserted into Suggestions table.");
            }
        }


        public static List<string> GetAllSuggestions()
        {
            List<string> suggestions = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string retrieveAllSuggestionsQuery = "SELECT suggestion_text FROM Suggestions";

                SqlCommand command = new SqlCommand(retrieveAllSuggestionsQuery, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string suggestion = reader.GetString(0);
                        suggestions.Add(suggestion);
                    }
                }
                else
                {
                    suggestions.Add("No suggestions exist.");
                }
            }

            return suggestions;
        }


        public static List<string> GetSuggestionsByUserId(int userId)
        {
            List<string> suggestions = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string retrieveSuggestionsByUserIdQuery = "SELECT suggestion_text FROM Suggestions WHERE user_id = @UserId";

                SqlCommand command = new SqlCommand(retrieveSuggestionsByUserIdQuery, connection);
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string suggestion = reader.GetString(0);
                        suggestions.Add(suggestion);
                    }
                }
                else
                {
                    suggestions.Add("No suggestions exist for this user.");
                }
            }

            return suggestions;
        }



    }
}
    
