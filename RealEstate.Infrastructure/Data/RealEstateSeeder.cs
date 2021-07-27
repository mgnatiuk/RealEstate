using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Enums;

namespace RealEstate.Infrastructure.Data
{
    public class RealEstateSeeder
    {
        private readonly RealEstateDbContext _dbContext;

        public RealEstateSeeder(RealEstateDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();
                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }

                if (!_dbContext.Estates.Any())
                {
                    var estates = GetEstates();
                    _dbContext.Estates.AddRange(estates);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Estate> GetEstates()
        {
            var estates = new List<Estate>()
            {
                new Apartment(2,7,DateTime.Now,2019,2500,BuildingMaterial.Brick, HeatingType.Central, FinishingType.ForLiving, "Title 1",
                new Address("Streat 1","Warsaw","PL","00-832","54","543","Mazowieckie"),OfferType.Private,AgreementType.Rent, true,"Description 1",43.2,5.5,3000,5),

                new Apartment(1,15,DateTime.Now,2020,0,BuildingMaterial.Brick, HeatingType.District, FinishingType.ForFinishing, "Title 2",
                new Address("Streat 2","Warsaw","PL","00-454","12","1","Mazowieckie"),OfferType.Company,AgreementType.Sale, true,"Description 2",25.2,5.5,1850000,5),

                new Apartment(5,2,DateTime.Now,2016,0,BuildingMaterial.Brick, HeatingType.District, FinishingType.ForLiving, "Title 3",
                new Address("Streat 3","Warsaw","PL","00-821","54","324","Mazowieckie"),OfferType.Company,AgreementType.Sale, true,"Description 3",320.2,5.5,650000,5)

            };

            return estates;
        }

         

    }
}
