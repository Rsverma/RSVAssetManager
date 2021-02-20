using System;
using System.Collections.Generic;
using System.Text;

namespace RAMApi.Library.Models
{
    public class SecurityModel
    {
        public int Id { get; set; }
        public string TickerSymbol { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastModified { get; set; }
    }
}
