using RAMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RAMDesktopUI.Library.Api
{
    public class OrderFieldsEndpoint : IOrderFieldsEndpoint
    {
        private readonly IAPIHelper _apiHelper;

        public OrderFieldsEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task<List<AccountModel>> GetAccounts()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Account/GetAllAccounts"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<AccountModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<BrokerModel>> GetBrokers()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Broker/GetAllBrokers"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<BrokerModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<SecurityModel>> GetSecurities()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Security/GetAllSecurities"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<SecurityModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
