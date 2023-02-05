using App.Models;

namespace App.Forms;

public partial class BeheerderForm : Form
{
    private Session Session { get; set; }
    public BeheerderForm()
    {
        InitializeComponent();
    }

    private void cbEvent_CheckedChanged(object sender, EventArgs e)
    {

    }
}