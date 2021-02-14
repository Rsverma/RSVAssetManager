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
            var orderDetails = await _orderEndpoint.GetAll();
            foreach(var order in orderDetails)
            {
                OrderManagerRowModel orderRow = new OrderManagerRowModel
                {
                    TickerSymbol = order.TickerSymbol,
                    AvgPrice = order.AvgPrice,
                    LimitPrice = order.LimitPrice,
                    OrderDate = order.OrderDate,
                    CommissionAndFees = order.CommissionAndFees,
                    TotalQuantity = order.Quantity,
                    ExecutedQuantity = order.Quantity,
                    RemainingQuantity = 0,
                    OrderType = order.OrderType == 0 ? "Market" : "Limit",
                    TraderName = "Ramesh Verma"
                };
                orderRow.TotalCost = order.AvgPrice + order.CommissionAndFees;

                orderRow.OrderSide = order.OrderSide switch
                {
                    1 => "Sell",
                    2 => "SellShort",
                    3 => "BuyToClose",
                    _ => "Buy"
                };
                Orders.Add(orderRow);
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
