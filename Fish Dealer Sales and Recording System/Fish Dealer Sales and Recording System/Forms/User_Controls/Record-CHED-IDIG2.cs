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
    public partial class Record : UserControl
    {
        private DateDeparturePropertiesModel dateProperties = new DateDeparturePropertiesModel();
        private DateDepartureConnector departureConnector = new DateDepartureConnector();
        private ExportConnector exportConnector = new ExportConnector();
        public Record()
        {
            InitializeComponent();
        }

        private void Record_Load(object sender, EventArgs e)
        {
            dgvRecord.DataSource = departureConnector.ReadDate();
        }

        private void TbSearch_Enter(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            tbSearch.ForeColor = Color.Black;
        }

        private void TbSearch_Leave(object sender, EventArgs e)
        {

        }

        private void DgvRecord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRecord.Columns[e.ColumnIndex].Name == "Edit")
            {
                dateProperties.boolEdit = true;
                dateProperties.CastOff = dgvRecord.Rows[e.RowIndex].Cells[6].Value.ToString();
                dateProperties.Docking = dgvRecord.Rows[e.RowIndex].Cells[7].Value.ToString();
                dateProperties.VesselName = dgvRecord.Rows[e.RowIndex].Cells[8].Value.ToString();
                dateProperties.IDClass = dgvRecord.Rows[e.RowIndex].Cells[5].Value.ToString();
                new AddRecord(dateProperties).ShowDialog();
            }
            if (dgvRecord.Columns[e.ColumnIndex].Name == "Delete")
            {
                DialogResult result = MessageBox.Show("Delete", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    departureConnector.DeleteDate(dgvRecord.Rows[e.RowIndex].Cells[5].Value.ToString());
                    dgvRecord.DataSource = departureConnector.ReadDate();
                }
            }
            if (dgvRecord.Columns[e.ColumnIndex].Name == "Manage")
            {
                new ManageRecord(dgvRecord.Rows[e.RowIndex].Cells[5].Value.ToString()).ShowDialog();
            }
            if (dgvRecord.Columns[e.ColumnIndex].Name == "Print")
            {
                try
                {
                    dateProperties.CastOff = dgvRecord.Rows[e.RowIndex].Cells[6].Value.ToString();
                    dateProperties.Docking = dgvRecord.Rows[e.RowIndex].Cells[7].Value.ToString();
                    dateProperties.VesselName = dgvRecord.Rows[e.RowIndex].Cells[8].Value.ToString();
                    dateProperties.IDClass = dgvRecord.Rows[e.RowIndex].Cells[5].Value.ToString();
                    List<ExportPropertiesModel> _list = new List<ExportPropertiesModel>();
                    // Linq
                    _list = (from DataRow dr in exportConnector.ReadExport(dgvRecord.Rows[e.RowIndex].Cells[5].Value.ToString()).Rows
                             select new ExportPropertiesModel()
                             {
                                 Date = Convert.ToDateTime(dr["Date"]),
                                 Vendor = dr["Vendor"].ToString(),
                                 Variety = dr["KindofFish"].ToString(),
                                 Bucket = Convert.ToDecimal(dr["NoofTub"].ToString()),
                                 Kilo = Convert.ToDecimal(dr["NoofKilo"].ToString()),
                                 UnitBucketPrice = Convert.ToDecimal(dr["UnitTubPrice"].ToString()),
                                 UnitKiloPrice = Convert.ToDecimal(dr["UnitKiloPrice"].ToString())
                             }).ToList();
                    using (PrintReport print = new PrintReport(_list, dateProperties))
                    {
                        print.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }
            }
        }

        private void BtnAddRecord_Click(object sender, EventArgs e)
        {
            new AddRecord().ShowDialog();
            dgvRecord.DataSource = departureConnector.ReadDate();
        }

        private void TbSearch_TextChanged(object sender, EventArgs e)
        {
            DataView data = departureConnector.ReadDate().DefaultView;
            data.RowFilter = "BoatName LIKE '" + tbSearch.Text+"%'";
            dgvRecord.DataSource = data;
        }

        private void TbSearch_Enter_1(object sender, EventArgs e)
        {
            tbSearch.Text = "";
        }

        private void TbSearch_Leave_1(object sender, EventArgs e)
        {
            if (tbSearch.Text == "")
            {
                tbSearch.Text = "Search Vessel Name";
                dgvRecord.DataSource = departureConnector.ReadDate();
            }
        }
    }
}
