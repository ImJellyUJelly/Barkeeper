namespace App.Forms;

public partial class PinForm : Form
{
    public bool IsClosed { get; private set; }
    public decimal Payment { get; private set; }

    public PinForm(decimal price)
    {
        InitializeComponent();
        nudPayment.Value = price;
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
        IsClosed = true;
        Close();
    }

    private void btContinue_Click(object sender, EventArgs e)
    {
        Payment = nudPayment.Value;
        Close();
    }
}
