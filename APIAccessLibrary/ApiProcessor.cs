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
            var helper = new ApiHelper();
            string url = "/api/usercreation";
            var client = helper?.ApiClient;
            using (HttpResponseMessage response = await  client.PostAsJsonAsync(url, modal))
            {
                if (response.IsSuccessStatusCode)
                {

                    return true;
                }
                else
                {
                    
                    return false;
                }
            }
        }

    }
}
