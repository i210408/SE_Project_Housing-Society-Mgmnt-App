using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class User
    {
        string userName;
        string password;
        User(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
    }
}
