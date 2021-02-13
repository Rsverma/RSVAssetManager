using System;
using System.Collections.Generic;
using System.Text;

namespace RAMApi.Library.Models
{
    public class OrderDBModel
    {
        public string Symbol { get; set; }
        public int OrderSide { get; set; }
        public int Quantity { get; set; }
        public int OrderType { get; set; }
        public decimal LimitPrice { get; set; }
        public decimal AvgPrice { get; set; }
        public string TraderId { get; set; }
        public DateTime TradeDate { get; set; } = DateTime.UtcNow;
    }
}
