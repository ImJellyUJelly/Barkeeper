using App.Services;
using Models;

namespace App.Forms;

public partial class BestellingOverzichtForm : Form
{
    private readonly IOrderService _orderService;

    public BestellingOverzichtForm(IOrderService orderService)
    {
        _orderService = orderService;

        InitializeComponent();
        LoadOrders();
    }

    private void LoadOrders()
    {
        btMergeOrders.Enabled = false;
        btSplitOrder.Enabled = false;

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
            item.SubItems.Add(order.CustomerName);
            if (order.IsMember)
            {
                item.SubItems.Add("Ja");
            }
            else
            {
                item.SubItems.Add("Nee");
            }
            item.SubItems.Add($"{order.OrderDate.ToString("dd/MM/yyyy")} - {order.OrderDate.ToShortTimeString()}");
            if (order.IsPaid)
            {
                item.SubItems.Add("Ja");
            }
            else
            {
                item.SubItems.Add("Nee");
            }
            item.SubItems.Add(order.OrderDetails.Count.ToString());
            lvOrders.Items.Add(item);
        }
    }

    private void lvOrders_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lvOrders.SelectedItems.Count > 0 && lvOrders.SelectedItems.Count < 2)
        {
            btSplitOrder.Enabled = true;
        }
        else
        {
            btSplitOrder.Enabled = false;
        }

        if (lvOrders.SelectedItems.Count > 1)
        {
            btMergeOrders.Enabled = true;
        }
        else
        {
            btMergeOrders.Enabled = false;
        }
    }

    private void btMergeOrders_Click(object sender, EventArgs e)
    {
        List<Order> orders = new List<Order>();
        foreach (ListViewItem item in lvOrders.Items)
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
        if(order == null) { return; }

        var form = new SplitBestellingForm(_orderService, order);
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
}