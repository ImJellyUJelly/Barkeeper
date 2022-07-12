using App.Models;
using App.Services;

namespace App.Forms
{
    public partial class CustomerForm : Form
    {
        private readonly ICustomerService _customerService;
        private Customer? _selectedCustomer;

        public CustomerForm(ICustomerService customerService)
        {
            _customerService = customerService;
            InitializeComponent();
            RefreshCustomerList();

            btEdit.Enabled = false;
            btDelete.Enabled = false;
        }

        private void RefreshCustomerList()
        {
            lvCustomers.Items.Clear();
            foreach (Customer customer in _customerService.GetCustomers())
            {
                var item = new ListViewItem();
                item.Tag = customer;
                item.Text = customer.Id.ToString();
                item.SubItems.Add(customer.Name);
                lvCustomers.Items.Add(item);
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (_selectedCustomer == null)
            {
                return;
            }

            _customerService.UpdateCustomer(_selectedCustomer);
            RefreshCustomerList();
        }

        private void lvCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCustomers.SelectedItems.Count <= 0)
            {
                _selectedCustomer = null;
                btEdit.Enabled = false;
                btDelete.Enabled = false;
                return;
            }

            var customer = lvCustomers.SelectedItems[0].Tag as Customer;
            _selectedCustomer = customer;

            btEdit.Enabled = true;
            btDelete.Enabled = true;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (tbCustomer.Text == "" || tbCustomer.Text == null)
            {
                MessageBox.Show("Voer een naam in");
                return;
            }

            _customerService.FindOrCreateCustomer(tbCustomer.Text);
            RefreshCustomerList();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (_selectedCustomer == null)
            {
                return;
            }

            DialogResult dialogResult = MessageBox.Show(
                $"Weet u zeker dat u {_selectedCustomer.Name} wil verwijderen?",
                "Verwijder klant",
                MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
            {
                tbCustomer.Text = "";
                return;
            }

            _customerService.DeleteCustomer(_selectedCustomer);
            RefreshCustomerList();
        }
    }
}
