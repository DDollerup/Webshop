using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.Models.BaseModels;
using Webshop.Factories;

namespace Webshop.Controllers
{
    public class BaseController : Controller
    {

        public ActionResult Search(string searchQuery)
        {
            ItemFactory itemFac = new ItemFactory();
            List<Item> allItems = itemFac.GetAll();

            List<Item> searchResult = new List<Item>();

            foreach (Item item in allItems)
            {
                if (item.Name.Contains(searchQuery))
                {
                    searchResult.Add(item);
                }
            }

            if (searchResult.Count <= 0)
            {
                ViewBag.MSG = "Did not find any search results";
                return View(searchResult);
            }
            else
            {
                return View(searchResult);
            }
        }

        [HttpPost]
        public ActionResult SearchSubmit(string searchQuery)
        {
            return RedirectToAction("Search", new { searchQuery = searchQuery });
        }
    }
}