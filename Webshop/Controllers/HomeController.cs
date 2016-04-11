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

        // GET: Home
        public ActionResult Index()
        {
            //Category category = new Category();
            //category.Name = "Fisk";

            //categoryFac.Add(category);

            //Home h = new Home();
            //h.Image = "fisk.jpg";
            //h.Text = "aksjdlakjd";

            //homeFac.Add(h);

            //Category category = new Category();
            //category.ID = 2;
            //category.Name = "Hest";

            //categoryFac.Update(category);

            return View();
        }
    }
}