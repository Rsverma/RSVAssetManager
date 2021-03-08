using Caliburn.Micro;
using RAMDesktopUI.EventModels;
using RAMDesktopUI.Helpers;
using RAMDesktopUI.Library.Api;
using RAMDesktopUI.Library.Cache;
using RAMDesktopUI.Library.Models;
using RAMDesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace RAMDesktopUI.ViewModels
{
    public class WatchlistViewModel : ModuleBase, IHandle<MarketDataEvent>
    {
        private readonly IEventAggregator _events;
        private readonly IWatchlistCache _watchlistCache;
        private readonly IMarketDataHelper _dataHelper;

        public WatchlistTabViewModel Tab1 { get; set; }
        public WatchlistTabViewModel Tab2 { get; set; }
        public WatchlistTabViewModel Tab3 { get; set; }
        public WatchlistTabViewModel Tab4 { get; set; }
        public WatchlistTabViewModel Tab5 { get; set; }
        public WatchlistViewModel(IEventAggregator events, IWatchlistCache watchlistCache, IMarketDataHelper dataHelper)
        {
            CurWindowState = WindowState.Maximized;
            _events = events;
            _events.SubscribeOnPublishedThread(this);
            _watchlistCache = watchlistCache;
            _dataHelper = dataHelper;
            
            List<string> symbols = _watchlistCache.TabWiseData.Values.SelectMany(x => x.Symbols).ToList();
            symbols.AddRange(_watchlistCache.TabWiseData.Values.Select(x => x.Index1));
            symbols.AddRange(_watchlistCache.TabWiseData.Values.Select(x => x.Index2));
            symbols.AddRange(_watchlistCache.TabWiseData.Values.Select(x => x.Index3));
            symbols.AddRange(_watchlistCache.TabWiseData.Values.Select(x => x.Index4));
            symbols.AddRange(_watchlistCache.TabWiseData.Values.Select(x => x.Index5));
            symbols.AddRange(_watchlistCache.TabWiseData.Values.Select(x => x.Index6));


            _dataHelper.AddSymbols(symbols);
            Tab1 = new WatchlistTabViewModel(watchlistCache, 1);
            Tab2 = new WatchlistTabViewModel(watchlistCache, 2);
            Tab3 = new WatchlistTabViewModel(watchlistCache, 3);
            Tab4 = new WatchlistTabViewModel(watchlistCache, 4);
            Tab5 = new WatchlistTabViewModel(watchlistCache, 5);
            Tab1Checked = true;
        }

        private bool _tab1Checked;
        public bool Tab1Checked
        {
            get { return _tab1Checked; }
            set
            {
                _tab1Checked = value;
                NotifyOfPropertyChange(() => Tab1Checked);
            }
        }

        private bool _tab2Checked;
        public bool Tab2Checked
        {
            get { return _tab2Checked; }
            set
            {
                _tab2Checked = value;
                NotifyOfPropertyChange(() => Tab2Checked);
            }
        }

        private bool _tab3Checked;
        public bool Tab3Checked
        {
            get { return _tab3Checked; }
            set
            {
                _tab3Checked = value;
                NotifyOfPropertyChange(() => Tab3Checked);
            }
        }

        private bool _tab4Checked;
        public bool Tab4Checked
        {
            get { return _tab4Checked; }
            set
            {
                _tab4Checked = value;
                NotifyOfPropertyChange(() => Tab4Checked);
            }
        }

        private bool _tab5Checked;
        public bool Tab5Checked
        {
            get { return _tab5Checked; }
            set
            {
                _tab5Checked = value;
                NotifyOfPropertyChange(() => Tab5Checked);
            }
        }


        public async Task HandleAsync(MarketDataEvent message, CancellationToken cancellationToken)
        {
            if(Tab1Checked)
            {
                await Tab1.UpdateLiveData(message.LiveFeed);
            }
            else if (Tab2Checked)
            {
                await Tab2.UpdateLiveData(message.LiveFeed);
            }
            else if (Tab3Checked)
            {
                await Tab3.UpdateLiveData(message.LiveFeed);
            }
            else if (Tab4Checked)
            {
                await Tab4.UpdateLiveData(message.LiveFeed);
            }
            else if (Tab5Checked)
            {
                await Tab5.UpdateLiveData(message.LiveFeed);
            }
        }
    }
}