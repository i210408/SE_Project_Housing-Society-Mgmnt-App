using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    internal class Class1
    {
        // Connection string
        static string connectionString = "Data Source=AZHANSPC\\SQLEXPRESS;Initial Catalog=df;Integrated Security=True";

        // SQL query to insert data into Users table
        static string insertQuery = "INSERT INTO Users (username, password, email, user_type) VALUES (@Username, @Password, @Email, @UserType)";

        // SQL query to retrieve data from Users table
        static string retrieveQuery = "SELECT username, password, email, user_type FROM Users";

        // Method to prompt user for input
        static string PromptUser(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        // Method to validate email format
        static bool ValidateEmail(string email)
        {
            // Check if email matches basic email pattern
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        // Method to validate password strength
        static bool ValidatePassword(string password)
        {
            // Check if password has at least 6 characters
            return password.Length >= 6;
        }

        // Method to validate user type
        static string ValidateUserType(string userType)
        {
            while (userType != "homeowner" && userType != "admin")
            {
                Console.WriteLine("Invalid user type. Please enter 'homeowner' or 'admin'.");
                userType = PromptUser("Enter user type (homeowner or admin):");
            }
            return userType;
        }

        // Method to insert user data into the database
        static void InsertUserData()
        {
            // Input data
            string username = PromptUser("Enter username:");
            string password;
            string email;
            string userType;

            do
            {
                password = PromptUser("Enter password:");
            } while (!ValidatePassword(password));

            do
            {
                email = PromptUser("Enter email:");
            } while (!ValidateEmail(email));

            userType = PromptUser("Enter user type (homeowner or admin):");
            userType = ValidateUserType(userType);

            // Execute the query to insert data
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

        // Method to retrieve user data from the database and display it
        static void RetrieveAndDisplayUserData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(retrieveQuery, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string username = reader["username"].ToString();
                        string password = reader["password"].ToString();
                        string email = reader["email"].ToString();
                        string userType = reader["user_type"].ToString();

                        Console.WriteLine($"Username: {username}");
                        Console.WriteLine($"Password: {password}");
                        Console.WriteLine($"Email: {email}");
                        Console.WriteLine($"User Type: {userType}");
                        Console.WriteLine(); // Add a blank line for readability
                    }
                }
                else
                {
                    Console.WriteLine("No data found in Users table.");
                }

            }
        }
    }
}
