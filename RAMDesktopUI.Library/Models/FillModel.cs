namespace RAMDesktopUI.Library.Models
{
    public class FillModel
    {
        public int Id { get; set; }
        public string ClOrderId { get; set; }
        public string OrderId { get; set; }
        public string ExecId { get; set; }
        public int ExecType { get; set; }
        public char OrderStatus { get; set; }
        public string TickerSymbol { get; set; }
        public char Side { get; set; }
        public int OrderQty { get; set; }
        public int LastQty { get; set; }
        public int LeavesQty { get; set; }
        public int CumQty { get; set; }
        public decimal AvgPx { get; set; }
    }
}
