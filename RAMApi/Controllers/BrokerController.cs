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
    public class BrokerController : ControllerBase
    {
        private readonly IBrokerData _brokerData;

        public BrokerController(IBrokerData brokerData)
        {
            _brokerData = brokerData;
        }

        [Route("GetAllBrokers")]
        [HttpGet]
        public List<BrokerModel> GetAllBrokers()
        {
            return _brokerData.GetAllBrokers();
        }
    }
}
