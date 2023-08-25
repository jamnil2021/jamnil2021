using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public class UpdateStocksPropertiesModel
    {
        public string IDClass { get; set; }
        public string Variety { get; set; }
        public int NoBucket { get; set; }
        public int NoKilo { get; set; }
        public int MBucket { get; set; }
        public int MKilo { get; set; }
    }
}
