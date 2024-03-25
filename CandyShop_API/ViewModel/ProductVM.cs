using System;

namespace CandyShop_API.ViewModel
{
    public class ProductVM
    {
        public Guid idPro { get; set; }
        public int idCate { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public decimal discount { get; set; } = 0;
    }
}
