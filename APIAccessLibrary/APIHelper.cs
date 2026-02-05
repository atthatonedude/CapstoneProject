
using System.Net.Http;
using System.Net.Http.Headers;

namespace APIAccessLibrary
{
    public  class ApiHelper
    {
        
            public  HttpClient? ApiClient { get; set; }
            

            public ApiHelper()
            {
                ApiClient = new HttpClient();
                ApiClient.BaseAddress = new Uri("https://localhost:7281"); 
                ApiClient.DefaultRequestHeaders.Accept.Clear();
                //look for json files from api
                ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            }


        
    }

}
