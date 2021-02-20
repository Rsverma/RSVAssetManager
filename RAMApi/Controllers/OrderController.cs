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
            OrderDBModel orderDetails = new OrderDBModel
            {
                TickerSymbol = order.Symbol,
                AvgPrice = order.AvgPrice,
                TraderId = traderId,
                LimitPrice = order.LimitPrice,
                StopPrice = order.StopPrice,
                Quantity = (int)order.Quantity,
            };
            orderDetails.OrderType = order.OrderType switch
            {
                "Limit" => 1,
                "Stoploss" => 2,
                _ => 0,
            };
            orderDetails.OrderSide = order.OrderSide switch
            {
                "Sell" => 1,
                "SellShort" => 2,
                "BuyToClose" => 3,
                _ => 0,
            };
            orderDetails.Broker = order.Broker switch
            {
                "GS" => 1,
                _ => 0,
            };
            orderDetails.Allocation = order.Allocation switch
            {
                "Acc1" => 1,
                "Acc2" => 2,
                "Acc3" => 3,
                _ => 0,
            };

            _orderData.SaveOrder(orderDetails);
        }

        [Authorize(Roles = "Admin,FundManager")]
        [Route("GetAllOrders")]
        [HttpGet]
        public List<OrderDBModel> GetAllOrders()
        {
            return _orderData.GetAllOrders();
        }

    }
}
