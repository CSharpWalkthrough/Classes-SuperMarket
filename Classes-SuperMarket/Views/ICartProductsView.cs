using Classes_SuperMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_SuperMarket.Views
{
    public interface ICartProductsView
    {
        void DisplayProducts(IEnumerable<Product> products);
        void DisplayCartProduct(ProductQuantity model);
        void DisplayCartTotal(decimal total);
        void ShowErrorMessage(string message);
    }
}
