using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer;

namespace BusinessLogicLayer
{
    internal class User
    {
        string userName;
        string password;
        string email;
        string type;

        User(string userName, string password, string email, string type)
        {
            this.userName = userName;
            this.password = password;
            this.email = email;
            this.type = type;   
        }

        public string GetUserName()
        {
            return userName;
        }
        public string GetPassword()
        {
            return password;
        }

        public void SetUsername(string userName)
        {
            this.userName=userName;
        }

        // Insert new user into the database.
        public static void InsertUser(string userName, string password, string email, string userType)
        {
            Class1.InsertUserData(userName,password,email,userType);
            Console.WriteLine("Called InsertUserData.");
        }

        // Check if user exists in database.
        public static bool IfUserExists(string userName, string password)
        {
            return Class1.RetrieveAndCheckUserData(userName,password);
        }

    }

}
