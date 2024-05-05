using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer;

namespace BusinessLogicLayer
{
    internal class ServiceManager
    {
        public static void RegisterService(string username, string serviceName, string serviceDescription, decimal serviceCost)
        {
            DB.RegisterService(username, serviceName, serviceDescription, serviceCost);
        }

        public static bool AssignWorker(string problem, string workerType)
        {
            return DB.DispatchWorker(problem, workerType);
        }

        public static bool RegisterRequest(string problem, int id)
        {
            return DB.RegisterRequest(problem, id);
        }

        public static List<string> GetAllRequests()
        {
            return DB.getallrequests();
        }
    }
}
