using RAMDesktopUI.Library.Api;
using RAMDesktopUI.Library.Models;
using RAMDesktopUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace RAMDesktopUI.ViewModels
{
    public class WatchlistViewModel : ModuleBase
    {
        private Timer _timer;
        private BindingList<LiveFeedDataModel> _symbolMarketData = new BindingList<LiveFeedDataModel>();
        private readonly IMarketDataEndpoint _marketData;
        private List<string> _symbols = new List<string>();

        public WatchlistViewModel(IMarketDataEndpoint marketData)
        {
            _marketData = marketData;
        }

        protected override void OnViewLoaded(object view)
        {
            _symbols = _marketData.GetWatchlistSymbols();
            _timer = new Timer(OnTimedEventAsync,null,0,5000);
            base.OnViewLoaded(view);
        }

        private async void OnTimedEventAsync(object state)
        {
            List<LiveFeedDataModel> marketData = await _marketData.GetSymbolMarketData(_symbols);
            Application.Current.Dispatcher.Invoke(() =>
            {
                foreach (var data in marketData)
                {
                    int index = SymbolMarketData.IndexOf(data);
                    if (index < 0)
                    {
                        SymbolMarketData.Add(data);
                    }
                    else
                        SymbolMarketData[index] = data;
                }
            });
        }

        public BindingList<LiveFeedDataModel> SymbolMarketData
        {
            get { return _symbolMarketData; }
            set
            {
                _symbolMarketData = value;

                NotifyOfPropertyChange(() => SymbolMarketData);
            }
        }
    }
}