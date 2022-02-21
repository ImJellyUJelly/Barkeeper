using App.Models;
using App.Services;

namespace App.Forms;

public partial class AfrekenForm : Form
{
    private readonly IOrderService _orderService;
    private readonly Order _order;

    public AfrekenForm(IOrderService orderService, Order order)
    {
        _orderService = orderService;
        _order = order;

        InitializeComponent();
        InitialLoad();
    }

    private void InitialLoad()
    {
        lbCustomerName.Text = _order.CustomerName;
        lbOrderDate.Text = $"{_order.OrderDate.ToShortTimeString()} - {_order.OrderDate.ToShortDateString()}";
        cbIsMember.Checked = _order.IsMember;
        lbPrice.Text = $"€ {_order.Price}";
        tbComments.Text = _order.Comment;
        LoadProducts();
    }

    private void cbIsMember_CheckedChanged(object sender, EventArgs e)
    {
        _order.IsMember = cbIsMember.Checked;
        _orderService.UpdateOrder(_order);
        lbPrice.Text = $"€ {_orderService.CalculateOrderPrice(_order)}";
        LoadProducts();
    }

    private void LoadProducts()
    {
        lvProducts.Items.Clear();
        foreach (OrderDetail detail in _order.OrderDetails)
        {
            var item = new ListViewItem();
            item.Tag = detail.Product;
            item.Text = detail.Product.Name;
            if (_order.IsMember)
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
    }
}
