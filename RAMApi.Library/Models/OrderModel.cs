using System;
using System.Collections.Generic;
using System.Text;

namespace RAMApi.Library.Models
{
    public class OrderModel
    {
        public string TickerSymbol { get; set; }
        public int OrderSide { get; set; }
        public uint Quantity { get; set; }
        public int OrderType { get; set; }
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
