namespace App.Forms
{
    public partial class TeruggaveForm : Form
    {
        public TeruggaveForm(decimal amount)
        {
            InitializeComponent();
            decimal remainder = 0 - amount;
            lbAmount.Text = $"€ {remainder}";
        }
        private void btContinue_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
