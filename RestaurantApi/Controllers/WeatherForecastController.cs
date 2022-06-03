using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _service;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get([FromQuery]int count, [FromQuery] int mintemp, [FromQuery] int maxtemp)
        {
            var result = _service.Get(count,mintemp,maxtemp);
            return result;
        }
        [HttpPost("postmethod")]
        public ActionResult<string> Hello([FromBody] string name)
        {
            //HttpContext.Response.StatusCode = 401;
            return StatusCode(401, $"Hello {name}");
            //return $"Hello {name}";
            //return NotFound($"Hello {name}");
        }
        [HttpPost("generate")]

        public ActionResult<IEnumerable<WeatherForecast>> Postmethod([FromQuery]int count, [FromBody]TemperatureRange range)
        {
            if(count < 0 || range.Max < range.Min)
            {
                return BadRequest();
            }

            var result =Get(count, range.Min, range.Max);
            return Ok(result);
           
        }
        

        
    }
}
