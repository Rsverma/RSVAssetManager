using System;
using System.Collections.Generic;
using System.Text;

namespace RAMDesktopUI.Library.Models
{
    public class OrderModel
    {
        public string Symbol { get; set; }
        public string OrderSide { get; set; }
        public uint Quantity { get; set; }
        public string OrderType { get; set; }
        public string Broker { get; set; }
        public string Allocation { get; set; }
        public decimal StopPrice { get; set; }
        public decimal LimitPrice { get; set; }
        public decimal AvgPrice { get; set; }
    }
}
