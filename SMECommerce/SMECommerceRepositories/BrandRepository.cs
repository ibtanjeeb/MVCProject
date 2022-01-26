using SmeCommerce.Models.EntityModels;
using SMECommerce.Databases.DbContexts;
using SMECommerce.Repositories.Abstraction;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMECommerceRepositories
{
    public class BrandRepository:Repository<Brands>, IBrandRepository
    {
        SMECommerceDbContext _db;

        public BrandRepository(SMECommerceDbContext db):base(db)
        {
            _db = db;

        }

        public override Brands GetById(int id)
        {
            return _db.Brand.FirstOrDefault(c => c.BrandId == id);
        }
    }
}
