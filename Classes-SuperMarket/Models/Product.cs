using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_SuperMarket.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductType ProductType { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            Product product = (Product)obj;
            return this.Name.ToLower() == product.Name.ToLower();
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
