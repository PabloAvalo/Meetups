using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace BussinesLogic.APIManager
{
    public static class APIHelper
    {

        public static HttpClient ApiClient { get; set; }

        public static void InitializeApiClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static void ClearHeader() {

            APIHelper.ApiClient.DefaultRequestHeaders.Clear();
        }

  
    }
}
