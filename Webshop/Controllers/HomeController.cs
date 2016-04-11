using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.Factories;
using Webshop.Models.BaseModels;

namespace Webshop.Controllers
{
    public class HomeController : Controller
    {
        HomeFactory homeFac = new HomeFactory();
        CategoryFactory categoryFac = new CategoryFactory();
        ItemFactory itemFac = new ItemFactory();

        // GET: Home
        public ActionResult Index()
        {
            List<Item> allItems = itemFac.GetAll();
            return View(allItems);
        }
    }
}