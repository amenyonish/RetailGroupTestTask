using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RetailGroupWebAPI.Models;
using RetailGroupWebAPI.Services;

namespace RetailGroupWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ComputerController : Controller
    {       
        private IDataService _dataService;
        private ILogger<ComputerController> _logger;

        public ComputerController(IDataService dataService, ILogger<ComputerController> logger)
        {
            _dataService = dataService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Ok";
        }

        [HttpPost]
        public JsonResult Post([FromBody] ComputerInfo compInfo)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IgnoreNullValues = true
            };
            try
            {
                _logger.LogInformation(JsonConvert.SerializeObject(compInfo));
                //TODO write do DB
                var response = new ResponseWS(compInfo.Id, (int)ErrorCode.OK);
                return Json(response, options);
            }
            catch (Exception ex)
            {
                var error = new ResponseWS(compInfo.Id, (int)ErrorCode.SmthWrong, ex.Message);
                return Json(error);
            }
            

        }
    }
}