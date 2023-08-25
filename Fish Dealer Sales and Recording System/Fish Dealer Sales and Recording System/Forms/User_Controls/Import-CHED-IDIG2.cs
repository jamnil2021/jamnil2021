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
        private ItemReaderConnector itemRetrieve = new ItemReaderConnector();
        private ImportConnector importConnector = new ImportConnector();
        private ImportPropertiesModel importProperties = new ImportPropertiesModel();
        private string IDClass;
        private int No;
        public Import(string IDClass)
        {
            InitializeComponent();
            this.IDClass = IDClass;
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

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearField();
        }

        private void Import_Load(object sender, EventArgs e)
        {
            cbVariety.DataSource = itemRetrieve.VarietyFish();
            cbVariety.DisplayMember = "VarietyofFish";
            dgvImport.DataSource = importConnector.ReadImport(IDClass);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            importProperties.IDClass = IDClass;
            importProperties.ItemName = cbVariety.Text;
            importProperties.NoofBucket = Convert.ToInt32(tbBucket.Text);
            importProperties.QuantityKilo = Convert.ToInt32(tbKilo.Text);
            importConnector.InsertImport(importProperties);
            dgvImport.DataSource = importConnector.ReadImport(IDClass);
            ClearField();
        }

        private void DgvImport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(e.ColumnIndex.ToString());
            if (dgvImport.Columns[e.ColumnIndex].Name == "Edit")
            {
                btnUpdate.Enabled = true;
                No = Convert.ToInt32(dgvImport.Rows[e.RowIndex].Cells[2].Value.ToString());
                cbVariety.Text = dgvImport.Rows[e.RowIndex].Cells[4].Value.ToString();
                tbBucket.Text = dgvImport.Rows[e.RowIndex].Cells[5].Value.ToString();
                tbKilo.Text = dgvImport.Rows[e.RowIndex].Cells[6].Value.ToString();
                tbKilo.ForeColor = Color.Black;
                tbBucket.ForeColor = Color.Black;
                cbVariety.ForeColor = Color.Black;
            }
            if (dgvImport.Columns[e.ColumnIndex].Name == "Delete")
            {
                DialogResult result = MessageBox.Show("Delete", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    importProperties.No = Convert.ToInt32(dgvImport.Rows[e.RowIndex].Cells[2].Value.ToString());
                    importProperties.IDClass = IDClass;
                    importConnector.DeleteImport(importProperties);
                    dgvImport.DataSource = importConnector.ReadImport(IDClass);
                    ClearField();
                }
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            importProperties.IDClass = IDClass;
            importProperties.No = No;
            importProperties.ItemName = cbVariety.Text;
            importProperties.NoofBucket = Convert.ToInt32(tbBucket.Text);
            importProperties.QuantityKilo = Convert.ToInt32(tbKilo.Text);
            importConnector.UpdateImport(importProperties);
            dgvImport.DataSource = importConnector.ReadImport(IDClass);
            ClearField();
        }

        private void BtnClear_Click_1(object sender, EventArgs e)
        {
            ClearField();
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
        }

        private void TbKilo_TextChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
        }

        private void TbBucket_TextChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
        }

        private void CbVariety_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
        }
    }
}
