using SmeCommerce.Models.EntityModels;
using SMECommerce.Repositories.Abstraction;
using SMECommerce.Services.Abstraction;
using SMECommerceRepositories;

using System;
using System.Collections.Generic;
using System.Text;

namespace SMECommerce.Services
{
   public class CategoryServicees:Service<Category>, ICategoryService
    {
        ICategoryRepository _categoryRepository;

        public CategoryServicees(ICategoryRepository categoryRepository):base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


       
    }
}
