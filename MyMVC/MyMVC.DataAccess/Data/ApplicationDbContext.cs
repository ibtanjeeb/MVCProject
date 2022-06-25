using System;
using System.Collections.Generic;
using System.Text;
using MyMVC.Models;

using Microsoft.EntityFrameworkCore;

namespace MyMVC.DataAccess.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Season>Seasons { get; set; }
        
    }
}


