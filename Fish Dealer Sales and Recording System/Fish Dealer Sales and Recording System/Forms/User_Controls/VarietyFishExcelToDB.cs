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
    public partial class VarietyFishExcelToDB : UserControl
    {
        private ItemReaderConnector itemReader = new ItemReaderConnector();
        private DataGridToDBConnector toDBConnector = new DataGridToDBConnector();
        public VarietyFishExcelToDB()
        {
            InitializeComponent();
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Microsoft.Office.Interop.Excel.Application excelApp;
                Microsoft.Office.Interop.Excel.Workbook excelWB;
                Microsoft.Office.Interop.Excel.Worksheet excelWS;
                Microsoft.Office.Interop.Excel.Range excelRange;

                int excelRow;
                string stringFileName;
                openFolder.Filter = "Excel Office |*xls; *xlsx";
                openFolder.ShowDialog();
                stringFileName = openFolder.FileName;

                if (stringFileName != "")
                {
                    excelApp = new Microsoft.Office.Interop.Excel.Application();
                    excelWB = excelApp.Workbooks.Open(stringFileName);
                    excelWS = excelWB.Worksheets["Variety"];
                    excelRange = excelWS.UsedRange;
                    int i = 0;

                    for (excelRow = 2; excelRow <= excelRange.Rows.Count; excelRow++)
                    {
                        i++;
                        if (excelRange.Cells[excelRow, 1].Text != "")
                        {
                            dgvData.Rows.Add(i, excelRange.Cells[excelRow, 1].Text);
                        }
                    }
                    excelWB.Close();
                    excelApp.Quit();
                    btnSave.Enabled = true;
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception)
            {
                // Do what
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            List<string> varietyList = new List<string>();
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                for (int i = 0; i < dgvData.Rows.Count; i++)
                {
                    varietyList.Add(dgvData.Rows[i].Cells[1].Value.ToString());
                }
                toDBConnector.VarietyDB(varietyList);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnSave.Enabled = false;
        }
    }
}
