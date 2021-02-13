﻿using Microsoft.AspNetCore.Authorization;
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
            string traderId = User.FindFirstValue(ClaimTypes.NameIdentifier); //RequestContext.Principal.Identity.GetUserId();
            OrderDBModel orderDetails = new OrderDBModel
            {
                Symbol = order.Symbol,
                AvgPrice = order.AvgPrice,
                TraderId = traderId,
                LimitPrice = order.LimitPrice,
                Quantity = (int)order.Quantity,
                OrderType = order.OrderType.Equals("Market") ? 0 : 1
            };
            orderDetails.OrderSide = order.OrderSide switch
            {
                "Sell" => 1,
                "SellShort" => 2,
                "BuyToClose" => 3,
                _ => 0,
            };
            _orderData.SaveOrder(orderDetails);
        }

        [Authorize(Roles = "Admin,FundManager")]
        [Route("GetAllOrders")]
        [HttpGet]
        public List<OrderDetailModel> GetAllOrders()
        {
            return _orderData.GetAllOrders();
        }

    }
}
