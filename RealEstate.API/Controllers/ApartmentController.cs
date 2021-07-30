using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealEstate.Application.Dtos.Create;
using RealEstate.Application.Dtos.List;
using RealEstate.Application.Interfaces;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApartmentController : Controller
    {
        private readonly ILogger<ApartmentController> _logger;
        private readonly IApartmentService _apartmentService;

        public ApartmentController(ILogger<ApartmentController> logger, IApartmentService apartmentService)
        {
            _logger = logger;
            _apartmentService = apartmentService;
        }

        // GET: api/apartment
        [HttpGet]
        public async Task<PagedResult<ApartmentListDto>> Get([FromQuery] RequestPaginationQuery query)
        {
            return await _apartmentService.GetAllapartmentsWithIncludes(query, new List<string> { nameof(Apartment.Address) });
        }

        // GET api/apartment/guid_here
        [HttpGet("{guid}")]
        public async Task<ApartmentListDto> Get(string guid)
        {
            ApartmentListDto dto = await _apartmentService.GetByGuidWithIncludes(guid, new List<string> { nameof(Apartment.Address) });
            return dto;
        }

        // POST api/apartment
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ApartmentCreateDto dto)
        {
            var guid = await _apartmentService.CreateApartment(dto);

            if (dto != null && guid != null)
                return Created($"/api/apartament/{guid}", null);
            else
                return BadRequest();
        }
 
        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
