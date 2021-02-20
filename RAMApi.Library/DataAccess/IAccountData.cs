using RAMApi.Library.Models;
using System.Collections.Generic;

namespace RAMApi.Library.DataAccess
{
    public interface IAccountData
    {
        List<AccountModel> GetAllAccounts();
    }
}