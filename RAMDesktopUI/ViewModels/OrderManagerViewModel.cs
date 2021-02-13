using Caliburn.Micro;
using RAMDesktopUI.Library.Api;
using RAMDesktopUI.Library.Models;
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
            Orders = new BindingList<OrderDetailModel>(orderDetails);
        }
        private BindingList<OrderDetailModel> _orders;

        public BindingList<OrderDetailModel> Orders
        {
            get { return _orders; }
            set { _orders = value;

                NotifyOfPropertyChange(() => Orders);
            }
        }

    }
}
