using Microsoft.EntityFrameworkCore;
using SmeCommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMECommerce.Databases.DbContexts
{
    public class SMECommerceDbContext : DbContext
    {
        // string connectionstring = @"Server= (local);Database=SMECommerceDB; Trusted_Connection=True";

        public SMECommerceDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Brands> Brand { get; set; }

        public DbSet<Items> Items { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder
                // .UseLazyLoadingProxies()

              //  .UseSqlServer(connectionstring);
        }



    }
}
