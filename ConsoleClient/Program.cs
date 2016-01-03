using System;
using System.Linq;

namespace ConsoleClient
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string baseUrl = "http://localhost:8080";
            string user = "user";
            string password = "user";

            VehicleClient vc = new VehicleClient(baseUrl, user, password);
            RecordClient rc = new RecordClient(baseUrl, user, password);
            foreach (var vehicle in vc.GetVehicles())
            {
                Console.WriteLine($"# Vehicle {vehicle.id}:");
                foreach(var rec in rc.GetRecordsForVehicle(vehicle).OrderBy(r => r.date)) {
                    Console.WriteLine ($"- {rec.date}");
                }
            }
        }
    }
}
