using App.Services;

namespace App.Forms;

public partial class OptiesForm : Form
{
    private IGeneralOptionsService GeneralOptionsService { get; }

    public OptiesForm(IGeneralOptionsService service)
    {
        GeneralOptionsService = service;
        InitializeComponent();
        nudProductSize.Value = service.GetGeneralOptions().ProductButtonSize;
    }

    private void btSave_Click(object sender, EventArgs e)
    {
        GeneralOptionsService.UpdateGeneralOptions((int)nudProductSize.Value);
        Close();
    }
}
