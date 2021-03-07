using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAMApi.Library.DataAccess;
using RAMApi.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WatchlistDataController : ControllerBase
    {
        private readonly IWatchlistData _watchlistData;

        public WatchlistDataController(IWatchlistData watchlistData)
        {
            _watchlistData = watchlistData;
        }

        [HttpGet]
        [Route("GetAllTabsData")]
        public Dictionary<int, WatchlistTabModel> GetAllTabsData()
        {
            return _watchlistData.GetAllTabsData();
        }

        [HttpPut]
        [Route("PutTabName")]
        public void PutTabName(KeyValuePair<int, string> tabName)
        {
            _watchlistData.UpdateTabName(tabName);
        }

        [HttpPut]
        [Route("PutTabIndices")]
        public void PutTabIndices(KeyValuePair<int, List<string>> tabIndices)
        {
            _watchlistData.UpdateTabIndices(tabIndices);
        }

        [HttpPost]
        [Route("PostTabSymbol")]
        public void PostTabSymbol(KeyValuePair<int, string> tabSymbol)
        {
            _watchlistData.SaveTabSymbol(tabSymbol);
        }
    }
}
