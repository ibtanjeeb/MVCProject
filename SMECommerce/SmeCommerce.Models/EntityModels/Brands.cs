using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmeCommerce.Models.EntityModels
{
    public class Brands
    {
        [Key]
        public int BrandId { get; set; }

        public string BrandName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Items> Items { get; set; }


    }
}
