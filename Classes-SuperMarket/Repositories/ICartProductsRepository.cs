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
        Product GetProductByName(string productName);

        void AddProductQuantity(ProductQuantity productQuantity);
        void RemoveAllProductQuantities();

        bool IsProductInCart(Product product);
        decimal GetCartTotal();
    }
}
