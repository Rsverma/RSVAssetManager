using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMDesktopUI.Models
{
    public class OrderManagerRowModel
    {
        public string TickerSymbol { get; set; }
        public string OrderSide { get; set; }
        public string Broker { get; set; }
        public string Allocation { get; set; }
        public int TotalQuantity { get; set; }
        public int ExecutedQuantity { get; set; }
        public int RemainingQuantity { get; set; }
        public string OrderType { get; set; }
        public string TIF { get; set; }
        public string InternalOrderType { get; set; }
        public string OrderStatus { get; set; }
        public decimal StopPrice { get; set; }
        public decimal LimitPrice { get; set; }
        public decimal AvgPrice { get; set; }
        public decimal CommissionAndFees { get; set; } = 0;
        public decimal TotalCost { get; set; } = 0;
        public string TraderName { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    }
}
