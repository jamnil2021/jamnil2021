using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public class SummaryPropertiesModel
    {
        public string IDClass
        {
            get { return "RECORD-" + DateTime.Now.ToString("yyyy dd mm").Replace(" ", "-") + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second; }
        }
        public DateTime DateGenerated { get; set; }
        public string Title { get; set; }
        public string VesselName { get; set; }
        public decimal GrossProfit { get; set; }
        public decimal Salary { get; set; }
        public decimal Operational { get; set; }
        public decimal Maintenance { get; set; }
        public decimal Merchandise { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalExpenses
        {
            get { return Salary + Operational + Maintenance + Merchandise; }
        }
        public decimal Commission { get; set; }
        public decimal Handling { get; set; }
        public decimal Unloading { get; set; }
        public decimal NetIncome
        {
            get { return GrossProfit - (Salary + Operational + Maintenance + Merchandise + Tax + Commission + Handling + Unloading); }
        }
        public decimal TotalExpenses1 { get; set; }
        public decimal NetIncome1 { get; set; }
    }
}