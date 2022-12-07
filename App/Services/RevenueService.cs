using App.Models;
using App.Repositories;
using Syncfusion.XlsIO;

namespace App.Services
{
    internal class RevenueService : IRevenueService
    {
        private readonly IRevenueRepository _revenueRepository;

        private int Year { get; set; }

        public RevenueService(IRevenueRepository revenueRepository)
        {
            _revenueRepository = revenueRepository;
        }

        public void AddPayment(Revenue revenue)
        {
            _revenueRepository.AddPayment(revenue);
        }

        public List<Revenue> GetRevenues()
        {
            return _revenueRepository.GetRevenues();
        }

        public List<Revenue> GetRevenuesBetweenDates(DateTime startDate, DateTime endDate)
        {
            return _revenueRepository.GetRevenuesBetweenDates(startDate, endDate);
        }

        public void ExportRevenues(List<Revenue> revenues)
        {
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2016;

                //Reads input Excel stream as a workbook
                IWorkbook workbook = application.Workbooks.Open(File.OpenRead(Path.GetFullPath(Constants.Constants.ExportRevenuePath)));
                IWorksheet sheet = workbook.Worksheets[0];

                //Preparing first array with different data types
                double[] expenseArray = new double[14];

                //Inserting a new row by formatting as a previous row.
                sheet.InsertRow(11, 1, ExcelInsertOptions.FormatAsBefore);

                //Import Peter's expenses and fill it horizontally
                sheet.ImportArray(expenseArray, 11, 1, false);

                //Preparing second array with double data type
                double[] expensesOnDec = new double[0];

                //Modify the December month's expenses and import it vertically
                sheet.ImportArray(expensesOnDec, 6, 13, true);

                //Save the file in the given path
                Stream excelStream = File.Create(Path.GetFullPath(@$"Omzet_{Year}.xlsx"));
                workbook.SaveAs(excelStream);
                excelStream.Dispose();
            }
        }
    }
}
