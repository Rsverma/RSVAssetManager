using RAMDesktopUI.Library.Api;
using RAMDesktopUI.Library.Models;
using RAMDesktopUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

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
            _timer = new Timer(3000);
            // Hook up the Elapsed event for the timer. 
            _timer.Elapsed += OnTimedEventAsync;
            _timer.AutoReset = true;
            _timer.Enabled = true;
            base.OnViewLoaded(view);
        }

        private async void OnTimedEventAsync(object sender, ElapsedEventArgs e)
        {
            List<LiveFeedDataModel> marketData = await _marketData.GetSymbolMarketData(_symbols);
            SymbolMarketData = new BindingList<LiveFeedDataModel>(marketData);
            //Newtonsoft.Json.
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