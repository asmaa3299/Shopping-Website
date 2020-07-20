using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Products.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public float price { get; set; }
        public int categoryId { get; set; }
        public virtual Category category { get; set; }
        public virtual Cart cart { get; set; }
    }
}