using Microsoft.AspNetCore.Mvc;
using SMECommerce.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMECommerce.Controllers
{
    public class ProductController : Controller
    {
        ICategoryService _categoryService;
        IProductService _productService;

        public ProductController(ICategoryService categoryService,IProductService productService)
        {
            _categoryService = categoryService;

            _productService = productService;

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
