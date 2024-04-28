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
       
        static string connectionString = "Data Source=AZHANSPC\\SQLEXPRESS;Initial Catalog=df;Integrated Security=True";


        static string insertQuery = "INSERT INTO Users (username, password, email, user_type) VALUES (@Username, @Password, @Email, @UserType)";

   
        static string retrieveQuery = "SELECT username, password, email, user_type FROM Users";



        static void InsertUserData(string username, string password, string email, string userType)
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


        static bool RetrieveAndCheckUserData(string username, string password)
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


    }
        }
    
