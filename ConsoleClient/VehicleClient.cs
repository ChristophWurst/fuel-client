using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators;
using ConsoleClient.Models;

namespace ConsoleClient
{
    public class VehicleClient
    {

        private RestClient client;

        public VehicleClient(string baseUrl, string user, string password)
        {
            client = new RestClient(baseUrl);
            client.Authenticator = new HttpBasicAuthenticator(user, password);
        }

        public List<Vehicle> GetVehicles() {
            var request = new RestRequest("index.php/apps/fuel/api/0.1/vehicles", Method.GET);

            var response = client.Execute<List<Vehicle>>(request);

            return response.Data;
        }
    }
}

