using App.Services;
using App.Models;

namespace App.Forms;

public partial class BestellingenSamenvoegenForm : Form
{
    private readonly IOrderService _orderService;
    private List<Order> _orders;

    public BestellingenSamenvoegenForm(IOrderService orderService, List<Order> orders)
    {
        _orderService = orderService;
        _orders = orders;
        InitializeComponent();
        InitializeMergeOrders();
    }

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
                if (order.IsMember)
                {
                    item.SubItems.Add($"€ {od.Product.MemberPrice}");
                    totalPrice += od.Product.MemberPrice;
                }
                else
                {
                    item.SubItems.Add($"€ {od.Product.Price}");
                    totalPrice += od.Product.Price;
                }
                item.SubItems.Add($"{od.TimeAdded.ToShortDateString()} - {od.TimeAdded.ToShortTimeString()}");
                item.SubItems.Add(order.CustomerName);
                lvProducts.Items.Add(item);
            }

            lbOrderCustomerNames.Text += $" {order.CustomerName}";
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
