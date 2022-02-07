using App.Agents;
using Models;
using System.Globalization;

namespace App.Forms;

public partial class OrderOverviewForm : Form
{
    private CultureInfo cultureInfo;
    private readonly IOrderAgent _orderAgent;
    private List<Product> _products;
    private Order _selectedOrder;

    public OrderOverviewForm(IOrderAgent orderAgent)
    {
        _orderAgent = orderAgent;

        InitializeComponent();
        InitializeGeneralInformation();
        ToggleOrderInfo(false, null);
        RefreshOrders();
    }

    private void InitializeGeneralInformation()
    {
        cultureInfo = CultureInfo.GetCultureInfo("nl-NL");
        lbDate.Text = $"{cultureInfo.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek)} {DateTime.Now.ToString("dd/MM/yyyy")}";

        _products = new List<Product>();
        _products.Add(new Product() { Id = 0, Name = "Koffie", Price = 1.20M, MemberPrice = true });
        _products.Add(new Product() { Id = 1, Name = "Thee", Price = 1.00M, MemberPrice = true });
        _selectedOrder = null;
    }

    private void btCreateOrder_Click(object sender, EventArgs e)
    {
        var products = new List<Product>();
        foreach (ListViewItem item in lvProducts.Items)
        {
            products.Add((Product)item.Tag);
        }

        var order = new Order();
        order.Products = products;

        CreateOrderForm form = new CreateOrderForm(_orderAgent, order);
        form.ShowDialog();
        RefreshOrders();
    }

    private void RefreshOrders()
    {
        lvOrders.Items.Clear();
        List<Order> orders = _orderAgent.GetOrders();

        foreach (Order order in orders)
        {
            var item = new ListViewItem();
            item.Tag = order;
            item.Text = order.CustomerName;
            lvOrders.Items.Add(item);
        }
    }

    private void RefreshProductsInOrder(Order order)
    {
        lvProducts.Items.Clear();
        if (order == null)
        {
            return;
        }

        foreach (Product product in order.Products)
        {
            var item = new ListViewItem();
            item.Tag = product;
            item.Text = product.Name;
            item.SubItems.Add($"€ {product.Price}");
            lvProducts.Items.Add(item);
        }
    }

    private void AddProductToOrder(string productName, bool member)
    {
        if (lvOrders.SelectedItems.Count > 0)
        {
            _selectedOrder = (Order)lvOrders.SelectedItems[0].Tag;
        }
        else if (_selectedOrder == null)
        {
            _selectedOrder = new Order();
            _selectedOrder.OrderDate = DateTime.Now;
        }

        Product product = _products.First(product => product.Name.Equals(productName));
        if (product == null)
        {
            MessageBox.Show("Product is niet gevonden.");
            return;
        }

        _selectedOrder.Products.Add(product);
        ToggleOrderInfo(true, _selectedOrder);
        RefreshProductsInOrder(_selectedOrder);
    }

    private void btKoffie_Click(object sender, EventArgs e)
    {
        AddProductToOrder("Koffie", true);
    }

    private void btThee_Click(object sender, EventArgs e)
    {
        AddProductToOrder("Thee", true);
    }

    private void lvOrders_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_selectedOrder != null && _selectedOrder.CustomerName == null)
        {
            DialogResult dialogResult = MessageBox.Show("Wil je de huidige bestelling opslaan of afrekenen?", "Huidige bestelling", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                return;
            }
        }

        if (lvOrders.SelectedItems.Count == 0)
        {
            lvProducts.Items.Clear();
            ToggleOrderInfo(false, null);
            _selectedOrder = null;
            return;
        }
    }

    private void lvOrders_Click(object sender, EventArgs e)
    {
        Order order = (Order)lvOrders.SelectedItems[0].Tag;
        _selectedOrder = order;
        if(order == null)
        {
            ToggleOrderInfo(false, null);
        }
        else
        {
            ToggleOrderInfo(true, order);
        }

        RefreshProductsInOrder(order);
    }

    private void ToggleOrderInfo(bool toggle, Order order)
    {
        if (!toggle)
        {
            lbName.Text = "";
            lbOrderDate.Text = "";
        }
        else
        {
            lbName.Text = order.CustomerName;
            lbOrderDate.Text = $"{order.OrderDate.ToShortDateString()} {order.OrderDate.ToShortTimeString()}";
        }

        btCreateOrder.Enabled = toggle;
        btPay.Enabled = toggle;
    }
}

