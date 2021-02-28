using RAMApi.Library.Internal.DataAccess;
using RAMApi.Library.Internal.FixAccess;
using RAMApi.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RAMApi.Library.DataAccess
{
    public class OrderData : IOrderData
    {
        private readonly ISqlDataAccess _sql;
        private readonly IFixDataAccess _fix;

        public OrderData(ISqlDataAccess sql, IFixDataAccess fix)
        {
            _sql = sql;
            _fix = fix;
        }
        public List<OrderModel> GetAllOrders()
        {
            var output = _sql.LoadData<OrderModel, dynamic>("dbo.spOrder_GetAll", new { }, "RAMData");
            return output;
        }

        public void SaveOrder(OrderModel orderInfo)
        {
            if (orderInfo.InternalOrderType == 2)
                _fix.SendOrder(orderInfo);
            _sql.SaveData("dbo.spOrder_Insert", orderInfo, "RAMData");
        }
    }
}
