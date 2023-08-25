using Fish_Dealer_Sales_and_Recording_System.Database;
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
    public partial class AddRecord : Form
    {
        private DateDeparturePropertiesModel dateProperties = new DateDeparturePropertiesModel();
        private DateDepartureConnector departureConnector = new DateDepartureConnector();
        private VesselNameConnector vesselConnector = new VesselNameConnector();
        private int rowKey;
        private bool boolEdit;
        private DateTime dateCast;
        private DateTime dateDock;
        private string VesselName;
        private string IDClass;

        public AddRecord(DateDeparturePropertiesModel recordPropertiesModel)
        {
            InitializeComponent();
            dateCast = Convert.ToDateTime(recordPropertiesModel.CastOff);
            dateDock = Convert.ToDateTime(recordPropertiesModel.Docking);
            rowKey = recordPropertiesModel.No;
            this.boolEdit = recordPropertiesModel.boolEdit;
            this.VesselName = recordPropertiesModel.VesselName;
            this.IDClass = recordPropertiesModel.IDClass;
        }

        public AddRecord()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (boolEdit == false)
            {
                if (dtpDocking.Enabled == true)
                {
                    if (dtpCastOff.Value.CompareTo(dtpDocking.Value) == -1)
                    {
                        DialogResult result = MessageBox.Show("Are you sure, you wan't to Continue?", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result == DialogResult.OK)
                        {
                            dateProperties.VesselName = tbVesselName.Text;
                            dateProperties.CastOff = dtpCastOff.Value.ToString("yyyy-MM-dd");
                            dateProperties.Docking = dtpDocking.Value.ToString("yyyy-MM-dd");
                            departureConnector.InsertDate(dateProperties);
                            MessageBox.Show("Successful Save!", "Message");
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Check Your Dock Date!");
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Are you sure, you wan't to Continue?", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        dateProperties.VesselName = tbVesselName.Text;
                        dateProperties.CastOff = dtpCastOff.Value.ToString("yyyy-MM-dd");
                        dateProperties.Docking = "2000-1-1";
                        departureConnector.InsertDate(dateProperties);
                        MessageBox.Show("Successful Save!");
                        this.Close();
                    }
                }
            }
            else
            {
                if (dtpCastOff.Value.CompareTo(dtpDocking.Value) == -1)
                {
                    DialogResult result = MessageBox.Show("Are you sure, you wan't to Continue?", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        dateProperties.VesselName = tbVesselName.Text;
                        dateProperties.CastOff = dtpCastOff.Value.ToString("yyyy-MM-dd");
                        dateProperties.Docking = dtpDocking.Value.ToString("yyyy-MM-dd");
                        dateProperties.IDClass = IDClass;
                        departureConnector.EditDate(dateProperties);
                        MessageBox.Show("Successful Update!", "Message");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Please Check Your Dock Date!", "Message");
                }
            }
        }
        public void ButtonTrigger()
        {
            if (tbVesselName.Text.Length != 0)
            {
                if (Convert.ToInt16(departureConnector.DateChecker(dtpCastOff.Value, tbVesselName.Text)) > 0)
                {
                    tbError.Text = "Unavailable!";
                    btnAdd.Enabled = false;
                }
                else
                {
                    tbError.Text = "Available!";
                    btnAdd.Enabled = true;
                }
            }
            else
            {
                tbError.Text = "Please Enter Vessel Name!";
                btnAdd.Enabled = false;
            }
        }

        private void TbVesselName_Enter(object sender, EventArgs e)
        {
            tbVesselName.Text = "";
            tbVesselName.ForeColor = Color.Black;
            lblMessage.Visible = true;
        }

        private void CboxSetDocking_CheckedChanged(object sender, EventArgs e)
        {
            if (dtpDocking.Enabled == false)
            {
                dtpDocking.Enabled = true;
            }
            else
            {
                dtpDocking.Enabled = false;
            }
        }

        private void AddRecord_Load(object sender, EventArgs e)
        {
            tbVesselName.DataSource = vesselConnector.RetrieveVesselName();
            tbVesselName.DisplayMember = "VesselName";
            tbVesselName.SelectedIndex = -1;
            if (boolEdit)
            {
                tbVesselName.Text = VesselName;
                tbVesselName.Enabled = false;
                dtpCastOff.Value = dateCast;
                if (dateCast.CompareTo(dateDock) == -1)
                {
                    cboxSetDocking.Checked = true;
                    dtpDocking.Enabled = true;
                    dtpDocking.Value = dateDock;
                }
                else
                {
                    cboxSetDocking.Checked = false;
                    dtpDocking.Enabled = false;
                    dtpDocking.Value = dateDock;
                }
            }
        }

        private void TbVesselName_Leave(object sender, EventArgs e)
        {
            if (tbVesselName.Text == "")
            {
                tbVesselName.Text = "Enter Vessel Name";
                tbVesselName.ForeColor = Color.LightGray;
            }
        }

        private void dtpCastOff_ValueChanged(object sender, EventArgs e)
        {
            ButtonTrigger();
        }

        private void tbVesselName_TextChanged_1(object sender, EventArgs e)
        {
            tbError.Visible = true;
            ButtonTrigger();
        }

        private void BtnAddRecord_Click(object sender, EventArgs e)
        {
            new AddNewVessel().ShowDialog();

            tbVesselName.DataSource = vesselConnector.RetrieveVesselName();
            tbVesselName.DisplayMember = "VesselName";
        }

        private void TbVesselName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButtonTrigger();
        }
    }
}
