﻿using App.Models;
using App.Services;

namespace App.Forms
{
    public partial class ProductOverzichtForm : Form
    {
        private IProductService _productService;
        private List<Product> _products;

        public ProductOverzichtForm(IProductService productService)
        {
            _productService = productService;
            _products = new();
            InitializeComponent();
            InitialLoad();
        }

        private void InitialLoad()
        {
            _products = _productService.GetProducts();
            UpdateProductsList();
        }

        private void UpdateProductsList()
        {
            foreach (var product in _products)
            {
                var item = new ListViewItem();
                item.Tag = product;
                item.Text = product.Id.ToString();
                item.SubItems.Add(product.Name);
                item.SubItems.Add($"€ {product.Price}");
                item.SubItems.Add($"€ {product.MemberPrice}");
                item.SubItems.Add(product.Category.ToString());
                lvProducts.Items.Add(item);
            }
        }

        private void lvProducts_DoubleClick(object sender, EventArgs e)
        {
            if (lvProducts.SelectedItems.Count <= 0)
            {
                return;
            }

            var product = (Product)lvProducts.SelectedItems[0].Tag;
            var form = new ProductDetailForm(_productService, product);
            form.ShowDialog();

            lvProducts.Items.Clear();
            _products = null;
            InitialLoad();
        }
    }
}
