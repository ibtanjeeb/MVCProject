using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmeCommerce.Models.EntityModels
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }


        public string CategoryName { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }
        public ICollection<Items>Items { get; set; }
    }
}
