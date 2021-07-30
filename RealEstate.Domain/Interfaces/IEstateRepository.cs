using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstate.Domain.Entities;

namespace RealEstate.Domain.Interfaces
{
    public interface IEstateRepository : IAsyncGenericRepository<Estate>
    {
        
    }
}
