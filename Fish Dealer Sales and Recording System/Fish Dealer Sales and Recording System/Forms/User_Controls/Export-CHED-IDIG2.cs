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
    public partial class Export : UserControl
    {
        private ValueUpdaterPropertiesModel valueUpdaterProperties = new ValueUpdaterPropertiesModel();
        private ExportPropertiesModel exportProperties = new ExportPropertiesModel();
        private ImportConnector importConnector = new ImportConnector();
        private ExportConnector exportConnector = new ExportConnector();
        private DataTable tableImport = new DataTable();
        private ValueUpdater valueUpdate;
        private bool InsufKiloStocks = false;
        private bool InsufTubStocks = false;
        private bool ValueEdit = false;
        private string IDClass;
        private int NoBucket;
        private int NoKilo;
        private int No;
        
        public Export(string IDClass)
        {
            InitializeComponent();
            this.IDClass = IDClass; 
        }

        private void ClearField()
        {
            tbVendor.Text = "";
            cbFish.SelectedIndex = -1;
            tbTubs.Text = "";
            tbTubsPrice.Text = "";
            tbKilosPrice.Text = "";
            btnClear.Enabled = false;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            ValueEdit = false;
            cbFish.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void BtnTriggerActivator()
        {
            if (tbVendor.Text.Length != 0 || cbFish.Text.Length != 0 || tbKilos.Text.Length != 0 || tbTubs.Text.Length != 0 || tbTubsPrice.Text.Length != 0 || tbKilosPrice.Text.Length != 0 || tbTubsPrice.Text.Length != 0)
            {
                btnClear.Enabled = true;
                if (tbVendor.Text != "" && cbFish.Text != "" && tbKilos.Text != "" && tbTubs.Text != "" && tbTubsPrice.Text != "" && tbKilosPrice.Text != "" && tbTubsPrice.Text != "" && InsufTubStocks == false && InsufKiloStocks == false)
                {
                    btnAdd.Enabled = true;
                }
                else
                {
                    btnAdd.Enabled = false;
                }
            }
            else
            {
                btnClear.Enabled = false;
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
            }
        }

        // Checker Method if The Stock is sufficient or not
        private void FishQuantityCheck()
        {
            string Variety = cbFish.Text;
            if (tbTubs.Text.Length != 0 || tbKilos.Text.Length != 0)
            {
                foreach (DataRow dataRow in tableImport.Rows)
                {
                    if (Variety == dataRow["KindofFish"].ToString())
                    {
                        if (tbTubs.Text.Length != 0 && ValueEdit == false)
                        {
                            if (Convert.ToDecimal(dataRow["NoofTubs"].ToString()) < Convert.ToDecimal(tbTubs.Text))
                            {
                                lblErrorTub.Visible = true;
                                InsufTubStocks = true;
                            }
                            else
                            {
                                lblErrorTub.Visible = false;
                                InsufTubStocks = false;
                            }
                        }
                        if (tbKilos.Text.Length != 0 && ValueEdit == false)
                        {
                            if (Convert.ToDecimal(dataRow["NoofKilos"].ToString()) < Convert.ToDecimal(tbKilos.Text))
                            {
                                lblErrorKilo.Visible = true;
                                InsufKiloStocks = true;
                            }
                            else
                            {
                                lblErrorKilo.Visible = false;
                                InsufKiloStocks = false;
                            }
                        }
                    }
                }
            }
        }

        // This method use for displaying the Avaiable Stocks in FlowLayOut Panel
        private void ImportDataDisplay()
        {
            DisplayRemainingStocks.Controls.Clear();
            tableImport = importConnector.RetrieverData(IDClass);
            foreach (DataRow dataRow in tableImport.Rows)
            {
                FishAvailableForm availableForm = new FishAvailableForm(DisplayRemainingStocks);
                if (Convert.ToDecimal(dataRow["NoofTubs"].ToString()) > 0 || Convert.ToDecimal(dataRow["NoofKilos"].ToString()) > 0)
                {
                    cbFish.Items.Add(dataRow["KindofFish"].ToString());
                    availableForm.Variety = dataRow["KindofFish"].ToString();
                    availableForm.Bucket = Convert.ToDecimal(dataRow["NoofTubs"].ToString());
                    availableForm.Kilo = Convert.ToDecimal(dataRow["NoofKilos"].ToString());
                    DisplayRemainingStocks.Controls.Add(availableForm);
                }
            }
        }


        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearField();
        }

        private void Date_ValueChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
        }

        private void TbTubs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void TbKilos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void TbTubPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void TbKiloPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void TbVendor_TextChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
        }

        private void CbFish_TextChanged(object sender, EventArgs e)
        {
            FishQuantityCheck();
            BtnTriggerActivator();
            if (cbFish.Text.Length != 0)
            {
                foreach (DataRow dataRow in tableImport.Rows)
                {
                    if (cbFish.Text == dataRow["KindofFish"].ToString())
                    {
                        if (Convert.ToDecimal(dataRow["NoofTubs"].ToString()) < 11)
                        {
                            tbTubs.Text = dataRow["NoofTubs"].ToString();
                        }
                        if (Convert.ToDecimal(dataRow["NoofKilos"].ToString()) < 11)
                        {
                            tbKilos.Text = dataRow["NoofKilos"].ToString();
                        }
                    }
                }
            }
        }

        private void TbTubs_TextChanged(object sender, EventArgs e)
        {
            FishQuantityCheck();
            BtnTriggerActivator();
            if (tbTubs.Text == "0" || tbTubs.Text.Length == 0)
            {
                tbTubsPrice.Text = "0";
            }
            
        }

        private void TbKilos_TextChanged(object sender, EventArgs e)
        {
            FishQuantityCheck();
            BtnTriggerActivator();
            if (tbKilos.Text == "0" || tbKilos.Text.Length == 0)
            {
                tbKilosPrice.Text = "0";
            }
        }

        private void TbTubPrice_TextChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
        }

        private void TbKiloPrice_TextChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // Insert Data in Export Table
            exportProperties.IDClass = IDClass;
            exportProperties.Date = Convert.ToDateTime(Date.Value).Date;
            exportProperties.Vendor = tbVendor.Text.Trim();
            exportProperties.Variety = cbFish.Text.Trim();
            exportProperties.Kilo = Convert.ToDecimal(tbKilos.Text.Trim());
            exportProperties.Bucket = Convert.ToDecimal(tbTubs.Text.Trim());
            exportProperties.UnitBucketPrice = (decimal)Convert.ToDouble((object)tbTubsPrice.Text.Trim());
            exportProperties.UnitKiloPrice = (decimal)Convert.ToDouble((object)tbKilosPrice.Text.Trim());
            exportConnector.InsertExport(exportProperties);
            cbFish.Items.Clear();
            dgvExport.DataSource = exportConnector.ReadExport(IDClass);

            // Update Stocks
            importConnector.UpdateInsertData(exportProperties);

            // Display Stocks
            ImportDataDisplay();

            // Clear TextField
            ClearField();
        }

        private void Export_Load(object sender, EventArgs e)
        {
            dgvExport.DataSource = exportConnector.ReadExport(IDClass);
            ImportDataDisplay();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"No. of Bucke/ts = {NoBucket}       No. of Kilo/s = {NoKilo}");
            exportProperties.No = No;
            exportProperties.IDClass = IDClass;
            exportProperties.Date = Convert.ToDateTime(Date.Value);
            exportProperties.Vendor = tbVendor.Text.Trim();
            exportProperties.Variety = cbFish.Text.Trim();
            exportProperties.Bucket = Convert.ToInt32(tbTubs.Text);
            exportProperties.Kilo = Convert.ToInt32(tbKilos.Text);
            exportProperties.UnitBucketPrice = (decimal)Convert.ToDouble((object)tbTubsPrice.Text.Trim());
            exportProperties.UnitKiloPrice = (decimal)Convert.ToDouble((object)tbKilosPrice.Text.Trim());
            exportConnector.UpdateExport(exportProperties);

            exportProperties.CBucket = NoBucket;
            exportProperties.CKilo = NoKilo;
            importConnector.UpdateEditData(exportProperties);
            dgvExport.DataSource = exportConnector.ReadExport(IDClass);
            ClearField();
            ImportDataDisplay();
            btnUpdate.Enabled = false;
            ValueEdit = false;
        }

        private void TbTubs_SizeChanged(object sender, EventArgs e)
        {
            FishQuantityCheck();
        }

        private void DgvExport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvExport.Columns[e.ColumnIndex].Name == "Delete")
            {
                No = Convert.ToInt32(dgvExport.Rows[e.RowIndex].Cells[2].Value.ToString());
                DialogResult result = MessageBox.Show("Delete", "Message", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    exportProperties.No = No;
                    exportProperties.IDClass = IDClass;
                    exportProperties.Variety = dgvExport.Rows[e.RowIndex].Cells[6].Value.ToString();
                    exportProperties.Kilo = Convert.ToInt32(dgvExport.Rows[e.RowIndex].Cells[8].Value.ToString());
                    exportProperties.Bucket = Convert.ToInt32(dgvExport.Rows[e.RowIndex].Cells[7].Value.ToString());

                    // Update Stocks
                    importConnector.UpdateDeleteData(exportProperties);
                    exportConnector.DeleteExport(exportProperties);
                    dgvExport.DataSource = exportConnector.ReadExport(IDClass);
                    ImportDataDisplay();
                }
            }
            if (dgvExport.Columns[e.ColumnIndex].Name == "Edit")
            {
                ValueEdit = true;
                cbFish.Enabled = false;
                btnUpdate.Enabled = true;
                No = Convert.ToInt32(dgvExport.Rows[e.RowIndex].Cells[2].Value.ToString());
                cbFish.DropDownStyle = ComboBoxStyle.Simple;
                Date.Value = Convert.ToDateTime(dgvExport.Rows[e.RowIndex].Cells[4].Value.ToString());
                tbVendor.Text = dgvExport.Rows[e.RowIndex].Cells[5].Value.ToString();
                cbFish.Text = dgvExport.Rows[e.RowIndex].Cells[6].Value.ToString();
                tbTubs.Text = dgvExport.Rows[e.RowIndex].Cells[7].Value.ToString();
                tbKilos.Text = dgvExport.Rows[e.RowIndex].Cells[8].Value.ToString();
                tbTubsPrice.Text = dgvExport.Rows[e.RowIndex].Cells[10].Value.ToString();
                tbKilosPrice.Text = dgvExport.Rows[e.RowIndex].Cells[9].Value.ToString();

                NoBucket = Convert.ToInt32(dgvExport.Rows[e.RowIndex].Cells[7].Value.ToString());
                NoKilo = Convert.ToInt32(dgvExport.Rows[e.RowIndex].Cells[8].Value.ToString());
                ImportDataDisplay();
            }
        }

        private void TbTubs_Click(object sender, EventArgs e)
        {
            if (ValueEdit == true)
            {
                valueUpdaterProperties.ItemName = cbFish.Text;
                valueUpdaterProperties.ItemValue = Convert.ToInt32(tbTubs.Text);
                valueUpdaterProperties.ValueName = "Bucket/s";
                valueUpdaterProperties.itemTable = tableImport;
                valueUpdate = new ValueUpdater(valueUpdaterProperties);
                valueUpdate.ShowDialog();
                tbTubs.Text = valueUpdate.newValue.ToString();
            }
        }

        private void CbFish_Click(object sender, EventArgs e)
        {
            cbFish.DroppedDown = true;
        }

        private void TbKilos_Click(object sender, EventArgs e)
        {
            if (ValueEdit == true)
            {
                valueUpdaterProperties.ItemName = cbFish.Text;
                valueUpdaterProperties.ItemValue = Convert.ToInt32(tbKilos.Text);
                valueUpdaterProperties.ValueName = "Kilo/s";
                valueUpdaterProperties.itemTable = tableImport;
                valueUpdate = new ValueUpdater(valueUpdaterProperties);
                valueUpdate.ShowDialog();
                tbKilos.Text = valueUpdate.newValue.ToString();
            }
        }
    }
}
