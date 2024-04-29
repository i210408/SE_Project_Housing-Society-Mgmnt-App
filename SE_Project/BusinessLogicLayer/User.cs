using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class User
    {
        private int userID;
        private string userName;
        private string password;
        private string email;
        private string type;

        public User(int userID, string userName, string password, string email, string type)
        {
            this.userID = userID;
            this.userName = userName;
            this.password = password;
            this.email = email;
            this.type = type;   
        }

        public User()
        {
            this.userID = -1;
            this.userName = " ";
            this.password = " ";
            this.email = " ";
            this.type = " ";
        }

        public int GetUserID()
        {
            return userID;
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

        public void SetUserID(int userID)
        {
            this.userID = userID;
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
