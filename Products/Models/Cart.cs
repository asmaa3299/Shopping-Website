using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Products.Models
{
    public class Cart
    {
        public Cart()
        {

        }
        public Cart(Product product)
        {
            this.product = product;
        }

        

        [Key , ForeignKey("product")]
        public int productId { get; set; }
        public System.DateTime added_at { get; set; }
        public virtual Product product { get; set; }
    }
}