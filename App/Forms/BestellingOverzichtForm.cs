using App.Services;
using App.Models;

namespace App.Forms;

public partial class BestellingOverzichtForm : Form
{
    private readonly IOrderService _orderService;
    private readonly ICustomerService _memberService;
    private readonly IMoneyCalculator _moneyCalculator;

    public BestellingOverzichtForm(IOrderService orderService, ICustomerService memberService, IMoneyCalculator moneyCalculator)
    {
        _orderService = orderService;
        _memberService = memberService;
        _moneyCalculator = moneyCalculator;

        InitializeComponent();
        LoadOrders();
    }

    private void LoadOrders()
    {
        btMergeOrders.Enabled = false;
        btSplitOrder.Enabled = false;
        btPay.Enabled = false;

        lvOrders.Items.Clear();
        List<Order> orders = _orderService.GetOrders()
            .OrderBy(order => order.IsPaid)
            .ThenBy(order => order.OrderDate)
            .ToList();

        foreach (Order order in orders)
        {
            var item = new ListViewItem();
            item.Tag = order;
            item.Text = order.Id.ToString();
            item.SubItems.Add(order.Customer.Name);
            item.SubItems.Add(GetTextFromBool(order.IsMember));
            item.SubItems.Add($"{order.OrderDate.ToString("dd/MM/yyyy")} - {order.OrderDate.ToShortTimeString()}");
            item.SubItems.Add(GetTextFromBool(order.IsPaid));
            item.SubItems.Add(GetTextFromBool(order.IsFinished));
            item.SubItems.Add($"€ {_moneyCalculator.PricePerOrder(order)}");
            item.SubItems.Add(order.Comment);
            lvOrders.Items.Add(item);
        }
    }

    private void lvOrders_SelectedIndexChanged(object sender, EventArgs e)
    {
        var orders = lvOrders.SelectedItems;
        Order order = orders.Count > 0 ? (Order)orders[0].Tag : null;

        btSplitOrder.Enabled = (orders.Count > 0 && orders.Count < 2) && order.CanPay ? true : false;
        btMergeOrders.Enabled = orders.Count > 1 ? true : false;
        btPay.Enabled = orders.Count == 1 && order.CanPay ? true : false;
    }

    private void btMergeOrders_Click(object sender, EventArgs e)
    {
        List<Order> orders = new List<Order>();
        foreach (ListViewItem item in lvOrders.SelectedItems)
        {
            orders.Add((Order)item.Tag);
        }

        var form = new BestellingenSamenvoegenForm(_orderService, orders);
        form.ShowDialog();
        LoadOrders();
    }

    private void btSplitOrder_Click(object sender, EventArgs e)
    {
        Order order = (Order)lvOrders.SelectedItems[0].Tag;
        if (order == null) { return; }

        var form = new SplitBestellingForm(_orderService, _memberService, _moneyCalculator, order);
        form.ShowDialog();
        LoadOrders();
    }

    private void lvOrders_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.A && e.Control)
        {
            foreach (ListViewItem item in lvOrders.Items)
            {
                item.Selected = true;
            }
        }
    }

    private string GetTextFromBool(bool value)
    {
        if (value)
        {
            return "Ja";
        }
        return "Nee";
    }

    private void btPay_Click(object sender, EventArgs e)
    {
        Order order = (Order)lvOrders.SelectedItems[0].Tag;
        if (order == null) { return; }

        var form = new AfrekenForm(_orderService, _moneyCalculator, order);
        form.ShowDialog();

        LoadOrders();
    }
}