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
        private const string PRODUCT_EXISTS_ERROR = "This product is already in your cart";

        private readonly ICartProductsView _view;

        public CartProductsPresenter(ICartProductsView cartProductsView)
        {
            _view = cartProductsView;
            DisplayProducts();
        }

        private void DisplayProducts()
        {
            List<Product>  currentProducts = CartProductsRepository.Instance.GetAllProducts();
            _view.DisplayProducts(currentProducts);
        }

        public void AddCartProductClicked(string productName, int quantity)
        {

            Product product = CartProductsRepository.Instance.GetProductByName(productName);

            if (CartProductsRepository.Instance.IsProductInCart(product))
            {
                _view.ShowErrorMessage(PRODUCT_EXISTS_ERROR);
                return;
            }

            ProductQuantity model = new ProductQuantity(product, quantity);
            CartProductsRepository.Instance.AddProductQuantity(model);
            _view.DisplayCartProduct(model);

            decimal total = CartProductsRepository.Instance.GetCartTotal();
            _view.DisplayCartTotal(total);
        }

        public void EmptyCart()
        {
            CartProductsRepository.Instance.RemoveAllProductQuantities();
            _view.DisplayCartTotal(0.00M);
        }
    }
}
