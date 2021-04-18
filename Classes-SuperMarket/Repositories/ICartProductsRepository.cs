using Classes_SuperMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_SuperMarket.Repositories
{
    public interface ICartProductsRepository
    {
        List<Product> GetAllProducts();
        List<ProductQuantity> GetProductQuantities();

        void AddProductQuantity(ProductQuantity productQuantity);

        void RemoveAllProductQuantities();
    }
}
