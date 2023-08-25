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
    public partial class Crew : UserControl
    {
        private AddCrewPropertiesModel addCrewProperty = new AddCrewPropertiesModel();
        private CrewSalaryConnector salaryConnector = new CrewSalaryConnector();
        private string IDClass;
        private int No;
        public Crew(string IDClass)
        {
            InitializeComponent();
            this.IDClass = IDClass;
        }
        
        private void ClearField()
        {
            tbSalary.Text = ""; cbCrewName.SelectedIndex = -1; cbPosition.SelectedIndex = -1; btnClear.Enabled = false; btnAdd.Enabled = false; btnUpdate.Enabled = false;
        }

        public void BtnTriggerActivator()
        {
            if (cbCrewName.Text.Length != 0 || cbPosition.Text.Length != 0 || tbSalary.Text.Length != 0)
            {
                btnClear.Enabled = true;
                if (cbCrewName.Text.Length != 0 &&  cbPosition.Text.Length != 0)
                {
                    btnAdd.Enabled = true;
                }
                else
                {
                    btnAdd.Enabled = false;
                }
            }
            else
            {
                btnClear.Enabled = false;
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
            }
        }

        private void Crew_Load(object sender, EventArgs e)
        {
            // Static Crew Position
            cbPosition.Items.Add("Captain");
            cbPosition.Items.Add("Mate");
            cbPosition.Items.Add("Chief Engineer");
            cbPosition.Items.Add("Engineer's Assistant");
            cbPosition.Items.Add("Cook");
            cbPosition.Items.Add("Steward");
            cbPosition.Items.Add("Lead Foreman");
            cbPosition.Items.Add("Deck/Gear/Factory CREW");
            cbPosition.Items.Add("Quality Control");

            dgvCrewSalary.DataSource = salaryConnector.ReadCrew(IDClass);
        }

        private void DgvCrewSalary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCrewSalary.Columns[e.ColumnIndex].Name == "Delete")
            {
                DialogResult result = MessageBox.Show("Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    addCrewProperty.IDClass = IDClass;
                    addCrewProperty.No = Convert.ToInt32(dgvCrewSalary.Rows[e.RowIndex].Cells[2].Value.ToString());
                    salaryConnector.DeleteCrew(addCrewProperty);
                    dgvCrewSalary.DataSource = salaryConnector.ReadCrew(IDClass);
                    ClearField();
                }
            }
            if (dgvCrewSalary.Columns[e.ColumnIndex].Name == "Edit")
            {
                btnUpdate.Enabled = true;
                No = Convert.ToInt32(dgvCrewSalary.Rows[e.RowIndex].Cells[2].Value.ToString());
                cbCrewName.DropDownStyle = ComboBoxStyle.Simple;
                cbCrewName.Text = dgvCrewSalary.Rows[e.RowIndex].Cells[4].Value.ToString();
                cbPosition.Text = dgvCrewSalary.Rows[e.RowIndex].Cells[5].Value.ToString();
                tbSalary.Text = dgvCrewSalary.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearField();
        }

        private void CbCrewName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
        }

        private void CbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
        }

        private void TbSalary_TextChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            addCrewProperty.IDClass = IDClass;
            addCrewProperty.CrewName = cbCrewName.Text;
            addCrewProperty.Position = cbPosition.Text;
            addCrewProperty.Salary = Convert.ToDecimal(tbSalary.Text);
            if (salaryConnector.SearchDuplicationCrew(addCrewProperty))
            {
                DialogResult result = MessageBox.Show($"Since {addCrewProperty.CrewName} already has a salary, would you like to add this salary amount to his/her existing salary?"



, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (salaryConnector.UpdateDuplicateSalary(addCrewProperty))
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
                    salaryConnector.InsertCrew(addCrewProperty);
                }
            }
            else
            {
                salaryConnector.InsertCrew(addCrewProperty);
            }
            dgvCrewSalary.DataSource = salaryConnector.ReadCrew(IDClass);
            ClearField();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            cbCrewName.DropDownStyle = ComboBoxStyle.DropDownList;
            addCrewProperty.IDClass = IDClass;
            addCrewProperty.No = No;
            addCrewProperty.CrewName = cbCrewName.Text;
            addCrewProperty.Position = cbPosition.Text;
            addCrewProperty.Salary = Convert.ToDecimal(tbSalary.Text);
            salaryConnector.UpdateCrew(addCrewProperty);
            dgvCrewSalary.DataSource = salaryConnector.ReadCrew(IDClass);
            ClearField();
        }

        private void TbSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }
    }
}
