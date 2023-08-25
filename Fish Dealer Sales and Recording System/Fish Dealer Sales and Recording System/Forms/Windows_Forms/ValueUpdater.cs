using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public partial class ValueUpdater : Form
    {
        private ValueUpdaterPropertiesModel valueProperties = new ValueUpdaterPropertiesModel();
        private string ItemName;
        private int ItemValue;
        private string ValueName;
        private string NameEdit;
        private bool availableTubStocks = false;
        private bool availableKiloStocks = false;
        public int newValue { get; set; }
        private DataTable itemTable;
        public ValueUpdater(ValueUpdaterPropertiesModel valueUpdater)
        {
            InitializeComponent();
            this.ItemName = valueUpdater.ItemName;
            this.ItemValue = valueUpdater.ItemValue;
            this.itemTable = valueUpdater.itemTable;
            this.ValueName = valueUpdater.ValueName;
            this.NameEdit = valueUpdater.NameEdit;
        }

        private void ValueUpdater_Load(object sender, EventArgs e)
        {
            tbItemName.Text = ItemName;
            tbItemValue.Text = ItemValue.ToString();
            tbItem.Text = $"Current {ValueName} Value";
            foreach (DataRow dataRow in itemTable.Rows)
            {
                if (dataRow["KindofFish"].ToString() == ItemName && Convert.ToInt16(dataRow["NoofTubs"]) > 0 && NameEdit == "Export")
                {
                    availableTubStocks = true;
                }
                if (dataRow["KindofFish"].ToString() == ItemName && Convert.ToInt16(dataRow["NoofKilos"]) > 0 && NameEdit == "Export")
                {
                    availableKiloStocks = true;
                }
            }
            if (availableTubStocks == false || availableKiloStocks == false)
            {
                tbAdd.Enabled = false;
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            newValue = Convert.ToInt32(tbItemValue.Text);
            this.Close();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (tbAdd.Text.Length != 0)
            {
                newValue = Convert.ToInt32(tbAdd.Text) + Convert.ToInt32(tbItemValue.Text);
            }
            else
            {
                newValue = Convert.ToInt32(tbItemValue.Text) - Convert.ToInt32(tbMinus.Text);
            }
            this.Close();
        }

        private void TbMinus_TextChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
        }

        private void TbAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void TbMinus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void BtnTriggerActivator()
        {
            if (NameEdit == "Export")
            {
                if (tbMinus.Text.Length != 0)
                {
                    lblErrorMinus.Visible = false;
                    tbAdd.Enabled = false;
                    if (Convert.ToInt16(ItemValue) >= Convert.ToInt16(tbMinus.Text))
                    {
                        if (Convert.ToInt32(tbItemValue.Text) >= Convert.ToInt32(tbMinus.Text))
                        {
                            lblErrorMinus.Visible = false;
                            btnUpdate.Enabled = true;
                        }
                        else
                        {
                            lblErrorMinus.Visible = true;
                            btnUpdate.Enabled = false;
                        }
                    }
                    else
                    {
                        lblErrorMinus.Visible = true;
                    }
                }
                else if (tbAdd.Text.Length != 0)
                {
                    tbMinus.Enabled = false;
                    foreach (DataRow dataRow in itemTable.Rows)
                    {
                        if (dataRow["KindofFish"].ToString() == tbItemName.Text)
                        {
                            if (ValueName == "Kilo/s")
                            {
                                if (Convert.ToInt32(dataRow["NoofKilos"]) >= Convert.ToInt32(tbAdd.Text))
                                {
                                    lblErrorAdd.Visible = false;
                                    btnUpdate.Enabled = true;
                                }
                                else
                                {
                                    lblErrorAdd.Text = "Insufficient Kilo/s Stock!";
                                    lblErrorAdd.Visible = true;
                                    btnUpdate.Enabled = false;
                                }
                            }
                            else
                            {
                                if (Convert.ToInt32(dataRow["NoofTubs"]) >= Convert.ToInt32(tbAdd.Text))
                                {
                                    lblErrorAdd.Visible = false;
                                    btnUpdate.Enabled = true;
                                }
                                else
                                {
                                    lblErrorAdd.Text = "Insufficient Bucket/s Stock!";
                                    lblErrorAdd.Visible = true;
                                    btnUpdate.Enabled = false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    lblErrorMinus.Visible = false;
                    tbAdd.Enabled = true;
                    tbMinus.Enabled = true;
                    btnUpdate.Enabled = false;
                }
            }
            if (NameEdit == "Import")
            {
                if (tbAdd.Text.Length != 0)
                {
                    tbMinus.Enabled = false;
                    btnUpdate.Enabled = true;
                }
                else if (tbMinus.Text.Length != 0)
                {
                    tbAdd.Enabled = false;
                    btnUpdate.Enabled = true;
                }
                else
                {
                    tbAdd.Enabled = true;
                    tbMinus.Enabled = true;
                    btnUpdate.Enabled = false;
                }
            }
        }

        private void TbAdd_TextChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
        }
    }
}