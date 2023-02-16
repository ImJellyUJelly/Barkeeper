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
            nudLedenPrice.Value = _product.EventPrice;
            cbCategory.SelectedItem = _product.Category;
            cbActive.Checked = _product.IsActive;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            decimal Price = nudPrice.Value;
            decimal eventPrice = nudLedenPrice.Value;
            ProductCategory category = (ProductCategory)cbCategory.SelectedItem;
            bool isActive = cbActive.Checked;

            if (tbName.Text == "" || tbName.Text == null)
            {
                MessageBox.Show("Vul een geldige naam in.");
                return;
            }

            if (nudPrice.Value < 0.00M || nudLedenPrice.Value < 0.00M)
            {
                MessageBox.Show("Vul een prijs en evenementprijs groter dan € 0,00 in.");
                return;
            }

            if (_product != null)
            {
                DialogResult dialogResult = MessageBox.Show($"Let op: het wijzigen van de prijs heeft invloed op de openstaande bestellingen! " +
                    $"Wilt u doorgaan?", "Product wijzigen", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                _productService.UpdateProduct(_product, name, Price, eventPrice, category, isActive);
            }
            else
            {
                _productService.AddProduct(name, Price, eventPrice, category, isActive);
            }

            Close();
        }
    }
}
