using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmeCommerce.Models.EntityModels;
using SMECommerce.Models;
using SMECommerce.Models.CategoryCreate;
using SMECommerce.Services;
using SMECommerce.Services.Abstraction;
using SMECommerceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMECommerce.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;


        IMapper _mapper;
        public CategoryController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;

            _mapper = mapper;
        }
        public string Index()
        {
            return "This Is default Action";

        }
        public IActionResult Create()
        {
            
            return View();

        }
        [HttpPost]
        public IActionResult Create(CategoryCreateVM model)
        {
           


            if (model.CategoryName != null)
            {
                //var category = new Category()
                //{
                //    CategoryName = model.Name,
                //    Description = model.Description,
                //    Code = model.Code

                //};
                var category = _mapper.Map<Category>(model);


                var IsAdded = _categoryService.Add(category);
                if(IsAdded)
                {
                    return RedirectToAction("List");
                }

                
            }
            return View();
        }


        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("List");
            }

            var category = _categoryService.GetById((int) id);

            if(category==null)
            {
                return RedirectToAction("List");


            }

            var categoryeditvm = new CategoryEditVM()
            {
                Id = category.CategoryId,
                Name = category.CategoryName,
                Code = category.CategoryName,
                Description = category.Description

            };
            return View(categoryeditvm);

        }
        [HttpPost]
        public IActionResult Edit(CategoryEditVM Model)
        {
            if(ModelState.IsValid)
            {
                //var category = new Category()
                //{
                //    CategoryId = Model.Id,
                //    CategoryName = Model.Name,
                //    Code = Model.Code,
                //    Description = Model.Description
                //};

                var category = _mapper.Map<Category>(Model);

                bool isUpdate = _categoryService.Update(category);

                if(isUpdate)
                {
                    return RedirectToAction("List");
                }
            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if(id==null)
            {
                return RedirectToAction("List");
            }

            var category = _categoryService.GetById((int)id);

            if(category==null)
            {
                return RedirectToAction("List");
            }
           bool IsRemove= _categoryService.Remove(category);

            if(IsRemove)
            {
                return RedirectToAction("List");
            }

            return RedirectToAction("List");

        }

        public IActionResult List()
        {
            var categoryList = _categoryService.GetAll();

            var CategorylistVm = new CategoryListVM()
            {
                Title = "Category Overview",
                Description = "You can Manage the categories from this page ,You can create,update and delete ",
                CategoryList = categoryList.ToList()

        };
            return View(CategorylistVm);
        }

        public string CategoryListCreate(CategoryCreateVM[] categories)
        {
            string data = "Category List Create" + Environment.NewLine;
            if(categories!=null && categories.Any())
            {
                foreach(var category in categories)
                {
                    data += $"Create Category:{category.CategoryName} code:{category.Code}" + Environment.NewLine;
                }
            }
            return data;
        }
    }
}
