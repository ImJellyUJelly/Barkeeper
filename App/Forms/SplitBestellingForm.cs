using App.Services;
using App.Models;

namespace App.Forms;

public partial class SplitBestellingForm : Form
{
    private readonly IOrderService _orderService;
    private readonly ICustomerService _memberService;

    private readonly Order _order;
    private List<Order> _orders;

    private int _numberOfNewOrders = 2;
    private Dictionary<ComboBox, NumericUpDown> _toolsNewOrders = new Dictionary<ComboBox, NumericUpDown>();

    public SplitBestellingForm(IOrderService orderService, ICustomerService memberService, Order order)
    {
        _orderService = orderService;
        _memberService = memberService;
        _order = order;
        _orders = _orderService.GetOrders();
        _orders.Remove(_order);

        InitializeComponent();
        InitializeForm();
    }

    private void InitializeForm()
    {
        lbId.Text = _order.Id.ToString();
        lbCustomerName.Text = _order.Customer.Name;
        lbOrderDate.Text = $"{_order.OrderDate.ToShortTimeString()} - {_order.OrderDate.ToShortDateString()}";
        lbPrice.Text = $"€ {_order.Price}";
        cbIsMember.Checked = _order.IsMember;
        cbIsFinished.Checked = _order.IsFinished;
        cbIsPaid.Checked = _order.IsPaid;
        tbComment.Text = _order.Comment;

        AddOrdersToComboBox(cbCustomerName1);
        AddOrdersToComboBox(cbCustomerName2);

        _toolsNewOrders.Add(cbCustomerName1, nudCustomer1);
        _toolsNewOrders.Add(cbCustomerName2, nudCustomer2);
        SetPriceForNewOrders();
    }

    private void btAddCustomer_Click(object sender, EventArgs e)
    {
        int heightdivider = cbCustomerName2.Location.Y - (cbCustomerName1.Location.Y + cbCustomerName1.Height);

        Label lbCustomerName = new Label();
        lbCustomerName.Text = "Naam:";
        lbCustomerName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        lbCustomerName.Size = new Size(lbCustomer1.Width, lbCustomer1.Height);
        lbCustomerName.Location = new Point(lbCustomer1.Location.X, (lbCustomer1.Location.Y + (_toolsNewOrders.Count * (cbCustomerName1.Height + heightdivider))));
        this.Controls.Add(lbCustomerName);

        ComboBox cbCustomerName = new ComboBox();
        cbCustomerName.TabIndex = _toolsNewOrders.Count + 1;
        cbCustomerName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        cbCustomerName.Size = new Size(cbCustomerName1.Width, cbCustomerName1.Height);
        cbCustomerName.Location = new Point(cbCustomerName1.Location.X, (cbCustomerName1.Location.Y + (_toolsNewOrders.Count * (cbCustomerName1.Height + heightdivider))));
        AddOrdersToComboBox(cbCustomerName);
        this.Controls.Add(cbCustomerName);

        Label lbPrice = new Label();
        lbPrice.Text = "Prijs:";
        lbPrice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        lbPrice.Size = new Size(lbPrice1.Width, lbPrice1.Height);
        lbPrice.Location = new Point(lbPrice1.Location.X, (lbPrice1.Location.Y + (_toolsNewOrders.Count * (cbCustomerName1.Height + heightdivider))));
        this.Controls.Add(lbPrice);

        Label lbEuroSign = new Label();
        lbEuroSign.Text = "€";
        lbEuroSign.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        lbEuroSign.Size = new Size(lbEuro1.Width, lbEuro1.Height);
        lbEuroSign.Location = new Point(lbEuro1.Location.X, (lbEuro1.Location.Y + (_toolsNewOrders.Count * (cbCustomerName1.Height + heightdivider))));
        this.Controls.Add(lbEuroSign);

        NumericUpDown nudPrice = new NumericUpDown();
        nudPrice.Minimum = 0;
        nudPrice.Maximum = 99999999999;
        nudPrice.DecimalPlaces = 2;
        nudPrice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        nudPrice.Size = new Size(nudCustomer1.Width, nudCustomer1.Height);
        nudPrice.Location = new Point(nudCustomer1.Location.X, (nudCustomer1.Location.Y + (_toolsNewOrders.Count * (cbCustomerName1.Height + heightdivider))));
        this.Controls.Add(nudPrice);

        _toolsNewOrders.Add(cbCustomerName, nudPrice);
        _numberOfNewOrders++;
        SetPriceForNewOrders();

        if (Height <= (cbCustomerName.Location.Y + cbCustomerName.Height + 34))
        {
            Height += cbCustomerName.Height;
        }
    }

    private void AddOrdersToComboBox(ComboBox comboBox)
    {
        comboBox.Items.Clear();
        foreach (var order in _orders)
        {
            comboBox.Items.Add(order);
        }

        comboBox.Items.Add("----------------");
        foreach (var name in _memberService.GetCustomers())
        {
            comboBox.Items.Add(name);
        }
    }

    private void SetPriceForNewOrders()
    {
        decimal price = _order.Price / _numberOfNewOrders;
        foreach (var dict in _toolsNewOrders)
        {
            dict.Value.Value = price;
        }
    }

    private void btSplitOrder_Click(object sender, EventArgs e)
    {
        if (!CheckIfAllNamesAreFilled())
        {
            return;
        }

        var newOrder = new Dictionary<string, decimal>();
        foreach (var pair in _toolsNewOrders)
        {
            decimal price = Math.Round(pair.Value.Value, 2);
            newOrder.Add(pair.Key.Text, price);
        }

        _orderService.SplitOrder(_order, newOrder);
        Close();
    }

    private bool CheckIfAllNamesAreFilled()
    {
        foreach (var item in _toolsNewOrders)
        {
            if (item.Key.Text == "" || item.Key.Text == "----------------")
            {
                return false;
            }
        }

        return true;
    }
}
