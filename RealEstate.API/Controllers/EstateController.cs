using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealEstate.Application.Dtos.List;
using RealEstate.Application.Interfaces;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstateController : ControllerBase
    {
        private readonly ILogger<EstateController> _logger;
        private readonly IEstateService _estateService;

        public EstateController(ILogger<EstateController> logger, IEstateService estateService)
        {
            _logger = logger;
            _estateService = estateService;
        }

        // GET: api/estate
        [HttpGet]
        public async Task<PagedResult<EstateListDto>> Get([FromQuery] RequestPaginationQuery query)
        {
            return await _estateService.GetAllEstatesWithIncludes(query, new List<string> { nameof(Estate.Address) });
        }

        // GET: api/estate/guid_here
        [HttpGet("guid")]
        public async Task<EstateListDto> Get(string guid)
        {
            return await _estateService.GetByGuidWithIncludes(guid, new List<string> { nameof(Estate.Address) });
        }
    }
}
