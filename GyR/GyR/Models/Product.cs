using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GyR.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string ScreenResolution { get; set; }
        public string Processor { get; set; }
        public string Memory { get; set; }
        public string ImageUrl { get; set; }
    }
}