using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmeCommerce.Models.EntityModels;
using SMECommerce.Models;
using SMECommerce.Models.CategoryCreate;
using SMECommerce.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMECommerce.Controllers.API
{
    [Route("api/catergories")]
    [ApiController]
    public class CategoriesController:ControllerBase
    {
        ICategoryService _categoryservice;

        IMapper _mapper;
        public CategoriesController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryservice = categoryService;
            _mapper = mapper;

        }

        [HttpGet]

        public IActionResult GetCategories()
        {
            var categories = _categoryservice.GetAll();
            if(categories==null)
            {
                return NoContent();
            }

            var categoriesResults = _mapper.Map<IList<CategoryResult>>(categories);

            return Ok(categoriesResults);



        }

        [HttpGet("{id}")]
        public IActionResult GetById(int? id)
        {

            if(id==null)
            {
                return BadRequest("Plese Provide Id ");
            }

            var category = _categoryservice.GetById((int)id);

            if(category==null)
            {
                return NotFound();
            }
            var categoryResult = _mapper.Map<CategoryResult>(category);

            return Ok( categoryResult);

        }
        [HttpPost]
        public IActionResult Post([FromBody] CategoryCreateVM model)
        {
            if(ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(model);

                var isSuccess = _categoryservice.Add(category);

                if(isSuccess)
                {
                    return Created($"api/categories{category.CategoryId}", category);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int?id ,[FromBody]CategoryEditVM model)
        {
            if(id==null)
            {
                return BadRequest("Please Provide ID");
            }

            var category = _categoryservice.GetById((int)id);

            if(category==null)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                _mapper.Map(model, category);

                var IsSuccess = _categoryservice.Update(category);

                if(IsSuccess)
                {
                    return Ok(category);
                }
            }
            return BadRequest(ModelState);
            
        }
    }
}
