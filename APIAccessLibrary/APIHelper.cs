
using System.Net.Http;
using System.Net.Http.Headers;

namespace APIAccessLibrary
{
    public static class ApiHelper
    {
        
            public static HttpClient ApiClient { get; set; }
            

            public static void InitializeClient()
            {
                ApiClient = new HttpClient();
                ApiClient.BaseAddress = new Uri("https://localhost:7281"); //Replace 7123 with the port your API uses
                ApiClient.DefaultRequestHeaders.Accept.Clear();
                //look for json files from api
                ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            }


        
    }

}
