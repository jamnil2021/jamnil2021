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
    public partial class AddNewVessel : Form
    {
        private VesselNameConnector vesselConnector = new VesselNameConnector();
        public AddNewVessel()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            vesselConnector.InsertVesselName(tbVesselName.Text);
            dgvVesselName.DataSource = vesselConnector.RetrieveVesselName();
        }

        private void AddNewVessel_Load(object sender, EventArgs e)
        {
            dgvVesselName.DataSource = vesselConnector.RetrieveVesselName();
        }

        private void DgvVesselName_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVesselName.Columns[e.ColumnIndex].Name == "Delete")
            {
                DialogResult result = MessageBox.Show($"Are you sure you want to Delete {dgvVesselName.Rows[e.RowIndex].Cells[2].Value.ToString()}", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (vesselConnector.DeleteVesselName(Convert.ToInt32(dgvVesselName.Rows[e.RowIndex].Cells[1].Value)))
                    {
                        MessageBox.Show("Successfully Deleted!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvVesselName.DataSource = vesselConnector.RetrieveVesselName();
                    }
                    else
                    {
                        MessageBox.Show("Unsuccessfully Deleted!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void TbVesselName_TextChanged(object sender, EventArgs e)
        {
            if (tbVesselName.Text.Length != 0)
            {
                btnAdd.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = false;
            }
        }
    }
}
