using App.Models;
using App.Services;

namespace App.Forms;

public partial class KlantDetailForm : Form
{
    private readonly ICustomerService _customerService;

    internal Customer Customer { get; private set; }

    public KlantDetailForm(ICustomerService customerService, Customer customer)
    {
        _customerService = customerService;
        Customer = customer;
        InitializeComponent();

        if(customer != null)
        {
            tbName.Text = customer.Name;
            cbIsMember.Checked = customer.IsMember;
        }
    }

    private void btSave_Click(object sender, EventArgs e)
    {
        if (tbName.Text == null || tbName.Text == "")
        {
            MessageBox.Show("Vul een naam in.");
            return;
        }

        Customer = new Customer { Name = tbName.Text, IsMember = cbIsMember.Checked };
        _customerService.UpdateOrCreateCustomer(Customer);
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
        Close();
    }
}
