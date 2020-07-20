using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Products.Models;

namespace Products.Controllers
{
    public class CartsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Carts
        public ActionResult Index()
        {
           
            return View();
        }

        
        // Check if the product id is already existing in the cart or not!
        public int isExisting(int id)
        {
            List<Cart> cart = (List<Cart>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)

                if (cart[i].productId == id)
                    //so it's exist!
                    return i;
                // it's not exist
                return -1;
            
        }
       
        //Add To Cart Method
        public ActionResult AddToCart(int id)
        {
            Cart cart = new Cart();
            Product product = db.Products.Find(id);
            if (Session["cart"] == null) //check if the cart is exist or not
            {
                List<Cart> shopCart = new List<Cart>(); //we make a cart here
                shopCart.Add(cart);
                Session["cart"] = shopCart;
            }
            else
            { 
                //if the cart already exist
                List<Cart> shopCart = (List<Cart>)Session["cart"];
                int Check_Id = isExisting(id); //check is the product id is already exist on the cart or not
                if (Check_Id == -1) //it's not exist
                {
                    
                    shopCart.Add(cart);
                    Session["cart"] = shopCart;

                }
                else
                {
                    //it's exist
                    Session["cart"] = shopCart;
                }


            }
            //save cart items data to the database
            List<Cart> shopCartCheck = (List<Cart>)Session["cart"];
            foreach (var c in shopCartCheck)
            {
                if (c.productId == product.id)
                {
                    return Redirect("../../Home/index");
                }
            }
            

                cart.productId = db.Products.Find(id).id;
                cart.added_at = DateTime.Now;
                db.Carts.Add(cart);
                db.SaveChanges();
            
            return Redirect("../../Home/index");
        }

        // Delete item from cart
        public ActionResult deleteCartItem(int id)
        {
            int checkId = isExisting(id);
            Cart itemCart = db.Carts.Find(id); // to find it and  delete from database
            List<Cart> cart = (List<Cart>)Session["cart"]; //to delete it from the cart view
            db.Carts.Remove(itemCart);
            cart.RemoveAt(checkId);
            Session["cart"] = cart;
            db.SaveChanges();
            return Redirect("../../Home/index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
