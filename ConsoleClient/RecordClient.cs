using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators;
using ConsoleClient.Models;

namespace ConsoleClient
{
    public class RecordClient
    {
        private RestClient client;

        public RecordClient(string baseUrl, string user, string password)
        {
            client = new RestClient(baseUrl);
            client.Authenticator = new HttpBasicAuthenticator(user, password);
        }

        public List<Record> GetRecordsForVehicle(Vehicle vehicle) {
            var request = new RestRequest("index.php/apps/fuel/api/0.1/vehicles/{vehicleId}/records", Method.GET);
            request.AddUrlSegment("vehicleId", vehicle.id.ToString());

            var response = client.Execute<List<Record>>(request);

            return response.Data;
        }
    }
}

