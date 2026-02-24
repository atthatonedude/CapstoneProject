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
{
	// This class processes HTTP requests to the API.
	public class ApiProcessor
	{
		public static Task<bool> CreateUserAsync(UserLoginModal modal)
		{
			var helper = new ApiHelper();
			var client = helper?.ApiClient ?? throw new InvalidOperationException("API client is not configured.");

			// Delegate to overload that accepts an HttpClient to make the HTTP logic testable.
			return CreateUserAsync(modal, client);
		}

		// Overload mainly for testing, allows injecting the HttpClient used for the request.
		public static async Task<bool> CreateUserAsync(UserLoginModal modal, HttpClient client)
		{
			if (client == null) throw new ArgumentNullException(nameof(client));

			const string url = "/api/usercreation";

			using (HttpResponseMessage response = await client.PostAsJsonAsync(url, modal))
			{
				return response.IsSuccessStatusCode;
			}
		}

		public static Task<bool> LoginUserAsync(UserLoginModal modal)
		{
			var helper = new ApiHelper();
			var client = helper?.ApiClient ?? throw new InvalidOperationException("API client is not configured.");

			return LoginUserAsync(modal, client);
		}

		// Overload mainly for testing, allows injecting the HttpClient used for the request.
		public static async Task<bool> LoginUserAsync(UserLoginModal modal, HttpClient client)
		{
			if (client == null) throw new ArgumentNullException(nameof(client));

			//Dont do this, it can be cached.
			string url = $"/api/userlogin?username={modal.UserName}&password={modal.UserPassword}";

			using (HttpResponseMessage response = await client.GetAsync(url))
			{
				return response.IsSuccessStatusCode;
			}
		}

		public static Task<List<ItemModel>> GetItemsAsync(ItemModel model)
		{
			var helper = new ApiHelper();
			var client = helper?.ApiClient ?? throw new InvalidOperationException("API client is not configured.");

			return GetItemsAsync(model, client);
		}

		// Overload mainly for testing, allows injecting the HttpClient used for the request.
		public static async Task<List<ItemModel>> GetItemsAsync(ItemModel model, HttpClient client)
		{
			if (client == null) throw new ArgumentNullException(nameof(client));

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

		public static Task<int> GetBuildableItemsAsync(int parentItemId)
		{
			var helper = new ApiHelper();
			var client = helper?.ApiClient ?? throw new InvalidOperationException("API client is not configured.");

			return GetBuildableItemsAsync(parentItemId, client);
		}

		// Overload mainly for testing, allows injecting the HttpClient used for the request.
		public static async Task<int> GetBuildableItemsAsync(int parentItemId, HttpClient client)
		{
			if (client == null) throw new ArgumentNullException(nameof(client));

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
