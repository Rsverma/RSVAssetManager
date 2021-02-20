using RAMApi.Library.Internal.DataAccess;
using RAMApi.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RAMApi.Library.DataAccess
{
    public class SecurityData : ISecurityData
    {
        private readonly ISqlDataAccess _sql;

        public SecurityData(ISqlDataAccess sql)
        {
            _sql = sql;
        }
        public List<SecurityModel> GetAllSecurities()
        {
            var output = _sql.LoadData<SecurityModel, dynamic>("dbo.spSecurity_GetAll", new { }, "RAMData");
            return output;
        }
    }
}
