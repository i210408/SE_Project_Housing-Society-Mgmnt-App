﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer;

namespace BusinessLogicLayer
{
    internal class AccountManager
    {
        public User currentUser;

        public AccountManager()
        {
            currentUser = null;
        }

        // Insert new user into the database.
        public static void InsertUser(string userName, string password, string email, string userType)
        {
            DB.InsertUserData(userName, password, email, userType);
            Console.WriteLine("Called InsertUserData.");
        }

        // Check if user exists in database.
        public static bool IfUserExists(string userName, string password)
        {
            return DB.RetrieveAndCheckUserData(userName, password);
        }

        // Returns true if either the userName already exists in the database.
        public static bool ValidateUsername(string userName)
        {
            if(DB.GetUserDetailsByUsername(userName) == null)
            {
                return false;
            }
            return true;
        }

        // Add details of the current user to the user object.

        public void AddCurrentUser(string userName)
        {
            List <string> userDetails =  DB.GetUserDetailsByUsername(userName);
            this.currentUser = new User(Int32.Parse(userDetails[0]), userDetails[1], userDetails[2], userDetails[3], userDetails[4]);
            Console.WriteLine("Current user added.");
        }

    }
}
