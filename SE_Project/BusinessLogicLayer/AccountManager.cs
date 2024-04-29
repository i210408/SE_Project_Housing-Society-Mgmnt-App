using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer;

namespace BusinessLogicLayer
{
    internal class AccountManager
    {

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
    }
}
