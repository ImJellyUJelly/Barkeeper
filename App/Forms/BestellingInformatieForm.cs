using App.Models;
using App.Services;

namespace App.Forms
{
    public partial class BestellingInformatieForm : Form
    {
        private bool _canEdit = true;

        private Order Order { get; set; }
        public BestellingInformatieForm(IOrderService orderService, ISessionService sessionService, Order order, bool canEdit)
        {
            InitializeComponent();
            OrderService = orderService;
            SessionService = sessionService;
            Order = order;
            _canEdit = canEdit;

            InitialLoad();
        }

        private ISessionService SessionService { get; }
        private IOrderService OrderService { get; }

        private void InitialLoad()
        {
            if (Order == null) return;

            tbName.Enabled = _canEdit;
            cbIsFinished.Enabled = _canEdit;
            cbIsPaid.Enabled = _canEdit;

            tbName.Text = Order.GetName();
            lbOrderDate.Text = $"{Order.OrderDate.ToShortDateString()} - {Order.OrderDate.ToShortTimeString()}";
            cbIsFinished.Checked = Order.IsFinished;
            cbIsPaid.Checked = Order.IsPaid;
            tbComment.Text = Order.Comment;

            FillProducts();
            UpdatePrice();
        }

        private void FillProducts()
        {
            lvProducts.Items.Clear();
            foreach (OrderDetail detail in Order.OrderDetails)
            {
                var item = new ListViewItem();
                item.Tag = detail;
                item.Text = detail.Product.Name;
                if (SessionService.BoughtDuringEvent(detail.TimeAdded))
                {
                    item.SubItems.Add($"€ {detail.Product.EventPrice}");
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
            Order.Comment = tbComment.Text == "" ? string.Empty : tbComment.Text;
            OrderService.UpdateOrder(Order);
            Close();
        }

        private void UpdatePrice()
        {
            OrderService.UpdateOrder(Order);
            lbPrice.Text = $"€ {Order.Price}";
            lbPaidAmount.Text = $"€ {Order.PaidAmount}";
        }
    }
}
