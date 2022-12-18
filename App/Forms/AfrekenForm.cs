using App.Models;
using App.Services;

namespace App.Forms;

public partial class AfrekenForm : Form
{
    private readonly IOrderService _orderService;
    private readonly IMoneyCalculator _moneyCalculator;
    private readonly IRevenueService _revenueService;

    private Order _order;

    public AfrekenForm(IOrderService orderService, IMoneyCalculator moneyCalculator, IRevenueService revenueService, Order order)
    {
        _orderService = orderService;
        _moneyCalculator = moneyCalculator;
        _revenueService = revenueService;
        _order = order;

        InitializeComponent();
        InitialLoad();
    }

    private void InitialLoad()
    {
        lbCustomerName.Text = _order.Customer?.Name;
        lbOrderDate.Text = $"{_order.OrderDate.ToShortTimeString()} - {_order.OrderDate.ToShortDateString()}";
        cbIsMember.Checked = _order.IsMember;
        tbComments.Text = _order.Comment;
        EditPriceLabel(_order);
        LoadProducts();
    }

    private void EditPriceLabel(Order order)
    {
        lbPrice.Text = $"€ {order.Price}";
    }

    private void cbIsMember_CheckedChanged(object sender, EventArgs e)
    {
        _order.IsMember = cbIsMember.Checked;
        if(_order.Customer != null)
        {
            _order.Customer.IsMember = cbIsMember.Checked;
        }

        _order.Price = _moneyCalculator.PricePerOrder(_order);
        _orderService.UpdateOrder(_order);
        EditPriceLabel(_order);
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
            item.SubItems.Add($"€ {detail.Price}");
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
        decimal remainder = _moneyCalculator.PayOrder(_order, amount);
        Revenue revenue = new Revenue() { Amount = amount, SaleDate = DateTime.Now };
        _revenueService.AddPayment(revenue);
        if (remainder > 0)
        {
            _order.PaidAmount += amount;
            _order.Price = _moneyCalculator.PricePerOrder(_order);
            _orderService.UpdateOrder(_order);
            EditPriceLabel(_order);
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
