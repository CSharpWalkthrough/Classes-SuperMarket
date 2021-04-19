# Classes-SuperMarket
An add-to-cart simulator to practise classes

## Models
* All properties are public and have getters and setters unless specified.

### ProductType (enum)

| Values    |
|-----------|
| Fruit     |
| Dairy     |
| Snack     |
| Vegetable |

### Product (class)

| Properties              |
|-------------------------|
| string Name             |
| decimal Price           |
| ProductType ProductType |

### ProductQuantity (class) (also referred to as CartProduct)

| Constructor                      |
|----------------------------------|
| public ProductQuantity(Product product, int quantity) |

| Properties                       |
|----------------------------------|
| Product Product                  |
| int Quantity                     |
| decimal TotalPrice (getter only) |

## Repositories

### CartProductsRepository

| Access modifier | Fields                                   |
|-----------------|------------------------------------------|
| private         | List<Product> _products                  |
| private         | List<ProductQuantity> _productQuantities |
| private         | CartProductsRepository _instance         |

| Access modifier | Properties                                                           |
|-----------------|----------------------------------------------------------------------|
| public static   | Returns the Repository (Initializes it if not already) (getter only) |

| Constructor                     | Description                                     |
|---------------------------------|-------------------------------------------------|
| public CartProductsRepository() | Initializes fields and calls InitializeProducts |

```csharp
  private void InitializeProducts()
  {
      _products.Add(new Product { Name = "Potato", Price = 2.50M, ProductType = ProductType.Vegetable });
      _products.Add(new Product { Name = "Chips", Price = 3.75M, ProductType = ProductType.Snack });
      _products.Add(new Product { Name = "Milk", Price = 6.25M, ProductType = ProductType.Dairy });
      _products.Add(new Product { Name = "Yogurt", Price = 1.00M, ProductType = ProductType.Dairy });
      _products.Add(new Product { Name = "Apple", Price = 0.99M, ProductType = ProductType.Fruit });
      _products.Add(new Product { Name = "Cookies", Price = 5.50M, ProductType = ProductType.Snack });
      _products.Add(new Product { Name = "Carrot", Price = 1.75M, ProductType = ProductType.Vegetable });
      _products.Add(new Product { Name = "Banana", Price = 2.50M, ProductType = ProductType.Fruit });
      _products.Add(new Product { Name = "Cheese", Price = 8.45M, ProductType = ProductType.Dairy });
      _products.Add(new Product { Name = "Lettuce", Price = 1.00M, ProductType = ProductType.Vegetable });
  }
```

| Access modifier | Methods                                                  |
|-----------------|----------------------------------------------------------|
| public          | List<Product> GetAllProducts()                           |
| public          | Product GetProductByName(string productName)             |
| public          | void AddProductQuantity(ProductQuantity productQuantity) |
| public          | void RemoveAllProductQuantities()                        |
| public          | bool IsProductInCart(Product product)                    |
| public          | decimal GetCartTotal()                                   |

## Views

### FrmMain

| Access modifiers   | Fields/Constructors/Events/Methods                                           | Description                                                                                           |
|--------------------|------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------|
| private readonly   | CartProductsPresenter                                                        | An instance of the presenter                                                                          |
| public constructor | FrmMain()                                                                    | Initializes the presenter                                                                             |
| private event      | void btnAdd_Click(object sender, EventArgs e)                                | Adds a new cart product. Calls Presenter.AddCartProductClicked                                        |
| private event      | void btnClear_Click(object sender, EventArgs e)                              | Clears the cart. Calls Presenter.ClearCartClicked()                                                   |
| private event      | void lvwProducts_SelectedIndexChanged(object sender, EventArgs e)            | Updates the UI accordingly by calling either ResetNewCartProductUI() or EnableNewCartProductUI()      |
| public             | void DisplayProducts(List<Product> products)                                 | Displays the products on the ListView lvwProducts. CreateListViewItem()                               |
| public             | void DisplayCartProduct(ProductQuantity model)                               | Adds a new row on the ListView lvwCartProduct. Calls CreateListViewItem() and ResetNewCartProductUI() |
| public             | void DisplayCartTotal(decimal total)                                         | Displays the new total (i.e.: $100.00)                                                                |
| public             | void ShowErrorMessage(string message)                                        | Displays an error message by calling MessageBox.Show(). Calls ResetNewCartProductUI()                 |
| private            | void ResetNewCartProductUI()                                                 | Disables the option to add a cart product (see demo)                                                  |
| private            | EnableNewCartProductUI()                                                     | Enables the option to add a cart product (see demo)                                                   |
| private            | ListViewItem CreateListViewItem(string firstColumn, params string[] columns) | Creates and returns a new ListViewItem with the data passed in the parameters                         |

