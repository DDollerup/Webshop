using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.Models.BaseModels;
using Webshop.Factories;

namespace Webshop.Areas.WebshopAdmin.Controllers
{
    public class WSAdminController : Controller
    {
        ItemFactory itemFac = new ItemFactory();
        CategoryFactory categoryFac = new CategoryFactory();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Item()
        {
            List<Item> allItems = itemFac.GetAll();
            return View(allItems);
        }

        public ActionResult AddItem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddItemSubmit(Item item)
        {
            // Add Database Function
            return RedirectToAction("Item");
        }

        public ActionResult EditItem(int id)
        {
            ViewBag.Categories = categoryFac.GetAll();
            Item itemToEdit = itemFac.Get(id);
            return View(itemToEdit);
        }

        [HttpPost]
        public ActionResult EditItemSubmit(Item item)
        {
            itemFac.Update(item);
            return RedirectToAction("Item");
        }

        [HttpPost]
        public ActionResult DeleteItemSubmit(int id)
        {
            return RedirectToAction("Item");
        }
    }
}