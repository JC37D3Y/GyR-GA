using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GyR.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCurrentRate()
        {
            decimal buyRate = 600;
            decimal sellRate = 605;
            string lastUpdated = DateTime.Now.ToString("g");
            return Json(new
            {
                success = true,
                buyRate = buyRate,
                sellRate = sellRate,
                lastUpdated = lastUpdated
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";
            return View();
        }

        public ActionResult compra()
        {
            return View();
        }

        // Acción para el menú de productos
        public ActionResult Menu()
        {
            var products = GetProducts(); // Obtener lista de productos
            return View(products);
        }

        // Método privado para obtener productos
        private List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Dell Latitude 3440 - Notebook - 14\"",
                    Description = "1920 x 1080 LED\nIntel Core i5 3.3 GHz\n8 GB DDR4 SDRAM",
                    Price = 899.99m,
                    ImageUrl = "~/Content/Images/dell-latitude.jpg"
                },
                new Product
                {
                    Id = 2,
                    Name = "Lenovo ThinkPad E15 - 15.6\"",
                    Description = "1920 x 1080 IPS\nIntel Core i7 4.7 GHz\n16 GB DDR4 RAM",
                    Price = 1099.99m,
                    ImageUrl = "~/Content/Images/lenovo-thinkpad.jpg"
                },
                new Product
                {
                    Id = 3,
                    Name = "MacBook Air M2 - 13.6\"",
                    Description = "2560 x 1664 Retina\nApple M2 Chip\n8 GB RAM Unificada",
                    Price = 1299.99m,
                    ImageUrl = "~/Content/Images/macbook-air.jpg"
                },
                new Product
                {
                    Id = 4,
                    Name = "HP Pavilion 15 - 15.6\"",
                    Description = "1920 x 1080 IPS\nAMD Ryzen 7 5800H\n16 GB DDR4 RAM",
                    Price = 999.99m,
                    ImageUrl = "~/Content/Images/hp-pavilion.jpg"
                },
                new Product
                {
                    Id = 5,
                    Name = "ASUS ROG Zephyrus - 14\"",
                    Description = "2560 x 1440 IPS\nAMD Ryzen 9 6900HS\n32 GB DDR5 RAM",
                    Price = 1499.99m,
                    ImageUrl = "~/Content/Images/asus-rog.jpg"
                },
                new Product
                {
                    Id = 6,
                    Name = "Acer Swift 5 - 14\"",
                    Description = "1920 x 1080 Touch\nIntel Core i7 1165G7\n16 GB LPDDR4X",
                    Price = 1199.99m,
                    ImageUrl = "~/Content/Images/acer-swift.jpg"
                }
            };
        }

        // Clase Product dentro del mismo namespace
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public string ImageUrl { get; set; }
        }
    }
}