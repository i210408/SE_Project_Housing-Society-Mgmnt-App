using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer;

namespace BusinessLogicLayer
{
    internal class NotificationManager
    {
        public static void InsertNotification(int userID, string notificationText)
        {
            DB.SendNotification(userID, notificationText);
        }

        public static List<(string notificationText, DateTime notificationDate)> RetrieveNotifications()
        {
            List<(string notificationText, DateTime notificationDate)> notificationList = DB.GetNotifications();

            if (notificationList.Count == 0)
                return null;                        // Returns null if no notifications were found in the database.
            else
                return notificationList;
        }
    }
}
