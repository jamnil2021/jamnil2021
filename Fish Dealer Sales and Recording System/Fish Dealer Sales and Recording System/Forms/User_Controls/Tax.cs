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
    public partial class Tax : UserControl
    {
        private TaxCommissionConnector taxCommission = new TaxCommissionConnector();
        private TaxPropertiesModel taxProperties = new TaxPropertiesModel();
        private ItemReaderConnector itemReader = new ItemReaderConnector();
        private ImportConnector importConnector = new ImportConnector();
        private TaxConnector taxConnector = new TaxConnector();
        private string DVariety;
        private decimal DKilo;
        private decimal DBucket;
        private string IDClass;
        private decimal CKilo;
        private decimal CBucket;
        private Int64 No;
        private bool ifSuffBucket = false;
        private bool ifSuffKilo = false;
        private bool ifTrueEdit = false;
        
       
        private DataTable tableImport;
        public Tax(string IDClass)
        {
            InitializeComponent();
            this.IDClass = IDClass;
        }

        public void TaxButtonActivator()
        {
            if (tbTax.Text != "" && tbHandling.Text != "" && tbUnloading.Text != "")
            {
                if (btnUpdate.Text != "Update")
                {
                    btnUpdate.Text = "Save";
                }
                else
                {
                    btnUpdate.Text = "Update";
                }
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }
        private void Tax_Load(object sender, EventArgs e)
        {
            if (taxConnector.TaxRead(IDClass).Rows.Count > 0)
            {
                foreach(DataRow dataRow in taxConnector.TaxRead(IDClass).Rows)
                {
                    tbHandling.Text = dataRow["Handling"].ToString();
                    tbUnloading.Text = dataRow["Unloading"].ToString();
                    tbTax.Text = dataRow["Tax"].ToString();
                    btnUpdate.Text = "Update";
                }
            }
            taxConnector.TaxAvailableFish(IDClass);
            ImportDataDisplay();
            dgvTax.DataSource = taxCommission.ReadTaxCom(IDClass);
        }

        private void BtnAdd_Clickd(object sender, EventArgs e)
        {
            if (btnAdd.Text == "ADD")
            {
               
            }
            else
            {
                taxProperties.IDClass = IDClass;
                taxProperties.Handling = Convert.ToDecimal(tbHandling.Text.TrimEnd());
                taxProperties.Tax = Convert.ToDecimal(tbTax.Text.TrimEnd());
                taxProperties.Unloading = Convert.ToDecimal(tbUnloading.Text.TrimEnd());
                taxConnector.TaxUpdate(taxProperties);
            }
        }
        public void ClearField()
        {
            cbVariety.SelectedIndex = -1; tbBucket.Text = ""; tbKilo.Text = ""; tbCommision.Text = ""; tbSeller.Text = ""; ifTrueEdit = false;
            tbPriceBucket.Text = ""; tbPriceKilo.Text = ""; btnUpdated.Enabled = false; btnAdd.Enabled = false; btnUpdated.Enabled = false;
            tbBucket.Enabled = false; tbKilo.Enabled = false; tbCommision.Enabled = false; ifSuffBucket = false; ifSuffKilo = false; ifTrueEdit = false;
            lblErrorKilo.Visible = false; cbVariety.DropDownStyle = ComboBoxStyle.DropDownList; DKilo = 0; DBucket = 0;
            DisplayRemainingStocks.Controls.Clear(); ImportDataDisplay();
        }
        public void BtnTriggerActivator()
        {
            if (tbSeller.Text.Length != 0 || tbBucket.Text.Length != 0 || cbVariety.Text.Length != 0 || tbKilo.Text.Length != 0 || tbBucket.Text.Length != 0 || tbCommision.Text.Length != 0 || tbPriceBucket.Text.Length != 0 || tbPriceKilo.Text.Length != 0)
            {
                btnClear.Enabled = true;
                if (tbSeller.Text != "" && tbBucket.Text != "" && cbVariety.Text != "" && tbKilo.Text != "" && tbBucket.Text != "" && tbCommision.Text != "" && tbPriceBucket.Text != "" && tbPriceKilo.Text != "" && ifSuffBucket == true && ifSuffKilo == true)
                {
                    if (ifTrueEdit == true)
                    {
                        btnUpdated.Enabled = true;
                    }
                    else
                    {
                        btnAdd.Enabled = true;
                    }
                }
                else
                {
                    btnAdd.Enabled = false;
                    btnUpdated.Enabled = false;
                }
            }
            else
            {
                btnClear.Enabled = false;
                btnAdd.Enabled = false;
                btnUpdated.Enabled = false;
            }
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Text == "Save")
            {
                taxProperties.IDClass = IDClass;
                taxProperties.Handling = Convert.ToDecimal(tbHandling.Text.TrimEnd());
                taxProperties.Tax = Convert.ToDecimal(tbTax.Text.TrimEnd());
                taxProperties.Unloading = Convert.ToDecimal(tbUnloading.Text.TrimEnd());
                taxConnector.TaxInsert(taxProperties);
            }
            else
            {
                taxProperties.IDClass = IDClass;
                taxProperties.Handling = Convert.ToDecimal(tbHandling.Text.TrimEnd());
                taxProperties.Tax = Convert.ToDecimal(tbTax.Text.TrimEnd());
                taxProperties.Unloading = Convert.ToDecimal(tbUnloading.Text.TrimEnd());
                taxConnector.TaxUpdate(taxProperties);
            }
        }

        private void CbVariety_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
            tbBucket.Enabled = true;
            tbKilo.Enabled = true;
            tbCommision.Enabled = true;

            // Display Data
            DisplayRemainingStocks.Controls.Clear();
            tableImport = importConnector.RetrieverData(IDClass);
            foreach (DataRow dataRow in tableImport.Rows)
            {
                if (dataRow["KindofFish"].ToString() == cbVariety.Text)
                {
                    DVariety = dataRow["KindofFish"].ToString();
                    DBucket = Convert.ToDecimal(dataRow["NoofTubs"].ToString());
                    DKilo = Convert.ToDecimal(dataRow["NoofKilos"].ToString());
                    ImportDataDisplay(DKilo, DBucket);
                }
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            btnBack.Enabled = true;
            btnNext.Enabled = false;
            DisplayRemainingStocks.Visible = false;
            panelTax.Visible = true;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            cbVariety.Items.Clear();
            btnBack.Enabled = false;
            btnNext.Enabled = true;
            DisplayRemainingStocks.Visible = true;
            panelTax.Visible = false;
            ImportDataDisplay();
        }
        private void ImportDataDisplay()
        {
            DisplayRemainingStocks.Controls.Clear();
            tableImport = importConnector.RetrieverData(IDClass);
            foreach (DataRow dataRow in tableImport.Rows)
            {
                FishAvailableForm availableForm = new FishAvailableForm(DisplayRemainingStocks);
                if (Convert.ToDecimal(dataRow["NoofTubs"].ToString()) > 0 || Convert.ToDecimal(dataRow["NoofKilos"].ToString()) > 0)
                {
                    cbVariety.Items.Add(dataRow["KindofFish"].ToString());
                    availableForm.Variety = dataRow["KindofFish"].ToString();
                    availableForm.Bucket = Convert.ToDecimal(dataRow["NoofTubs"].ToString());
                    availableForm.Kilo = Convert.ToDecimal(dataRow["NoofKilos"].ToString());
                    DisplayRemainingStocks.Controls.Add(availableForm);
                }
            }
        }

        private void ImportDataDisplay(decimal kilo, decimal bucket)
        {
            if (kilo != 0 || bucket != 0)
            {
                // Tenary Operator
                decimal tbIBucket = Convert.ToString(tbBucket.Text) == "" || Convert.ToString(tbBucket.Text) == "." ? 0 : Convert.ToDecimal(tbBucket.Text);
                decimal tbIKilo = Convert.ToString(tbKilo.Text) == "" || Convert.ToString(tbKilo.Text) == "." ? 0 : Convert.ToDecimal(tbKilo.Text);

                DisplayRemainingStocks.Controls.Clear();
                FishAvailableForm availableForm = new FishAvailableForm(DisplayRemainingStocks);
                availableForm.Variety = DVariety;
                availableForm.Bucket = bucket - tbIBucket;
                availableForm.Kilo = kilo - tbIKilo;
                DisplayRemainingStocks.Controls.Add(availableForm);


                if ((DBucket - tbIBucket) >= 0)
                {
                    ifSuffBucket = true;
                    lblErrorTub.Visible = false;
                }
                else
                {
                    ifSuffBucket = false;
                    lblErrorTub.Visible = true;
                }

                if ((DKilo - tbIKilo) >= 0)
                {
                    ifSuffKilo = true;
                    lblErrorKilo.Visible = false;
                }
                else
                {
                    ifSuffKilo = false;
                    lblErrorKilo.Visible = true;
                }
            }
            else
            {
                DisplayRemainingStocks.Controls.Clear();
            }
        }

        private void TbTax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void TbHandling_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void TbUnloading_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void DgvTax_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            No = Convert.ToInt64(dgvTax.Rows[e.RowIndex].Cells[2].Value.ToString());
            if (dgvTax.Columns[e.ColumnIndex].Name == "Delete")
            {
                taxProperties.IDClass = dgvTax.Rows[e.RowIndex].Cells[3].Value.ToString();
                taxProperties.No = No;
                taxProperties.Variety = dgvTax.Rows[e.RowIndex].Cells[7].Value.ToString();
                taxProperties.NoBucket = Convert.ToInt32(dgvTax.Rows[e.RowIndex].Cells[8].Value.ToString());
                taxProperties.NoKilo = Convert.ToInt32(dgvTax.Rows[e.RowIndex].Cells[9].Value.ToString());
                DialogResult result = MessageBox.Show("Are you sure you wan't to Delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (taxCommission.DeleteTaxCom(taxProperties))
                    {
                        MessageBox.Show("Successfully Deleted!","Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ImportDataDisplay();
                        dgvTax.DataSource = taxCommission.ReadTaxCom(IDClass);
                    }
                    
                }
            }
            if (dgvTax.Columns[e.ColumnIndex].Name == "Edit")
            {
                ifTrueEdit = true;
                tbKilo.Enabled = true;
                tbBucket.Enabled = true;
                tbCommision.Enabled = true;
                tbPriceBucket.Enabled = true;
                tbPriceKilo.Enabled = true;
                cbVariety.DropDownStyle = ComboBoxStyle.Simple;
                CKilo = Convert.ToDecimal(dgvTax.Rows[e.RowIndex].Cells[9].Value.ToString());
                CBucket = Convert.ToDecimal(dgvTax.Rows[e.RowIndex].Cells[8].Value.ToString());
                Date.Value = Convert.ToDateTime(dgvTax.Rows[e.RowIndex].Cells[5].Value.ToString());
                tbSeller.Text = dgvTax.Rows[e.RowIndex].Cells[4].Value.ToString();
                tbBucket.Text = dgvTax.Rows[e.RowIndex].Cells[8].Value.ToString();
                cbVariety.Text = dgvTax.Rows[e.RowIndex].Cells[7].Value.ToString();
                tbKilo.Text = dgvTax.Rows[e.RowIndex].Cells[9].Value.ToString();
                tbCommision.Text = dgvTax.Rows[e.RowIndex].Cells[6].Value.ToString();
                tbPriceBucket.Text = dgvTax.Rows[e.RowIndex].Cells[11].Value.ToString();
                tbPriceKilo.Text = dgvTax.Rows[e.RowIndex].Cells[10].Value.ToString();
                cbVariety.Enabled = true;
                

                // Display Data
                DisplayRemainingStocks.Controls.Clear();
                tableImport = importConnector.RetrieverData(IDClass);
                foreach (DataRow dataRow in tableImport.Rows)
                {
                    if (dataRow["KindofFish"].ToString() == cbVariety.Text)
                    {
                        DVariety = dataRow["KindofFish"].ToString();
                        DBucket = Convert.ToDecimal(dataRow["NoofTubs"].ToString()) + Convert.ToInt32(dgvTax.Rows[e.RowIndex].Cells[8].Value.ToString());
                        DKilo = Convert.ToDecimal(dataRow["NoofKilos"].ToString()) + Convert.ToInt32(dgvTax.Rows[e.RowIndex].Cells[9].Value.ToString());
                        ImportDataDisplay(DKilo, DBucket);
                    }
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        { 
            taxProperties.IDClass = IDClass;
            taxProperties.Vendor = tbSeller.Text;
            taxProperties.Variety = cbVariety.Text;
            taxProperties.Date = Date.Value;
            taxProperties.NoBucket = Convert.ToInt32(tbBucket.Text);
            taxProperties.NoKilo = Convert.ToDecimal(tbKilo.Text);
            taxProperties.PriceBucket = Convert.ToDecimal(tbPriceBucket.Text);
            taxProperties.PriceKilo = Convert.ToDecimal(tbPriceKilo.Text);
            taxProperties.Commission = Convert.ToDecimal(tbCommision.Text);
            if (taxCommission.SearchDuplicate(taxProperties))
            {
                DialogResult dialogResult = MessageBox.Show($"This Costumer's is Already Have {cbVariety.Text} Fish Do you want to combine this to the Old Data?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    if (taxCommission.UpdateDuplicate(taxProperties))
                    {
                        if (taxCommission.InsertUpdateTaxComm(taxProperties))
                        {
                            MessageBox.Show("Successfully Added!", "Message", MessageBoxButtons.OK);
                            ImportDataDisplay();
                        }
                        else
                        {
                            MessageBox.Show("Unsuccessfully Add!", "Message", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unsuccessfully Add!", "Message", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    if (taxCommission.InsertTaxCom(taxProperties))
                    {
                        MessageBox.Show("Successfully Inserted!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ImportDataDisplay();
                    }
                    else
                    {
                        MessageBox.Show("Unsuccessfully Insert!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                if (taxCommission.InsertTaxCom(taxProperties))
                {
                    MessageBox.Show("Successfully Inserted!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ImportDataDisplay();
                }
                else
                {
                    MessageBox.Show("Unsuccessfully Insert!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            dgvTax.DataSource = taxCommission.ReadTaxCom(IDClass);
            ImportDataDisplay();
            ClearField();
        }

        private void BtnUpdated_Click(object sender, EventArgs e)
        {
            taxProperties.IDClass = IDClass;
            taxProperties.No = No;
            taxProperties.Vendor = tbSeller.Text;
            taxProperties.Variety = cbVariety.Text;
            taxProperties.Date = Date.Value;
            taxProperties.NoBucket = Convert.ToDecimal(tbBucket.Text);
            taxProperties.NoKilo = Convert.ToDecimal(tbKilo.Text);
            taxProperties.PriceBucket = Convert.ToDecimal(tbPriceBucket.Text);
            taxProperties.PriceKilo = Convert.ToDecimal(tbPriceKilo.Text);
            taxProperties.Commission = Convert.ToDecimal(tbCommision.Text);
            if (taxCommission.UpdateTaxCom(taxProperties))
            {
                MessageBox.Show("Successfully Updated!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvTax.DataSource = taxCommission.ReadTaxCom(IDClass);
            }
            else
            {
                MessageBox.Show("Unsuccessfully Update!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            taxProperties.CKilo = CKilo;
            taxProperties.CBucket = CBucket;
            taxCommission.UpdateEditDataComm(taxProperties);
            ImportDataDisplay();
            ClearField();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearField();
        }

        private void TbBucket_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void TbKilo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void TbCommision_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void TbPriceBucket_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void TbPriceKilo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void TbSeller_TextChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
        }

        private void TbBucket_TextChanged(object sender, EventArgs e)
        {
            if (tbBucket.Text == "" || tbBucket.Text == "0" || tbBucket.Text == "." )
            {
                tbPriceBucket.Text = "0";
                tbPriceBucket.Enabled = false;
            }
            else
            {
                tbPriceBucket.Enabled = true;
            }
            ImportDataDisplay(DKilo, DBucket);
            BtnTriggerActivator();
        }

        private void TbKilo_TextChanged(object sender, EventArgs e)
        {   
            if (tbKilo.Text == "" || tbKilo.Text == "0")
            {
                tbPriceKilo.Text = "0";
                tbPriceKilo.Enabled = false;
            }
            else
            {
                tbPriceKilo.Enabled = true;
                tbPriceBucket.Enabled = true;
                if (ifTrueEdit)
                {
                    if (DKilo >= Convert.ToDecimal(tbKilo.Text))
                    {
                        ifSuffKilo = true;
                        lblErrorKilo.Visible = false;
                    }
                    else
                    {
                        ifSuffKilo = false;
                        lblErrorKilo.Visible = true;
                    }
                }
            }
            ImportDataDisplay(DKilo, DBucket);
            BtnTriggerActivator();
        }

        private void TbCommision_TextChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
        }

        private void TbPriceBucket_TextChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
        }

        private void TbPriceKilo_TextChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
        }

        private void TbBucket_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void TbTax_TextChanged(object sender, EventArgs e)
        {
            TaxButtonActivator();
        }

        private void TbHandling_TextChanged(object sender, EventArgs e)
        {
            TaxButtonActivator();
        }

        private void TbUnloading_TextChanged(object sender, EventArgs e)
        {
            TaxButtonActivator();
        }
    }
}
