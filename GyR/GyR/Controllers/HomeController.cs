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
            // Aquí deberías obtener los valores de compra y venta desde tu fuente de datos
            decimal buyRate = 600; // Ejemplo de tasa de compra
            decimal sellRate = 605; // Ejemplo de tasa de venta
            string lastUpdated = DateTime.Now.ToString("g"); // Última actualización

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
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public string ImageUrl { get; set; } // URL de la imagen del producto
        }

    }
}