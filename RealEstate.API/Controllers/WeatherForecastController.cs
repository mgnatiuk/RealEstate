using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealEstate.Application.Dtos.ListDtos;
using RealEstate.Application.Interfaces;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        
        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IEstateService _estateService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IEstateService estateService)
        {
            _logger = logger;
            _estateService = estateService;
        }

        [HttpGet]
        public async Task<IEnumerable<EstateListDto>> Get()
        {
            return await _estateService.GetAllWithIncludes(new List<string> { nameof(Estate.Address)});
        }
    }
}
