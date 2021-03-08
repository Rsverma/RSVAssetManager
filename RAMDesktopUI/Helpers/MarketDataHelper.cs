using Caliburn.Micro;
using RAMDesktopUI.EventModels;
using RAMDesktopUI.Library.Api;
using RAMDesktopUI.Library.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RAMDesktopUI.Helpers
{
    public class MarketDataHelper : IMarketDataHelper
    {
        private ConcurrentDictionary<string, LiveFeedDataModel> _liveFeedDict = new ConcurrentDictionary<string, LiveFeedDataModel>();

        private readonly Timer liveFeedTimer;
        private readonly IEventAggregator _events;
        private readonly IMarketDataEndpoint _marketData;

        public MarketDataHelper(IEventAggregator events, IMarketDataEndpoint marketData)
        {
            liveFeedTimer = new(FetchLiveData, null, 0, 5000);
            _events = events;
            _marketData = marketData;
        }

        public void AddSymbols(IEnumerable<string> symbols)
        {
            foreach (string symbol in symbols)
            {
                _ = _liveFeedDict.TryAdd(symbol, new LiveFeedDataModel { Symbol = symbol });
            }
        }

        public void RemoveSymbols(List<string> symbols)
        {
            foreach (string symbol in symbols)
            {
                _ = _liveFeedDict.TryRemove(symbol, out _);
            }
        }

        private void UpdateLiveFeedData(List<LiveFeedDataModel> liveFeedData)
        {
            foreach (LiveFeedDataModel data in liveFeedData)
            {
                _liveFeedDict[data.Symbol] = data;
            }
        }

        private async void FetchLiveData(object state)
        {
            List<LiveFeedDataModel> liveData = await _marketData.GetSymbolMarketData(_liveFeedDict.Keys);
            UpdateLiveFeedData(liveData);
            await _events.PublishOnUIThreadAsync(new MarketDataEvent(_liveFeedDict));
        }
    }
}
