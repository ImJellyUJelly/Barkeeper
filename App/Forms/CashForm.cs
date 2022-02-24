namespace App.Forms;

public partial class CashForm : Form
{
    public bool IsClosed { get; private set; }
    public decimal Payment { get; private set; }

    public CashForm()
    {
        InitializeComponent();
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
        IsClosed = true;
        Close();
    }

    private void btPay_Click(object sender, EventArgs e)
    {
        Payment = nudPayment.Value;
        Close();
    }
}
