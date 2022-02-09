using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.Resource;
using WebAPI.Interfaces;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherAndStockController : ControllerBase
    {
        
        private readonly ILogger<WeatherAndStockController> _logger;
        private readonly ICorrelationService _correlationService;

        public WeatherAndStockController(ILogger<WeatherAndStockController> logger, ICorrelationService correlationService)
        {
            _logger = logger;
            _correlationService = correlationService;
        }

        [HttpGet]
        public Task<CorrelationReply> Get()
        {
            return _correlationService.GetData(new CorrelationRequest()
            {
                Name = "test"
            });
        }
    }
}