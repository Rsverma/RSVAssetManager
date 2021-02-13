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
        public List<OrderDetailModel> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public void SaveOrder(OrderDBModel orderInfo)
        {
            _sql.SaveData("dbo.spOrder_Insert", orderInfo, "RAMData");
        }
    }
}
