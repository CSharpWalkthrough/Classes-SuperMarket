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

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }
    }
}
