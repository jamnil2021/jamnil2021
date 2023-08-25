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
        private ItemReaderConnector itemReader = new ItemReaderConnector();
        private ImportConnector importConnector = new ImportConnector();
        private ExportConnector exportConnector = new ExportConnector();
        private DataTable tableImport = new DataTable();
        private bool InsufKiloStocks = false;
        private bool InsufTubStocks = false;
        private bool ifEditMode = false;
        private string VarietyFish;
        private string IDClass;
        private int TotalStocksNoBucket;
        private int TotalStocksNoKilo;
        private decimal DBucket;
        private decimal DKilo;
        private string DVariety;
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
            tbVendor.Text = ""; cbFish.SelectedIndex = -1; tbTubs.Text = ""; tbTubsPrice.Text = ""; tbKilosPrice.Text = ""; btnClear.Enabled = false;
            btnAdd.Enabled = false; btnUpdate.Enabled = false; tbTubs.Enabled = false; tbTubsPrice.Enabled = false; tbKilos.Enabled = false; tbVendor.SelectedIndex = -1;
            tbKilosPrice.Enabled = false; cbFish.DropDownStyle = ComboBoxStyle.DropDownList; tbKilosPrice.Text = ""; ifEditMode = false; cbFish.Enabled = true; tbKilos.Text = "";
        }
        public void BtnTriggerActivator() 
        {
            if (tbVendor.Text.Length != 0 || cbFish.Text.Length != 0 || tbKilos.Text.Length != 0 || tbTubs.Text.Length != 0 || tbTubsPrice.Text.Length != 0 || tbKilosPrice.Text.Length != 0 || tbTubsPrice.Text.Length != 0)
            {
                btnClear.Enabled = true;
                if (tbVendor.Text != "" && cbFish.Text != "" && tbKilos.Text != "" && tbTubs.Text != "" && tbTubsPrice.Text != "" && tbKilosPrice.Text != "" && tbTubsPrice.Text != "" && InsufTubStocks == false && InsufKiloStocks == false && (tbKilos.Text != "0" || tbTubs.Text != "0"))
                {
                    if (ifEditMode)
                    {
                        btnUpdate.Enabled = true;
                    }
                    else
                    {
                        btnAdd.Enabled = true;
                    }
                }
                else
                {
                    btnAdd.Enabled = false;
                    btnUpdate.Enabled = false;
                }
            }
            else
            {
                btnClear.Enabled = false;
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
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


        private void CbFish_TextChanged(object sender, EventArgs e)
        {
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

        private void Export_Load(object sender, EventArgs e)
        {
            tbVendor.DataSource = itemReader.CostumersName();
            tbVendor.DisplayMember = "Name";
            dgvExport.DataSource = exportConnector.ReadExport(IDClass);
            ImportDataDisplay();
        }


        private void DgvExport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvExport.Columns[e.ColumnIndex].Name == "Delete")
            {
                No = Convert.ToInt32(dgvExport.Rows[e.RowIndex].Cells[2].Value.ToString());
                DialogResult result = MessageBox.Show("Are you sure you wan't to Delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                ifEditMode = true;
                cbFish.Enabled = false;
                tbKilos.Enabled = true;
                tbTubs.Enabled = true;
                btnAdd.Enabled = false;
                tbTubsPrice.Enabled = true;
                tbKilosPrice.Enabled = true;
                No = Convert.ToInt32(dgvExport.Rows[e.RowIndex].Cells[2].Value.ToString());
                cbFish.DropDownStyle = ComboBoxStyle.Simple;
                Date.Value = Convert.ToDateTime(dgvExport.Rows[e.RowIndex].Cells[4].Value.ToString());
                tbVendor.Text = dgvExport.Rows[e.RowIndex].Cells[5].Value.ToString();
                cbFish.Text = dgvExport.Rows[e.RowIndex].Cells[6].Value.ToString();
                tbTubs.Text = dgvExport.Rows[e.RowIndex].Cells[7].Value.ToString();
                tbKilos.Text = dgvExport.Rows[e.RowIndex].Cells[8].Value.ToString();
                
                tbTubsPrice.Text = dgvExport.Rows[e.RowIndex].Cells[9].Value.ToString();
                tbKilosPrice.Text = dgvExport.Rows[e.RowIndex].Cells[10].Value.ToString();

                NoBucket = Convert.ToInt32(dgvExport.Rows[e.RowIndex].Cells[7].Value.ToString());
                NoKilo = Convert.ToInt32(dgvExport.Rows[e.RowIndex].Cells[8].Value.ToString());

                SelectedVarietyStocks();
                foreach (DataRow dataRow in tableImport.Rows)
                {
                    if (dataRow["KindofFish"].ToString() == cbFish.Text)
                    {
                        DVariety = dataRow["KindofFish"].ToString();
                        DBucket = Convert.ToDecimal(dataRow["NoofTubs"].ToString()) + Convert.ToInt32(dgvExport.Rows[e.RowIndex].Cells[7].Value.ToString());
                        DKilo = Convert.ToDecimal(dataRow["NoofKilos"].ToString()) + Convert.ToInt32(dgvExport.Rows[e.RowIndex].Cells[8].Value.ToString());
                        ImportDataDisplay(DKilo, DBucket);
                    }
                }
            }
        }


        private void BtnUpdate_Click(object sender, EventArgs e)
        {
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
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearField();
        }

        private void Date_ValueChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
        }

        private void TbVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
        }

        private void CbFish_Click(object sender, EventArgs e)
        {
            cbFish.DroppedDown = true;
        }

        private void TbKilosPrice_TextChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
        }

        private void TbTubsPrice_TextChanged(object sender, EventArgs e)
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

        private void TbTubs_TextChanged(object sender, EventArgs e)
        {
            SelectedVarietyStocks();
            if (tbTubs.Text != "")
            {
                if (Convert.ToInt64(tbTubs.Text) > TotalStocksNoBucket)
                {
                    lblErrorTub.Visible = true;
                    InsufTubStocks = true;
                }
                else
                {
                    //DisplaySelectEditData();
                    lblErrorTub.Visible = false;
                    InsufTubStocks = false;
                    if (tbTubs.Text != "0")
                    {
                        tbTubsPrice.Text = "";
                        tbTubsPrice.Enabled = true;
                    }
                    else
                    {
                        tbTubsPrice.Text = "0";
                        tbTubsPrice.Enabled = false;
                    }
                }
                ImportDataDisplay(DKilo, DBucket);
            }
            else
            {
                tbTubsPrice.Enabled = false;
            }
            ImportDataDisplay(DKilo, DBucket);
            BtnTriggerActivator();
        }

        private void TbKilos_TextChanged(object sender, EventArgs e)
        {
            SelectedVarietyStocks();
            if (tbKilos.Text != "")
            {
                if (Convert.ToInt16(tbKilos.Text) > TotalStocksNoKilo)
                {
                    lblErrorKilo.Visible = true;
                    InsufKiloStocks = true;
                }
                else
                {
                    //DisplaySelectEditData();
                    lblErrorKilo.Visible = false;
                    InsufKiloStocks = false;
                    if (tbKilos.Text != "0")
                    {
                        tbKilosPrice.Text = "";
                        tbKilosPrice.Enabled = true;
                    }
                    else
                    {
                        tbKilosPrice.Text = "0";
                        tbKilosPrice.Enabled = false;
                    }
                }
                ImportDataDisplay(DKilo, DBucket);
            }
            else
            {
                tbKilosPrice.Enabled = false;
            }
            ImportDataDisplay(DKilo, DBucket);
            BtnTriggerActivator();
        }
        private void TbKilosPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void TbTubsPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void CbFish_SelectedIndexChanged(object sender, EventArgs e)
        {
            VarietyFish = cbFish.Text;
            tbTubs.Enabled = true;
            tbKilos.Enabled = true;
            // Display Data
            DisplayRemainingStocks.Controls.Clear();
            tableImport = importConnector.RetrieverData(IDClass);
            foreach (DataRow dataRow in tableImport.Rows)
            {
                if (dataRow["KindofFish"].ToString() == cbFish.Text)
                {
                    DVariety = dataRow["KindofFish"].ToString();
                    DBucket = Convert.ToDecimal(dataRow["NoofTubs"].ToString());
                    DKilo = Convert.ToDecimal(dataRow["NoofKilos"].ToString());
                    ImportDataDisplay(DKilo, DBucket);
                }
            }
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

            if (exportConnector.SearchDuplication(exportProperties))
            {
                DialogResult result = MessageBox.Show("Do you wan't to Add this in Existing Data?", "Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    exportConnector.UpdateDuplication(exportProperties);
                }
                else if (result == DialogResult.No)
                {
                    exportConnector.InsertExport(exportProperties);
                }
                else
                {
                    ClearField();
                }

                // Update Data Grid View for Costumers Data
                dgvExport.DataSource = exportConnector.ReadExport(IDClass);
            }
            else
            {
                exportConnector.InsertExport(exportProperties);

                // Add New Costumers Name in database if not exist
                exportConnector.InsertCustomersName(exportProperties.Vendor);

                // Update Stocks
                importConnector.UpdateInsertData(exportProperties);
            }
            // Update Data Grid View for Costumers Data
            dgvExport.DataSource = exportConnector.ReadExport(IDClass);

            // Update DataSource in ComboBox
            tbVendor.DataSource = itemReader.CostumersName();
            tbVendor.DisplayMember = "Name";

            cbFish.Items.Clear();
            // Display Stocks
            ImportDataDisplay();

            // Clear TextField
            ClearField();
        }

        public void DisplaySelectEditData()
        {
            try
            {
                DisplayRemainingStocks.Controls.Clear();
                FishAvailableForm availableForm = new FishAvailableForm(DisplayRemainingStocks);
                availableForm.Variety = VarietyFish;
                availableForm.Bucket = Convert.ToDecimal(TotalStocksNoBucket - Convert.ToInt16(tbTubs.Text));
                availableForm.Kilo = Convert.ToDecimal(TotalStocksNoKilo - Convert.ToInt16(tbKilos.Text));
                DisplayRemainingStocks.Controls.Add(availableForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SelectedVarietyStocks()
        {
            bool isFound = false;
            foreach (DataRow dataFish in tableImport.Rows)
            {
                if (Convert.ToString(dataFish["KindofFish"].ToString()) == Convert.ToString(cbFish.Text))
                {
                    if (ifEditMode)
                    {
                        TotalStocksNoBucket = Convert.ToInt32(dataFish["NoofTubs"]) + NoBucket;
                        TotalStocksNoKilo = Convert.ToInt32(dataFish["NoofKilos"]) + NoKilo;
                    }
                    else
                    {
                        TotalStocksNoBucket = Convert.ToInt32(dataFish["NoofTubs"]);
                        TotalStocksNoKilo = Convert.ToInt32(dataFish["NoofKilos"]);
                    }
                    isFound = true;
                }
                if (isFound == true)
                {
                    break;
                }
            }
        }

        private void TbTubs_SizeChanged(object sender, EventArgs e)
        {
            if (tbTubs.Text != "" && tbTubs.Text != "0")
            {
                //DisplaySelectEditData();
            }
        }

        private void ImportDataDisplay(decimal kilo, decimal bucket)
        {
            if (kilo != 0 || bucket != 0)
            {
                // Tenary Operator
                decimal tbIBucket = Convert.ToString(tbTubs.Text) == "" || Convert.ToString(tbTubs.Text) == "." ? 0 : Convert.ToDecimal(tbTubs.Text);
                decimal tbIKilo = Convert.ToString(tbKilos.Text) == "" || Convert.ToString(tbKilos.Text) == "." ? 0 : Convert.ToDecimal(tbKilos.Text);

                DisplayRemainingStocks.Controls.Clear();
                FishAvailableForm availableForm = new FishAvailableForm(DisplayRemainingStocks);
                availableForm.Variety = DVariety;
                availableForm.Bucket = bucket - tbIBucket;
                availableForm.Kilo = kilo - tbIKilo;
                DisplayRemainingStocks.Controls.Add(availableForm);


                if ((DBucket - tbIBucket) >= 0)
                {
                    InsufKiloStocks = false;
                    lblErrorTub.Visible = false;
                }
                else
                {
                    InsufKiloStocks = true;
                    lblErrorTub.Visible = true;
                }

                if ((DKilo - tbIKilo) >= 0)
                {
                    InsufKiloStocks = false;
                    lblErrorKilo.Visible = false;
                }
                else
                {
                    InsufKiloStocks = true;
                    lblErrorKilo.Visible = true;
                }
            }
            else
            {
                DisplayRemainingStocks.Controls.Clear();
            }
        }
    }
}
