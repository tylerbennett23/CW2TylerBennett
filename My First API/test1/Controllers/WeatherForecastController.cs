﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace test1.Controllers{ 


[ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            //var rng = new Random();
            return Enumerable.Range(1, 1).Select(index => new WeatherForecast
            {
                Data = Program.JSONFile,
                ResponsAPI = Program.FinalResponse
            })
            .ToArray();
        }
    }
}
