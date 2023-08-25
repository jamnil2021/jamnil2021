using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Fish_Dealer_Sales_and_Recording_System.Forms.User_Controls
{
    public partial class StatisticBucket : UserControl
    {
        private DateTime fromDate;
        private DateTime toDate;
        private DataTable _variety;
        private DataTable _bucket;
        private DataTable _dummyData;
        private int _count = 0;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public StatisticBucket(DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            this.fromDate = fromDate;
            this.toDate = toDate;
        }

        private void StatisticBucket_Load(object sender, EventArgs e)
        {
            _variety = new StatisticDataReader().VarietyData(fromDate, toDate);
            _bucket = new StatisticDataReader().StatisticData(fromDate, toDate);
            _dummyData = new StatisticDataReader().DummyStatistic();
            _count = _variety.Rows.Count;
            if (_variety.Rows.Count > 0 && _bucket.Rows.Count > 0)
            {
                chartBucket.Series.Clear();
                chartBucket.Titles.Clear();
                dgvBucket.Rows.Clear();
                decimal totalBucket = 0;
                foreach (DataRow dataRow in _variety.Rows)
                {
                    totalBucket = 0;
                    this.chartBucket.Series.Add(dataRow["Variety"].ToString());
                    foreach (DataRow rowofBucket in _bucket.Rows)
                    {
                        if (dataRow["Variety"].ToString() == rowofBucket["Variety"].ToString())
                        {
                            totalBucket = totalBucket + Convert.ToDecimal(rowofBucket["Bucket"]);
                        }
                    }
                    chartBucket.Series[Convert.ToString(dataRow["Variety"])].Points.AddY(totalBucket);
                    chartBucket.Series[Convert.ToString(dataRow["Variety"])].ToolTip = totalBucket.ToString();
                    dgvBucket.Rows.Add(dataRow["Variety"].ToString(), totalBucket);
                }
                this.dgvBucket.Sort(this.dgvBucket.Columns[1], ListSortDirection.Descending);
            }
            /*else
            {
                chartBucket.Series.Clear();
                chartBucket.Titles.Clear();
                dgvBucket.Rows.Clear();
                decimal totalBucket = 0;
                foreach (DataRow dataRow in _dummyData.Rows)
                {
                    totalBucket = 0;
                    this.chartBucket.Series.Add(dataRow["Variety"].ToString());
                    foreach (DataRow rowofBucket in _dummyData.Rows)
                    {
                        if (dataRow["Variety"].ToString() == rowofBucket["Variety"].ToString())
                        {
                            totalBucket = totalBucket + Convert.ToDecimal(rowofBucket["NoofTub"]);
                        }
                    }
                    chartBucket.Series[Convert.ToString(dataRow["Variety"])].Points.AddY(totalBucket);
                    chartBucket.Series[Convert.ToString(dataRow["Variety"])].ToolTip = totalBucket.ToString();
                    dgvBucket.Rows.Add(dataRow["Variety"].ToString(), totalBucket);
                }
                this.dgvBucket.Sort(this.dgvBucket.Columns[1], ListSortDirection.Descending);
            }*/
        }
    }
}
