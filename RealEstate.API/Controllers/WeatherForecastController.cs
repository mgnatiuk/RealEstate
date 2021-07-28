using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealEstate.Application.Dtos.ListDtos;
using RealEstate.Application.Interfaces;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

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

        //[HttpGet]
        //public async Task<PagedResult<BuildingListDto>> GetAllBuildings([FromQuery] RequestQuery query)
        //{
        //    return await _estateService.GetAllBuildingsWithIncludes(query, new List<string> { nameof(Building.Address) });
        //}


        [HttpGet]
        public async Task<PagedResult<EstateListDto>> GetAllEstates([FromQuery] RequestPaginationQuery query)
        {
            return await _estateService.GetAllEstatesWithIncludes(query, new List<string> { nameof(Estate.Address) });
        }

    }
}
