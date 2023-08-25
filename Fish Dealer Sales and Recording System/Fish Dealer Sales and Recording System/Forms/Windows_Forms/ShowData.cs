using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public partial class ShowData : Form
    {
        private DataTableConnector _tableConnector = new DataTableConnector();
        ReportSalesSummary salesSummary = new ReportSalesSummary();
        public ShowData(List<ExportPropertiesModel> _listExport, DateDeparturePropertiesModel _dateDeparture)
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
        }
        public ShowData(List<PrintDataPropertiesModel> _listPrintData)
        {
            InitializeComponent();
            ReportCostumersData reportCostumers = new ReportCostumersData();
            reportCostumers.SetDataSource(_listPrintData);
            crystalReportViewer1.ReportSource = reportCostumers;
            crystalReportViewer1.Refresh();
        }

        public ShowData(List<PrintDataPropertiesModel> _listPrintData, bool? name)
        {
            InitializeComponent();
            ReportGenerated reportCostumers = new ReportGenerated();
            reportCostumers.SetDataSource(_listPrintData);
            crystalReportViewer1.ReportSource = reportCostumers;
            crystalReportViewer1.Refresh();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
