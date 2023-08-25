using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Fish_Dealer_Sales_and_Recording_System.Forms.User_Controls;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public partial class Statistic : UserControl
    {
        private string ActiveStat = "Bucket";

        public Statistic()
        {
            InitializeComponent();
        }

        private void Statistic_Load(object sender, EventArgs e)
        {
            SwitchPanel(new StatisticBucket(dtpFromDate.Value, dtpToDate.Value));
            btnBack.Enabled = false;
        }

        private void SwitchPanel(UserControl form)
        {
            form.Dock = DockStyle.Fill;
            panelToForm.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            SwitchPanel(new StatisticKilo(dtpFromDate.Value, dtpToDate.Value));
            btnNext.Enabled = false;
            btnBack.Enabled = true;
            ActiveStat = "Kilo";
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            SwitchPanel(new StatisticBucket(dtpFromDate.Value, dtpToDate.Value));
            btnBack.Enabled = false;
            btnNext.Enabled = true;
            ActiveStat = "Bucket";
        }


        private void DtpToDate_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(dtpFromDate.Value.Date, dtpToDate.Value.Date) == 0 || DateTime.Compare(dtpFromDate.Value.Date, dtpToDate.Value.Date) == -1)
            {
                SwitchPanel(new StatisticBucket(dtpFromDate.Value, dtpToDate.Value));
            }
            else
            {
                MessageBox.Show("Invalid Date! From Date must Lower or Equal to To Date!");
            }
        }

        private void DtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            
            if (DateTime.Compare(dtpFromDate.Value.Date, dtpToDate.Value.Date) == 0 || DateTime.Compare(dtpFromDate.Value.Date, dtpToDate.Value.Date) == -1)
            {
                SwitchPanel(new StatisticBucket(dtpFromDate.Value, dtpToDate.Value));
            }
            else
            {
                MessageBox.Show("Invalid Date! From Date must Lower or Equal to To Date!");
            }
        }
    }
}
