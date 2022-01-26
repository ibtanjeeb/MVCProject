using SmeCommerce.Models.EntityModels;
using SMECommerce.Databases.DbContexts;
using SMECommerce.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMECommerceRepositories
{
    public class ProductRepository : Repository<Items>, IProductRepository
    {
        SMECommerceDbContext _db;
        public ProductRepository(SMECommerceDbContext db) : base(db)
        {
            _db = db;
        }
        public override Items GetById(int id)
        {
            return _db.Items.FirstOrDefault(c => c.Id == id);
        }

    }
}
