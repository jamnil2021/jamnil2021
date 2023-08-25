using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public partial class Expenses : UserControl
    {
        private ExpensesPropertiesModel expensesProperties = new ExpensesPropertiesModel();
        private ItemReaderConnector itemReader = new ItemReaderConnector();
        private ExpensesConnector expensesConnector = new ExpensesConnector();
        private int No;
        private string IDClass;
        public Expenses(string IDClass)
        {
            InitializeComponent();
            this.IDClass = IDClass;
        }

        private void Expenses_Load(object sender, EventArgs e)
        {
            cbCategory.Items.Add("MAINTENANCE AND REPAIR");
            cbCategory.Items.Add("OPERATIONAL");
            cbCategory.Items.Add("MERCHANDISE");
            dgvExpenses.DataSource = expensesConnector.ReadExpeses(IDClass);
        }

        private void DgvExpenses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            No = Convert.ToInt32(dgvExpenses.Rows[e.RowIndex].Cells[2].Value.ToString());
            if (dgvExpenses.Columns[e.ColumnIndex].Name == "Delete")
            {
                DialogResult result = MessageBox.Show("Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    expensesProperties.No = No;
                    expensesProperties.IDClass = IDClass;
                    expensesConnector.DeleteExpenses(expensesProperties);
                    dgvExpenses.DataSource = expensesConnector.ReadExpeses(IDClass);
                    ClearField();
                }
            }
            if (dgvExpenses.Columns[e.ColumnIndex].Name == "Edit")
            {
                btnUpdate.Enabled = true;
                cbCategory.Text = dgvExpenses.Rows[e.RowIndex].Cells[4].Value.ToString();
                tbItem.Text = dgvExpenses.Rows[e.RowIndex].Cells[5].Value.ToString();
                tbPrice.Text = dgvExpenses.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
        }
        private void BtnTriggerActivation()
        {
            if (cbCategory.SelectedIndex > -1 || tbItem.Text.Length != 0 || tbPrice.Text.Length != 0)
            {
                btnClear.Enabled = true;
                if (cbCategory.Text.Length != 0 && tbItem.Text.Length != 0 && tbPrice.Text.Length != 0)
                {
                    btnAdd.Enabled = true;
                }
            }
            else
            {
                btnClear.Enabled = false;
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
            }
        }
        private void ClearField()
        {
            cbCategory.SelectedIndex = -1;
            tbItem.Text = "";
            tbPrice.Text = "";
            btnClear.Enabled = false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            expensesProperties.IDClass = IDClass;
            expensesProperties.Category = cbCategory.Text.TrimEnd();
            expensesProperties.Item = tbItem.Text.TrimEnd();
            expensesProperties.Price = Convert.ToDecimal(tbPrice.Text.TrimEnd());
            if (expensesConnector.checkerExpenses(expensesProperties))
            {
                DialogResult result = MessageBox.Show("Do you wan't to Add this in Existing Data?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (expensesConnector.UpdateDuplication(expensesProperties))
                    {
                        MessageBox.Show("Successfully Updated!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Unsuccessfully Updated!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    ClearField();
                }
            }
            else
            {
                if (expensesConnector.InsertExpenses(expensesProperties))
                {
                    MessageBox.Show("Successfull Inserted!", "Message",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Successfull Inserted!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (expensesConnector.SearchDuplicationCategory(expensesProperties) == false)
            {
                expensesConnector.InsertCategory(expensesProperties);
            }
            dgvExpenses.DataSource = expensesConnector.ReadExpeses(IDClass);
            ClearField();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            expensesProperties.No = No;
            expensesProperties.IDClass = IDClass;
            expensesProperties.Category = cbCategory.Text.TrimEnd();
            expensesProperties.Item = tbItem.Text.TrimEnd();
            expensesProperties.Price = Convert.ToInt32(tbPrice.Text.TrimEnd());
            expensesConnector.UpdateExpenses(expensesProperties);
            dgvExpenses.DataSource = expensesConnector.ReadExpeses(IDClass);
            btnUpdate.Enabled = false;
            ClearField();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearField();
        }

        private void TbPrice_TextChanged(object sender, EventArgs e)
        {
            BtnTriggerActivation();
        }

        private void TbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnTriggerActivation();
        }

        private void CbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnTriggerActivation();
            tbItem.DataSource = itemReader.ExpensesCategory(cbCategory.Text);
            tbItem.DisplayMember = "ItemName";
            tbItem.Text = "";
        }

        private void TbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }
    }
}
