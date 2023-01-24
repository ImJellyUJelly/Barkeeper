using App.Models;
using App.Services;

namespace App.Forms;

public partial class CustomerForm : Form
{
    private readonly ICustomerService _customerService;
    private Customer? _selectedCustomer;

    public CustomerForm(ICustomerService customerService)
    {
        _customerService = customerService;
        InitializeComponent();
        RefreshCustomerList();
    }

    private void RefreshCustomerList()
    {
        btEdit.Enabled = false;
        btDelete.Enabled = false;
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

        var form = new KlantDetailForm(_customerService, _selectedCustomer);
        form.Show();
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
        KlantDetailForm form = new KlantDetailForm(_customerService, null);
        form.ShowDialog();
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

        if (dialogResult == DialogResult.Yes)
        {
            _customerService.DeleteCustomer(_selectedCustomer);
        }

        RefreshCustomerList();
    }
}