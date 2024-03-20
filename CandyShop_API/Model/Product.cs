using System;
using System.Collections;
using System.Collections.Generic;

namespace CandyShop_API.Model
{
    public class Product
    {
        public Product()
        {
            this.images = new List<Image>();
        }

        public Guid idPro { get; set; }
        public int idCate { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public decimal discount { get; set; } = 0;

        public Category category { get; set; }  
        public ICollection<Image> images { get; set; }
    }
}
