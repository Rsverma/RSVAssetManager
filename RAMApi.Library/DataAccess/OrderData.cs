using RAMApi.Library.Internal.DataAccess;
using RAMApi.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RAMApi.Library.DataAccess
{
    public class OrderData : IOrderData
    {
        private readonly ISqlDataAccess _sql;

        public OrderData(ISqlDataAccess sql)
        {
            _sql = sql;
        }
        public List<OrderModel> GetAllOrders()
        {
            var output = _sql.LoadData<OrderModel, dynamic>("dbo.spOrder_GetAll", new { }, "RAMData");
            return output;
        }

        public void SaveOrder(OrderModel orderInfo)
        {
            _sql.SaveData("dbo.spOrder_Insert", orderInfo, "RAMData");
        }

        public void SendOrder(OrderModel orderInfo)
        {
            
        }
    }
}
