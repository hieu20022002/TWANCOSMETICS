using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWANCOSMETICS.Models
{
    [Serializable]
    public class ProductViewModel
    {
        public int id { get; set; }
        
        public string name { get; set; }
        public string description { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string u_image { get; set; }
        public double price { get; set; }
        public List<int> ListPrice { get; set; }
        public decimal quantity { get; set; }
        public string variant { get; set; }
        public System.DateTime date_created { get; set; }
        public System.DateTime date_updated { get; set; }
        public byte status { get; set; }
        public byte delete_flag { get; set; }
    }
}
