using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer;

namespace BusinessLogicLayer
{
    internal class EventManager
    {
        public static bool AddEventToCalendar(string eventTitle, string eventDescription, DateTime eventDate)
        {
            if(DB.IsEventOnDay(eventDate))
            {
                return false;
            }
            DB.AddEventToCalendar(eventTitle, eventDescription, eventDate);
            return true;
        }

    }
}
