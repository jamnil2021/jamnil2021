using System;
using System.Data;
using System.Windows;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public class ReportSummaryGenerator
    {
        private SummaryConnector summaryConnector = new SummaryConnector();
        private DataTableConnector dataTableConnector = new DataTableConnector();
        private string _date = DateTime.Now.ToString("yyyy-MM-dd");
        public ReportSummaryGenerator()
        {
            foreach (DataRow dataRow in summaryConnector.SummaryRead().Rows)
            {
                if (Convert.ToDateTime(_date).DayOfWeek == DayOfWeek.Sunday && dataTableConnector.SearchExist() == false)
                {
                    SummaryPropertiesModel summaryProperties = new SummaryPropertiesModel();
                    foreach (DataRow dataGenerate in dataTableConnector.DataTableWeekPrint().Rows)
                    {
                        summaryProperties.DateGenerated = DateTime.Now;
                        summaryProperties.Title = "Weekly";
                        summaryProperties.VesselName = dataGenerate["BoatName"].ToString();
                        summaryProperties.GrossProfit = Convert.ToDecimal(dataGenerate["GrossProfit"]);
                        summaryProperties.Salary = Convert.ToDecimal(dataGenerate["TotalSalary"]);
                        summaryProperties.Operational = Convert.ToDecimal(dataGenerate["TotalOperational"]);
                        summaryProperties.Maintenance = Convert.ToDecimal(dataGenerate["TotalMaintenance"]);
                        summaryProperties.Merchandise = Convert.ToDecimal(dataGenerate["TotalMerchandise"]);
                        summaryProperties.Tax = Convert.ToDecimal(dataGenerate["Tax"]);
                        summaryProperties.Commission = Convert.ToDecimal(dataGenerate["Commission"]);
                        summaryProperties.Handling = Convert.ToDecimal(dataGenerate["Handling"]);
                        summaryProperties.Unloading = Convert.ToDecimal(dataGenerate["Unloading"]);
                        dataTableConnector.InsertSummary(summaryProperties);
                    }
                }
            }



            foreach (DataRow dataRow in summaryConnector.SummaryRead().Rows)
            {
                if (Convert.ToDateTime(_date).Day == 1 && dataTableConnector.SearchExist() == false)
                {
                    SummaryPropertiesModel summaryProperties = new SummaryPropertiesModel();
                    foreach (DataRow dataGenerate in dataTableConnector.DataTableMonthPrint().Rows)
                    {
                        summaryProperties.DateGenerated = DateTime.Now;
                        summaryProperties.Title = "Monthly";
                        summaryProperties.VesselName = dataGenerate["BoatName"].ToString();
                        summaryProperties.GrossProfit = Convert.ToDecimal(dataGenerate["GrossProfit"]);
                        summaryProperties.Salary = Convert.ToDecimal(dataGenerate["TotalSalary"]);
                        summaryProperties.Operational = Convert.ToDecimal(dataGenerate["TotalOperational"]);
                        summaryProperties.Maintenance = Convert.ToDecimal(dataGenerate["TotalMaintenance"]);
                        summaryProperties.Merchandise = Convert.ToDecimal(dataGenerate["TotalMerchandise"]);
                        summaryProperties.Tax = Convert.ToDecimal(dataGenerate["Tax"]);
                        summaryProperties.Commission = Convert.ToDecimal(dataGenerate["Commission"]);
                        summaryProperties.Handling = Convert.ToDecimal(dataGenerate["Handling"]);
                        summaryProperties.Unloading = Convert.ToDecimal(dataGenerate["Unloading"]);
                        dataTableConnector.InsertSummary(summaryProperties);
                    }
                }
            }

            foreach (DataRow dataRow in summaryConnector.SummaryRead().Rows)
            {
                if (Convert.ToDateTime(_date).DayOfYear == 1 && dataTableConnector.SearchExist() == false)
                {
                    SummaryPropertiesModel summaryProperties = new SummaryPropertiesModel();
                    foreach (DataRow dataGenerate in dataTableConnector.DataTableYearPrint().Rows)
                    {
                        summaryProperties.DateGenerated = DateTime.Now;
                        summaryProperties.Title = "Yearly";
                        summaryProperties.VesselName = dataGenerate["BoatName"].ToString();
                        summaryProperties.GrossProfit = Convert.ToDecimal(dataGenerate["GrossProfit"]);
                        summaryProperties.Salary = Convert.ToDecimal(dataGenerate["TotalSalary"]);
                        summaryProperties.Operational = Convert.ToDecimal(dataGenerate["TotalOperational"]);
                        summaryProperties.Maintenance = Convert.ToDecimal(dataGenerate["TotalMaintenance"]);
                        summaryProperties.Merchandise = Convert.ToDecimal(dataGenerate["TotalMerchandise"]);
                        summaryProperties.Tax = Convert.ToDecimal(dataGenerate["Tax"]);
                        summaryProperties.Commission = Convert.ToDecimal(dataGenerate["Commission"]);
                        summaryProperties.Handling = Convert.ToDecimal(dataGenerate["Handling"]);
                        summaryProperties.Unloading = Convert.ToDecimal(dataGenerate["Unloading"]);
                        dataTableConnector.InsertSummary(summaryProperties);
                    }
                }
            }
        }
    }
}
