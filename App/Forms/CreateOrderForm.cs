using App.Agents;
using Models;

namespace App.Forms;

public partial class CreateOrderForm : Form
    {
        private readonly IOrderAgent _orderAgent;
        private readonly Order _order;

        public CreateOrderForm(IOrderAgent orderAgent, Order order)
        {
            InitializeComponent();
            _orderAgent = orderAgent;
            _order = order;
        }

        private void btCreateOrder_Click(object sender, EventArgs e)
        {
            if (cbCustomerName.Text == "" && tbCustomerName.Text != "")
            {
                CreateOrder(tbCustomerName.Text);
            }
            else if (tbCustomerName.Text != "" && tbCustomerName.Text == "")
            {
                CreateOrder(cbCustomerName.Text);
            }
            else
            {
                MessageBox.Show("Vul een naam in of selecteer een naam uit de lijst.");
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CreateOrder(string customerName)
        {
            _order.CustomerName = customerName;
            _orderAgent.CreateOrder(_order);
            Close();
        }
    }
