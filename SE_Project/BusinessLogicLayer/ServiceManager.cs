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
        public static void RegisterService(string serviceName, string serviceDescription, decimal serviceCost)
        {
            DB.RegisterService(serviceName, serviceDescription, serviceCost);
        }

        public static bool AssignWorker(string problem, string workerType)
        {
            return DB.DispatchWorker(problem, workerType);
        }

        public static void RegisterRequest(string problem, int id)
        {
            DB.RegisterRequest(problem, id);
        }
    }
}
