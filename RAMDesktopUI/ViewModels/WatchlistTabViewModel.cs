using Caliburn.Micro;
using Microsoft.Win32;
using RAMDesktopUI.Controls;
using RAMDesktopUI.Helpers;
using RAMDesktopUI.Library.Cache;
using RAMDesktopUI.Library.Models;
using RAMDesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RAMDesktopUI.ViewModels
{
    public class WatchlistTabViewModel : Screen
    {
        private readonly IWatchlistCache _watchlistCache;
        private readonly int _tabIndex;
        private readonly IMarketDataHelper _dataHelper;
        private ObservableCollection<LiveFeedDataModel> _liveFeedData;

        public ObservableCollection<LiveFeedDataModel> LiveFeedData
        {
            get { return _liveFeedData; }
            set
            {
                _liveFeedData = value;
                NotifyOfPropertyChange(() => LiveFeedData);
            }
        }

        private ICollectionView _marketDataRows;
        public ICollectionView MarketDataRows
        {
            get { return _marketDataRows; }
        }
        public WatchlistTabViewModel(IWatchlistCache watchlistCache, int index, IMarketDataHelper dataHelper)
        {
            _watchlistCache = watchlistCache;
            _tabIndex = index;
            _dataHelper = dataHelper;
            WatchlistTabModel tabData = _watchlistCache.TabWiseData[_tabIndex];
            Header = tabData.TabName;
            var dataList = tabData.Symbols.Select(x => new LiveFeedDataModel { Symbol = x });

            LiveFeedData = new ObservableCollection<LiveFeedDataModel>(dataList);
            _marketDataRows = CollectionViewSource.GetDefaultView(LiveFeedData);
            //_marketDataRows.CurrentChanged += _marketDataRows_CurrentChanged;
            _marketDataRows.Filter = _marketDataRows_Filter;

            Index1 = new WatchlistIndexModel { Symbol = tabData.Index1, Name = tabData.Index1 };
            Index2 = new WatchlistIndexModel { Symbol = tabData.Index2, Name = tabData.Index2 };
            Index3 = new WatchlistIndexModel { Symbol = tabData.Index3, Name = tabData.Index3 };
            Index4 = new WatchlistIndexModel { Symbol = tabData.Index4, Name = tabData.Index4 };
            Index5 = new WatchlistIndexModel { Symbol = tabData.Index5, Name = tabData.Index5 };
            Index6 = new WatchlistIndexModel { Symbol = tabData.Index6, Name = tabData.Index6 };
        }

        private bool _marketDataRows_Filter(object obj)
        {
            return true;
            //throw new NotImplementedException();
        }

        private void _marketDataRows_CurrentChanged(object sender, System.EventArgs e)
        {
            //throw new System.NotImplementedException();
        }
        private LiveFeedDataModel _selectedMarketDataRow;

        public LiveFeedDataModel SelectedMarketDataRow
        {
            get { return _selectedMarketDataRow; }
            set
            {
                _selectedMarketDataRow = value;
                NotifyOfPropertyChange(() => _selectedMarketDataRow);
            }
        }

        private string header;
        public string Header
        {
            get => header;
            set
            {
                header = value;
                NotifyOfPropertyChange(() => Header);
            }
        }

        #region indicesData
        public WatchlistIndexModel Index1
        {
            get => index1; 
            set
            {
                index1 = value;
                NotifyOfPropertyChange(() => Index1);
            }
        }
        public WatchlistIndexModel Index2
        {
            get => index2; 
            set
            {
                index2 = value;
                NotifyOfPropertyChange(() => Index2);
            }
        }
        public WatchlistIndexModel Index3
        {
            get => index3; 
            set
            {
                index3 = value;
                NotifyOfPropertyChange(() => Index3);
            }
        }
        public WatchlistIndexModel Index4
        {
            get => index4; 
            set
            {
                index4 = value;
                NotifyOfPropertyChange(() => Index4);
            }
        }
        public WatchlistIndexModel Index5
        {
            get => index5; 
            set
            {
                index5 = value;
                NotifyOfPropertyChange(() => Index5);
            }
        }
        public WatchlistIndexModel Index6
        {
            get => index6;
            set
            {
                index6 = value;
                NotifyOfPropertyChange(() => Index6);
            }
        }

        private WatchlistIndexModel index1;
        private WatchlistIndexModel index2;
        private WatchlistIndexModel index3;
        private WatchlistIndexModel index4;
        private WatchlistIndexModel index5;
        private WatchlistIndexModel index6;
        #endregion

        private string _symbol;

        public string Symbol
        {
            get { return _symbol; }
            set
            {
                _symbol = value;
                NotifyOfPropertyChange(() => Symbol);
            }
        }

        public void AddSymbol()
        {
            if (!string.IsNullOrWhiteSpace(Symbol))
            {
                string errMsg = _watchlistCache.AddSymbolToTab(Symbol, _tabIndex);
                if (string.IsNullOrWhiteSpace(errMsg))
                {
                    _dataHelper.AddSymbols(new List<string> { Symbol });
                    lock (_locker)
                    {
                        LiveFeedData.Add(new LiveFeedDataModel { Symbol = Symbol });
                    }
                }
                Symbol = string.Empty;
            }
        }
        private readonly object _locker = new object();
        public void RemoveSymbol(object source)
        {
            if (SelectedMarketDataRow != null)
            {
                string errMsg = _watchlistCache.RemoveSymbolFromTab(SelectedMarketDataRow.Symbol, _tabIndex);
                if (string.IsNullOrWhiteSpace(errMsg))
                {
                    lock (_locker)
                    {
                        LiveFeedDataModel model = LiveFeedData.FirstOrDefault(x => x.Symbol.Equals(SelectedMarketDataRow.Symbol, StringComparison.OrdinalIgnoreCase));
                        if (model != null)
                        {
                            LiveFeedData.Remove(model);
                        }
                    }
                }
            }
        }

        public void ImportSymbols()
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "CSV documents (.csv)|*.csv";
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                List<string> vs = File.ReadAllLines(openFileDialog.FileName).ToList();
                for (int i = 0; i < vs.Count; )
                {
                    if (!string.IsNullOrWhiteSpace(vs[i]) && i > 0)
                    {
                        string symbol = vs[i].Replace("\"", "").Replace("\\", "").Trim().ToUpper();
                        string errMsg = _watchlistCache.AddSymbolToTab(symbol, _tabIndex);
                        if (string.IsNullOrWhiteSpace(errMsg))
                        {
                            lock (_locker)
                            {
                                LiveFeedData.Add(new LiveFeedDataModel { Symbol = symbol });
                            }
                            i++;
                        }
                        else
                            vs.RemoveAt(i);
                    }
                    else
                        vs.RemoveAt(i);
                }
                _dataHelper.AddSymbols(vs);
            }
        }

        public void RenameTab()
        {
            InputBox popUp = new InputBox("Please enter tab name:", Header);

            if(popUp.ShowDialog() == true)
            {
                if (!string.IsNullOrWhiteSpace(popUp.Answer) && !Header.Equals(popUp.Answer))
                {
                    string errMsg = _watchlistCache.RenameTab(_tabIndex, popUp.Answer);
                    if (string.IsNullOrWhiteSpace(errMsg))
                    {
                        Header = popUp.Answer;
                    }
                }
            }
        }

        public async Task UpdateLiveData(IDictionary<string, LiveFeedDataModel> liveFeedDict)
        {
            lock (_locker)
            {
                for (int i = 0; i < LiveFeedData.Count; i++)
                {
                    LiveFeedDataModel data = LiveFeedData[i];
                    if (liveFeedDict.ContainsKey(data.Symbol))
                        LiveFeedData[i] = liveFeedDict[data.Symbol];
                }
            }
            if (liveFeedDict.ContainsKey(index1.Symbol))
            {
                index1.Name = liveFeedDict[index1.Symbol].shortName;
                index1.Price = liveFeedDict[index1.Symbol].Last;
                index1.Change = liveFeedDict[index1.Symbol].Change;
                index1.ChangeDescript = liveFeedDict[index1.Symbol].Change.ToString("+#.00;-#.00;0.00")
                    + liveFeedDict[index1.Symbol].ChangePercent.ToString(" (+#.00) ▲; (-#.00) ▼; (0.00)");
            }
            if (liveFeedDict.ContainsKey(index2.Symbol))
            {
                index2.Name = liveFeedDict[index2.Symbol].shortName;
                index2.Price = liveFeedDict[index2.Symbol].Last;
                index2.Change = liveFeedDict[index2.Symbol].Change;
                index2.ChangeDescript = liveFeedDict[index2.Symbol].Change.ToString("+#.00;-#.00;0.00")
                    + liveFeedDict[index2.Symbol].ChangePercent.ToString(" (+#.00) ▲; (-#.00) ▼; (0.00)");
            }
            if (liveFeedDict.ContainsKey(index3.Symbol))
            {
                index3.Name = liveFeedDict[index3.Symbol].shortName;
                index3.Price = liveFeedDict[index3.Symbol].Last;
                index3.Change = liveFeedDict[index3.Symbol].Change;
                index3.ChangeDescript = liveFeedDict[index3.Symbol].Change.ToString("+#.00;-#.00;0.00")
                    + liveFeedDict[index3.Symbol].ChangePercent.ToString(" (+#.00) ▲; (-#.00) ▼; (0.00)");
            }
            if (liveFeedDict.ContainsKey(index4.Symbol))
            {
                index4.Name = liveFeedDict[index4.Symbol].shortName;
                index4.Price = liveFeedDict[index4.Symbol].Last;
                index4.Change = liveFeedDict[index4.Symbol].Change;
                index4.ChangeDescript = liveFeedDict[index4.Symbol].Change.ToString("+#.00;-#.00;0.00")
                    + liveFeedDict[index4.Symbol].ChangePercent.ToString(" (+#.00) ▲; (-#.00) ▼; (0.00)");
            }
            if (liveFeedDict.ContainsKey(index5.Symbol))
            {
                index5.Name = liveFeedDict[index5.Symbol].shortName;
                index5.Price = liveFeedDict[index5.Symbol].Last;
                index5.Change = liveFeedDict[index5.Symbol].Change;
                index5.ChangeDescript = liveFeedDict[index5.Symbol].Change.ToString("+#.00;-#.00;0.00")
                    + liveFeedDict[index5.Symbol].ChangePercent.ToString(" (+#.00) ▲; (-#.00) ▼; (0.00)");
            }
            if (liveFeedDict.ContainsKey(index6.Symbol))
            {
                index6.Name = liveFeedDict[index6.Symbol].shortName;
                index6.Price = liveFeedDict[index6.Symbol].Last;
                index6.Change = liveFeedDict[index6.Symbol].Change;
                index6.ChangeDescript = liveFeedDict[index6.Symbol].Change.ToString("+#.00;-#.00;0.00")
                    + liveFeedDict[index6.Symbol].ChangePercent.ToString(" (+#.00) ▲; (-#.00) ▼; (0.00)");
            }
            await Task.CompletedTask;
        }
    }
}
