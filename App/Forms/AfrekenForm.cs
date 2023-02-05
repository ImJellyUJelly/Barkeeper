using App.Models;
using App.Services;

namespace App.Forms;

public partial class AfrekenForm : Form
{
    private readonly IOrderService _orderService;
    private readonly IMoneyCalculator _moneyCalculator;
    private readonly Order _order;

    public AfrekenForm(IOrderService orderService, IMoneyCalculator moneyCalculator, IRevenueService revenueService, Order order)
    {
        _orderService = orderService;
        _moneyCalculator = moneyCalculator;
        _order = order;

        InitializeComponent();
        InitialLoad();
    }

    private void InitialLoad()
    {
        lbCustomerName.Text = _order.GetName();
        lbOrderDate.Text = $"{_order.OrderDate.ToShortTimeString()} - {_order.OrderDate.ToShortDateString()}";
        tbComments.Text = _order.Comment;
        EditPriceLabels(_order);
        LoadProducts();
    }

    private void EditPriceLabels(Order order)
    {
        lbPrice.Text = $"€ {order.Price}";
        lbCoins.Text = $"{order.Coins}";
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
        Pay(5, PayMethod.Cash);
    }

    private void btTen_Click(object sender, EventArgs e)
    {
        Pay(10, PayMethod.Cash);
    }

    private void btTwenty_Click(object sender, EventArgs e)
    {
        Pay(20, PayMethod.Cash);
    }

    private void btFifty_Click(object sender, EventArgs e)
    {
        Pay(50, PayMethod.Cash);
    }

    private void btCash_Click(object sender, EventArgs e)
    {
        var form = new CashForm();
        form.ShowDialog();

        if(form.IsClosed)
        {
            return;
        }

        Pay(form.Payment, PayMethod.Cash);
    }

    private void btPin_Click(object sender, EventArgs e)
    {
        var form = new PinForm(_order.Price);
        form.ShowDialog();

        if (form.IsClosed)
        {
            return;
        }

        Pay(form.Payment, PayMethod.Card);
    }

    private void Pay(decimal amount, PayMethod payMethod)
    {
        decimal remainder = _orderService.PayOrder(_order, amount, payMethod);
        if (remainder > 0)
        {
            EditPriceLabels(_order);
            return;
        }

        if (remainder < 0)
        {
            var form = new TeruggaveForm(remainder);
            form.ShowDialog();
        }

        _orderService.FinishOrder(_order);
        Close();
    }

    private void btMunten_Click(object sender, EventArgs e)
    {
        var amount = _order.Price - _order.PaidAmount;
        Pay(amount, PayMethod.Coins);
    }
}
