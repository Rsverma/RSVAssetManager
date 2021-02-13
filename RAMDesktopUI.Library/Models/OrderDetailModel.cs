using System;
using System.Collections.Generic;
using System.Text;

namespace RAMDesktopUI.Library.Models
{
    public class OrderDetailModel
    {
        public string TickerSymbol { get; set; }
        public int OrderSide { get; set; }
        public int Quantity { get; set; }
        public int OrderType { get; set; }
        public decimal LimitPrice { get; set; }
        public decimal AvgPrice { get; set; }
        public decimal CommissionAndFees { get; set; } = 0;
        public string TraderId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    }
}
