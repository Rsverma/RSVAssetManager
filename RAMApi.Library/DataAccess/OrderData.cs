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
            orderInfo.ClOrderId = _fix.GetNewClOrderID();
            orderInfo.OrigClOrderId = orderInfo.ClOrderId;
            _sql.StartTransaction("RAMData");
            try
            {
                switch (orderInfo.InternalOrderType)
                {
                    case 1:
                        {
                            OrderModel stage = orderInfo.ShallowCopy();
                            stage.InternalOrderType = 0;
                            stage.ClOrderId = _fix.GetNewClOrderID();
                            stage.OrigClOrderId = stage.ClOrderId;
                            orderInfo.StageOrderId = stage.ClOrderId;
                            FillModel fill = new FillModel
                            {
                                AvgPx = orderInfo.AvgPrice,
                                ClOrderId = orderInfo.ClOrderId,
                                CumQty = orderInfo.Quantity,
                                LastQty = orderInfo.Quantity,
                                LeavesQty = 0,
                                OrderQty = orderInfo.Quantity,
                                Side = orderInfo.Side,
                                OrderStatus = orderInfo.OrderStatus,
                                TickerSymbol = orderInfo.TickerSymbol,
                                ExecId = _fix.GetNewClOrderID(),
                                ExecType = 2,
                                OrderId = _fix.GetNewClOrderID(),

                            };
                            _sql.SaveDataInTransaction("dbo.spOrder_Insert", stage);
                            _sql.SaveDataInTransaction("dbo.spOrder_Insert", orderInfo);
                            _sql.SaveDataInTransaction("dbo.spFill_Insert", fill);
                        }
                        break;
                    case 2:
                        {
                            _fix.SendOrder(orderInfo);
                            OrderModel stage = orderInfo.ShallowCopy();
                            stage.InternalOrderType = 0;
                            stage.ClOrderId = _fix.GetNewClOrderID();
                            stage.OrigClOrderId = stage.ClOrderId;
                            orderInfo.StageOrderId = stage.ClOrderId;
                            _sql.SaveDataInTransaction("dbo.spOrder_Insert", stage);
                            _sql.SaveDataInTransaction("dbo.spOrder_Insert", orderInfo);
                        }
                        break;
                    default:
                        _sql.SaveDataInTransaction("dbo.spOrder_Insert", orderInfo);
                        break;
                }
                _sql.CommitTransaction();
            }
            catch(Exception)
            {
                _sql.RollbackTransaction();
                throw;
            }
        }
    }
}
