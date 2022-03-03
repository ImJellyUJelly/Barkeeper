using App.Services;
using App.Models;
using System.Globalization;

namespace App.Forms;

public partial class KassaOverzichtForm : Form
{
    private CultureInfo _cultureInfo;
    private Order? _selectedOrder;

    private readonly IOrderService _orderService;
    private readonly IProductService _productService;
    private readonly ICustomerService _customerService;

    public KassaOverzichtForm(IOrderService orderService, 
        IProductService productService, 
        ICustomerService customerService)
    {
        _orderService = orderService;
        _productService = productService;
        _customerService = customerService;

        InitializeComponent();
        InitializeGeneralInformation();
        ToggleOrderInfo();
    }

    private void InitializeGeneralInformation()
    {
        _cultureInfo = CultureInfo.GetCultureInfo("nl-NL");
        lbDate.Text = $"{_cultureInfo.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek)} {DateTime.Now.ToString("dd/MM/yyyy")}";
        _selectedOrder = null;
        btDeleteProduct.Visible = false;
        btPay.Enabled = false;

        RefreshCustomerComboBox();
        InitializeProductButtons();
    }

    private void RefreshCustomerComboBox()
    {
        cbCustomerName.Items.Clear();
        foreach (Order order in _orderService.GetUnFinishedAndUnPaidOrders())
        {
            cbCustomerName.Items.Add(order.Customer.Name);
        }

        cbCustomerName.Text = "";
    }

    private void RefreshProductsInOrder()
    {
        lvProducts.Items.Clear();
        if (_selectedOrder == null)
        {
            return;
        }

        foreach (OrderDetail detail in _selectedOrder.OrderDetails)
        {
            var item = new ListViewItem();
            item.Tag = detail;
            item.Text = detail.Product.Name;
            if (_selectedOrder.IsMember)
            {
                item.SubItems.Add($"€ {detail.Product.MemberPrice}");
            }
            else
            {
                item.SubItems.Add($"€ {detail.Product.Price}");
            }

            item.SubItems.Add($"{detail.TimeAdded.ToShortTimeString()} - {detail.TimeAdded.ToShortDateString()}");
            lvProducts.Items.Add(item);
        }

        CalculateTotalPrice(_selectedOrder);
    }

    private void CalculateTotalPrice(Order? order)
    {
        decimal totalPrice = 0.00M;
        if (order == null)
        {
            foreach (ListViewItem item in lvProducts.Items)
            {
                OrderDetail detail = (OrderDetail)item.Tag;
                totalPrice += detail.Product.Price;
            }
        }
        else
        {
            totalPrice = _orderService.CalculateOrderPrice(order);
        }

        lbOrderPrice.Text = $"€ {totalPrice}";
    }

    private void AddProductToOrder(Product product)
    {
        if (product == null)
        {
            MessageBox.Show("Product is niet gevonden.");
            return;
        }

        if (_selectedOrder == null)
        {
            OrderDetail detail = new OrderDetail() { Product = product };
            var item = new ListViewItem();
            item.Tag = detail;
            item.Text = product.Name;
            item.SubItems.Add($"€ {product.Price}");
            item.SubItems.Add($"{DateTime.Now.ToShortDateString()} - {DateTime.Now.ToShortTimeString()}");
            lvProducts.Items.Add(item);
            CalculateTotalPrice(null);
            return;
        }
        else
        {
            _orderService.AddProductToOrder(_selectedOrder, product);
        }

        ToggleOrderInfo();
        RefreshProductsInOrder();
    }

    private void ToggleOrderInfo()
    {
        bool toggle = false;
        if (_selectedOrder == null)
        {
            lbName.Text = "";
            lbOrderDate.Text = "";
            lbOrderPrice.Text = "€ 0,00";
            cbIsMember.Checked = false;
            cbIsMember.Enabled = false;
        }
        else
        {
            lbName.Text = _selectedOrder.Customer.Name;
            lbOrderDate.Text = $"{_selectedOrder.OrderDate.ToShortDateString()} - {_selectedOrder.OrderDate.ToShortTimeString()}";
            CalculateTotalPrice(_selectedOrder);
            cbIsMember.Checked = _selectedOrder.IsMember;
            cbIsMember.Enabled = true;
            toggle = true;
        }

        btPay.Enabled = toggle;
    }

    private void btDeleteProduct_Click(object sender, EventArgs e)
    {
        OrderDetail detail = (OrderDetail)lvProducts.SelectedItems[0].Tag;
        if (detail == null) { return; }

        if (_selectedOrder == null)
        {
            lvProducts.Items.Remove(lvProducts.SelectedItems[0]);
            return;
        }

        _orderService.DeleteProductFromOrder(_selectedOrder, detail);
        RefreshProductsInOrder();
    }

    private void btSelectCustomer_Click(object sender, EventArgs e)
    {
        string customerName = cbCustomerName.Text.Trim();
        if (customerName == "" && _selectedOrder == null)
        {
            if (lvProducts.Items.Count > 0)
            {
                MessageBox.Show("Voer een geldige naam in.");
                return;
            }
            else
            {
                RefreshProductsInOrder();
                ToggleOrderInfo();
                return;
            }
        }
        else if (customerName == "" && _selectedOrder != null)
        {
            _selectedOrder = null;
            RefreshProductsInOrder();
            ToggleOrderInfo();
            return;
        }
        else if (customerName != "" && _selectedOrder == null)
        {
            Order order = _orderService.GetOrderByCustomerName(customerName);
            if (order == null)
            {

                order = new Order() { Customer = _customerService.FindOrCreateCustomer(customerName) };
                DialogResult dialogResult = MessageBox.Show($"Is {customerName} een lid van de club?", "Nieuwe klant", MessageBoxButtons.YesNoCancel);

                if (dialogResult == DialogResult.Cancel)
                {
                    cbCustomerName.Text = "";
                    return;
                }
                else if (dialogResult == DialogResult.Yes)
                {
                    order.IsMember = true;
                }

                foreach (ListViewItem item in lvProducts.Items)
                {
                    var detail = (OrderDetail)item.Tag;
                    detail.Order = order;
                    detail.TimeAdded = DateTime.Now;
                    order.OrderDetails.Add(detail);
                }

                _orderService.CreateOrder(order);
                _selectedOrder = order;
            }
            else
            {
                _selectedOrder = order;
                foreach (ListViewItem item in lvProducts.Items)
                {
                    var detail = (OrderDetail)item.Tag;
                    _orderService.AddProductToOrder(_selectedOrder, detail.Product);
                }
            }
        }
        else if (customerName != "" && _selectedOrder != null)
        {
            Order order = _orderService.GetOrderByCustomerName(customerName);
            _selectedOrder = order;
        }

        RefreshCustomerComboBox();
        RefreshProductsInOrder();
        ToggleOrderInfo();
    }

    private void lvProducts_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lvProducts.SelectedItems.Count <= 0)
        {
            btDeleteProduct.Visible = false;
            return;
        }

        OrderDetail detail = (OrderDetail)lvProducts.SelectedItems[0].Tag;
        btDeleteProduct.Visible = true;
    }

    private void InitializeProductButtons()
    {
        int a = 0;
        int b = 0;
        int factor = 0;
        int j = 1;
        foreach (var product in _productService.GetProducts())
        {
            Button button = new Button();
            button.Top = 10;
            button.Left = 10;
            //button.Size = new Size(116, 85);
            button.Size = new Size(85, 85);
            button.Text = product.Name;
            button.Tag = product;
            button.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            button.BackColor = ButtonBackColor(product);
            button.Click += new EventHandler(ProductClick);

            int buttonWidth = factor * button.Size.Width;

            if (buttonWidth + button.Size.Width >= pProducts.Width)
            {
                a = 0;
                b = button.Size.Height * j;
                j++;
                factor = 0;
            }
            else
            {
                a = buttonWidth;
                factor++;
            }

            button.Location = new Point(a, b);
            pProducts.Controls.Add(button);
        }
    }

    private Color ButtonBackColor(Product product)
    {
        switch (product.Category)
        {
            case ProductCategory.Warme_Dranken:
                return Color.LightSalmon;
            case ProductCategory.Frisdranken:
                return Color.LightGreen;
            case ProductCategory.Bieren:
                return Color.LightBlue;
            case ProductCategory.Wijnen:
                return Color.LightPink;
            case ProductCategory.Gedestilleerd:
                return Color.LightSlateGray;
            case ProductCategory.Specials:
                return Color.LightYellow;
            case ProductCategory.Snacks:
                return Color.LightCyan;
            case ProductCategory.Broodjes:
                return Color.LightSkyBlue;
            case ProductCategory.Chips:
                return Color.LightCoral;
            case ProductCategory.Snoep:
                return Color.LightGoldenrodYellow;
            default:
                return Color.Gray;
        }
    }

    private void ProductClick(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        Product product = (Product)button.Tag;
        if (product == null) { return; }

        AddProductToOrder(product);
    }

    private void cbIsMember_Click(object sender, EventArgs e)
    {
        bool isMember = cbIsMember.Checked;
        if (_selectedOrder == null) { return; }

        _selectedOrder.IsMember = isMember;
        _orderService.UpdateOrder(_selectedOrder);
        RefreshProductsInOrder();
    }

    private void bestellingOverzichtToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var orderForm = new BestellingOverzichtForm(_orderService, _customerService);
        orderForm.ShowDialog();

        _selectedOrder = null;
        ToggleOrderInfo();
        RefreshProductsInOrder();
        RefreshCustomerComboBox();
    }

    private void cbCustomerName_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            btSelectCustomer.PerformClick();
        }
    }

    private void btPay_Click(object sender, EventArgs e)
    {
        if (_selectedOrder == null)
        {
            return;
        }

        var form = new AfrekenForm(_orderService, _selectedOrder);
        form.ShowDialog();

        _selectedOrder = null;
        ToggleOrderInfo();
        RefreshProductsInOrder();
        RefreshCustomerComboBox();
    }
}
