using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Models.Entity
{
    public class Product :BaseEntity
    {

        public string ImagePath { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Price { get; set; }

        public string Bed { get; set; }
        public string Baths { get; set; }
        public string Sqft { get; set; }
        public string Description { get; set; }
        public string ShopDescription { get; set; }




    }
}
