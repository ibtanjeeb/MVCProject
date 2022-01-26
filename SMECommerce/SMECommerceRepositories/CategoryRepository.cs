using Microsoft.EntityFrameworkCore;
using SmeCommerce.Models.EntityModels;
using SMECommerce.Databases.DbContexts;
using SMECommerce.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMECommerceRepositories
{
    public class CategoryRepository:Repository<Category>, ICategoryRepository
    {
        SMECommerceDbContext db;
        public CategoryRepository(SMECommerceDbContext db ):base(db)
        {
            this.db = db;
        }
        public override Category GetById(int id)
        {
            return db.Categories.FirstOrDefault(c => c.CategoryId == id);
        }

        public override ICollection<Category> GetAll()
        {
            return db.Categories.Include(c => c.Items).ToList();
        }

        

       

       


    }
}
