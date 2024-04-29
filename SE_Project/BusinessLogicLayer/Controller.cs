using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class Controller
    {
        // Login to the application.
        public bool Login(string userName, string password)
        {
            if(AccountManager.IfUserExists(userName, password))
                return true;
            else return false;

        }

        // Create a new account.
        public void SignUp(string userName, string password, string email, string type)
        {
            AccountManager.InsertUser(userName, password, email, type);
        }
    }
}
