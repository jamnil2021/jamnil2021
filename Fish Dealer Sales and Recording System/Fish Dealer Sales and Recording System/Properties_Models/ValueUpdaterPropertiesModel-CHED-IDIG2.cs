using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public class ValueUpdaterPropertiesModel
    {
        public string ItemName { get; set; }
        public int ItemValue { get; set; }
        public string ValueName { get; set; }
        public int NewItemValue { get; set; }
        public DataTable itemTable { get; set; }
        public ValueUpdaterPropertiesModel()
        {
            itemTable = new DataTable();
        }
    }
}
