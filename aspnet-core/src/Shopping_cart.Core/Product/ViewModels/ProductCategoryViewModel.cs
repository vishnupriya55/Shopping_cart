using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_cart.Models
{
    public class ProductCategoryViewModel
    {
        public List<Product> Products { get; set; }
        public SelectList Categories { get; set; }

        public string ProductCategory { get; set; }
        public string SearchString { get; set; }
        public List<Category> CategoriesList { get; set; }

    }
}
