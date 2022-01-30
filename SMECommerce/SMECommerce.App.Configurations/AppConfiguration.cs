using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SMECommerce.Databases.DbContexts;
using SMECommerce.Repositories.Abstraction;
using SMECommerce.Services;
using SMECommerce.Services.Abstraction;
using SMECommerceRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMECommerce.App.Configurations
{
    public class AppConfiguration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SMECommerceDbContext>(c => c.UseSqlServer(@"Server = (local); Database = SMECommerceDB; Trusted_Connection = True"));

            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddTransient<ICategoryService, CategoryServicees>();

            services.AddTransient<IProductService, ProductService>();

            services.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
