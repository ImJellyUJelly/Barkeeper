using App.Services;

namespace App.Forms
{
    public partial class OmzetOverzichtForm : Form
    {
        public OmzetOverzichtForm(IRevenueService revenueService)
        {
            InitializeComponent();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
