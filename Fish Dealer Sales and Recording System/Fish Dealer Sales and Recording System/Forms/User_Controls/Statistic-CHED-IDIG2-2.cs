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

namespace Fish_Dealer_Sales_and_Recording_System
{
    public partial class Statistic : UserControl
    {
        private DataTable _variety;
        private DataTable _bucket;
        private int _count = 0;

        public Statistic()
        {
            InitializeComponent();
        }

        private void Statistic_Load(object sender, EventArgs e)
        {
            chartBucket.Series.Clear();
            chartKilo.Series.Clear();
            chartBucket.Titles.Clear();
            chartKilo.Titles.Clear();
            dgvBucket.Rows.Clear();
            dgvKilo.Rows.Clear();
            _variety = new StatisticDataReader().VarietyData(DateTime.Now, DateTime.Now);
            _bucket = new StatisticDataReader().StatisticData(DateTime.Now, DateTime.Now);
            _count = _variety.Rows.Count;
            decimal totalKilo = 0;
            decimal totalBucket = 0;
            this.chartBucket.Titles.Add("BUCKET/S");
            this.chartKilo.Titles.Add("KILO/S");
            foreach (DataRow dataRow in _variety.Rows)
            {
                totalKilo = 0;
                totalBucket = 0;
                this.chartBucket.Series.Add(dataRow["Variety"].ToString());
                this.chartKilo.Series.Add(dataRow["Variety"].ToString());
                foreach (DataRow rowofBucket in _bucket.Rows)
                {
                    if (dataRow["Variety"].ToString() == rowofBucket["Variety"].ToString())
                    {
                        totalBucket = totalBucket + Convert.ToDecimal(rowofBucket["Bucket"]);
                        totalKilo = totalKilo + Convert.ToDecimal(rowofBucket["Kilo"]);
                    }
                }
                chartBucket.Series[Convert.ToString(dataRow["Variety"])].Points.AddY(totalBucket);
                chartBucket.Series[Convert.ToString(dataRow["Variety"])].ToolTip = totalBucket.ToString();
                chartKilo.Series[Convert.ToString(dataRow["Variety"])].Points.AddY(totalKilo);
                chartKilo.Series[Convert.ToString(dataRow["Variety"])].ToolTip = totalKilo.ToString();
                dgvBucket.Rows.Add(dataRow["Variety"].ToString(), totalBucket);
                dgvKilo.Rows.Add(dataRow["Variety"].ToString(), totalKilo);
            }
            this.dgvBucket.Sort(this.dgvBucket.Columns[1], ListSortDirection.Descending);
            this.dgvKilo.Sort(this.dgvKilo.Columns[1], ListSortDirection.Descending);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            chartBucket.Series.Clear();
            chartKilo.Series.Clear();
            chartBucket.Titles.Clear();
            chartKilo.Titles.Clear();
            dgvBucket.Rows.Clear();
            dgvKilo.Rows.Clear();
            _variety = new StatisticDataReader().VarietyData(dtpFromDate.Value, dtpToDate.Value);
            _bucket = new StatisticDataReader().StatisticData(dtpFromDate.Value, dtpToDate.Value);
            _count = _variety.Rows.Count;
            decimal totalKilo = 0;
            decimal totalBucket = 0;
            this.chartBucket.Titles.Add("BUCKET/S");
            this.chartKilo.Titles.Add("KILO/S");
            foreach (DataRow dataRow in _variety.Rows)
            {
                totalKilo = 0;
                totalBucket = 0;
                this.chartBucket.Series.Add(dataRow["Variety"].ToString());
                this.chartKilo.Series.Add(dataRow["Variety"].ToString());
                foreach (DataRow rowofBucket in _bucket.Rows)
                {
                    if (dataRow["Variety"].ToString() == rowofBucket["Variety"].ToString())
                    {
                        totalBucket = totalBucket + Convert.ToDecimal(rowofBucket["Bucket"]);
                        totalKilo = totalKilo + Convert.ToDecimal(rowofBucket["Kilo"]);
                    }
                }
                chartBucket.Series[Convert.ToString(dataRow["Variety"])].Points.AddY(totalBucket);
                chartBucket.Series[Convert.ToString(dataRow["Variety"])].ToolTip = totalBucket.ToString();
                chartKilo.Series[Convert.ToString(dataRow["Variety"])].Points.AddY(totalKilo);
                chartKilo.Series[Convert.ToString(dataRow["Variety"])].ToolTip = totalKilo.ToString();
                dgvBucket.Rows.Add(dataRow["Variety"].ToString(), totalBucket);
                dgvKilo.Rows.Add(dataRow["Variety"].ToString(), totalKilo);
            }
            this.dgvBucket.Sort(this.dgvBucket.Columns[1], ListSortDirection.Descending);
            this.dgvKilo.Sort(this.dgvKilo.Columns[1], ListSortDirection.Descending);
        }
    }
}
