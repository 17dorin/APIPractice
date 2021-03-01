using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace APIPractice.Models
{
    public class WeatherDAL
    {
        public string GetData(string url)
        {
            HttpWebRequest request = WebRequest.CreateHttp(url);
            request.UserAgent = "apipractice.com";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());
            string json = rd.ReadToEnd();

            return json;
        }

        public Weather ConvertToWeather(string url)
        {
            string weatherData = GetData(url);
            Weather w = JsonConvert.DeserializeObject<Weather>(weatherData);

            return w;
        }
    }
}
