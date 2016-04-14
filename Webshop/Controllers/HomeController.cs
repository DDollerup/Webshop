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
        public ActionResult Index(int id = 0)
        {
            ViewBag.Categories = categoryFac.GetAll();

            List<Item> allItems = itemFac.GetAll();

            if (id == 0)
            {
                return View(allItems);
            }
            else
            {
                List<Item> filteredItems = new List<Item>();

                foreach (Item item in allItems)
                {
                    if (item.CategoryID == id)
                    {
                        filteredItems.Add(item);
                    }
                }

                return View(filteredItems);
            }
        }

        public ActionResult FilterItems(int id)
        {
            return RedirectToAction("Index", new { id = id });
        }
    }
}