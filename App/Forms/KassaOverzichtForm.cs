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
    private readonly IMoneyCalculator _moneyCalculator;
    private readonly IRevenueService _revenueService;

    public KassaOverzichtForm(IOrderService orderService,
        IProductService productService,
        ICustomerService customerService,
        IMoneyCalculator moneyCalculator,
        IRevenueService revenueService,
        ISessionService sessionService)
    {
        _orderService = orderService;
        _productService = productService;
        _customerService = customerService;
        _moneyCalculator = moneyCalculator;
        _revenueService = revenueService;
        SessionService = sessionService;

        CurrentSession = SessionService.GetCurrentSession();

        InitializeComponent();
        InitializeGeneralInformation();
        ToggleOrderInfo();
    }

    private ISessionService SessionService { get; }
    private Session CurrentSession { get; set; }

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
        cbCustomerName.Items.Add("Open bestellingen:");
        var orders = _orderService.GetUnFinishedAndUnPaidOrders().OrderBy(order => order.Customer.Name);
        foreach (Order order in orders)
        {
            cbCustomerName.Items.Add(order.Customer?.Name);
        }

        cbCustomerName.Items.Add("----------------");
        cbCustomerName.Items.Add("Klanten:");
        var customers = _customerService.GetCustomers().OrderBy(customer => customer.Name);
        foreach (Customer customer in customers)
        {
            cbCustomerName.Items.Add(customer);
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
            item.SubItems.Add($"€ {detail.Price}");
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
                totalPrice += detail.Price;
            }
        }
        else
        {
            totalPrice = _moneyCalculator.PricePerOrder(order);
            totalPrice += order.SplitPrice;
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

        if (_selectedOrder is not null)
        {
            _orderService.AddProductToOrder(_selectedOrder, product);
            ToggleOrderInfo();
            RefreshProductsInOrder();
            return;
        }

        OrderDetail detail = new () { Order = _selectedOrder, Product = product };
        detail.Price = _moneyCalculator.PricePerOrderDetail(detail, CurrentSession.IsEvent);
        var item = new ListViewItem();
        item.Tag = detail;
        item.Text = product.Name;
        item.SubItems.Add($"€ {detail.Price}");
        item.SubItems.Add($"{DateTime.Now.ToShortDateString()} - {DateTime.Now.ToShortTimeString()}");
        lvProducts.Items.Add(item);
        CalculateTotalPrice(null);
    }

    private void ToggleOrderInfo()
    {
        bool toggle = false;
        if (_selectedOrder == null)
        {
            lbName.Text = "";
            lbOrderDate.Text = "";
            lbOrderPrice.Text = "€ 0,00";
        }
        else
        {
            lbName.Text = _selectedOrder.Customer.Name;
            lbOrderDate.Text = $"{_selectedOrder.OrderDate.ToShortDateString()} - {_selectedOrder.OrderDate.ToShortTimeString()}";
            CalculateTotalPrice(_selectedOrder);
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
        Customer customer = _customerService.FindCustomer(customerName);

        if (IsCustomerNameNotValid(customerName))
        {
            _selectedOrder = null;
            RefreshCustomerComboBox();
            return;
        }

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
        // When an order is selected, but it must be unselected.
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
            bool isMember = customer != null ? customer.IsMember : false;
            if (order == null)
            {
                if (customer == null)
                {
                    DialogResult dialogResult = MessageBox.Show($"Is {customerName} een lid van de club?", "Nieuwe klant", MessageBoxButtons.YesNoCancel);
                    if (dialogResult == DialogResult.Cancel)
                    {
                        cbCustomerName.Text = "";
                        return;
                    }
                    else if (dialogResult == DialogResult.Yes)
                    {
                        isMember = true;
                    }
                }

                order = new Order() { Customer = _customerService.FindOrCreateCustomer(customerName) };
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

    private bool IsCustomerNameNotValid(string customerName)
    {
        return customerName.Equals("Open bestellingen:") ||
            customerName.Equals("Klanten:") ||
            customerName.Equals("----------------");

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
        pProducts.Controls.Clear();
        int a = 0;
        int b = 0;
        int factor = 0;
        int j = 1;
        foreach (var product in _productService.GetProducts())
        {
            if (product.IsActive)
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

    private void bestellingOverzichtToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var orderForm = new BestellingOverzichtForm(_orderService, _customerService, _moneyCalculator, _revenueService, SessionService);
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
        if (_selectedOrder.Price > 0.00M)
        {

            var form = new AfrekenForm(_orderService, _moneyCalculator, _revenueService, _selectedOrder);
            form.ShowDialog();
        }
        else
        {
            _orderService.PayOrder(_selectedOrder, 0.00M, PayMethod.None);
        }

        _selectedOrder = null;
        ToggleOrderInfo();
        RefreshProductsInOrder();
        RefreshCustomerComboBox();
    }

    private void TSMICustomers_Click(object sender, EventArgs e)
    {
        var form = new CustomerForm(_customerService);
        form.ShowDialog();

        RefreshCustomerComboBox();
    }

    private void overzichtToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var form = new ProductOverzichtForm(_productService);
        form.ShowDialog();
        InitializeProductButtons();
    }

    private void omzetOverzichtToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var form = new OmzetOverzichtForm(_revenueService);
        form.ShowDialog();
    }

    private void sessieBeheerToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var form = new BeheerderForm();
        form.ShowDialog();
    }
}
