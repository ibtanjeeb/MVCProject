using System;
using System.Collections.Generic;
using System.Text;

namespace MyMVC.Models.ViewModels
{
    public class SeasonVM
    {
        public IEnumerable<Season> Seasons { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
