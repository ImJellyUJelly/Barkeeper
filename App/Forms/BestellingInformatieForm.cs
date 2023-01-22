using App.Models;
using App.Services;

namespace App.Forms
{
    public partial class BestellingInformatieForm : Form
    {
        private bool _canEdit = true;

        private IMoneyCalculator Calculator { get; }
        private IOrderService OrderService { get; }

        private Order Order { get; set; }
        public BestellingInformatieForm(IOrderService orderService, IMoneyCalculator calculator, Order order, bool canEdit)
        {
            InitializeComponent();
            Calculator = calculator;
            OrderService = orderService;
            Order = order;
            _canEdit = canEdit;

            InitialLoad();
        }

        private void InitialLoad()
        {
            if (Order == null) return;

            tbName.Enabled = _canEdit;
            cbIsMember.Enabled = _canEdit;
            cbIsFinished.Enabled = _canEdit;
            cbIsPaid.Enabled = _canEdit;

            tbName.Text = Order.Customer?.Name;
            lbOrderDate.Text = $"{Order.OrderDate.ToShortDateString()} - {Order.OrderDate.ToShortTimeString()}";
            cbIsMember.Checked = Order.IsMember;
            cbIsFinished.Checked = Order.IsFinished;
            cbIsPaid.Checked = Order.IsPaid;
            tbComment.Text = Order.Comment;

            FillProducts();
            CalculatePrice();
        }

        private void FillProducts()
        {
            lvProducts.Items.Clear();
            foreach (OrderDetail detail in Order.OrderDetails)
            {
                var item = new ListViewItem();
                item.Tag = detail;
                item.Text = detail.Product.Name;
                if (Order.IsMember)
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

        private void btClose_Click(object sender, EventArgs e) => Close();

        private void btSave_Click(object sender, EventArgs e)
        {
            Order.IsFinished = cbIsFinished.Checked;
            Order.IsPaid = cbIsPaid.Checked;
            Order.Comment = tbComment.Text == "" ? null : tbComment.Text;
            OrderService.UpdateOrder(Order, Order.IsMember);
            Close();
        }

        private void CalculatePrice()
        {
            lbPrice.Text = $"€ {Calculator.PricePerOrder(Order)}";
            lbPaidAmount.Text = $"€ {Order.PaidAmount}";
        }

        private void cbIsMember_Click(object sender, EventArgs e)
        {
            Order.IsMember = cbIsMember.Checked;
            FillProducts();
            CalculatePrice();
        }
    }
}
