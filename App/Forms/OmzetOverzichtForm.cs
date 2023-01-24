using App.Extensions;
using App.Models;
using App.Services;

namespace App.Forms
{
    public partial class OmzetOverzichtForm : Form
    {
        private IRevenueService service;
        private List<TextBox> monthTextboxes;
        private List<TextBox> dayTextboxes;
        private List<Label> dayLabels;
        private List<string> months;
        private readonly DateTime currentDate = DateTime.Now;

        public OmzetOverzichtForm(IRevenueService revenueService)
        {
            InitializeComponent();
            service = revenueService;
            FillTextBoxLists();
            FillWeeklyRevenue();
            FillMonthlyRevenue(currentDate.Year);
        }

        private void FillTextBoxLists()
        {
            months = new List<string>
            {
                "Januari",
                "Februari",
                "Maart",
                "April",
                "Mei",
                "Juni",
                "Juli",
                "Augustus",
                "September",
                "Oktober",
                "November",
                "December"
            };

            monthTextboxes = new List<TextBox>
            {
                tbJanuary,
                tbFebruary,
                tbMarch,
                tbApril,
                tbMay,
                tbJune,
                tbJuly,
                tbAugust,
                tbSeptember,
                tbOctober,
                tbNovember,
                tbDecember
            };

            dayTextboxes = new List<TextBox>
            {
                tbMonday,
                tbTuesday,
                tbWednesday,
                tbThursday,
                tbFriday,
                tbSaturday,
                tbSunday
            };

            dayLabels = new List<Label>
            {
                lbMonday,
                lbTuesday,
                lbWednesday,
                lbThursday,
                lbFriday,
                lbSaturday,
                lbSunday
            };

            for (int i = currentDate.Year; i > currentDate.Year - 2; i--)
            {
                cbYears.Items.Add(i);
            }
            cbYears.SelectedIndex = 0;
        }

        private void FillMonthlyRevenue(int year)
        {
            try
            {
                for (int i = 0; i < 12; i++)
                {
                    DateTime datum = new DateTime(year, 1, 1).AddMonths(i);
                    var omzet = service.GetRevenueBetweenDates(datum, datum.AddMonths(1));
                    monthTextboxes[i].Text = $"{omzet.ToString("C")}";
                }
                tbJaarOmzet.Text = $"{service.GetRevenueBetweenDates(new DateTime(year, 1, 1), new DateTime(year + 1, 1, 1)).ToString("C")}";
            }
            catch (Exception exception)
            {
                //MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine +
                //                exception.Message);
            }
        }

        private void FillWeeklyRevenue()
        {
            try
            {
                DateTime datum = DateTime.Now.StartOfWeek();
                for (int i = 0; i < dayTextboxes.Count; i++)
                {
                    var omzet = service.GetRevenueBetweenDates(datum, datum.AddDays(1));
                    dayTextboxes[i].Text = $"{omzet.ToString("C")}";
                    dayLabels[i].Text = datum.ToShortDateString();
                    datum = datum.AddDays(1);
                }
            }
            catch (Exception exception)
            {
                //MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine +
                //                exception.Message);
            }
        }

        private void cbYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbYears.Text) > 2000)
            {
                FillMonthlyRevenue(Convert.ToInt32(cbYears.Text));
            }
        }

        private void UpdateListView(Order order, ListView listView)
        {
            ListViewItem lvi = new ListViewItem(order.Price.ToString("C"));
            lvi.SubItems.Add(order.Comment);
            lvi.SubItems.Add($"{order.OrderDate.ToShortDateString()}");
            lvi.SubItems.Add($"{order.OrderDate.ToShortTimeString()}");
            lvi.Tag = order;
            listView.Items.Add(lvi);
        }

        private void btExportToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "CSV file (*.csv)|*.csv";
            dialog.ShowDialog();

            var revenues = service.GetRevenuesForFileExport();

            var result = dialog.FileName;
            try
            {
                using (var file = File.Create(result))
                using (var writer = new StreamWriter(file))
                {
                    foreach (var revenue in revenues)
                    {
                        writer.WriteLine(revenue.Amount);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er is een error opgetreden!" + Environment.NewLine + Environment.NewLine + ex.Message);
                Console.WriteLine(ex.Message);
            }
        }
    }
}
