using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using weatherer.Interfaces;
using weatherer.Models;

namespace weatherer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForecastController : ControllerBase
    {
        private readonly ILogger<ForecastController> _logger;
        private readonly IForecastRetrievable _forecastRetriever;

        public ForecastController(ILogger<ForecastController> logger, IForecastRetrievable forecastRetriever)
        {
            _logger = logger;
            this._forecastRetriever = forecastRetriever;
        }

        [HttpGet]
        public async Task<ActionResult<Forecast>> Get()
        {
            return await this._forecastRetriever.GetCurrentAsync();
        }
    }
}