using System;
using System.Collections;
using System.Collections.Generic;

namespace CandyShop_API.Model
{
    public class Image
    {
        public Guid idImg { get; set; }
        public Guid idPro {  get; set; }
        public string path { get; set; }
        public Product product { get; set; }    
    }
}
