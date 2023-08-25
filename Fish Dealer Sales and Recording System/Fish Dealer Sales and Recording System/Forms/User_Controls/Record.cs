using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public partial class Record : UserControl
    {
        private DateDeparturePropertiesModel dateProperties = new DateDeparturePropertiesModel();
        private DateDepartureConnector departureConnector = new DateDepartureConnector();
        private ManageRecord recordForm;
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
            
        }

        public void Populate()
        {
            Button btn = new Button();
            btn.Name = "iconButton";
            btn.Text = "Delete";
            dgvRecord.Rows.Add(btn);
        }
        private void BtnAddRecord_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            new AddRecord().ShowDialog();
            dgvRecord.DataSource = departureConnector.ReadDate();
            this.Enabled = true;
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

        private void DgvRecord_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRecord.Columns[e.ColumnIndex].Name == "Edits")
            {
                dateProperties.boolEdit = true;
                dateProperties.CastOff = dgvRecord.Rows[e.RowIndex].Cells[7].Value.ToString();
                dateProperties.Docking = dgvRecord.Rows[e.RowIndex].Cells[8].Value.ToString();
                dateProperties.VesselName = dgvRecord.Rows[e.RowIndex].Cells[9].Value.ToString();
                dateProperties.IDClass = dgvRecord.Rows[e.RowIndex].Cells[6].Value.ToString();
                new AddRecord(dateProperties).ShowDialog();
            }
            if (dgvRecord.Columns[e.ColumnIndex].Name == "Deletes")
            {
                DialogResult result = MessageBox.Show("Delete " + dgvRecord.Rows[e.RowIndex].Cells[8].Value.ToString() + "?", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    departureConnector.DeleteDate(dgvRecord.Rows[e.RowIndex].Cells[6].Value.ToString());
                    dgvRecord.DataSource = departureConnector.ReadDate();
                }
            }
            if (dgvRecord.Columns[e.ColumnIndex].Name == "Manages")
            {
                this.Enabled = false;
                this.BackColor = Color.Black;
                dgvRecord.BackgroundColor = Color.Black;
                recordForm = new ManageRecord(dgvRecord.Rows[e.RowIndex].Cells[6].Value.ToString());
                recordForm.ShowDialog();
                this.BackColor = Color.White;
                dgvRecord.BackgroundColor = Color.White;
                this.Enabled = true;
            }
            if (dgvRecord.Columns[e.ColumnIndex].Name == "Printer")
            {
                try
                {
                    dateProperties.CastOff = dgvRecord.Rows[e.RowIndex].Cells[7].Value.ToString();
                    dateProperties.Docking = dgvRecord.Rows[e.RowIndex].Cells[8].Value.ToString();
                    dateProperties.VesselName = dgvRecord.Rows[e.RowIndex].Cells[9].Value.ToString();
                    dateProperties.IDClass = dgvRecord.Rows[e.RowIndex].Cells[6].Value.ToString();
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
                    MessageBox.Show("Please Fill Up the Important Data"+ ex.Message, "Message");
                }
            }
            if (dgvRecord.Columns[e.ColumnIndex].Name == "Show")
            {
                try
                {
                    dateProperties.CastOff = dgvRecord.Rows[e.RowIndex].Cells[7].Value.ToString();
                    dateProperties.Docking = dgvRecord.Rows[e.RowIndex].Cells[8].Value.ToString();
                    dateProperties.VesselName = dgvRecord.Rows[e.RowIndex].Cells[9].Value.ToString();
                    dateProperties.IDClass = dgvRecord.Rows[e.RowIndex].Cells[6].Value.ToString();
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
                    using (ShowData print = new ShowData(_list, dateProperties))
                    {
                        print.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please Fill Up the Important Data" + ex.Message, "Message");
                }
            }
        }

        private void DgvRecord_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                toolTipRecord.ToolTipTitle = "Edit";
            }
        }
    }
}
