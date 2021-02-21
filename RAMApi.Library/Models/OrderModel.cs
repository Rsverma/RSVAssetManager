using System;
using System.Collections.Generic;
using System.Text;

namespace RAMApi.Library.Models
{
    public class OrderModel
    {
        public string TickerSymbol { get; set; }
        public char OrderSide { get; set; }
        public int Quantity { get; set; }
        public char OrderType { get; set; }
        public char TIF { get; set; }
        public char OrderStatus { get; set; }
        public int Broker { get; set; }
        public int Allocation { get; set; }
        public decimal StopPrice { get; set; }
        public decimal LimitPrice { get; set; }
        public decimal AvgPrice { get; set; }
        public decimal CommissionAndFees { get; set; } = 0;
        public string TraderId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    }
}
