using App.Services;
using Models;

namespace App.Forms
{
    public partial class SplitBestellingForm : Form
    {
        private readonly IOrderService _orderService;
        private readonly Order _order;

        private int _numberOfNewOrders = 2;
        private Dictionary<TextBox, NumericUpDown> _toolsNewOrders = new Dictionary<TextBox, NumericUpDown>();

        public SplitBestellingForm(IOrderService orderService, Order order)
        {
            _orderService = orderService;
            _order = order;
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            lbId.Text = _order.Id.ToString();
            lbCustomerName.Text = _order.CustomerName;
            lbOrderDate.Text = $"{_order.OrderDate.ToShortTimeString()} - {_order.OrderDate.ToShortDateString()}";
            lbPrice.Text = $"€ {_order.Price}";
            cbIsMember.Checked = _order.IsMember;
            cbIsFinished.Checked = _order.IsFinished;
            cbIsPaid.Checked = _order.IsPaid;
            tbComment.Text = _order.Comment;

            _toolsNewOrders.Add(tbCustomer1, nudCustomer1);
            _toolsNewOrders.Add(tbCustomer2, nudCustomer2);
            SetPriceForNewOrders();
        }

        private void btAddCustomer_Click(object sender, EventArgs e)
        {
            Label lbCustomerName = new Label();
            lbCustomerName.Text = "Naam:";
            lbCustomerName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbCustomerName.Size = new Size(68, 28);
            lbCustomerName.Location = new Point(18, (232 + (_toolsNewOrders.Count * 40)));
            this.Controls.Add(lbCustomerName);

            TextBox tbCustomerName = new TextBox();
            tbCustomerName.TabIndex = _toolsNewOrders.Count + 1;
            tbCustomerName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbCustomerName.Size = new Size(528, 34);
            tbCustomerName.Location = new Point(92, (229 + (_toolsNewOrders.Count * 40)));
            this.Controls.Add(tbCustomerName);

            Label lbPrice = new Label();
            lbPrice.Text = "Prijs:";
            lbPrice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbPrice.Size = new Size(52, 28);
            lbPrice.Location = new Point(653, (232 + (_toolsNewOrders.Count * 40)));
            this.Controls.Add(lbPrice);

            Label lbEuroSign = new Label();
            lbEuroSign.Text = "€";
            lbEuroSign.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbEuroSign.Size = new Size(23, 28);
            lbEuroSign.Location = new Point(711, (232 + (_toolsNewOrders.Count * 40)));
            this.Controls.Add(lbEuroSign);

            NumericUpDown nudPrice = new NumericUpDown();
            nudPrice.Minimum = 0;
            nudPrice.Maximum = 99999999999;
            nudPrice.DecimalPlaces = 2;
            nudPrice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            nudPrice.Size = new Size(100, 34);
            nudPrice.Location = new Point(738, (232 + (_toolsNewOrders.Count * 40)));
            this.Controls.Add(nudPrice);

            _toolsNewOrders.Add(tbCustomerName, nudPrice);
            _numberOfNewOrders++;
            SetPriceForNewOrders();

            if(Height <= (tbCustomerName.Location.Y + tbCustomerName.Height + 34))
            {
                Height += tbCustomerName.Height;
            }
        }

        private void SetPriceForNewOrders()
        {
            decimal price = _order.Price / _numberOfNewOrders;
            foreach(var dict in _toolsNewOrders)
            {
                dict.Value.Value = price;
            }
        }
    }
}
