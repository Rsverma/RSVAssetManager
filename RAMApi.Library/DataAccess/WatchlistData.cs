using RAMApi.Library.Internal.DataAccess;
using RAMApi.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RAMApi.Library.DataAccess
{
    public class WatchlistData : IWatchlistData
    {
        private readonly ISqlDataAccess _sql;

        public WatchlistData(ISqlDataAccess sql)
        {
            _sql = sql;
        }

        public Dictionary<int, WatchlistTabModel> GetAllTabsData()
        {
            List<WatchlistTabModel> output = _sql.LoadData<WatchlistTabModel, dynamic>("dbo.spWatchlist_GetAllTabsData", new { }, "RAMData");
            for (int i = 0; i < output.Count; i++)
            {
                List<string> symbols = _sql.LoadData<string, dynamic>("dbo.spWatchlist_GetTabSymbols", new { index = i }, "RAMData");
                WatchlistTabModel tabModel = output[i];
                tabModel.Symbols = symbols;
            }
            return output.Select((s, i) => (s, i))
                         .ToDictionary(x => x.i, x => x.s);
        }

        public void UpdateTabName(KeyValuePair<int, string> tabName)
        {
            _ = _sql.SaveData("dbo.spWatchlist_UpdateTabName", tabName, "RAMData");
        }

        public void UpdateTabIndices(KeyValuePair<int, List<string>> tabIndices)
        {
            _ = _sql.SaveData<dynamic>("dbo.spWatchlist_UpdateTabIndices",
                new
                {
                    tabIndex = tabIndices.Key,
                    index1 = tabIndices.Value[0],
                    index2 = tabIndices.Value[1],
                    index3 = tabIndices.Value[2],
                    index4 = tabIndices.Value[3],
                    index5 = tabIndices.Value[4],
                    index6 = tabIndices.Value[5]
                },
                "RAMData");
        }

        public void SaveTabSymbol(KeyValuePair<int, string> tabSymbol)
        {
            _ = _sql.SaveData("dbo.spWatchlist_InsertTabSymbol", tabSymbol, "RAMData");
        }

    }
}
