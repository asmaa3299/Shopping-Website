using Products.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Products.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Index(string search)
        {
            if (search != null)
            {
                ViewBag.values = db.Categories.ToList();
                ViewBag.type = search;
                if (search == "All Categories")
                {
                    return View(db.Products.ToList());
                }
                else
                {
                    var products = db.Products.Where(a => a.category.name.Contains(search));
                    return View(products);

                }

            }
            ViewBag.type = "All Categories";
            ViewBag.values = db.Categories.ToList();
            return View(db.Products.ToList());

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        

    }
}