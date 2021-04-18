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
        private readonly ICartProductsView _view;
        private IEnumerable<Product> _currentProducts;
        private IEnumerable<ProductQuantity> _currentProductQuantities;

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
