using Caliburn.Micro;
using RAMDesktopUI.Library.Api;
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
        public OrderManagerViewModel(IOrderEndpoint orderEndpoint)
        {
            _orderEndpoint = orderEndpoint;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadOrders();
        }

        private async Task LoadOrders()
        {
            List<OrderDetailModel> orderDetails = await _orderEndpoint.GetAll();
            foreach (OrderDetailModel order in orderDetails)
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

                orderRow.OrderType = order.OrderType switch
                {
                    1 => "Limit",
                    2 => "Stoploss",
                    _ => "Market",
                };
                orderRow.OrderSide = order.OrderSide switch
                {
                    1 => "Sell",
                    2 => "SellShort",
                    3 => "BuyToClose",
                    _ => "Buy"
                };
                orderRow.Broker = order.Broker switch
                {
                    1 => "GS",
                    _ => "MS",
                };
                orderRow.Allocation = order.Allocation switch
                {
                    1 => "Acc1",
                    2 => "Acc2",
                    3 => "Acc3",
                    _ => "Unallocated",
                };
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
            set { _orders = value;

                NotifyOfPropertyChange(() => Orders);
            }
        }

    }
}
