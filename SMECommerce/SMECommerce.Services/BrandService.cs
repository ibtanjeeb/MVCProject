using SmeCommerce.Models.EntityModels;
using SMECommerce.Repositories.Abstraction;
using SMECommerce.Services.Abstraction;

using System;
using System.Collections.Generic;
using System.Text;

namespace SMECommerce.Services
{
  public class BrandService:Service<Brands>,IBrandService
    {

        IBrandRepository _brandRepository;

        public BrandService(IBrandRepository  brandRepository):base(brandRepository)
        {
            _brandRepository = brandRepository;
        }
    }
}
