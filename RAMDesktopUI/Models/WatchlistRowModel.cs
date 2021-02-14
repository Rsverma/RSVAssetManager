using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMDesktopUI.Models
{
    public class WatchlistRowModel
    {
        public string TickerSymbol { get; set; }
        public decimal Ask { get; set; }
        public decimal Bid { get; set; }
        public decimal Last { get; set; }
        public decimal Change { get; set; }
        public decimal ChangePercent { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Open { get; set; }
        public decimal Close { get; set; }
        public string QuoteType { get; set; }
        public string Currency { get; set; }
        public string AssetClass { get; set; }
    }
}
