using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace APIPractice.Models
{
    public class StarWarsDAL
    {
        public string GetData(int id, string section)
        {
            //Make request
            string url = @$"https://swapi.dev/api/{section}/{id}/";
            HttpWebRequest request = WebRequest.CreateHttp(url);
            //Get response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //HTTP response codes:
            // 200 == good request
            // 404 == entry/endpoint not found, check url
            // any 500 error == server error - either API server is down, or your request is set up incorrectly

            //Get data from response
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string json = rd.ReadToEnd();

            return json;
        }

        public string GetData(string url)
        {
            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());
            string json = rd.ReadToEnd();

            return json;
        }

        public Person ConvertToPerson(int id)
        {
            string personData = GetData(id, "people");
            Person p = JsonConvert.DeserializeObject<Person>(personData);

            return p;
        }

        //public Person ConvertToPerson(string url)
        //{
        //    string personData = GetData(url);
        //    Person p = JsonConvert.DeserializeObject<Person>(personData);

        //    return p;
        //}

        //public Homeworld ConvertToHomeworld(int id)
        //{
        //    string planetData = GetData(id, "planets");
        //    Homeworld h = JsonConvert.DeserializeObject<Homeworld>(planetData);

        //    return h;
        //}

        public Homeworld ConvertToHomeworld(string url)
        {
            string planetData = GetData(url);
            Homeworld h = JsonConvert.DeserializeObject<Homeworld>(planetData);

            return h;
        }
    }
}
