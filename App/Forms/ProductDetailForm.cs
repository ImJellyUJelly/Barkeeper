using App.Models;
using App.Services;

namespace App.Forms
{
    public partial class ProductDetailForm : Form
    {
        private readonly IProductService _productService;
        private Product _product;

        public ProductDetailForm(IProductService service, Product product)
        {
            _productService = service;
            _product = product;
            InitializeComponent();
            InitialLoad();
        }

        private void InitialLoad()
        {
            cbCategory.DataSource = Enum.GetValues(typeof(ProductCategory));

            if (_product == null) return;

            tbName.Text = _product.Name;
            nudPrice.Value = _product.Price;
            nudLedenPrice.Value = _product.MemberPrice;
            cbCategory.SelectedItem = _product.Category;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            decimal price = nudPrice.Value;
            decimal memberPrice = nudLedenPrice.Value;
            ProductCategory category = (ProductCategory)cbCategory.SelectedItem;

            if(tbName.Text == "" || tbName.Text == null)
            {
                MessageBox.Show("Vul een geldige naam in.");
            }

            if(nudPrice.Value < 0.00M || nudLedenPrice.Value < 0.00M)
            {
                MessageBox.Show("Vul een prijs en ledenprijs groter dan € 0,00 in.");
            }

            if (_product != null)
            {
                _product.Name = name;
                _product.Price = price;
                _product.MemberPrice = memberPrice;
                _product.Category = category;

                _productService.UpdateProduct(_product);
            }
            else
            {
                _product = new Product()
                {
                    Name = name,
                    Price = price,
                    MemberPrice = memberPrice,
                    Category = category
                };

                _productService.AddProduct(_product);
            }

            Close();
        }
    }
}
