using App.Services;
using Models;

namespace App.Forms
{
    public partial class SplitBestellingForm : Form
    {
        private readonly IOrderService _orderService;
        private readonly Order _order;

        public SplitBestellingForm(IOrderService orderService, Order order)
        {
            _orderService = orderService;
            _order = order;
            InitializeComponent();
        }
    }
}
