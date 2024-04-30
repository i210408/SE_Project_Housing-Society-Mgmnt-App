using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer;

namespace BusinessLogicLayer
{
    internal class AdManager
    {
        public static void AddAdvertisement(int userID, string advertisementText)
        {
            DB.AddAdvertisement(userID, advertisementText);
        }

        public static List<string> RetrieveAdvertisements()
        {
            return DB.GetAdvertisements();
        }
    }
}
