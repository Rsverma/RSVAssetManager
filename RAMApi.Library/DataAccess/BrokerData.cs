using RAMApi.Library.Internal.DataAccess;
using RAMApi.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RAMApi.Library.DataAccess
{
    public class BrokerData : IBrokerData
    {
        private readonly ISqlDataAccess _sql;

        public BrokerData(ISqlDataAccess sql)
        {
            _sql = sql;
        }
        public List<BrokerModel> GetAllBrokers()
        {
            var output = _sql.LoadData<BrokerModel, dynamic>("dbo.spBroker_GetAll", new { }, "RAMData");
            return output;
        }
    }
}
