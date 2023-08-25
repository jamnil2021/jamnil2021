using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Microsoft.Office.Interop.Excel;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public partial class ExcelToDBForms : Form
    {
        private IconButton currentButton;
        private IconButton previousButton;
        public ExcelToDBForms()
        {
            InitializeComponent();
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
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
                excelWS = excelWB.Worksheets["Sheet1"];
                excelRange = excelWS.UsedRange;

                int i = 0;

                for (excelRow = 2; excelRow <= excelRange.Rows.Count; excelRow++)
                {
                    i++;
                    if (excelRange.Cells[excelRow,1].Text != "")
                    {
                        //dgvVariety.Rows.Add(i, excelRange.Cells[excelRow, 1].Text);
                    }
                }
                excelWB.Close();
                excelApp.Quit();
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SwitchForm(Panel panel, UserControl form)
        {
            form.Dock = DockStyle.Fill;
            panel.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        // Set Active Button to HighLight
        private void ActiveButton(object buttonSender)
        {
            if (buttonSender != null)
            {
                if (currentButton != (IconButton)buttonSender)
                {

                    DisableButton();
                    currentButton = (IconButton)buttonSender;
                    currentButton.ForeColor = Color.Black;
                    currentButton.IconColor = Color.Black;
                    currentButton.BackColor = Color.WhiteSmoke;
                    previousButton = currentButton;
                }
            }
        }

        private void DisableButton()
        {
            if (previousButton != null)
            {
                previousButton.ForeColor = Color.Gainsboro;
                previousButton.IconColor = Color.Gainsboro;
                previousButton.BackColor = Color.FromArgb(48, 56, 65);
            }
        }

        private void BtnVariety_Click(object sender, EventArgs e)
        {
            SwitchForm(SwitchForms, new VarietyFishExcelToDB());
            ActiveButton(btnVariety);
        }

        private void ExcelToDBForms_Load(object sender, EventArgs e)
        {
            SwitchForm(SwitchForms, new VarietyFishExcelToDB());
            ActiveButton(btnVariety);
        }

        private void BtnExpenses_Click(object sender, EventArgs e)
        {
            SwitchForm(SwitchForms, new ExpensesExcelToDB());
            ActiveButton(btnExpenses);
        }
    }
}
