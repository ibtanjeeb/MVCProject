using System;
using System.Collections.Generic;
using System.Text;

namespace SmeCommerce.Models.EntityModels
{
    public class CategoryListVM
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public List<Category> CategoryList { get; set; }

    }
}
