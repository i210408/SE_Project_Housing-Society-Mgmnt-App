using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    internal class User
    {
        private string userName;
        private string password;
        private string email;
        private string type;

        User(string userName, string password, string email, string type)
        {
            this.userName = userName;
            this.password = password;
            this.email = email;
            this.type = type;   
        }

        User()
        {
            this.userName = " ";
            this.password = " ";
            this.email = " ";
            this.type = " ";
        }

        public string GetUserName()
        {
            return userName;
        }
        public string GetPassword()
        {
            return password;
        }

        public string GetEmail()
        {
            return email;
        }

        public string GetUserType()
        {
            return type;
        }

        public void SetUsername(string userName)
        {
            this.userName=userName;
        }

        public void SetPassword(string password)
        {
            this.password=password;
        }

        public void SetEmail(string email)
        {
            this.email=email;
        }

        public void SetType(string type)
        {
            this.type=type;
        }

    }

}
