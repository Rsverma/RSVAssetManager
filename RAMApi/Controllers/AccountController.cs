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
    public class AccountController : ControllerBase
    {
        private readonly IAccountData _accountData;

        public AccountController(IAccountData accountData)
        {
            _accountData = accountData;
        }

        [Route("GetAllAccounts")]
        [HttpGet]
        public List<AccountModel> GetAllAccounts()
        {
            List<AccountModel> accounts = new List<AccountModel> 
            { 
                new AccountModel 
                { 
                    Id = 0,
                    Name = "Unallocated" 
                } 
            };
            accounts.AddRange(_accountData.GetAllAccounts());
            return accounts;
        }
    }
}
