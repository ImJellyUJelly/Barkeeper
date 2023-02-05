using App.Services;
using App.Models;

namespace App.Forms;

public partial class BestellingenSamenvoegenForm : Form
{
    private readonly IOrderService _orderService;
    private readonly IMoneyCalculator _moneyCalculater;
    private List<Order> _orders;

    public BestellingenSamenvoegenForm(IOrderService orderService,
        IMoneyCalculator moneyCalculator,
        ISessionService sessionService,
        List<Order> orders)
    {
        _orderService = orderService;
        _orders = orders;
        _moneyCalculater = moneyCalculator;
        SessionService = sessionService;
        InitializeComponent();
        InitializeMergeOrders();
    }

    private ISessionService SessionService { get; }

    private void InitializeMergeOrders()
    {
        lvProducts.Items.Clear();
        lbOrderCustomerNames.Text = "";
        decimal totalPrice = 0.00M;
        for (int i = 0; i < _orders.Count; i++)
        {
            var order = _orders[i];
            if(i > 0)
            {
                lbOrderCustomerNames.Text += ",";
            }

            foreach (OrderDetail od in order.OrderDetails)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = od;
                item.Text = od.Product.Name;
                if (SessionService.BoughtDuringEvent(od.TimeAdded))
                {
                    item.SubItems.Add($"€ {od.Product.EventPrice}");
                }
                else
                {
                    item.SubItems.Add($"€ {od.Product.Price}");
                }

                item.SubItems.Add($"{od.TimeAdded.ToShortDateString()} - {od.TimeAdded.ToShortTimeString()}");
                item.SubItems.Add(order.GetName());
                lvProducts.Items.Add(item);
            }

            totalPrice += _moneyCalculater.PricePerOrder(order) + order.SplitPrice;
            lbOrderCustomerNames.Text += $" {order.GetName()}";
            if(lbOrderCustomerNames.Width > 610)
            {
                lbOrderCustomerNames.Width = 610;
            }
        }
        lbTotalPrice.Text = $"€ {totalPrice}";
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void btSave_Click(object sender, EventArgs e)
    {
        string customerName = tbCustomerName.Text;
        if (customerName.Trim() == "")
        {
            MessageBox.Show("Vul een naam in voor de samengevoegde bestelling.");
            return;
        }

        _orderService.MergeOrders(_orders, customerName);
        Close();
    }
}
