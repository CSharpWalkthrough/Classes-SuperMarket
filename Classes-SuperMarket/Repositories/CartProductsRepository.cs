using Classes_SuperMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_SuperMarket.Repositories
{
    public class CartProductsRepository : ICartProductsRepository
    {
        private const string PRODUCT_QUANTITY_ERROR = "This product is already in your cart";

        private readonly List<Product> _products;
        private readonly List<ProductQuantity> _productQuantities;
        private static CartProductsRepository _instance;

        public static CartProductsRepository Instance 
        {
            get
            {
                if (_instance != null)
                    _instance = new CartProductsRepository();

                return _instance;
            }
        }

        public CartProductsRepository()
        {
            _products = new List<Product>();
            _productQuantities = new List<ProductQuantity>();

            InitializeProducts();
        }

        public void InitializeProducts()
        {
            _products.Add(new Product { Name = "Potato", Price = 2.50M, ProductType = ProductType.VEGETABLE });
            _products.Add(new Product { Name = "Chips", Price = 3.75M, ProductType = ProductType.SNACK });
            _products.Add(new Product { Name = "Milk", Price = 6.25M, ProductType = ProductType.DAIRY });
            _products.Add(new Product { Name = "Yogurt", Price = 1.00M, ProductType = ProductType.DAIRY });
            _products.Add(new Product { Name = "Apple", Price = 0.99M, ProductType = ProductType.FRUIT });
            _products.Add(new Product { Name = "Cookies", Price = 5.50M, ProductType = ProductType.SNACK });
            _products.Add(new Product { Name = "Carrot", Price = 1.75M, ProductType = ProductType.VEGETABLE });
            _products.Add(new Product { Name = "Banana", Price = 2.50M, ProductType = ProductType.FRUIT });
            _products.Add(new Product { Name = "Cheese", Price = 8.45M, ProductType = ProductType.DAIRY });
            _products.Add(new Product { Name = "Lettuce", Price = 1.00M, ProductType = ProductType.VEGETABLE });
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public List<ProductQuantity> GetProductQuantities()
        {
            return _productQuantities;
        } 

        public void AddProductQuantity(ProductQuantity productQuantity)
        {
            //In presenter
            //int index = _productQuantities.FindIndex(pq => pq.Product.Equals(productQuantity));
            //if (index != -1)
            //    throw new ArgumentException(PRODUCT_QUANTITY_ERROR);

            _productQuantities.Add(productQuantity);
        }

        public void RemoveAllProductQuantities()
        {
            _productQuantities.Clear();
        }
    }
}
