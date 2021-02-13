using RAMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RAMDesktopUI.Library.Api
{
    public class OrderEndpoint : IOrderEndpoint
    {
        private readonly IAPIHelper _apiHelper;

        public OrderEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task PostOrder(OrderModel order)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("/api/Order", order))
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
