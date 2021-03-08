using System.Collections.Generic;

namespace RAMDesktopUI.Helpers
{
    public interface IMarketDataHelper
    {
        void AddSymbols(IEnumerable<string> symbols);
        void RemoveSymbols(List<string> symbols);
    }
}