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
        private string IDClass;
        private TaxConnector taxConnector = new TaxConnector();
        private TaxPropertiesModel taxProperties = new TaxPropertiesModel();
        public Tax(string IDClass)
        {
            InitializeComponent();
            this.IDClass = IDClass;
        }

        private void Tax_Load(object sender, EventArgs e)
        {
            if (taxConnector.TaxRead(IDClass).Rows.Count > 0)
            {
                foreach(DataRow dataRow in taxConnector.TaxRead(IDClass).Rows)
                {
                    tbCommission.Text = dataRow["Commission"].ToString();
                    tbHandling.Text = dataRow["Handling"].ToString();
                    tbUnloading.Text = dataRow["Unloading"].ToString();
                    tbTax.Text = dataRow["Tax"].ToString();
                    btnAdd.Text = "Update";
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "ADD")
            {
                taxProperties.IDClass = IDClass;
                taxProperties.Handling = Convert.ToDecimal(tbHandling.Text.TrimEnd());
                taxProperties.Tax = Convert.ToDecimal(tbTax.Text.TrimEnd());
                taxProperties.Unloading = Convert.ToDecimal(tbUnloading.Text.TrimEnd());
                taxProperties.Commission = Convert.ToDecimal(tbCommission.Text.TrimEnd());
                taxConnector.TaxInsert(taxProperties);
            }
            else
            {
                taxProperties.IDClass = IDClass;
                taxProperties.Handling = Convert.ToDecimal(tbHandling.Text.TrimEnd());
                taxProperties.Tax = Convert.ToDecimal(tbTax.Text.TrimEnd());
                taxProperties.Unloading = Convert.ToDecimal(tbUnloading.Text.TrimEnd());
                taxProperties.Commission = Convert.ToDecimal(tbCommission.Text.TrimEnd());
                taxConnector.TaxUpdate(taxProperties);
            }
        }

        private void TbTax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void TbCommission_KeyPress(object sender, KeyPressEventArgs e)
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

        public void BtnTriggerActivator()
        {
            if (tbCommission.Text.Length != 0 && tbTax.Text.Length != 0 && tbUnloading.Text.Length != 0 && tbHandling.Text.Length != 0)
            {
                btnAdd.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = false;
            }
        }

        private void TbTax_TextChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
        }

        private void TbCommission_TextChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
        }

        private void TbHandling_TextChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
        }

        private void TbUnloading_TextChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
        }

        private void DgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
