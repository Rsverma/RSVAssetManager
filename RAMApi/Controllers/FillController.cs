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
    public class FillController : ControllerBase
    {
        private readonly IFillData _fillData;

        public FillController(IFillData fillData)
        {
            _fillData = fillData;
        }


        [Authorize(Roles = "Trader")]
        [HttpPost]
        public void Post(FillModel fill)
        {
            _fillData.SaveFill(fill);
        }

        [Route("GetAllFills")]
        [HttpGet]
        public List<FillModel> GetAllFills()
        {
            return _fillData.GetFillsByClOrderID();
        }

    }
}
