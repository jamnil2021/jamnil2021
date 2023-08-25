using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public class ExportPropertiesModel
    {
        public int No { get; set; }
        public string IDClass { get; set; }
        public DateTime Date { get; set; }
        public String Vendor { get; set; }
        public string Variety { get; set; }
        public decimal Bucket { get; set; }
        public decimal Kilo { get; set; }
        public decimal CBucket { get; set; }
        public decimal CKilo { get; set; }
        public decimal UnitBucketPrice { get; set; }
        public decimal UnitKiloPrice { get; set; }
        public decimal TotalPrice1
        {
            get => (Bucket * UnitBucketPrice) + (Kilo * UnitKiloPrice);
        }
    }
}
