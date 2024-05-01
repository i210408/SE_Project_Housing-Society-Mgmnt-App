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

        public static void AssignWorker(string problem, string workerType)
        {
            DB.AssignWorkerToProblem(problem, workerType);
        }
    }
}
