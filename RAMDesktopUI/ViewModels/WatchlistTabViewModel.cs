using Caliburn.Micro;
using RAMDesktopUI.Library.Cache;
using RAMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RAMDesktopUI.ViewModels
{
    public class WatchlistTabViewModel : Screen
    {
        private readonly IWatchlistCache _watchlistCache;

        public WatchlistTabViewModel(IWatchlistCache watchlistCache)
        {
            _watchlistCache = watchlistCache;
        }

        public string TabIndex { get; set; }

        protected override void OnViewLoaded(object view)
        {
            //_symbols = _marketData.GetWatchlistSymbols();
            //_timer = new Timer(OnTimedEventAsync, null, 0, 5000);
            base.OnViewLoaded(view);
        }

        private async void OnTimedEventAsync(object state)
        {
           // List<LiveFeedDataModel> marketData = await _marketData.GetSymbolMarketData(_symbols);
            Application.Current.Dispatcher.Invoke(() =>
            {


            });
        }
        private ObservableCollection<LiveFeedDataModel> _marketDataRows;

        public ObservableCollection<LiveFeedDataModel> MarketDataRows
        {
            get { return _marketDataRows; }
            set
            {
                _marketDataRows = value;
                NotifyOfPropertyChange(() => MarketDataRows);
            }
        }

    }
}
