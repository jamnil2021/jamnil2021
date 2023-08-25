using FontAwesome.Sharp;
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
    public partial class ManageRecord : Form
    {
        private string IDClass;
        private IconButton currentButton;
        private IconButton previousButton;
        private bool ActiveMenu = false;
        public ManageRecord(string IDClass)
        {
            InitializeComponent();
            this.Size = new Size(SystemInformation.WorkingArea.Width - 50, SystemInformation.WorkingArea.Height - 70);
            this.IDClass = IDClass;
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
                previousButton.BackColor = Color.FromArgb(37, 37, 37);
            }
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            SwitchForm(panelSwitchForm,  new Import(IDClass));
            ActiveButton(btnImport);
        }

        private void ManageRecord_Load(object sender, EventArgs e)
        {
            SwitchForm(panelSwitchForm, new Import(IDClass));
            ActiveButton(btnImport);
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            SwitchForm(panelSwitchForm, new Export(IDClass));
            ActiveButton(btnExport);
        }

        private void BtnExpenses_Click(object sender, EventArgs e)
        {
            ActiveButton(btnExpenses);
            SwitchForm(panelSwitchForm, new Expenses(IDClass));
        }

        private void BtnTax_Click(object sender, EventArgs e)
        {
            ActiveButton(btnTax);
            SwitchForm(panelSwitchForm, new Tax(IDClass));
        }

        private void BtnCrew_Click(object sender, EventArgs e)
        {
            ActiveButton(btnCrew);
            SwitchForm(panelSwitchForm, new Crew(IDClass));
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            if (ActiveMenu)
            {
                // Set the width of navigation panel
                buttonNavationPanel.Width = 47;

                // Remove the text in buttons
                btnImport.Text = "";
                btnExport.Text = "";
                btnCrew.Text = "";
                btnExpenses.Text = "";
                btnTax.Text = "";

                // Buttons image align when small
                btnImport.ImageAlign = ContentAlignment.MiddleCenter;
                btnExport.ImageAlign = ContentAlignment.MiddleCenter;
                btnCrew.ImageAlign = ContentAlignment.MiddleCenter;
                btnExpenses.ImageAlign = ContentAlignment.MiddleCenter;
                btnTax.ImageAlign = ContentAlignment.MiddleCenter;

                // Buttons Width will adjust automatically
                btnImport.Width = 47;
                btnExport.Width = 47;
                btnCrew.Width = 47;
                btnExpenses.Width = 47;
                btnTax.Width = 47;

                btnMenu.Location = new Point((buttonNavationPanel.Width / 2) - (btnMenu.Width / 2), 11);

                ActiveMenu = false;
            }
            else
            {
                // Set Navigation Panel Size
                buttonNavationPanel.Width = 140;

                //  Assign Text in Buttons
                btnImport.Text = "IMPORT";
                btnExport.Text = "EXPORT";
                btnCrew.Text = "CREW";
                btnExpenses.Text = "EXPENSES";
                btnTax.Text = "TAX";

                // Buttons Width will adjust automatically
                btnImport.Width = 140;
                btnExport.Width = 140;
                btnCrew.Width = 140;
                btnExpenses.Width = 140;
                btnTax.Width = 140;

                // Buttons image align when inlarge
                btnImport.ImageAlign = ContentAlignment.MiddleLeft;
                btnExport.ImageAlign = ContentAlignment.MiddleLeft;
                btnCrew.ImageAlign = ContentAlignment.MiddleLeft;
                btnExpenses.ImageAlign = ContentAlignment.MiddleLeft;
                btnTax.ImageAlign = ContentAlignment.MiddleLeft;

                btnMenu.Location = new Point((buttonNavationPanel.Width / 2) - (btnMenu.Width / 2), 11);

                ActiveMenu = true;
            }
        }
    }
}
