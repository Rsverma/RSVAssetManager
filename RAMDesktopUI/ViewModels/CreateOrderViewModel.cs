using Caliburn.Micro;
using RAMDesktopUI.Library.Api;
using RAMDesktopUI.Library.Cache;
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
    public class CreateOrderViewModel : ModuleBase
    {
        private readonly IOrderEndpoint _orderEndpoint;
        private readonly IOrderFieldsCache _fieldsCache;

        public CreateOrderViewModel(IOrderEndpoint orderEndpoint, IOrderFieldsCache fieldsCache)
        {
            _orderEndpoint = orderEndpoint;
            _fieldsCache = fieldsCache;
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            InitializeData();
        }

        private void InitializeData()
        {
            Symbols = new BindingList<SecurityModel>(_fieldsCache.Securities);
            OrderSides = new BindingList<string>() { "Buy", "Sell", "SellShort", "BuyToClose" };
            OrderTypes = new BindingList<string>() { "Market", "Limit", "Stoploss" };
            Brokers = new BindingList<BrokerModel>(_fieldsCache.Brokers);
            Allocations = new BindingList<AccountModel>(_fieldsCache.Accounts);
            SelectedSymbol = _fieldsCache.Securities.First();
            SelectedOrderSide = "Buy";
            SelectedOrderType = "Market";
            SelectedBroker = _fieldsCache.Brokers.First();
            SelectedAllocation = _fieldsCache.Accounts.First();
            Quantity = 1;
            StopPrice = 0;
            LimitPrice = 0;
            AvgPrice = 0;
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

        private SecurityModel _selectedSymbol;

        public SecurityModel SelectedSymbol
        {
            get { return _selectedSymbol; }
            set { _selectedSymbol = value; }
        }

        private BindingList<SecurityModel> _symbols;

        public BindingList<SecurityModel> Symbols
        {
            get { return _symbols; }
            set
            {
                _symbols = value;
                NotifyOfPropertyChange(() => Symbols);
            }
        }

        private string _selectedOrderSide = "Buy";

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

        private string _selectedOrderType = "Market";

        public string SelectedOrderType
        {
            get { return _selectedOrderType; }
            set
            {
                _selectedOrderType = value;
                NotifyOfPropertyChange(() => SelectedOrderType);
                NotifyOfPropertyChange(() => LimitPriceEnabled);
                NotifyOfPropertyChange(() => StopPriceEnabled);
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
                return (bool)(SelectedOrderType?.Equals("Limit")) || (bool)(SelectedOrderType?.Equals("Stoploss"));
            }
        }

        private BrokerModel _selecteBroker;

        public BrokerModel SelectedBroker
        {
            get { return _selecteBroker; }
            set
            {
                _selecteBroker = value;
                NotifyOfPropertyChange(() => SelectedBroker);
            }
        }

        private BindingList<BrokerModel> _brokers;

        public BindingList<BrokerModel> Brokers
        {
            get { return _brokers; }
            set
            {
                _brokers = value;
                NotifyOfPropertyChange(() => Brokers);
            }
        }

        private AccountModel _selectedAllocation;

        public AccountModel SelectedAllocation
        {
            get { return _selectedAllocation; }
            set
            {
                _selectedAllocation = value;
                NotifyOfPropertyChange(() => SelectedAllocation);
            }
        }

        private BindingList<AccountModel> _allocations;

        public BindingList<AccountModel> Allocations
        {
            get { return _allocations; }
            set
            {
                _allocations = value;
                NotifyOfPropertyChange(() => Allocations);
            }
        }

        public bool StopPriceEnabled
        {
            get
            {
                return (bool)(SelectedOrderType?.Equals("Stoploss"));
            }
        }

        private decimal _stopPrice = 0;

        public decimal StopPrice
        {
            get { return _stopPrice; }
            set
            {
                _stopPrice = value;
                NotifyOfPropertyChange(() => StopPrice);
            }
        }

        private uint _quantity = 1;

        public uint Quantity
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
        public bool IsValidOrder(bool isSaveOnly)
        {
            return SelectedSymbol.Id <= 0 && OrderTypes.Contains(SelectedOrderType)
                && OrderSides.Contains(SelectedOrderSide) && Quantity > 0 && LimitPrice >= 0 && (!isSaveOnly || AvgPrice >= 0); ;
        }

        public async Task SaveOrder()
        {
            OrderModel order = new OrderModel
            {
                Symbol = SelectedSymbol.TickerSymbol,
                OrderSide = SelectedOrderSide,
                Quantity = Quantity,
                OrderType = SelectedOrderType,
                Broker = SelectedBroker.Name,
                Allocation = SelectedAllocation.Name,
                StopPrice = StopPrice,
                LimitPrice = LimitPrice,
                AvgPrice = AvgPrice
            };
            try
            {
                await _orderEndpoint.PostOrder(order);
                Status = "Order Saved";
            }
            catch(Exception ex)
            {
                Status = ex.Message;
            }
            ResetOrderViewModel();
        }
        private void ResetOrderViewModel()
        {
            InitializeData();
        }

    }
}
