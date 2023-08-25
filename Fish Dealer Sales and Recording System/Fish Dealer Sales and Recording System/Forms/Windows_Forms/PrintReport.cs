using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public partial class PrintReport : Form
    {
        private DataTableConnector _tableConnector = new DataTableConnector();
        ReportSalesSummary salesSummary = new ReportSalesSummary();

        public PrintReport(List<ExportPropertiesModel> _listExport, DateDeparturePropertiesModel _dateDeparture)
        {
            InitializeComponent();
            
            salesSummary.SetParameterValue("parDockingDate", _dateDeparture.Docking);
            salesSummary.SetParameterValue("parCastOffDate", _dateDeparture.CastOff);
            salesSummary.SetParameterValue("parBoatName", _dateDeparture.VesselName);
            crystalReportViewer1.ReportSource = salesSummary;
            crystalReportViewer1.Refresh();

            foreach (DataRow dataRow in _tableConnector.DataTablePrint(_dateDeparture.IDClass).Rows)
            {
                salesSummary.SetParameterValue("parGross", Convert.ToDecimal(dataRow["GrossProfit"]));
                salesSummary.SetParameterValue("parMerchandise", Convert.ToDecimal(dataRow["TotalMerchandise"]));
                salesSummary.SetParameterValue("parSalary", Convert.ToDecimal(dataRow["TotalSalary"]));
                salesSummary.SetParameterValue("parOperational", Convert.ToDecimal(dataRow["TotalOperational"]));
                salesSummary.SetParameterValue("parMaintenance", Convert.ToDecimal(dataRow["TotalMaintenance"]));
                salesSummary.SetParameterValue("parTotal", Convert.ToDecimal(dataRow["TotalMaintenance"]) + Convert.ToDecimal(dataRow["TotalOperational"]) + Convert.ToDecimal(dataRow["TotalSalary"]) + Convert.ToDecimal(dataRow["TotalMerchandise"]));
                salesSummary.SetParameterValue("parCommission", Convert.ToDecimal(dataRow["Commission"]));
                salesSummary.SetParameterValue("parHandling", Convert.ToDecimal(dataRow["Handling"]));
                salesSummary.SetParameterValue("parUnloading", Convert.ToDecimal(dataRow["Unloading"]));
                salesSummary.SetParameterValue("parTax", Convert.ToDecimal(dataRow["Tax"]) * Convert.ToDecimal(dataRow["TotalTubs"]));
                salesSummary.SetParameterValue("parNet", Convert.ToDecimal(dataRow["GrossProfit"]) - (Convert.ToDecimal(dataRow["TotalMaintenance"]) + Convert.ToDecimal(dataRow["TotalOperational"]) + Convert.ToDecimal(dataRow["TotalSalary"]) + Convert.ToDecimal(dataRow["TotalMerchandise"]) + Convert.ToDecimal(dataRow["Commission"]) + Convert.ToDecimal(dataRow["Handling"]) + Convert.ToDecimal(dataRow["Unloading"]) + Convert.ToDecimal(dataRow["Tax"])));
            }
            // Printer Setup
            salesSummary.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
            salesSummary.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;

            //Print the File
            salesSummary.PrintToPrinter(1, false, 0, 0);
        }

        public PrintReport(List<PrintDataPropertiesModel> _listPrintData)
        {
            InitializeComponent();
            ReportCostumersData reportCostumers = new ReportCostumersData();
            reportCostumers.SetDataSource(_listPrintData);
            crystalReportViewer1.ReportSource = reportCostumers;
            crystalReportViewer1.Refresh();

            // Printer Setup
            reportCostumers.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
            reportCostumers.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;

            //Print the File
            reportCostumers.PrintToPrinter(1, false, 0, 0);

        }

        public PrintReport(List<PrintDataPropertiesModel> _listPrintData, bool? name)
        {
            InitializeComponent();
            ReportGenerated reportCostumers = new ReportGenerated();
            reportCostumers.SetDataSource(_listPrintData);
            crystalReportViewer1.ReportSource = reportCostumers;
            crystalReportViewer1.Refresh();

            // Printer Setup
            reportCostumers.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
            reportCostumers.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;

            //Print the File
            reportCostumers.PrintToPrinter(1, false, 0, 0);

        } 

        private void BtnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrintReport_Load(object sender, EventArgs e)
        {
            Timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {

        }
    }
}
