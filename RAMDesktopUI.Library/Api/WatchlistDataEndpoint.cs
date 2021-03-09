using Newtonsoft.Json;
using RAMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RAMDesktopUI.Library.Api
{
    public class WatchlistDataEndpoint : IWatchlistDataEndpoint
    {
        private readonly IAPIHelper _apiHelper;

        public WatchlistDataEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task PostTabSymbol(KeyValuePair<int, string> tabSymbol)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("/api/WatchlistData/PostTabSymbol", tabSymbol))
            {
                if (response.IsSuccessStatusCode)
                {
                    // log successfull call?
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public async Task PutTabIndices(KeyValuePair<int, List<string>> tabIndices)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PutAsJsonAsync("/api/WatchlistData/PutTabIndices", tabIndices))
            {
                if (response.IsSuccessStatusCode)
                {
                    // log successfull call?
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public async Task PutTabName(KeyValuePair<int, string> tabName)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PutAsJsonAsync("/api/WatchlistData/PutTabName", tabName))
            {
                if (response.IsSuccessStatusCode)
                {
                    // log successfull call?
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<Dictionary<int, WatchlistTabModel>> GetAllTabsData()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/WatchlistData/GetAllTabsData"))
            {
                if (response.IsSuccessStatusCode)
                {
                    Dictionary<int, WatchlistTabModel> result = await response.Content.ReadAsAsync<Dictionary<int, WatchlistTabModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task DeleteTabSymbol(KeyValuePair<int, string> tabSymbol)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "/api/WatchlistData/DeleteTabSymbol");
            request.Content = new StringContent(JsonConvert.SerializeObject(tabSymbol), Encoding.UTF8, "application/json");
            
            using (HttpResponseMessage response = await _apiHelper.ApiClient.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    // log successfull call?
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
