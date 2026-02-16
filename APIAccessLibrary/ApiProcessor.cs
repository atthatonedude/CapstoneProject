using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using APIAccessLibrary.Model;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Security.RightsManagement;

namespace APIAccessLibrary
{    //this will process requests to db. Create functions to process to db.
    public class ApiProcessor
    {
        public static async Task<bool> CreateUserAsync(UserLoginModal modal)
        {
            var helper = new ApiHelper();
            string url = "/api/usercreation";
            var client = helper?.ApiClient;
            using (HttpResponseMessage response = await client.PostAsJsonAsync(url, modal))
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
        public static async Task<bool> LoginUserAsync(UserLoginModal modal)
        {
            var helper = new ApiHelper();
            var client = helper?.ApiClient;
            //Dont do this, it can be cached.
            string url = $"/api/userlogin?username={modal.UserName}&password={modal.UserPassword}";


            using (HttpResponseMessage response = await client.GetAsync(url))
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

        public static async Task<List<ItemModel>> GetItemsAsync(ItemModel model)
        {
            var helper = new ApiHelper();
            var client = helper?.ApiClient;
            string url = $"/api/getitems?searchedpartnumber={model.ItemPartNumber}";
            using (HttpResponseMessage response = await client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var items = await response.Content.ReadFromJsonAsync<List<ItemModel>>();
                    return items ?? new List<ItemModel>();
                }
                else
                {
                    return new List<ItemModel>();
                }
            }

        }

        public static async Task<int> GetBuildableItemsAsync(int parentItemId)
        {
            var helper = new ApiHelper();
            var client = helper?.ApiClient;

            string url = $"/api/getmaxbuildqty?parentItemId={parentItemId}";

            using (HttpResponseMessage response = await client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var qty = await response.Content.ReadFromJsonAsync<int>();
                    return qty;
                }
                else
                {
                    return 0;
                }
            }

        }
    }
}
