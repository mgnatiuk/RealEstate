using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        
        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IEstateRepository _estateRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IEstateRepository estateRepository)
        {
            _logger = logger;
            _estateRepository = estateRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Estate>> Get()
        {
            return await _estateRepository.GetAllWithIncludes(new List<string> { nameof(Estate.Address)});
        }
    }
}
