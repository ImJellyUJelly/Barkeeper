using App.Models;
using App.Services;

namespace App.Forms;

public partial class AfrekenForm : Form
{
    private readonly IOrderService _orderService;
    private readonly IMoneyCalculator _moneyCalculator;

    private Order _order;

    public AfrekenForm(IOrderService orderService, IMoneyCalculator moneyCalculator, Order order)
    {
        _orderService = orderService;
        _moneyCalculator = moneyCalculator;
        _order = order;

        InitializeComponent();
        InitialLoad();
    }

    private void InitialLoad()
    {
        lbCustomerName.Text = _order.Customer.Name;
        lbOrderDate.Text = $"{_order.OrderDate.ToShortTimeString()} - {_order.OrderDate.ToShortDateString()}";
        cbIsMember.Checked = _order.IsMember;
        tbComments.Text = _order.Comment;
        EditPriceLabel(_order.Price);
        LoadProducts();
    }

    private void EditPriceLabel(decimal price)
    {
        lbPrice.Text = $"€ {price}";
    }

    private void cbIsMember_CheckedChanged(object sender, EventArgs e)
    {
        _order.IsMember = cbIsMember.Checked;
        _orderService.UpdateOrder(_order);
        EditPriceLabel(_moneyCalculator.PricePerOrder(_order));
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

    private void btFive_Click(object sender, EventArgs e)
    {
        Pay(5);
    }

    private void btTen_Click(object sender, EventArgs e)
    {
        Pay(10);
    }

    private void btTwenty_Click(object sender, EventArgs e)
    {
        Pay(20);
    }

    private void btFifty_Click(object sender, EventArgs e)
    {
        Pay(50);
    }

    private void btCash_Click(object sender, EventArgs e)
    {
        var form = new CashForm();
        form.ShowDialog();
        if(form.IsClosed)
        {
            return;
        }

        Pay(form.Payment);
    }

    private void btPin_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Not implemented");
    }

    private void Pay(decimal amount)
    {
        decimal remainder = _order.Price - amount;
        if (remainder > 0)
        {
            _order.Price = remainder;
            _orderService.UpdateOrder(_order);
            EditPriceLabel(_order.Price);
            return;
        }

        if (remainder < 0)
        {
            var form = new TeruggaveForm(remainder);
            form.ShowDialog();
        }

        _orderService.PayOrder(_order, amount);
        Close();
    }
}
