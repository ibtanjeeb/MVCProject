using AutoMapper;
using SmeCommerce.Models.EntityModels;
using SMECommerce.Models;
using SMECommerce.Models.CategoryCreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMECommerce.Profiles
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CategoryCreateVM, Category>();
            CreateMap<CategoryEditVM, Category>();
            CreateMap<Category, CategoryCreateVM>();
            CreateMap<Category, CategoryEditVM>();

            CreateMap<Category, CategoryResult>();

        }
    }
}
