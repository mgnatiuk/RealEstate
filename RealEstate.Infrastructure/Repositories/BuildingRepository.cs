using System;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;
using RealEstate.Infrastructure.Data;

namespace RealEstate.Infrastructure.Repositories
{
    public class BuildingRepository : AsyncRepository<Building>, IBuildingRepository
    {
        private readonly RealEstateDbContext _context;

        public BuildingRepository(RealEstateDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
