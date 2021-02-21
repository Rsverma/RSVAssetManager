using RAMApi.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RAMApi.Library.DataAccess
{
    public interface IOrderData
    {
        void SaveOrder(OrderModel order);
        List<OrderModel> GetAllOrders();
    }
}
