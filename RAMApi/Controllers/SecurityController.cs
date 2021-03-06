﻿using Microsoft.AspNetCore.Authorization;
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
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityData _securityData;

        public SecurityController(ISecurityData securityData)
        {
            _securityData = securityData;
        }

        [Route("GetAllSecurities")]
        [HttpGet]
        public List<SecurityModel> GetAllSecurities()
        {
            return _securityData.GetAllSecurities();
        }
    }
}
