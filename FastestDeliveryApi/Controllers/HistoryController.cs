using FastestDeliveryApi.database;
using FastestDeliveryApi.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastestDeliveryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {

        private EfModel _efModel;

        public HistoryController(EfModel model)
        {
            _efModel = model;
        }

        [HttpGet]
        public async Task<ActionResult<List<History>>> GetHistory ()
        {
            return await _efModel.Histories.ToListAsync();
        }
    }
}
