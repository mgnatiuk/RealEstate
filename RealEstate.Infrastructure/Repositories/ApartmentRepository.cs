using System;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;
using RealEstate.Infrastructure.Data;

namespace RealEstate.Infrastructure.Repositories
{
    public class ApartmentRepository : AsyncGenericRepository<Apartment>, IApartmentRepository
    {
        private readonly RealEstateDbContext _context;

        public ApartmentRepository(RealEstateDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
