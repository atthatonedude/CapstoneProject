using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using APIAccessLibrary.Model;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace APIAccessLibrary
{    //this will process requests to db. Create functions to process to db.
    public class ApiProcessor
    {
        public static async Task<bool> CreateUserAsync(UserLoginModal modal)
        {
            
            string url = "/api/usercreation";
            using (HttpResponseMessage response = await  ApiHelper.ApiClient.PostAsJsonAsync(url, modal))
            {
                if (response.IsSuccessStatusCode)
                {

                    return true;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}
