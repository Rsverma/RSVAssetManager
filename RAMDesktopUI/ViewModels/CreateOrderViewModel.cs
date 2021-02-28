using Caliburn.Micro;
using RAMDesktopUI.Library.Api;
using RAMDesktopUI.Library.Cache;
using RAMDesktopUI.Library.Helpers;
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
            OrderSides = new BindingList<OrderSide>(Enum.GetValues(typeof(OrderSide)).Cast<OrderSide>().ToList());
            OrderTypes = new BindingList<OrderType>(Enum.GetValues(typeof(OrderType)).Cast<OrderType>().ToList());
            TIFs = new BindingList<TimeInForce>(Enum.GetValues(typeof(TimeInForce)).Cast<TimeInForce>().ToList());
            Brokers = new BindingList<BrokerModel>(_fieldsCache.Brokers);
            Allocations = new BindingList<AccountModel>(_fieldsCache.Accounts);
            SetDefaultValues();
        }

        private void SetDefaultValues()
        {
            SelectedSymbol = _fieldsCache.Securities.First();
            SelectedOrderSide = OrderSide.Buy;
            SelectedOrderType = OrderType.Market;
            SelectedTIF = TimeInForce.Day;
            SelectedBroker = _fieldsCache.Brokers.First();
            SelectedAllocation = _fieldsCache.Accounts.First();
            Quantity = 1;
            StopPrice = 0;
            LimitPrice = 0;
            AvgPrice = 0;
            Date = DateTime.Now;
            Commission = 0;
            Fees = 0;
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

        private OrderSide _selectedOrderSide;

        public OrderSide SelectedOrderSide
        {
            get { return _selectedOrderSide; }
            set
            {
                _selectedOrderSide = value;
                NotifyOfPropertyChange(() => SelectedOrderSide);
            }
        }

        private BindingList<OrderSide> _orderSides;

        public BindingList<OrderSide> OrderSides
        {
            get { return _orderSides; }
            set
            {
                _orderSides = value;
                NotifyOfPropertyChange(() => OrderSides);
            }
        }

        private OrderType _selectedOrderType;

        public OrderType SelectedOrderType
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

        private BindingList<OrderType> _orderTypes;

        public BindingList<OrderType> OrderTypes
        {
            get { return _orderTypes; }
            set
            {
                _orderTypes = value;
                NotifyOfPropertyChange(() => OrderTypes);
            }
        }

        private TimeInForce _selectedTIF;

        public TimeInForce SelectedTIF
        {
            get { return _selectedTIF; }
            set
            {
                _selectedTIF = value;
                NotifyOfPropertyChange(() => SelectedTIF);
            }
        }

        private BindingList<TimeInForce> _tifs;

        public BindingList<TimeInForce> TIFs
        {
            get { return _tifs; }
            set
            {
                _tifs = value;
                NotifyOfPropertyChange(() => TIFs);
            }
        }

        public bool LimitPriceEnabled
        {
            get
            {
                return SelectedOrderType == OrderType.Limit || SelectedOrderType == OrderType.StopLimit;
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
                return SelectedOrderType == OrderType.Stop || SelectedOrderType == OrderType.StopLimit;
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

        private DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                NotifyOfPropertyChange(() => Date);
            }
        }

        private decimal _commission = 0;

        public decimal Commission
        {
            get { return _commission; }
            set
            {
                _commission = value;
                NotifyOfPropertyChange(() => Commission);
            }
        }

        private decimal _fees = 0;

        public decimal Fees
        {
            get { return _fees; }
            set
            {
                _fees = value;
                NotifyOfPropertyChange(() => Fees);
            }
        }

        public bool IsValidOrder(bool isSaveOnly)
        {
            return SelectedSymbol.Id > 0 && OrderTypes.Contains(SelectedOrderType)
                && OrderSides.Contains(SelectedOrderSide) && Quantity > 0 && LimitPrice >= 0 && (!isSaveOnly || AvgPrice >= 0)
                && Commission >= 0 && Fees >= 0;
        }

        public async Task CreateStage()
        {
            OrderModel order = GetOrderFromUI();
            order.OrderStatus = (char)OrderStatus.New;
            order.InternalOrderType = (int)InternalOrderType.Stage;
            try
            {
                await _orderEndpoint.PostOrder(order);
                Status = "Stage order saved.";
            }
            catch (Exception ex)
            {
                Status = ex.Message;
            }
            ResetOrderViewModel();
        }

        public async Task SaveManual()
        {
            OrderModel order = GetOrderFromUI();
            order.OrderStatus = (char)OrderStatus.Filled;
            order.InternalOrderType = (int)InternalOrderType.Manual;
            try
            {
                await _orderEndpoint.PostOrder(order);
                Status = "Manual order saved.";
            }
            catch (Exception ex)
            {
                Status = ex.Message;
            }
            ResetOrderViewModel();
        }

        public async Task SendToBroker()
        {
            OrderModel order = GetOrderFromUI();
            order.OrderStatus = (char)OrderStatus.PendingNew;
            order.InternalOrderType = (int)InternalOrderType.Live;
            try
            {
                await _orderEndpoint.PostOrder(order);
                Status = "Live order sent to broker.";
            }
            catch (Exception ex)
            {
                Status = ex.Message;
            }
            ResetOrderViewModel();
        }

        private OrderModel GetOrderFromUI()
        {
            return new OrderModel
            {
                TickerSymbol = SelectedSymbol.TickerSymbol,
                OrderDate = Date,
                CommissionAndFees = Commission + Fees,
                Side = (Char)SelectedOrderSide,
                Quantity = (int)Quantity,
                Type = (Char)SelectedOrderType,
                TIF = (Char)SelectedTIF,
                Broker = SelectedBroker.Id,
                Allocation = SelectedAllocation.Id,
                StopPrice = StopPrice,
                LimitPrice = LimitPrice,
                AvgPrice = AvgPrice
            };
        }

        private void ResetOrderViewModel()
        {
            SetDefaultValues();
        }

    }
}
