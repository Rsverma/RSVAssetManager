using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace RAMDesktopUI.Library.Models
{

    public class LiveFeedDataModel : INotifyPropertyChanged
    {
        private string _symbol;
        private double _ask;
        private double _bid;
        private double _last;
        private bool? _isLastGreater;

        public string Symbol
        {
            get => _symbol; set
            {
                _symbol = value;
                NotifyPropertyChanged();
            }
        }

        public double Ask
        {
            get => _ask;
            set
            {
                _ask = value;
                NotifyPropertyChanged();
            }
        }

        public double Bid
        {
            get => _bid;
            set
            {
                _bid = value;
                NotifyPropertyChanged();
            }
        }

        public double Last
        {
            get => _last;
            set
            {
                if (_last == value)
                {
                    IsLastGreater = null;
                }
                else
                {
                    IsLastGreater = value > _last;
                    _last = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool? IsLastGreater
        {
            get => _isLastGreater; set
            {
                _isLastGreater = value;
                NotifyPropertyChanged();
            }
        }

        public double High { get; set; }
        public double Low { get; set; }
        public double Open { get; set; }
        public double Change { get; set; }
        public double ChangePercent { get; set; }
        public double Close { get; set; }
        public string Asset { get; set; }
        public string language { get; set; }
        public string region { get; set; }
        public string quoteSourceName { get; set; }
        public bool triggerable { get; set; }
        public string currency { get; set; }
        public long firstTradeDateMilliseconds { get; set; }
        public int priceHint { get; set; }
        public double postMarketChangePercent { get; set; }
        public int postMarketTime { get; set; }
        public double postMarketPrice { get; set; }
        public double postMarketChange { get; set; }
        public int regularMarketTime { get; set; }
        public string regularMarketDayRange { get; set; }
        public long regularMarketVolume { get; set; }
        public int bidSize { get; set; }
        public int askSize { get; set; }
        public string fullExchangeName { get; set; }
        public string financialCurrency { get; set; }
        public long averageDailyVolume3Month { get; set; }
        public long averageDailyVolume10Day { get; set; }
        public double fiftyTwoWeekLowChange { get; set; }
        public double fiftyTwoWeekLowChangePercent { get; set; }
        public string fiftyTwoWeekRange { get; set; }
        public double fiftyTwoWeekHighChange { get; set; }
        public double fiftyTwoWeekHighChangePercent { get; set; }
        public double fiftyTwoWeekLow { get; set; }
        public double fiftyTwoWeekHigh { get; set; }
        public int dividendDate { get; set; }
        public int earningsTimestamp { get; set; }
        public int earningsTimestampStart { get; set; }
        public int earningsTimestampEnd { get; set; }
        public double trailingAnnualDividendRate { get; set; }
        public double trailingPE { get; set; }
        public double trailingAnnualDividendYield { get; set; }
        public double epsTrailingTwelveMonths { get; set; }
        public double epsForward { get; set; }
        public double epsCurrentYear { get; set; }
        public double priceEpsCurrentYear { get; set; }
        public long sharesOutstanding { get; set; }
        public double bookValue { get; set; }
        public double fiftyDayAverage { get; set; }
        public double fiftyDayAverageChange { get; set; }
        public double fiftyDayAverageChangePercent { get; set; }
        public double twoHundredDayAverage { get; set; }
        public double twoHundredDayAverageChange { get; set; }
        public double twoHundredDayAverageChangePercent { get; set; }
        public long marketCap { get; set; }
        public double forwardPE { get; set; }
        public double priceToBook { get; set; }
        public int sourceInterval { get; set; }
        public int exchangeDataDelayedBy { get; set; }
        public bool tradeable { get; set; }
        public string marketState { get; set; }
        public string exchange { get; set; }
        public string shortName { get; set; }
        public string longName { get; set; }
        public string messageBoardId { get; set; }
        public string exchangeTimezoneName { get; set; }
        public string exchangeTimezoneShortName { get; set; }
        public int gmtOffSetMilliseconds { get; set; }
        public string market { get; set; }
        public bool esgPopulated { get; set; }
        public string displayName { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
