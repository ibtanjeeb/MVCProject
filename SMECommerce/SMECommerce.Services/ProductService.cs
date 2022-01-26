using SmeCommerce.Models.EntityModels;
using SMECommerce.Services.Abstraction;
using SMECommerce.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMECommerce.Services
{
    public class ProductService : Service<Items>, IProductService
    {
        IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;

        }
    }
       
}
