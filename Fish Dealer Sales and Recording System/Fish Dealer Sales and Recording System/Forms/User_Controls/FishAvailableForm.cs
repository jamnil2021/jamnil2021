using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public partial class FishAvailableForm : UserControl
    {
        private string variety;
        private decimal bucket;
        private decimal kilo;

        public FishAvailableForm(FlowLayoutPanel panel)
        {
            InitializeComponent();
            this.Height = panel.Height;
            this.Width = (panel.Width - 50) / 2;
        }

        [Category("Fish Data")]
        public string Variety
        {
            get { return variety; }
            set { variety = value; lblVariety.Text = Convert.ToString(value); }
        }

        [Category("Fish Data")]
        public decimal Bucket
        {
            get { return bucket; }
            set { bucket = value; lblBucket.Text = Convert.ToString(value)  + " Bucket/s"; }
        }

        [Category("Fish Data")]
        public decimal Kilo
        {
            get { return kilo; }
            set { kilo = value; lblKilo.Text = Convert.ToString(value) + " Kilo/s"; }
        }

    }
}
