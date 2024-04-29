using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }

}
