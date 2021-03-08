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
                List<string> symbols = _sql.LoadData<string, dynamic>("dbo.spWatchlist_GetTabSymbols", new { index = i + 1 }, "RAMData");
                WatchlistTabModel tabModel = output[i];
                tabModel.Symbols = symbols;
            }
            return output.ToDictionary(x => x.TabIndex);
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
                    TabIndex = tabIndices.Key,
                    Index1 = tabIndices.Value[0],
                    Index2 = tabIndices.Value[1],
                    Index3 = tabIndices.Value[2],
                    Index4 = tabIndices.Value[3],
                    Index5 = tabIndices.Value[4],
                    Index6 = tabIndices.Value[5]
                },
                "RAMData");
        }

        public void SaveTabSymbol(KeyValuePair<int, string> tabSymbol)
        {
            _ = _sql.SaveData("dbo.spWatchlist_InsertTabSymbol", tabSymbol, "RAMData");
        }

        public void DeleteTabSymbol(KeyValuePair<int, string> tabSymbol)
        {
            _ = _sql.SaveData("dbo.spWatchlist_DeleteTabSymbol", tabSymbol, "RAMData");
        }
    }
}
