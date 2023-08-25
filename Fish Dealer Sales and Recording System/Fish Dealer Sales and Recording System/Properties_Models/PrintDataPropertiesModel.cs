using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public class PrintDataPropertiesModel
    {
        public DateTime DateGenerated { get; set; }
        public string Title { get; set; }
        public string VesselName { get; set; }
        public decimal GrossProfit { get; set; }
        public decimal Salary { get; set; }
        public decimal Operational { get; set; }
        public decimal Maintenance { get; set; }
        public decimal Merchandise { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal Commission { get; set; }
        public decimal Handling { get; set; }
        public decimal Unloading { get; set; }
        public decimal NetIncome { get; set; }

        // For Costumers Data
        public string Date { get; set; }
        public string Vendor { get; set; }
        public string Variety { get; set; }
        public int Bucket { get; set; }
        public int Kilo { get; set; }
        public decimal UnitKiloPrice { get; set; }
        public decimal UnitBucketPrice { get; set; }
        public decimal TotalPrice { get; set; }
        //public decimal TotalExpenses
        //{
        //    get { return (Salary + Operational + Maintenance + Merchandise);  }
        //}
        //public decimal NetIncome
        //{
        //    get { return (GrossProfit -(TotalExpenses+Tax)); }
        //}
    }
}
