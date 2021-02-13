using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RAMDesktopUI.ViewModels
{
    public class CreateOrderViewModel : ModuleBase
    {
        public CreateOrderViewModel()
        {

        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            InitializeData();
        }

        private void InitializeData()
        {
            Securities = new BindingList<string>() { "AAPL", "MSFT", "GOOG" };
            OrderSides = new BindingList<string>() { "Buy", "Sell", "SellShort", "BuyToClose" };
            OrderTypes = new BindingList<string>() { "Market", "Limit"};
        }

        private string _symbol = string.Empty;

        public string Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }

        private BindingList<string> _securities = new BindingList<string>();

        public BindingList<string> Securities
        {
            get { return _securities; }
            set
            {
                _securities = value;
                NotifyOfPropertyChange(() => Securities);
            }
        }

        private string _selectedOrderSide;

        public string SelectedOrderSide
        {
            get { return _selectedOrderSide; }
            set
            {
                _selectedOrderSide = value;
                NotifyOfPropertyChange(() => SelectedOrderSide);
            }
        }

        private BindingList<string> _orderSides;

        public BindingList<string> OrderSides
        {
            get { return _orderSides; }
            set
            {
                _orderSides = value;
                NotifyOfPropertyChange(() => OrderSides);
            }
        }

        private string _selectedOrderType;

        public string SelectedOrderType
        {
            get { return _selectedOrderType; }
            set
            {
                _selectedOrderType = value;
                NotifyOfPropertyChange(() => SelectedOrderType);
                NotifyOfPropertyChange(() => LimitPriceEnabled);
            }
        }

        private BindingList<string> _orderTypes;

        public BindingList<string> OrderTypes
        {
            get { return _orderTypes; }
            set
            {
                _orderTypes = value;
                NotifyOfPropertyChange(() => OrderTypes);
            }
        }

        public bool LimitPriceEnabled
        {
            get
            {
                return !string.IsNullOrEmpty(SelectedOrderType) && SelectedOrderType.Equals("Limit");
            }
        }

        private int _quantity = 1;

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                NotifyOfPropertyChange(() => Quantity);
            }
        }

        private decimal _limitPrice = 0;

        public decimal LimitPrice
        {
            get { return _limitPrice; }
            set
            {
                _limitPrice = value;
                NotifyOfPropertyChange(() => LimitPrice);
            }
        }

        private decimal _avgPrice = 0;

        public decimal AvgPrice
        {
            get { return _avgPrice; }
            set
            {
                _avgPrice = value;
                NotifyOfPropertyChange(() => AvgPrice);
            }
        }

    }
}
