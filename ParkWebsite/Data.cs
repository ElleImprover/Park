using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParkWebsite.Models;

namespace ParkWebsite
{
    public class Data
    {

        private static readonly HttpClient _httpClient = new HttpClient();
        //List<Park> parks;
        public Data()
        {
            // parks = new List<Park>();
        }
        public string GetResponseString(string search)
        {
            var uri = "https://seriouslyfundata.azurewebsites.net/api/parks";

            ////ed-Debug
            //var searchUri2 = "?$select=Parkname,Borough,Acres,Description";

            ////($filter = Name eq 'Trip in US')
            ////var searchUri = $"?$filter=contains(Parkname, {search}) or contains(Description, {search})";
            ////var searchUri = $"?$filter=(Parkname eq {search}) or Description eq {search})";
            //var searchUri = $"?$filter=(parkname eq {search})";

            ////uri=$filter=contains(Parkname, search)
            ////var uri = baseURI + searchUri;


            Console.WriteLine("Sending request (HTTP GET)...", uri);
            Console.WriteLine(uri);
            var response = _httpClient.GetAsync(uri).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Request successful.");

                //Get the response content and parse it.  
                string responseBody = response.Content.ReadAsStringAsync().Result;
                //if (PrettyPrintJson)
                //{
                //    PrettyPrint(responseBody);
                //}


                //var jobj = JObject.Parse(responseBody);
                // return jobj.ToString();
                return responseBody;

            }
            else
            {
                Console.WriteLine("The request failed with a status of '{0}'", response.ReasonPhrase);
                return null;
            }
        }

        public List<Park> GetAllParks(string response)
        {
            List<Park> parks = new List<Park>();
            return JsonConvert.DeserializeObject<List<Park>>(response);

        }

        public List<Park> GetParksFromSearch(string search)
        {
            var response = GetResponseString(search);
            List<Park> allParks = GetAllParks(response);
            //var srchParks = allParks.FindAll(x => x.Parkname.Contains("search", StringComparison.CurrentCultureIgnoreCase) || x.Description.Contains("search", StringComparison.CurrentCultureIgnoreCase));
            var srchParks=  FindParks(search, allParks);
            return srchParks;
        }

        public List<Park> FindParks(string search, List<Park> allParks)
        {
            List<Park> srchParks = new List<Park>();
            foreach (var x in allParks)
            {
                if ((x.Description).ToString().Contains(search, StringComparison.CurrentCultureIgnoreCase) || (x.Parkname.Contains(search, StringComparison.CurrentCultureIgnoreCase)))
                {
                    srchParks.Add(x);
                    srchParks.Sort();
                }
            }
            return srchParks;
        }
    }
}
