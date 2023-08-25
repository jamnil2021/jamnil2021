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
    public partial class Files : UserControl
    {
        private string query = @"SELECT Date, Vendor, KindofFish, NoofTub, NoofKilo, UnitTubPrice, UnitKiloPrice, TotalPrice FROM tblCostumerData WHERE ";
        private DataTableConnector tableConnector= new DataTableConnector();

        //private string exportQuery;
        private List<ExportPropertiesModel> actAsDataSource = new List<ExportPropertiesModel>();
        public Files()
        {
            InitializeComponent();
        }

        private void Reset()
        {
            query = @"SELECT Date, Vendor, KindofFish, NoofTub, NoofKilo, UnitTubPrice, UnitKiloPrice, TotalPrice FROM tblCostumerData WHERE ";
            Vendor.Checked = false; Date.Checked = false; NoofTub.Checked = false; NoofKilo.Checked = false; UnitTubPrice.Checked = false;
            UnitKiloPrice.Checked = false; KindofFish.Checked = false; tbVendor.Text = ""; cbKindofFish.Text = ""; tbNoofTub.Text = "";
            tbNoofKilo.Text = ""; tbTubPrice.Text = ""; tbKiloPrice.Text = ""; btnShowData.Visible = false;
        }

        private void ButtonEnable()
        {
            if (Date.Checked || Vendor.Checked || KindofFish.Checked || NoofKilo.Checked || NoofTub.Checked || UnitKiloPrice.Checked || UnitTubPrice.Checked)
            {
                btnSearch.Enabled = true;
            }
            else
            {
                btnSearch.Enabled = false;
            }
        }

        private void File_Load(object sender, EventArgs e)
        {
            dgvExcelFiles.DataSource = tableConnector.ReadData();
        }

        private void Vendor_CheckedChanged(object sender, EventArgs e)
        {
            if (Vendor.Checked)
            {
                tbVendor.Enabled = true;
                btnPrint.Visible = false;
                ButtonEnable();
            }
            else
            {
                tbVendor.Enabled = false;
                ButtonEnable();
            }
        }

        private void KindofFish_CheckedChanged(object sender, EventArgs e)
        {
            if (KindofFish.Checked)
            {
                cbKindofFish.Enabled = true;
                btnPrint.Visible = false;
                ButtonEnable();
            }
            else
            {
                cbKindofFish.Enabled = false;
                ButtonEnable();
            }
        }

        private void Date_CheckedChanged(object sender, EventArgs e)
        {
            if (Date.Checked)
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
                btnPrint.Visible = false;
                ButtonEnable();
            }
            else
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
                ButtonEnable();
            }
        }

        private void NoofTub_CheckedChanged(object sender, EventArgs e)
        {
            if (NoofTub.Checked)
            {
                tbNoofTub.Enabled = true;
                btnPrint.Visible = false;
                ButtonEnable();
            }
            else
            {
                tbNoofTub.Enabled = false;
                ButtonEnable();
            }
        }

        private void UnitKiloPrice_CheckedChanged(object sender, EventArgs e)
        {
            if (NoofKilo.Checked)
            {
                tbNoofKilo.Enabled = true;
                btnPrint.Visible = false;
                ButtonEnable();
            }
            else
            {
                tbNoofKilo.Enabled = false;
                ButtonEnable();
            }
        }

        private void UnitTubPrice_CheckedChanged(object sender, EventArgs e)
        {
            if (UnitTubPrice.Checked)
            {
                tbTubPrice.Enabled = true;
                btnPrint.Visible = false;
                ButtonEnable();
            }
            else
            {
                tbTubPrice.Enabled = false;
                ButtonEnable();
            }
        }

        private void NoofKilo_CheckedChanged(object sender, EventArgs e)
        {
            if (NoofKilo.Checked)
            {
                tbNoofKilo.Enabled = true;
                btnPrint.Visible = false;
                ButtonEnable();
            }
            else
            {
                tbNoofKilo.Enabled = false;
                ButtonEnable();
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            List<PrintDataPropertiesModel> _list = new List<PrintDataPropertiesModel>();

            foreach(DataGridViewRow row in dgvExport.Rows)
            {
                PrintDataPropertiesModel printData = new PrintDataPropertiesModel();
                printData.Date = row.Cells["dnDate"].Value.ToString();
                printData.Vendor = row.Cells["dnVendor"].Value.ToString();
                printData.Variety = row.Cells["dnVariety"].Value.ToString();
                printData.Kilo = Convert.ToInt32(row.Cells["dnKilo"].Value.ToString());
                printData.Bucket = Convert.ToInt32(row.Cells["dnBucket"].Value.ToString());
                printData.UnitBucketPrice = Convert.ToDecimal(row.Cells["dnBPrice"].Value.ToString());
                printData.UnitKiloPrice = Convert.ToDecimal(row.Cells["dnKilo"].Value.ToString());
                printData.TotalPrice = Convert.ToDecimal(row.Cells["dnTotal"].Value.ToString());
                _list.Add(printData);
            }
            using (PrintReport printReport = new PrintReport(_list))
            {
                printReport.ShowDialog();
                _list.Clear();
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            Queue<string> queue = new Queue<string>();

            foreach (Control control in SearchCategoryPanel.Controls)
            {
                if (control is CheckBox)
                {
                    CheckBox itemCheckedCheck = (CheckBox)control;
                    if (itemCheckedCheck.Checked)
                    {
                        queue.Enqueue(itemCheckedCheck.Name);
                    }
                }
            }

            while (queue.Count > 0)
            {
                foreach (Control control in groupBoxSearch.Controls)
                {
                    if (queue.Count > 1)
                    {
                        if ((control.Name == "tb" + queue.Peek()) && (control is TextBox))
                        {
                            TextBox textBox = (TextBox)control;
                            query = $@"{query} {queue.Dequeue()} = '{textBox.Text.Trim()}' AND ";
                            break;
                        }
                        if ((control.Name == "cb" + queue.Peek()) && (control is ComboBox))
                        {
                            ComboBox comboBox = (ComboBox)control;
                            query = $@"{query} {queue.Dequeue()} = '{comboBox.Text.Trim()}' AND ";
                            break;
                        }
                        if ((control.Name == "dtFrom" + queue.Peek()) && (control is DateTimePicker))
                        {
                            query = $@"{query} Date BETWEEN '{dtFromDate.Value.ToString("yyyy-MM-dd")}' AND '{dtToDate.Value.ToString("yyyy-MM-dd")}' AND ";
                            queue.Dequeue();
                            break;
                        }
                    }
                    else
                    {
                        if ((control.Name == "tb" + queue.Peek()) && (control is TextBox))
                        {
                            TextBox textBox = (TextBox)control;
                            query = $@"{query} {queue.Dequeue()} = '{textBox.Text.Trim()}'";
                            break;
                        }
                        if ((control.Name == "cb" + queue.Peek()) && (control is ComboBox))
                        {
                            ComboBox comboBox = (ComboBox)control;
                            query = $@"{query} {queue.Dequeue()} = '{comboBox.Text.Trim()}'";
                            break;
                        }
                        if ((control.Name == "dtFrom" + queue.Peek()) && (control is DateTimePicker))
                        {
                            query = $@"{query} Date BETWEEN '{dtFromDate.Value.ToString("yyyy-MM-dd")}' AND '{dtToDate.Value.ToString("yyyy-MM-dd")}'";
                            queue.Dequeue();
                            break;
                        }
                    }
                }
            }
            dgvExport.DataSource = tableConnector.CostumersData(query);
            Reset();
            if (dgvExport.RowCount > 0)
            {
                btnPrint.Visible = true;
                btnShowData.Visible = true;
            }
        }

        private void TbNoofKilo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void TbNoofTub_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void TbKiloPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void TbTubPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void BtnShowData_Click(object sender, EventArgs e)
        {
            List<PrintDataPropertiesModel> _list = new List<PrintDataPropertiesModel>();

            foreach (DataGridViewRow row in dgvExport.Rows)
            {
                PrintDataPropertiesModel printData = new PrintDataPropertiesModel();
                printData.Date = row.Cells["dnDate"].Value.ToString();
                printData.Vendor = row.Cells["dnVendor"].Value.ToString();
                printData.Variety = row.Cells["dnVariety"].Value.ToString();
                printData.Kilo = Convert.ToInt32(row.Cells["dnKilo"].Value.ToString());
                printData.Bucket = Convert.ToInt32(row.Cells["dnBucket"].Value.ToString());
                printData.UnitBucketPrice = Convert.ToDecimal(row.Cells["dnBPrice"].Value.ToString());
                printData.UnitKiloPrice = Convert.ToDecimal(row.Cells["dnKilo"].Value.ToString());
                printData.TotalPrice = Convert.ToDecimal(row.Cells["dnTotal"].Value.ToString());
                _list.Add(printData);
            }
            using (ShowData printReport = new ShowData(_list))
            {
                printReport.ShowDialog();
                _list.Clear();
            }
        }

        private void DgvExcelFiles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            List<PrintDataPropertiesModel> _summaryData = tableConnector.PrintData(dgvExcelFiles.Rows[e.RowIndex].Cells[0].Value.ToString());
            if (dgvExcelFiles.Columns[e.ColumnIndex].Name == "DateGenerated")
            {
                new ModalForm(_summaryData, dgvExcelFiles).ShowDialog();
            }
        }
    }
}
