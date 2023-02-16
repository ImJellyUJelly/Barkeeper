using App.Services;
using App.Models;
using System.Globalization;

namespace App.Forms;

public partial class KassaOverzichtForm : Form
{
    private CultureInfo _cultureInfo;
    private int _productButtonSize = 85;

    public KassaOverzichtForm(IOrderService orderService,
        IProductService productService,
        ICustomerService customerService,
        IMoneyCalculator moneyCalculator,
        IRevenueService revenueService,
        ISessionService sessionService,
        IServiceProvider serviceProvider,
        IGeneralOptionsService generalOptionsService)
    {
        ServiceProvider = serviceProvider;
        OrderService = orderService;
        ProductService = productService;
        CustomerService = customerService;
        MoneyCalculator = moneyCalculator;
        RevenueService = revenueService;
        _cultureInfo = CultureInfo.GetCultureInfo("nl-NL");
        SessionService = sessionService;
        GeneralOptionsService = generalOptionsService;

        InitializeComponent();
        InitializeGeneralInformation();
        ToggleOrderInfo();
    }

    private IServiceProvider ServiceProvider { get; }
    private IOrderService OrderService { get; }
    private IProductService ProductService { get; }
    private ICustomerService CustomerService { get; }
    private IMoneyCalculator MoneyCalculator { get; }
    private IRevenueService RevenueService { get; }
    private ISessionService SessionService { get; }
    private IGeneralOptionsService GeneralOptionsService { get; }

    private Order? SelectedOrder { get; set; }
    private bool IsEvent { get; set; }

    private void InitializeGeneralInformation()
    {
        lbDate.Text = $"{_cultureInfo.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek)} {DateTime.Now:dd/MM/yyyy}";
        SelectedOrder = null;
        btDeleteProduct.Visible = false;
        btPay.Enabled = false;

        IsEvent = SessionService.GetCurrentSession() is not null ? true : false;

        ProductService.CoinsMustBePresent();

        RefreshCustomerComboBox();
        InitializeProductButtons();
    }

    private void RefreshCustomerComboBox()
    {
        cbCustomerName.Items.Clear();
        cbCustomerName.Items.Add("Open bestellingen:");
        var orders = OrderService.GetUnFinishedAndUnPaidOrders().OrderBy(order => order.GetName());
        foreach (Order order in orders)
        {
            cbCustomerName.Items.Add(order.GetName());
        }

        cbCustomerName.Items.Add("----------------");
        cbCustomerName.Items.Add("Klanten:");
        var customers = CustomerService.GetCustomers().OrderBy(customer => customer.Name);
        foreach (Customer customer in customers)
        {
            cbCustomerName.Items.Add(customer);
        }

        cbCustomerName.Text = "";
    }

    private void RefreshProductsInOrder()
    {
        lvProducts.Items.Clear();
        if (SelectedOrder == null)
        {
            return;
        }

        foreach (OrderDetail detail in SelectedOrder.OrderDetails)
        {
            var item = new ListViewItem();
            item.Tag = detail;
            item.Text = detail.Product.Name;
            item.SubItems.Add($"€ {detail.Price}");
            item.SubItems.Add($"{detail.TimeAdded.ToShortTimeString()} - {detail.TimeAdded.ToShortDateString()}");
            lvProducts.Items.Add(item);
        }

        CalculateTotalPrice(SelectedOrder);
    }

    private void CalculateTotalPrice(Order? order)
    {
        decimal totalPrice = 0.00M;
        if (order is null)
        {
            foreach (ListViewItem item in lvProducts.Items)
            {
                OrderDetail detail = (OrderDetail)item.Tag;
                totalPrice += detail.Price;
            }
        }
        else
        {
            totalPrice = MoneyCalculator.PricePerOrder(order);
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

        if (SelectedOrder is not null)
        {
            OrderService.AddProductToOrder(SelectedOrder, product);
            ToggleOrderInfo();
            RefreshProductsInOrder();
            return;
        }

        OrderDetail detail = new () { Order = SelectedOrder, Product = product, TimeAdded = DateTime.Now};
        detail.Price = MoneyCalculator.PricePerOrderDetail(detail, IsEvent);
        var item = new ListViewItem();
        item.Tag = detail;
        item.Text = product.Name;
        item.SubItems.Add($"€ {detail.Price}");
        item.SubItems.Add($"{detail.TimeAdded.ToShortDateString()} - {detail.TimeAdded.ToShortTimeString()}");
        lvProducts.Items.Add(item);
        CalculateTotalPrice(null);

        btPay.Enabled = true;
    }

    private void ToggleOrderInfo()
    {
        bool toggle = false;
        if (SelectedOrder == null)
        {
            lbName.Text = "";
            lbOrderDate.Text = "";
            lbOrderPrice.Text = "€ 0,00";
        }
        else
        {
            lbName.Text = SelectedOrder.GetName();
            lbOrderDate.Text = $"{SelectedOrder.OrderDate.ToShortDateString()} - {SelectedOrder.OrderDate.ToShortTimeString()}";
            CalculateTotalPrice(SelectedOrder);
            toggle = true;
        }

        btPay.Enabled = toggle;
    }

    private void btDeleteProduct_Click(object sender, EventArgs e)
    {
        OrderDetail detail = (OrderDetail)lvProducts.SelectedItems[0].Tag;
        if (detail == null) { return; }

        if (SelectedOrder == null)
        {
            lvProducts.Items.Remove(lvProducts.SelectedItems[0]);
            return;
        }

        OrderService.DeleteProductFromOrder(SelectedOrder, detail);
        RefreshProductsInOrder();
    }

    private void btSelectCustomer_Click(object sender, EventArgs e)
    {
        string customerName = cbCustomerName.Text.Trim();
        if (IsCustomerNameNotValid(customerName))
        {
            SelectedOrder = null;
            RefreshCustomerComboBox();
            return;
        }

        if (customerName == "" && SelectedOrder == null)
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
        else if (customerName == "" && SelectedOrder != null)
        {
            SelectedOrder = null;
            RefreshProductsInOrder();
            ToggleOrderInfo();
            return;
        }
        else if (customerName != "" && SelectedOrder == null)
        {
            Order order = OrderService.GetOrderByCustomerName(customerName);
            if (order == null)
            {
                order = new Order() { Customer = CustomerService.FindOrCreateCustomer(customerName) };
                foreach (ListViewItem item in lvProducts.Items)
                {
                    var detail = (OrderDetail)item.Tag;
                    detail.Order = order;
                    detail.TimeAdded = DateTime.Now;

                    order.OrderDetails.Add(detail);
                }

                OrderService.CreateOrder(order);
                SelectedOrder = order;
            }
            else
            {
                SelectedOrder = order;
                foreach (ListViewItem item in lvProducts.Items)
                {
                    var detail = (OrderDetail)item.Tag;
                    OrderService.AddProductToOrder(SelectedOrder, detail.Product);
                }
            }
        }
        else if (customerName != "" && SelectedOrder != null)
        {
            Order order = OrderService.GetOrderByCustomerName(customerName);
            SelectedOrder = order;
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
        var productButtonSize = GeneralOptionsService.GetGeneralOptions().ProductButtonSize;

        pProducts.Controls.Clear();
        int a = 0;
        int b = 0;
        int factor = 0;
        int j = 1;
        foreach (var product in ProductService.GetProducts())
        {
            if (product.IsActive)
            {
                Button button = new Button();
                button.Top = 10;
                button.Left = 10;
                //button.Size = new Size(116, 85);
                //button.Size = new Size(85, 85);
                button.Size = new Size(200, 200);
                button.Text = product.Name;
                button.Tag = product;
                button.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
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
        var orderForm = new BestellingOverzichtForm(OrderService, CustomerService, MoneyCalculator, ProductService, SessionService);
        orderForm.ShowDialog();

        SelectedOrder = null;
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
        if (SelectedOrder is null && lvProducts.Items.Count > 0)
        {
            List<OrderDetail> orderDetails = new ();
            foreach(ListViewItem detail in lvProducts.Items)
            {
                orderDetails.Add(detail.Tag as OrderDetail);
            }

            var form = new AfrekenForm(orderDetails, OrderService, MoneyCalculator, ProductService);
            form.ShowDialog();
        }
        else if (SelectedOrder.Price > 0.00M)
        {
            var form = new AfrekenForm(SelectedOrder, OrderService, MoneyCalculator, ProductService);
            form.ShowDialog();
        }
        else
        {
            OrderService.PayOrder(SelectedOrder, 0.00M, PayMethod.None);
        }

        SelectedOrder = null;
        ToggleOrderInfo();
        RefreshProductsInOrder();
        RefreshCustomerComboBox();
    }

    private void TSMICustomers_Click(object sender, EventArgs e)
    {
        var form = new CustomerForm(CustomerService);
        form.ShowDialog();

        RefreshCustomerComboBox();
    }

    private void overzichtToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var form = new ProductOverzichtForm(ProductService);
        form.ShowDialog();
        InitializeProductButtons();
    }

    private void omzetOverzichtToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var form = new OmzetOverzichtForm(RevenueService);
        form.ShowDialog();
    }

    private void sessieBeheerToolStripMenuItem_Click(object sender, EventArgs e)
    {
        BeheerderForm? form = ServiceProvider.GetService(typeof(BeheerderForm)) as BeheerderForm;
        form.ShowDialog();
        IsEvent = SessionService.GetCurrentSession() is not null ? true : false;
    }

    private void optiesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        OptiesForm? form = ServiceProvider.GetService(typeof(OptiesForm)) as OptiesForm;
        form.ShowDialog();
        InitializeProductButtons();
    }
}
