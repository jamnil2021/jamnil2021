using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public class TaxPropertiesModel
    {
        public Int64 No { get; set; }
        public string IDClass { get; set; }
        public DateTime Date { get; set; }
        public decimal Tax { get; set; }
        public string Vendor { get; set; }
        public decimal Commission { get; set; }
        public decimal Unloading { get; set; }
        public decimal Handling { get; set; }
        public decimal NoBucket { get; set; }
        public decimal NoKilo { get; set; }
        public string Variety { get; set; }
        public decimal PriceBucket { get; set; }
        public decimal PriceKilo { get; set; }
        public decimal CBucket { get; set; }
        public decimal CKilo { get; set; }
        public decimal TotalCommission
        {
            get => (Commission / 100) * ((NoBucket * PriceBucket) + (NoKilo * PriceKilo));
        }
        public decimal TotalPrice
        {
            get => (NoBucket * PriceBucket) + (NoKilo * PriceKilo);
        }
    }
}
