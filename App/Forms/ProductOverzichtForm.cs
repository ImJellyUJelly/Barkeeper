using App.Models;
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
            lvProducts.Items.Clear();
            foreach (var product in _products)
            {
                var item = new ListViewItem();
                item.Tag = product;
                item.Text = product.Id.ToString();
                item.SubItems.Add(product.Name);
                item.SubItems.Add($"€ {product.Price}");
                item.SubItems.Add($"€ {product.EventPrice}");
                item.SubItems.Add(product.Category.ToString());
                item.SubItems.Add(product.IsActive ? "Ja" : "Nee");
                lvProducts.Items.Add(item);
            }
        }

        private void lvProducts_DoubleClick(object sender, EventArgs e)
        {
            if (lvProducts.SelectedItems.Count <= 0)
            {
                return;
            }

            OpenProductDetailsForm(false);
        }

        private void btNewProduct_Click(object sender, EventArgs e)
        {
            OpenProductDetailsForm(true);
        }

        private void OpenProductDetailsForm(bool newProduct)
        {
            ProductDetailForm form;
            if (newProduct)
            {
                form = new ProductDetailForm(_productService, null);
            }
            else
            {
                var product = (Product)lvProducts.SelectedItems[0].Tag;
                form = new ProductDetailForm(_productService, product);
            }

            form.ShowDialog();

            _products = null;
            InitialLoad();
        }
    }
}
