using Classes_SuperMarket.Models;
using Classes_SuperMarket.Repositories;
using Classes_SuperMarket.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_SuperMarket.Presenters
{
    public class CartProductsPresenter
    {
        private const string PRODUCT_QUANTITY_ERROR = "This product is already in your cart";

        private readonly ICartProductsView _view;
        private List<Product> _currentProducts;
        private List<ProductQuantity> _currentProductQuantities;

        public CartProductsPresenter(ICartProductsView cartProductsView)
        {
            _view = cartProductsView;
            DisplayProducts();
        }

        private void DisplayProducts()
        {
            _currentProducts = CartProductsRepository.Instance.GetAllProducts();
            _view.DisplayProducts(_currentProducts);
        }
    }
}
