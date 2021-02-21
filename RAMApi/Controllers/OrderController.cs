using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAMApi.Library.DataAccess;
using RAMApi.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RAMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderData _orderData;

        public OrderController(IOrderData orderData)
        {
            _orderData = orderData;
        }


        [Authorize(Roles = "Trader")]
        [HttpPost]
        public void Post(OrderModel order)
        {
            string traderId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            order.TraderId = traderId;
            _orderData.SaveOrder(order);
        }

        [Authorize(Roles = "Admin,FundManager")]
        [Route("GetAllOrders")]
        [HttpGet]
        public List<OrderModel> GetAllOrders()
        {
            return _orderData.GetAllOrders();
        }

    }
}
