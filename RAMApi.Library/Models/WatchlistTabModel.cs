using System;
using System.Collections.Generic;
using System.Text;

namespace RAMApi.Library.Models
{
    public class WatchlistTabModel
    {
        public int TabIndex { get; set; }
        public string TabName { get; set; }
        public string Index1 { get; set; }
        public string Index2 { get; set; }
        public string Index3 { get; set; }
        public string Index4 { get; set; }
        public string Index5 { get; set; }
        public string Index6 { get; set; }

        public List<string> Symbols { get; set; }

    }
}
