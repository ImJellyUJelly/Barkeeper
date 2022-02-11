using App.Services;
using Models;
using System.Globalization;

namespace App.Forms
{
    public partial class BestellingOverzichtForm : Form
    {
        private readonly IOrderService _orderService;

        public BestellingOverzichtForm(IOrderService orderService)
        {
            _orderService = orderService;

            InitializeComponent();
            InitializeLoadOrders();
        }

        private void InitializeLoadOrders()
        {
            lvOrders.Items.Clear();
            List<Order> orders = _orderService.GetOrders()
                .OrderBy(order => order.IsPaid)
                .ThenBy(order => order.OrderDate)
                .ToList();

            foreach (Order order in orders)
            {
                var item = new ListViewItem();
                item.Tag = order;
                item.Text = order.Id.ToString();
                item.SubItems.Add(order.CustomerName);
                if (order.IsMember)
                {
                    item.SubItems.Add("Ja");
                }
                else
                {
                    item.SubItems.Add("Nee");
                }
                item.SubItems.Add($"{order.OrderDate.ToString("dd/MM/yyyy")} - {order.OrderDate.ToShortTimeString()}");
                if (order.IsPaid)
                {
                    item.SubItems.Add("Ja");
                }
                else
                {
                    item.SubItems.Add("Nee");
                }
                item.SubItems.Add(order.OrderDetails.Count.ToString());
                lvOrders.Items.Add(item);
            }
        }
    }
}
