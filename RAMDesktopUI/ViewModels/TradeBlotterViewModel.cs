using Caliburn.Micro;
using RAMDesktopUI.Library.Api;
using RAMDesktopUI.Library.Cache;
using RAMDesktopUI.Library.Helpers;
using RAMDesktopUI.Library.Models;
using RAMDesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RAMDesktopUI.ViewModels
{
    public class TradeBlotterViewModel : ModuleBase
    {
        private readonly IOrderCache _orderCache;
        private readonly IOrderFieldsCache _fieldsCache;

        public TradeBlotterViewModel(IOrderCache orderCache, IOrderFieldsCache fieldsCache)
        {
            _orderCache = orderCache;
            _fieldsCache = fieldsCache;
        }

        protected override void OnViewLoaded(object view)
        {
            LoadOrders();
            base.OnViewLoaded(view);
        }

        private void LoadOrders()
        {
            foreach (OrderModel order in _orderCache.StageOrders)
            {
                OrderManagerRowModel orderRow = new OrderManagerRowModel
                {
                    ClOrderId = order.ClOrderId,
                    TickerSymbol = order.TickerSymbol,
                    AvgPrice = order.AvgPrice,
                    StopPrice = order.StopPrice,
                    LimitPrice = order.LimitPrice,
                    OrderDate = order.OrderDate,
                    CommissionAndFees = order.CommissionAndFees,
                    TotalCost = order.AvgPrice + order.CommissionAndFees,
                    TotalQuantity = order.Quantity,
                    ExecutedQuantity = order.Quantity,
                    RemainingQuantity = 0,
                    TraderName = "Ramesh Verma"
                };
                orderRow.OrderType = ((OrderType)order.Type).ToString();
                orderRow.OrderSide = ((OrderSide)order.Side).ToString();
                orderRow.TIF = ((TimeInForce)order.TIF).ToString();
                orderRow.InternalOrderType = ((InternalOrderType)order.InternalOrderType).ToString();
                orderRow.OrderStatus = ((OrderStatus)order.OrderStatus).ToString();
                orderRow.Broker = _fieldsCache.Brokers.First(x => x.Id.Equals(order.Broker)).Name;
                orderRow.Allocation = _fieldsCache.Accounts.First(x => x.Id.Equals(order.Allocation)).Name;
                Stages.Add(orderRow);
            }

            foreach (OrderModel order in _orderCache.SubOrders)
            {
                OrderManagerRowModel orderRow = new OrderManagerRowModel
                {
                    ClOrderId = order.ClOrderId,
                    TickerSymbol = order.TickerSymbol,
                    AvgPrice = order.AvgPrice,
                    StopPrice = order.StopPrice,
                    LimitPrice = order.LimitPrice,
                    OrderDate = order.OrderDate,
                    CommissionAndFees = order.CommissionAndFees,
                    TotalCost = order.AvgPrice + order.CommissionAndFees,
                    TotalQuantity = order.Quantity,
                    ExecutedQuantity = order.Quantity,
                    RemainingQuantity = 0,
                    TraderName = "Ramesh Verma"
                };
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

        private ObservableCollection<OrderManagerRowModel> _orders = new ObservableCollection<OrderManagerRowModel>();

        public ObservableCollection<OrderManagerRowModel> Orders
        {
            get { return _orders; }
            set
            {
                _orders = value;

                NotifyOfPropertyChange(() => Orders);
            }
        }

        private OrderManagerRowModel _selectedOrder;
        public OrderManagerRowModel SelectedOrder
        {
            get { return _selectedOrder; }
            set
            {
                _selectedOrder = value;
                Fills.Clear();
                foreach (FillModel fill in _orderCache.Fills)
                {
                    if (fill.ClOrderId.Equals(_selectedOrder.ClOrderId, StringComparison.Ordinal))
                    {
                        Fills.Add(fill);
                    }
                }

                NotifyOfPropertyChange(() => SelectedStage);
            }
        }

        private ObservableCollection<OrderManagerRowModel> _stages = new ObservableCollection<OrderManagerRowModel>();

        public ObservableCollection<OrderManagerRowModel> Stages
        {
            get { return _stages; }
            set
            {
                _stages = value;

                NotifyOfPropertyChange(() => Stages);
            }
        }

        private OrderManagerRowModel _selectedStage;
        public OrderManagerRowModel SelectedStage
        {
            get { return _selectedStage; }
            set
            {
                _selectedStage = value;
                Subs.Clear();
                foreach (OrderModel order in _orderCache.SubOrders)
                {
                    if (order.StageOrderId.Equals(_selectedStage.ClOrderId, StringComparison.Ordinal))
                    {
                        OrderManagerRowModel orderRow = new OrderManagerRowModel
                        {
                            ClOrderId = order.ClOrderId,
                            TickerSymbol = order.TickerSymbol,
                            AvgPrice = order.AvgPrice,
                            StopPrice = order.StopPrice,
                            LimitPrice = order.LimitPrice,
                            OrderDate = order.OrderDate,
                            CommissionAndFees = order.CommissionAndFees,
                            TotalCost = order.AvgPrice + order.CommissionAndFees,
                            TotalQuantity = order.Quantity,
                            ExecutedQuantity = order.Quantity,
                            RemainingQuantity = 0,
                            TraderName = "Ramesh Verma"
                        };
                        orderRow.OrderType = ((OrderType)order.Type).ToString();
                        orderRow.OrderSide = ((OrderSide)order.Side).ToString();
                        orderRow.TIF = ((TimeInForce)order.TIF).ToString();
                        orderRow.InternalOrderType = ((InternalOrderType)order.InternalOrderType).ToString();
                        orderRow.OrderStatus = ((OrderStatus)order.OrderStatus).ToString();
                        orderRow.Broker = _fieldsCache.Brokers.First(x => x.Id.Equals(order.Broker)).Name;
                        orderRow.Allocation = _fieldsCache.Accounts.First(x => x.Id.Equals(order.Allocation)).Name;
                        Subs.Add(orderRow);
                    }
                }

                NotifyOfPropertyChange(() => SelectedStage);
            }
        }

        private ObservableCollection<OrderManagerRowModel> _subs = new ObservableCollection<OrderManagerRowModel>();

        public ObservableCollection<OrderManagerRowModel> Subs
        {
            get { return _subs; }
            set
            {
                _subs = value;

                NotifyOfPropertyChange(() => Subs);
            }
        }
        
        private ObservableCollection<FillModel> _fills = new ObservableCollection<FillModel>();

        public ObservableCollection<FillModel> Fills
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
