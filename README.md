# Classes-SuperMarket
An add-to-cart simulator to practise classes

## FrmMain

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

