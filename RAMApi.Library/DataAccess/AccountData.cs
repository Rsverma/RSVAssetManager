using RAMApi.Library.Internal.DataAccess;
using RAMApi.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RAMApi.Library.DataAccess
{
    public class AccountData : IAccountData
    {
        private readonly ISqlDataAccess _sql;

        public AccountData(ISqlDataAccess sql)
        {
            _sql = sql;
        }
        public List<AccountModel> GetAllAccounts()
        {
            var output = _sql.LoadData<AccountModel, dynamic>("dbo.spAccount_GetAll", new { }, "RAMData");
            return output;
        }
    }
}
