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
        public int newValue { get; set; }
        private DataTable itemTable;
        public ValueUpdater(ValueUpdaterPropertiesModel valueUpdater)
        {
            InitializeComponent();
            this.ItemName = valueUpdater.ItemName;
            this.ItemValue = valueUpdater.ItemValue;
            this.itemTable = valueUpdater.itemTable;
            this.ValueName = valueUpdater.ValueName;
        }

        private void ValueUpdater_Load(object sender, EventArgs e)
        {
            tbItemName.Text = ItemName;
            tbItemValue.Text = ItemValue.ToString();
            tbItem.Text = $"Current {ValueName} Value";
            if (ItemValue == 0)
            {
                tbAdd.Enabled = false;
                tbMinus.Enabled = false;
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


        private void TbAdd_TextChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
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
            if (tbAdd.Text.Length != 0 || tbMinus.Text.Length != 0)
            {
                foreach (DataRow dataRow in itemTable.Rows)
                {
                    if (dataRow["KindofFish"].ToString() == tbItemName.Text)
                    {
                        if (tbMinus.Text.Length != 0)
                        {
                            tbAdd.Text = "";
                            tbAdd.Enabled = false;
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
                            tbMinus.Text = "";
                            tbMinus.Enabled = false;
                            if (tbAdd.Text.Length != 0 && ValueName == "Kilo/s")
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
            }
            else
            {
                btnUpdate.Enabled = false;
                tbAdd.Text = "";
                tbAdd.Enabled = true;
                tbMinus.Text = "";
                tbMinus.Enabled = true;
                lblErrorAdd.Visible = false;
                lblErrorMinus.Visible = false;
            }
        }

        private void tbItemValue_TextChanged(object sender, EventArgs e)
        {

        }
    }
}