using System;
using System.Collections.Generic;
using System.Text;

namespace RAMApi.Library.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string TickerSymbol { get; set; }
        public string OrigClOrderId { get; set; }
        public string ClOrderId { get; set; }
        public string StageOrderId { get; set; }
        public int InternalOrderType { get; set; }
        public string TraderId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public int Quantity { get; set; }
        public decimal StopPrice { get; set; }
        public decimal LimitPrice { get; set; }
        public decimal AvgPrice { get; set; }
        public decimal CommissionAndFees { get; set; } = 0;
        public decimal TotalCost { get; set; }
        public char Side { get; set; }
        public char Type { get; set; }
        public char TIF { get; set; }
        public char OrderStatus { get; set; }
        public int Broker { get; set; }
        public int Allocation { get; set; }
    }
}
