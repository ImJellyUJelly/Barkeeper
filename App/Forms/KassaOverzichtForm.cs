using App.Services;
using Models;
using System.Globalization;

namespace App.Forms;

public partial class KassaOverzichtForm : Form
{
    private CultureInfo cultureInfo;
    private List<Product> _products;
    private Order? _selectedOrder;

    private readonly IOrderService _orderService;

    public KassaOverzichtForm(IOrderService orderService)
    {
        _orderService = orderService;

        InitializeComponent();
        InitializeGeneralInformation();
        ToggleOrderInfo();
    }

    private void InitializeGeneralInformation()
    {
        cultureInfo = CultureInfo.GetCultureInfo("nl-NL");
        lbDate.Text = $"{cultureInfo.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek)} {DateTime.Now.ToString("dd/MM/yyyy")}";
        _selectedOrder = null;
        btDeleteProduct.Visible = false;
        btPay.Enabled = false;

        #region TestProducts
        _products = new List<Product>();
        _products.Add(new Product() { Id = 0, Name = "Koffie", MemberPrice = 1.20M, Price = 1.75M });
        _products.Add(new Product() { Id = 1, Name = "Thee", MemberPrice = 1.20M, Price = 1.75M });
        _products.Add(new Product() { Id = 2, Name = "Bier", MemberPrice = 1.80M, Price = 2.20M });
        _products.Add(new Product() { Id = 3, Name = "Cola", MemberPrice = 1.80M, Price = 2.20M });
        _products.Add(new Product() { Id = 4, Name = "Chocomel", MemberPrice = 1.80M, Price = 2.20M });
        _products.Add(new Product() { Id = 5, Name = "Ice Tea", MemberPrice = 1.80M, Price = 2.20M });
        _products.Add(new Product() { Id = 6, Name = "Cappuccino", MemberPrice = 1.80M, Price = 2.20M });
        _products.Add(new Product() { Id = 7, Name = "Chips", MemberPrice = 1.00M, Price = 1.75M });
        _products.Add(new Product() { Id = 8, Name = "Mars", MemberPrice = 1.20M, Price = 1.75M });
        _products.Add(new Product() { Id = 9, Name = "Whiskey", MemberPrice = 1.00M, Price = 1.75M });
        _products.Add(new Product() { Id = 10, Name = "1", MemberPrice = 1.20M, Price = 1.75M });
        _products.Add(new Product() { Id = 11, Name = "2", MemberPrice = 1.00M, Price = 1.75M });
        _products.Add(new Product() { Id = 12, Name = "3", MemberPrice = 1.20M, Price = 1.75M });
        _products.Add(new Product() { Id = 13, Name = "4", MemberPrice = 1.00M, Price = 1.75M });
        _products.Add(new Product() { Id = 14, Name = "4", MemberPrice = 1.20M, Price = 1.75M });
        _products.Add(new Product() { Id = 15, Name = "5", MemberPrice = 1.00M, Price = 1.75M });
        _products.Add(new Product() { Id = 16, Name = "6", MemberPrice = 1.00M, Price = 1.75M });
        _products.Add(new Product() { Id = 17, Name = "7", MemberPrice = 1.00M, Price = 1.75M });
        _products.Add(new Product() { Id = 18, Name = "8", MemberPrice = 1.20M, Price = 1.75M });
        _products.Add(new Product() { Id = 19, Name = "9", MemberPrice = 1.00M, Price = 1.75M });
        _products.Add(new Product() { Id = 20, Name = "10", MemberPrice = 1.20M, Price = 1.75M });
        _products.Add(new Product() { Id = 21, Name = "11", MemberPrice = 1.00M, Price = 1.75M });
        _products.Add(new Product() { Id = 22, Name = "12", MemberPrice = 1.20M, Price = 1.75M });
        _products.Add(new Product() { Id = 23, Name = "13", MemberPrice = 1.00M, Price = 1.75M });
        _products.Add(new Product() { Id = 24, Name = "14", MemberPrice = 1.20M, Price = 1.75M });
        _products.Add(new Product() { Id = 25, Name = "15", MemberPrice = 1.00M, Price = 1.75M });
        _products.Add(new Product() { Id = 26, Name = "16", MemberPrice = 1.20M, Price = 1.75M });
        _products.Add(new Product() { Id = 27, Name = "17", MemberPrice = 1.00M, Price = 1.75M });
        _products.Add(new Product() { Id = 28, Name = "18", MemberPrice = 1.20M, Price = 1.75M });
        _products.Add(new Product() { Id = 29, Name = "19", MemberPrice = 1.00M, Price = 1.75M });
        #endregion

        RefreshCustomerComboBox();
        InitializeProductButtons();
    }

    private void RefreshCustomerComboBox()
    {
        cbCustomerName.Items.Clear();
        foreach (Order order in _orderService.GetOrders())
        {
            cbCustomerName.Items.Add(order.CustomerName);
        }
    }

    private void RefreshProductsInOrder()
    {
        if (_selectedOrder == null)
        {
            lvProducts.Items.Clear();
            return;
        }

        lvProducts.Items.Clear();
        foreach (OrderDetail detail in _selectedOrder.OrderDetails)
        {
            var item = new ListViewItem();
            item.Tag = detail.Product;
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
                Product product = (Product)item.Tag;
                totalPrice += product.Price;
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
        if (_selectedOrder == null)
        {
            var item = new ListViewItem();
            item.Tag = product;
            item.Text = product.Name;
            item.SubItems.Add($"€ {product.Price}");
            lvProducts.Items.Add(item);
            CalculateTotalPrice(null);
            return;
        }

        if (product == null)
        {
            MessageBox.Show("Product is niet gevonden.");
            return;
        }

        _orderService.AddProductToOrder(_selectedOrder, product);
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
            lbName.Text = _selectedOrder.CustomerName;
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
        // To be implemented
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
                order = new Order() { CustomerName = customerName, OrderDate = DateTime.Now };
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
                    order.OrderDetails.Add(new OrderDetail() { Order = order, Product = (Product)item.Tag, TimeAdded = DateTime.Now });
                }

                _orderService.CreateOrder(order);
                _selectedOrder = order;
            }
            else
            {
                _selectedOrder = order;
                foreach (ListViewItem item in lvProducts.Items)
                {
                    order.OrderDetails.Add(new OrderDetail() { Order = order, Product = (Product)item.Tag, TimeAdded = DateTime.Now });
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
        cbCustomerName.Text = "";
    }

    private void lvProducts_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lvProducts.SelectedItems.Count <= 0)
        {
            btDeleteProduct.Visible = false;
            return;
        }

        Product product = (Product)lvProducts.SelectedItems[0].Tag;
        btDeleteProduct.Visible = true;
    }

    private void InitializeProductButtons()
    {
        int a = 0;
        int b = 0;
        int factor = 0;
        int j = 1;
        foreach (var product in _products)
        {
            Button button = new Button();
            button.Top = 10;
            button.Left = 10;
            button.Size = new Size(85, 85);
            button.Text = product.Name;
            button.Tag = product;
            button.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
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
        var orderForm = new BestellingOverzichtForm(_orderService);
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
}
