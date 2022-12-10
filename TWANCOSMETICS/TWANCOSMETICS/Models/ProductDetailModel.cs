using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWANCOSMETICS.Models
{
    public class ProductDetailModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string u_image { get; set; }
        public byte status { get; set; }
        public int amount { get; set; }
        public Dictionary<string, double> Unit { get; set; }
        
    }
}