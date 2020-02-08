using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BussinesLogic.APIManager
{
    public static class ClimaProcessor
    {
        private const string API_KEY = "d5f0461e8cmshdceed573998b3dfp1b7b16jsn1210dbc9606b";
        private const string URL = "https://community-open-weather-map.p.rapidapi.com/weather?callback=test&id=2172797&units=%2522metric%2522%20or%20%2522imperial%2522&mode=xml%252C%20html&q=Buenos%20Aires";
        private const string API_HOST = "community-open-weather-map.p.rapidapi.com";



        public static async Task GetClima() {

            APIHelper.ApiClient.DefaultRequestHeaders.Add("x-rapidapi-key", API_KEY);
            APIHelper.ApiClient.DefaultRequestHeaders.Add("x-rapidapi-host",API_HOST);

            using (HttpResponseMessage response = await  APIHelper.ApiClient.GetAsync(URL)) {

                if (response.IsSuccessStatusCode)
                {
                    var clima = response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }


            }
            APIHelper.ClearHeader();
        }

    }
}
