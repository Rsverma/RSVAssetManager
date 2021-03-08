using RAMDesktopUI.Library.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMDesktopUI.EventModels
{
    public class MarketDataEvent
    {
        public MarketDataEvent(ConcurrentDictionary<string, LiveFeedDataModel> liveFeed)
        {
            LiveFeed = liveFeed;
        }

        public readonly ConcurrentDictionary<string, LiveFeedDataModel> LiveFeed;
    }
}
