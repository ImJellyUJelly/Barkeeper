using App.Services;
using App.Models;

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
            int heightdivider = tbCustomer2.Location.Y - (tbCustomer1.Location.Y + tbCustomer1.Height);

            Label lbCustomerName = new Label();
            lbCustomerName.Text = "Naam:";
            lbCustomerName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbCustomerName.Size = new Size(lbCustomer1.Width, lbCustomer1.Height);
            lbCustomerName.Location = new Point(lbCustomer1.Location.X, (lbCustomer1.Location.Y + (_toolsNewOrders.Count * (tbCustomer1.Height + heightdivider))));
            this.Controls.Add(lbCustomerName);

            TextBox tbCustomerName = new TextBox();
            tbCustomerName.TabIndex = _toolsNewOrders.Count + 1;
            tbCustomerName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbCustomerName.Size = new Size(tbCustomer1.Width, tbCustomer1.Height);
            tbCustomerName.Location = new Point(tbCustomer1.Location.X, (tbCustomer1.Location.Y + (_toolsNewOrders.Count * (tbCustomer1.Height + heightdivider))));
            this.Controls.Add(tbCustomerName);

            Label lbPrice = new Label();
            lbPrice.Text = "Prijs:";
            lbPrice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbPrice.Size = new Size(lbPrice1.Width, lbPrice1.Height);
            lbPrice.Location = new Point(lbPrice1.Location.X, (lbPrice1.Location.Y + (_toolsNewOrders.Count * (tbCustomer1.Height + heightdivider))));
            this.Controls.Add(lbPrice);

            Label lbEuroSign = new Label();
            lbEuroSign.Text = "€";
            lbEuroSign.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbEuroSign.Size = new Size(lbEuro1.Width, lbEuro1.Height);
            lbEuroSign.Location = new Point(lbEuro1.Location.X, (lbEuro1.Location.Y + (_toolsNewOrders.Count * (tbCustomer1.Height + heightdivider))));
            this.Controls.Add(lbEuroSign);

            NumericUpDown nudPrice = new NumericUpDown();
            nudPrice.Minimum = 0;
            nudPrice.Maximum = 99999999999;
            nudPrice.DecimalPlaces = 2;
            nudPrice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            nudPrice.Size = new Size(nudCustomer1.Width, nudCustomer1.Height);
            nudPrice.Location = new Point(nudCustomer1.Location.X, (nudCustomer1.Location.Y + (_toolsNewOrders.Count * (tbCustomer1.Height + heightdivider))));
            this.Controls.Add(nudPrice);

            _toolsNewOrders.Add(tbCustomerName, nudPrice);
            _numberOfNewOrders++;
            SetPriceForNewOrders();

            if (Height <= (tbCustomerName.Location.Y + tbCustomerName.Height + 34))
            {
                Height += tbCustomerName.Height;
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
    }
}
