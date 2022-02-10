using App.Agents;
using Models;
using System.Globalization;

namespace App.Forms;

public partial class OrderOverviewForm : Form
{
    private CultureInfo cultureInfo;
    private readonly IOrderAgent _orderAgent;
    private List<Product> _products;
    private Order? _selectedOrder;

    public OrderOverviewForm(IOrderAgent orderAgent)
    {
        _orderAgent = orderAgent;
        InitializeComponent();
        InitializeGeneralInformation();
        ToggleOrderInfo(null);
        RefreshOrders();
    }

    private void InitializeGeneralInformation()
    {
        cultureInfo = CultureInfo.GetCultureInfo("nl-NL");
        lbDate.Text = $"{cultureInfo.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek)} {DateTime.Now.ToString("dd/MM/yyyy")}";
        lbInvoiceNr.Text = "12345";

        _products = new List<Product>();
        _products.Add(new Product() { Id = 0, Name = "Koffie", Price = 1.20M, MemberPrice = true });
        _products.Add(new Product() { Id = 1, Name = "Thee", Price = 1.00M, MemberPrice = true });
        _selectedOrder = null;
    }

    private void btCreateOrder_Click(object sender, EventArgs e)
    {
        var orderDetails = new List<OrderDetail>();
        var order = new Order();
        foreach (ListViewItem item in lvProducts.Items)
        {
            orderDetails.Add(new OrderDetail() { Order = order, Product = (Product)item.Tag, ProductId = ((Product)item.Tag).Id });
        }

        order.OrderDetails = orderDetails;

        CreateOrderForm form = new CreateOrderForm(_orderAgent, order);
        form.ShowDialog();

        RefreshOrders();
        _selectedOrder = null;
        RefreshProductsInOrder(_selectedOrder);
        ToggleOrderInfo(_selectedOrder);
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

    private void RefreshProductsInOrder(Order? order)
    {
        lvProducts.Items.Clear();
        if (order == null)
        {
            return;
        }

        foreach (OrderDetail detail in order.OrderDetails)
        {
            var item = new ListViewItem();
            item.Tag = detail.Product;
            item.Text = detail.Product.Name;
            item.SubItems.Add($"€ {detail.Product.Price}");
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
            var order = new Order();
            order.OrderDate = DateTime.Now;
            _selectedOrder = order;
        }

        Product product = _products.First(product => product.Name.Equals(productName));
        if (product == null)
        {
            MessageBox.Show("Product is niet gevonden.");
            return;
        }

        _selectedOrder.OrderDetails.Add(new OrderDetail() { Order = _selectedOrder, Product = product });
        ToggleOrderInfo(_selectedOrder);
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

    private void lvOrders_Click(object sender, EventArgs e)
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
            ToggleOrderInfo(null);
            _selectedOrder = null;
            return;
        }

        Order order = (Order)lvOrders.SelectedItems[0].Tag;
        _selectedOrder = order;
        if(order == null)
        {
            ToggleOrderInfo(null);
        }
        else
        {
            ToggleOrderInfo(order);
        }

        RefreshProductsInOrder(order);
    }

    private void ToggleOrderInfo(Order? order)
    {
        bool toggle = false;
        if (order == null)
        {
            lbName.Text = "";
            lbOrderDate.Text = "";
        }
        else
        {
            lbName.Text = order.CustomerName;
            lbOrderDate.Text = $"{order.OrderDate.ToShortDateString()} - {order.OrderDate.ToShortTimeString()}";
            toggle = true;
        }

        btCreateOrder.Enabled = toggle;
        btPay.Enabled = toggle;
    }
}

