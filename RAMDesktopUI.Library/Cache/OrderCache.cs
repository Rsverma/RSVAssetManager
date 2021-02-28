using RAMDesktopUI.Library.Api;
using RAMDesktopUI.Library.Helpers;
using RAMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RAMDesktopUI.Library.Cache
{
    public class OrderCache : IOrderCache
    {
        private readonly IOrderEndpoint _orderEndpoint;
        private readonly IFillEndpoint _fillEndpoint;
        public event EventHandler InitializationCompleted;
        public OrderCache(IOrderEndpoint orderEndpoint, IFillEndpoint fillEndpoint)
        {
            _orderEndpoint = orderEndpoint;
            _fillEndpoint = fillEndpoint;
            _ = InitializeCache();
        }

        private async Task InitializeCache()
        {
            List<OrderModel> orders = await _orderEndpoint.GetAll();
            StringBuilder clOrderIds = new StringBuilder();
            foreach (OrderModel order in orders)
            {
                if (order.InternalOrderType == (int)InternalOrderType.Stage)
                {
                    _stageOrders.Add(order);
                }
                else
                {
                    _subOrders.Add(order);
                    clOrderIds.Append(order.ClOrderId + ',');
                }
            }
            //clOrderIds.Length--;
            _fills = await _fillEndpoint.GetAll();
            InitializationCompleted?.Invoke(this, null);
        }

        private List<OrderModel> _stageOrders = new List<OrderModel>();

        public List<OrderModel> StageOrders
        {
            get { return _stageOrders; }
        }

        private List<OrderModel> _subOrders = new List<OrderModel>();

        public List<OrderModel> SubOrders
        {
            get { return _subOrders; }
        }

        private List<FillModel> _fills = new List<FillModel>();

        public List<FillModel> Fills
        {
            get { return _fills; }
        }

    }
}
