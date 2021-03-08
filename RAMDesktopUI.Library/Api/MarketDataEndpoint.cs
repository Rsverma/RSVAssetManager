using Newtonsoft.Json;
using RAMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RAMDesktopUI.Library.Api
{
    public class MarketDataEndpoint : IMarketDataEndpoint
    {
        private readonly IAPIHelper _apiHelper;
        private const string url = "https://query1.finance.yahoo.com/v7/finance/quote?symbols=";
        public MarketDataEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<LiveFeedDataModel>> GetSymbolMarketData(ICollection<string> symbols)
        {
            List<LiveFeedDataModel> result = new List<LiveFeedDataModel>();
            try
            {
                string myJsonResponse = await new WebClient().DownloadStringTaskAsync(url + string.Join(",", symbols));
                Root root = JsonConvert.DeserializeObject<Root>(myJsonResponse);
                if (root.quoteResponse.result != null)
                {
                    foreach(Result res in root.quoteResponse.result)
                    {
                        LiveFeedDataModel data = GetLiveFeedFromResponse(res);
                        result.Add(data);
                    }
                }
            }
            catch { }
            return result;
        }

        private LiveFeedDataModel GetLiveFeedFromResponse(Result result)
        {
            LiveFeedDataModel data = new LiveFeedDataModel
            {
                language = result.language,
                region = result.region,
                Asset = result.quoteType,
                quoteSourceName = result.quoteSourceName,
                triggerable = result.triggerable,
                currency = result.currency,
                firstTradeDateMilliseconds = result.firstTradeDateMilliseconds,
                priceHint = result.priceHint,
                postMarketChangePercent = result.postMarketChangePercent,
                postMarketTime = result.postMarketTime,
                postMarketPrice = result.postMarketPrice,
                postMarketChange = result.postMarketChange,
                Change = result.regularMarketChange,
                ChangePercent = result.regularMarketChangePercent,
                regularMarketTime = result.regularMarketTime,
                Last = result.regularMarketPrice,
                High = result.regularMarketDayHigh,
                regularMarketDayRange = result.regularMarketDayRange,
                Low = result.regularMarketDayLow,
                regularMarketVolume = result.regularMarketVolume,
                Close = result.regularMarketPreviousClose,
                Bid = result.bid,
                Ask = result.ask,
                bidSize = result.bidSize,
                askSize = result.askSize,
                fullExchangeName = result.fullExchangeName,
                financialCurrency = result.financialCurrency,
                Open = result.regularMarketOpen,
                averageDailyVolume3Month = result.averageDailyVolume3Month,
                averageDailyVolume10Day = result.averageDailyVolume10Day,
                fiftyTwoWeekLowChange = result.fiftyTwoWeekLowChange,
                fiftyTwoWeekLowChangePercent = result.fiftyTwoWeekLowChangePercent,
                fiftyTwoWeekRange = result.fiftyTwoWeekRange,
                fiftyTwoWeekHighChange = result.fiftyTwoWeekHighChange,
                fiftyTwoWeekHighChangePercent = result.fiftyTwoWeekHighChangePercent,
                fiftyTwoWeekLow = result.fiftyTwoWeekLow,
                fiftyTwoWeekHigh = result.fiftyTwoWeekHigh,
                dividendDate = result.dividendDate,
                earningsTimestamp = result.earningsTimestamp,
                earningsTimestampStart = result.earningsTimestampStart,
                earningsTimestampEnd = result.earningsTimestampEnd,
                trailingAnnualDividendRate = result.trailingAnnualDividendRate,
                trailingPE = result.trailingPE,
                trailingAnnualDividendYield = result.trailingAnnualDividendYield,
                epsTrailingTwelveMonths = result.epsTrailingTwelveMonths,
                epsForward = result.epsForward,
                epsCurrentYear = result.epsCurrentYear,
                priceEpsCurrentYear = result.priceEpsCurrentYear,
                sharesOutstanding = result.sharesOutstanding,
                bookValue = result.bookValue,
                fiftyDayAverage = result.fiftyDayAverage,
                fiftyDayAverageChange = result.fiftyDayAverageChange,
                fiftyDayAverageChangePercent = result.fiftyDayAverageChangePercent,
                twoHundredDayAverage = result.twoHundredDayAverage,
                twoHundredDayAverageChange = result.twoHundredDayAverageChange,
                twoHundredDayAverageChangePercent = result.twoHundredDayAverageChangePercent,
                marketCap = result.marketCap,
                forwardPE = result.forwardPE,
                priceToBook = result.priceToBook,
                sourceInterval = result.sourceInterval,
                exchangeDataDelayedBy = result.exchangeDataDelayedBy,
                tradeable = result.tradeable,
                marketState = result.marketState,
                exchange = result.exchange,
                shortName = result.shortName,
                longName = result.longName,
                messageBoardId = result.messageBoardId,
                exchangeTimezoneName = result.exchangeTimezoneName,
                exchangeTimezoneShortName = result.exchangeTimezoneShortName,
                gmtOffSetMilliseconds = result.gmtOffSetMilliseconds,
                market = result.market,
                esgPopulated = result.esgPopulated,
                displayName = result.displayName,
                Symbol = result.symbol
            };
            return data;
        }
        
    }
}
