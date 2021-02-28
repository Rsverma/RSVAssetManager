using Caliburn.Micro;
using RAMDesktopUI.Library.Api;
using RAMDesktopUI.Library.Cache;
using RAMDesktopUI.Library.Helpers;
using RAMDesktopUI.Library.Models;
using RAMDesktopUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RAMDesktopUI.ViewModels
{
    public class OrderManagerViewModel : ModuleBase
    {
        private readonly IOrderEndpoint _orderEndpoint;
        private readonly IOrderFieldsCache _fieldsCache;

        public OrderManagerViewModel(IOrderEndpoint orderEndpoint, IOrderFieldsCache fieldsCache)
        {
            _orderEndpoint = orderEndpoint;
            _fieldsCache = fieldsCache;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadOrders();
        }

        private async Task LoadOrders()
        {
            List<OrderModel> orderDetails = await _orderEndpoint.GetAll();
            foreach (OrderModel order in orderDetails)
            {
                OrderManagerRowModel orderRow = new OrderManagerRowModel
                {
                    TickerSymbol = order.TickerSymbol,
                    AvgPrice = order.AvgPrice,
                    StopPrice = order.StopPrice,
                    LimitPrice = order.LimitPrice,
                    OrderDate = order.OrderDate,
                    CommissionAndFees = order.CommissionAndFees,
                    TotalQuantity = order.Quantity,
                    ExecutedQuantity = order.Quantity,
                    RemainingQuantity = 0,
                    TraderName = "Ramesh Verma"
                };
                orderRow.TotalCost = order.AvgPrice + order.CommissionAndFees;
                orderRow.OrderType = ((OrderType)order.Type).ToString();
                orderRow.OrderSide = ((OrderSide)order.Side).ToString();
                orderRow.TIF = ((TimeInForce)order.TIF).ToString();
                orderRow.InternalOrderType = ((InternalOrderType)order.InternalOrderType).ToString();
                orderRow.OrderStatus = ((OrderStatus)order.OrderStatus).ToString();
                orderRow.Broker = _fieldsCache.Brokers.First(x => x.Id.Equals(order.Broker)).Name;
                orderRow.Allocation = _fieldsCache.Accounts.First(x => x.Id.Equals(order.Allocation)).Name;
                Orders.Add(orderRow);
            }
            Status = "Data Initialized";
        }

        private string _status = string.Empty;
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                NotifyOfPropertyChange(() => Status);
            }
        }

        private BindingList<OrderManagerRowModel> _orders = new BindingList<OrderManagerRowModel>();

        public BindingList<OrderManagerRowModel> Orders
        {
            get { return _orders; }
            set
            {
                _orders = value;

                NotifyOfPropertyChange(() => Orders);
            }
        }
        
        private BindingList<OrderManagerRowModel> _stages = new BindingList<OrderManagerRowModel>();

        public BindingList<OrderManagerRowModel> Stages
        {
            get { return _stages; }
            set
            {
                _stages = value;

                NotifyOfPropertyChange(() => Stages);
            }
        }
        
        private BindingList<OrderManagerRowModel> _subs = new BindingList<OrderManagerRowModel>();

        public BindingList<OrderManagerRowModel> Subs
        {
            get { return _subs; }
            set
            {
                _subs = value;

                NotifyOfPropertyChange(() => Subs);
            }
        }
        private BindingList<OrderManagerRowModel> _fills = new BindingList<OrderManagerRowModel>();

        public BindingList<OrderManagerRowModel> Fills
        {
            get { return _fills; }
            set
            {
                _fills = value;

                NotifyOfPropertyChange(() => Fills);
            }
        }

    }
}
