using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fish_Dealer_Sales_and_Recording_System.Forms.User_Controls
{
    public partial class StatisticKilo : UserControl
    {
        private DateTime fromDate;
        private DateTime toDate;
        private DataTable _variety;
        private DataTable _bucket;
        private DataTable _dummyData;
        private int _count = 0;
        public StatisticKilo(DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            this.fromDate = fromDate;
            this.toDate = toDate;
        }

        private void StatisticKilo_Load(object sender, EventArgs e)
        {
            _variety = new StatisticDataReader().VarietyData(fromDate, toDate);
            _bucket = new StatisticDataReader().StatisticData(fromDate, toDate);
            _dummyData = new StatisticDataReader().DummyStatistic();
            _count = _variety.Rows.Count;
            if (_variety.Rows.Count > 0 && _bucket.Rows.Count > 0)
            {
                chartKilo.Series.Clear();
                chartKilo.Titles.Clear();
                dgvKilo.Rows.Clear();
                decimal totalKilo = 0;
                decimal totalBucket = 0;
                this.chartKilo.Titles.Add("KILO/S");
                foreach (DataRow dataRow in _variety.Rows)
                {
                    totalKilo = 0;
                    totalBucket = 0;
                    this.chartKilo.Series.Add(dataRow["Variety"].ToString());
                    foreach (DataRow rowofBucket in _bucket.Rows)
                    {
                        if (dataRow["Variety"].ToString() == rowofBucket["Variety"].ToString())
                        {
                            totalBucket = totalBucket + Convert.ToDecimal(rowofBucket["Bucket"]);
                            totalKilo = totalKilo + Convert.ToDecimal(rowofBucket["Kilo"]);
                        }
                    }
                    chartKilo.Series[Convert.ToString(dataRow["Variety"])].Points.AddY(totalKilo);
                    chartKilo.Series[Convert.ToString(dataRow["Variety"])].ToolTip = totalKilo.ToString();
                    dgvKilo.Rows.Add(dataRow["Variety"].ToString(), totalKilo);
                }
                this.dgvKilo.Sort(this.dgvKilo.Columns[1], ListSortDirection.Descending);
            }
            /*else
            {
                chartKilo.Series.Clear();
                chartKilo.Titles.Clear();
                dgvKilo.Rows.Clear();
                decimal totalKilo = 0;
                decimal totalBucket = 0;
                this.chartKilo.Titles.Add("KILO/S");
                foreach (DataRow dataRow in _dummyData.Rows)
                {
                    totalKilo = 0;
                    totalBucket = 0;
                    this.chartKilo.Series.Add(dataRow["Variety"].ToString());
                    foreach (DataRow rowofBucket in _dummyData.Rows)
                    {
                        if (dataRow["Variety"].ToString() == rowofBucket["Variety"].ToString())
                        {
                            totalBucket = totalBucket + Convert.ToDecimal(rowofBucket["NoofTub"]);
                            totalKilo = totalKilo + Convert.ToDecimal(rowofBucket["NoofKilo"]);
                        }
                    }
                    chartKilo.Series[Convert.ToString(dataRow["Variety"])].Points.AddY(totalKilo);
                    chartKilo.Series[Convert.ToString(dataRow["Variety"])].ToolTip = totalKilo.ToString();
                    dgvKilo.Rows.Add(dataRow["Variety"].ToString(), totalKilo);
                }
                this.dgvKilo.Sort(this.dgvKilo.Columns[1], ListSortDirection.Descending);
            }*/
        }
    }
}
