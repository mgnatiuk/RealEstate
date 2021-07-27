using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;
using RealEstate.Infrastructure.Data;

namespace RealEstate.Infrastructure.Repositories
{
    
    public class EstateRepository : AsyncRepository<Estate>, IEstateRepository
    {
        private readonly RealEstateDbContext _context;

        public EstateRepository(RealEstateDbContext context) : base(context) {
            _context = context;
        }
    }
}
