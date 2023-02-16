using App.Models;
using App.Services;

namespace App.Forms;

public partial class AfrekenForm : Form
{
    private readonly IOrderService _orderService;
    private readonly IMoneyCalculator _moneyCalculator;
    private readonly IProductService _productService;

    public Order Order { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }

    private decimal Price { get; set; }
    private decimal Coins { get; set; }

    public AfrekenForm(IOrderService orderService, IMoneyCalculator moneyCalculator, IProductService productService)
    {
        _orderService = orderService;
        _moneyCalculator = moneyCalculator;
        _productService = productService;

        InitializeComponent();
    }

    public AfrekenForm(List<OrderDetail> orderDetails, IOrderService orderService, IMoneyCalculator moneyCalculator, IProductService productService)
        : this(orderService, moneyCalculator, productService)
    {
        OrderDetails = orderDetails;
        InitialLoad();
    }

    public AfrekenForm(Order order, IOrderService orderService, IMoneyCalculator moneyCalculator, IProductService productService)
    : this(orderService, moneyCalculator, productService)
    {
        Order = order;
        InitialLoad();
    }

    private void InitialLoad()
    {
        var coins = _productService.GetProductByName("Munten");
        if (Order is null)
        {
            lbCustomerName.Text = "Directe betaling";
            lbOrderDate.Text = $"{DateTime.Now.ToShortTimeString()} - {DateTime.Now.ToShortDateString()}";
            tbComments.Enabled = false;
            Price = _moneyCalculator.PriceForNoOrder(OrderDetails);
            Coins = _moneyCalculator.GetCoinsForNoOrder(OrderDetails, coins.Price / 10);
            EditPriceLabels();
            LoadProducts(OrderDetails);
        }
        else
        {
            lbCustomerName.Text = Order.GetName();
            lbOrderDate.Text = $"{Order.OrderDate.ToShortTimeString()} - {Order.OrderDate.ToShortDateString()}";
            tbComments.Text = Order.Comment;
            Price = _moneyCalculator.PricePerOrder(Order);
            Coins = _moneyCalculator.PricePerOrder(Order) / (coins.Price / 10);
            EditPriceLabels();
            LoadProducts(Order.OrderDetails);
        }

    }

    private void EditPriceLabels()
    {
        lbPrice.Text = $"€ {Price}";
        lbCoins.Text = $"{Coins}";
    }

    private void LoadProducts(List<OrderDetail> orderDetails)
    {
        lvProducts.Items.Clear();
        foreach (OrderDetail detail in orderDetails)
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

        if (form.IsClosed)
        {
            return;
        }

        Pay(form.Payment, PayMethod.Cash);
    }

    private void btPin_Click(object sender, EventArgs e)
    {
        var form = new PinForm(Price);
        form.ShowDialog();

        if (form.IsClosed)
        {
            return;
        }

        Pay(form.Payment, PayMethod.Card);
    }

    private void Pay(decimal amount, PayMethod payMethod)
    {
        decimal remainder = _orderService.PayOrder(Order, amount, payMethod);
        Price = remainder;
        if (remainder > 0)
        {
            EditPriceLabels();
            return;
        }

        if (remainder < 0)
        {
            var form = new TeruggaveForm(remainder);
            form.ShowDialog();
        }

        _orderService.FinishOrder(Order);
        Close();
    }

    private void btMunten_Click(object sender, EventArgs e)
    {
        var amount = Price - (Order is not null ? Order.PaidAmount : 0);
        Pay(amount, PayMethod.Coins);
    }
}
