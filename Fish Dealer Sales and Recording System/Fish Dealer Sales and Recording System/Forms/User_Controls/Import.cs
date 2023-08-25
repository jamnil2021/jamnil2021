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
    public partial class Import : UserControl
    {
        private ValueUpdaterPropertiesModel valueUpdater = new ValueUpdaterPropertiesModel();
        private ImportPropertiesModel importProperties = new ImportPropertiesModel();
        private ItemReaderConnector itemRetrieve = new ItemReaderConnector();
        private ImportConnector importConnector = new ImportConnector();
        private ValueUpdater newValueUpdate;
        private bool editChecker = false;
        private string IDClass;
        private int No;
        public Import(string IDClass)
        {
            InitializeComponent();
            this.IDClass = IDClass;
        }

        private void Import_Load(object sender, EventArgs e)
        {
            cbVariety.DataSource = itemRetrieve.VarietyFish();
            cbVariety.DisplayMember = "VarietyofFish";
            foreach (DataRow data in importConnector.ReadTotalTubs(IDClass).Rows)
            {
                lblTotalTubs.Text = data["TotalTubs"].ToString();
            }            
            // Set DataSource of DataGridView
            dgvImport.DataSource = importConnector.ReadImport(IDClass);
        }

        private void DgvImport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvImport.Columns[e.ColumnIndex].Name == "Edits")
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                No = Convert.ToInt32(dgvImport.Rows[e.RowIndex].Cells[2].Value.ToString());
                cbVariety.Text = dgvImport.Rows[e.RowIndex].Cells[4].Value.ToString();
                tbBucket.Text = dgvImport.Rows[e.RowIndex].Cells[5].Value.ToString();
                tbKilo.Text = dgvImport.Rows[e.RowIndex].Cells[6].Value.ToString();
                tbKilo.ForeColor = Color.Black;
                tbBucket.ForeColor = Color.Black;
                cbVariety.ForeColor = Color.Black;
            }
            if (dgvImport.Columns[e.ColumnIndex].Name == "Deletes")
            {
                DialogResult result = MessageBox.Show("Delete", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    importProperties.No = Convert.ToInt32(dgvImport.Rows[e.RowIndex].Cells[2].Value.ToString());
                    importProperties.IDClass = IDClass;
                    importConnector.DeleteImport(importProperties);
                    dgvImport.DataSource = importConnector.ReadImport(IDClass);
                    ClearField();
                }
            }
            foreach (DataRow data in importConnector.ReadTotalTubs(IDClass).Rows)
            {
                lblTotalTubs.Text = data["TotalTubs"].ToString();
            }
        }
        private void BtnTriggerActivator()
        {
            if (cbVariety.Text.Length != 0 || tbBucket.Text.Length != 0 || tbKilo.Text.Length != 0 )
            {
                btnClear.Enabled = true;
                if (cbVariety.Text.Length != 0 && tbBucket.Text.Length != 0 && tbKilo.Text.Length != 0)
                {
                    btnAdd.Enabled = true;
                }
            }
            else
            {
                btnAdd.Enabled = false;
                btnClear.Enabled = false;
                btnUpdate.Enabled = false;
            }
        }

        private void ClearField()
        {
            cbVariety.Text = "";
            tbKilo.Text = "";
            tbBucket.Text = "";
            editChecker = false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            importProperties.IDClass = IDClass;
            importProperties.ItemName = cbVariety.Text.ToUpper();
            importProperties.NoofBucket = Convert.ToInt32(tbBucket.Text);
            importProperties.QuantityKilo = Convert.ToInt32(tbKilo.Text);
            if (importConnector.SearchDuplicate(importProperties) == true)
            {
                DialogResult dialogResult = MessageBox.Show($"Are you sure you wan't to add this in Stocks of {cbVariety.Text}?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    if (importConnector.UpdateDuplication(importProperties) == true)
                    {
                        MessageBox.Show("Successfully Added!", "Message", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Unsuccessfully Add!", "Message", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                importConnector.InsertImport(importProperties);

                if (importConnector.CheckerNewSpecies(cbVariety.Text) == false)
                {
                    itemRetrieve.VarietyInsert(cbVariety.Text.ToUpper());
                    cbVariety.DataSource = itemRetrieve.VarietyFish();
                    cbVariety.DisplayMember = "VarietyofFish";
                }
            }
            ClearField();
            foreach (DataRow data in importConnector.ReadTotalTubs(IDClass).Rows)
            {
                lblTotalTubs.Text = data["TotalTubs"].ToString();
            }
            dgvImport.DataSource = importConnector.ReadImport(IDClass);
        }

        private void TbBucket_TextChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
        }

        private void TbKilo_TextChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
        }

        private void CbVariety_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            importProperties.IDClass = IDClass;
            importProperties.No = No;
            importProperties.ItemName = cbVariety.Text;
            importProperties.NoofBucket = Convert.ToInt32(tbBucket.Text);
            importProperties.QuantityKilo = Convert.ToInt32(tbKilo.Text);
            if (importProperties.NoofBucket > 0 || importProperties.QuantityKilo > 0)
            {
                importConnector.UpdateImport(importProperties);
            }
            else
            {
                importConnector.DeleteImport(importProperties);
            }

            dgvImport.DataSource = importConnector.ReadImport(IDClass);
            foreach (DataRow data in importConnector.ReadTotalTubs(IDClass).Rows)
            {
                lblTotalTubs.Text = data["TotalTubs"].ToString();
            }
            ClearField();
        }

        private void TbBucket_Click(object sender, EventArgs e)
        {
            if (editChecker == true)
            {
                valueUpdater.ItemName = cbVariety.Text;
                valueUpdater.ItemValue = Convert.ToInt16(tbBucket.Text);
                valueUpdater.NameEdit = "Import";
                newValueUpdate = new ValueUpdater(valueUpdater);
                newValueUpdate.ShowDialog();
                tbBucket.Text = newValueUpdate.newValue.ToString();
            }
        }

        private void TbKilo_Click(object sender, EventArgs e)
        {
            if (editChecker == true)
            {
                valueUpdater.ItemName = cbVariety.Text;
                valueUpdater.ItemValue = Convert.ToInt16(tbKilo.Text);
                valueUpdater.NameEdit = "Import";
                newValueUpdate = new ValueUpdater(valueUpdater);
                newValueUpdate.ShowDialog();
                tbKilo.Text = newValueUpdate.newValue.ToString();
            }
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
    }
}
