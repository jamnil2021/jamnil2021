using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public partial class ExpensesExcelToDB : UserControl
    {
        DataGridToDBConnector gridToDBConnector = new DataGridToDBConnector();
        public ExpensesExcelToDB()
        {
            InitializeComponent();
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excelApp;
            Microsoft.Office.Interop.Excel.Workbook excelWB;
            Microsoft.Office.Interop.Excel.Worksheet excelWS;
            Microsoft.Office.Interop.Excel.Range excelRange;
            try
            {
                int excelRow;
                string stringFileName;
                openFolder.Filter = "Excel Office |*xls; *xlsx";
                openFolder.ShowDialog();
                stringFileName = openFolder.FileName;

                if (stringFileName != "")
                {
                    excelApp = new Microsoft.Office.Interop.Excel.Application();
                    excelWB = excelApp.Workbooks.Open(stringFileName);
                    excelWS = excelWB.Worksheets["Expenses"];
                    excelRange = excelWS.UsedRange;

                    int i = 0;

                    for (excelRow = 2; excelRow <= excelRange.Rows.Count; excelRow++)
                    {
                        i++;
                        if (excelRange.Cells[excelRow, 1].Text != "")
                        {
                            dgvData.Rows.Add(i, excelRange.Cells[excelRow, 1].Text, excelRange.Cells[excelRow, 2].Text, excelRange.Cells[excelRow, 3].Text);
                        }
                    }
                    excelWB.Close();
                    excelApp.Quit();
                }
            }
            catch(Exception)
            {
                // Do 
            }
            btnSave.Enabled = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            List<ExpensesToDBPropertiesModel> expensesList = new List<ExpensesToDBPropertiesModel>();
            
            for (int rows = 0; rows < dgvData.Rows.Count; rows++)
            {
                ExpensesToDBPropertiesModel expensesProperties = new ExpensesToDBPropertiesModel();
                expensesProperties.ItemCategory = dgvData.Rows[rows].Cells[1].Value.ToString().TrimEnd();
                expensesProperties.ItemName = dgvData.Rows[rows].Cells[2].Value.ToString().TrimEnd();
                expensesList.Add(expensesProperties);
            }
            gridToDBConnector.ExpensesDB(expensesList);
        }
    }
}
