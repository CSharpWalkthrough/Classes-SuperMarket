using Classes_SuperMarket.Models;
using Classes_SuperMarket.Presenters;
using Classes_SuperMarket.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Classes_SuperMarket
{
    public partial class FrmMain : Form, ICartProductsView
    {
        private readonly CartProductsPresenter _presenter;
        public FrmMain()
        {
            InitializeComponent();
            _presenter = new CartProductsPresenter(this);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string productName = txtProductName.Text;
            int quantity = (int)nudQuantity.Value;

            _presenter.AddCartProductClicked(productName, quantity);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _presenter.EmptyCart();
            lvwCartProduct.Items.Clear();
        }

        private void lvwProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwProducts.SelectedItems.Count < 1)
                ResetNewCartProductUI();
            else
                EnableNewCartProductUI();
        }

        public void DisplayProducts(IEnumerable<Product> products)
        {
            lvwProducts.Items.Clear();

            foreach (Product product in products)
            {
                ListViewItem lvi = new ListViewItem(product.Name);
                lvi.SubItems.Add(product.ProductType.ToString());
                lvi.SubItems.Add(product.Price.ToString());

                lvwProducts.Items.Add(lvi);
            }
        }

        public void DisplayCartProduct(ProductQuantity model)
        {
            string productName = model.Product.Name;
            string unitPrice = model.Product.Price.ToString();
            string quantity = model.Quantity.ToString();
            string totalPrice = model.TotalPrice.ToString();

            ListViewItem lvi = CreateListViewItem(productName, unitPrice, quantity, totalPrice);
            lvwCartProduct.Items.Add(lvi);

            ResetNewCartProductUI();
        }

        public void DisplayCartTotal(decimal total)
        {
            txtCartTotal.Text = $"${total}";
        }

        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            ResetNewCartProductUI();
        }

        private void ResetNewCartProductUI()
        {
            btnAdd.Enabled = false;
            txtProductName.Text = string.Empty;
            nudQuantity.Value = 1;
            lvwProducts.SelectedItems.Clear();
        }

        private void EnableNewCartProductUI()
        {
            btnAdd.Enabled = true;
            txtProductName.Text = lvwProducts.SelectedItems[0].Text;
        }

        private ListViewItem CreateListViewItem(string firstColumn, params string[] columns)
        {
            ListViewItem lvi = new ListViewItem(firstColumn);
            foreach (string col in columns)
                lvi.SubItems.Add(col);
            return lvi;
        }
    }
}
