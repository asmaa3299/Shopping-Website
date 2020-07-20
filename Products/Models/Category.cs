using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Products.Models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public int num_of_products { get; set; }
        public ICollection<Product> products { get; set; }
    }
}