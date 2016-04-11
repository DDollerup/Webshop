using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop.Models.BaseModels
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CateogoryID { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public bool OnSale { get; set; }
        public string SalePrice { get; set; }
        public string Image { get; set; }
    }
}