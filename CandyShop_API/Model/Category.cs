using System.Collections;
using System.Collections.Generic;

namespace CandyShop_API.Model
{
    public class Category
    {
        public int idCate { get; set; }
        public string name { get; set; }

        public ICollection<Product> products { get; set; }
    }
}
