using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public class DateDeparturePropertiesModel
    {
        public int No { get; set; }
        public string CastOff { get; set; }
        public string Docking { get; set; }
        public string VesselName { get; set; }
        public bool boolEdit { get; set; }
        public string IDClass { get; set; }
        public string GetIDNo
        {
            get { return "RECORD-" + DateTime.Now.ToString("yyyy dd mm").Replace(" ", "-") + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second; }
        }
    }
}
