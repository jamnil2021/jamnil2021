using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public partial class Dashboard : Form
    {
        private Form Login;
        private bool mouseDown;
        private Point offset;
        private IconButton currentButton;
        private IconButton previousButton;
        private int oldPositionX;
        private int oldPositionY;
        private static int width = SystemInformation.WorkingArea.Width;
        private static int height = SystemInformation.WorkingArea.Height;
        private static int oldWidth = width - 50;
        private static int oldHeight = height - 150;
        private Thread threading;
        private bool activeMenu = false;

        public Dashboard()
        {
            InitializeComponent();
            this.Size = new Size(SystemInformation.WorkingArea.Width - 50, SystemInformation.WorkingArea.Height - 70);
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

        private void PanelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                oldPositionX = this.Location.X;
                oldPositionY = this.Location.Y;
                System.Drawing.Point currentPosition = this.PointToScreen(e.Location);
                this.Location = new System.Drawing.Point(currentPosition.X - offset.X, currentPosition.Y - offset.Y);
            }
        }

        private void PanelTop_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void PanelTop_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void BtnRecord_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            SwitchForm(SwitchFormPanel, new Record());
        }

        private void BtnFiles_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            SwitchForm(SwitchFormPanel, new Files());
        }

        public void Logins()
        {
            Application.Run(new Login());
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            ActiveButton(btnDashboard);
            SwitchForm(SwitchFormPanel, new Statistic());
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            new ExcelToDBForms().ShowDialog();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you wan't to Exit?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            //btnImport.Visible = false;
            ActiveButton(btnDashboard);
            SwitchForm(SwitchFormPanel, new Statistic());
            this.KeyPreview = true;
            Timer.Start();
        }

        private void Dashboard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.D)
            {
                btnDashboard.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.R)
            {
                btnRecord.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.S)
            {
                btnReports.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.L)
            {
                btnLogout.PerformClick();
            }
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            if (activeMenu)
            {
                // Set the width of navigation panel
                buttonNavationPanel.Width = 47;

                // Remove the text in buttons
                btnDashboard.Text = "";
                btnRecord.Text = "";
                btnReports.Text = "";
                btnLogout.Text = "";

                // Buttons image align when small
                btnDashboard.ImageAlign = ContentAlignment.MiddleCenter;
                btnRecord.ImageAlign = ContentAlignment.MiddleCenter;
                btnReports.ImageAlign = ContentAlignment.MiddleCenter;
                btnLogout.ImageAlign = ContentAlignment.MiddleCenter;

                // Buttons Width will adjust automatically
                btnDashboard.Width = 47;
                btnRecord.Width = 47;
                btnReports.Width = 47;
                btnLogout.Width = 47;

                btnMenu.Location = new Point((buttonNavationPanel.Width / 2) - (btnMenu.Width/2), 11);

                activeMenu = false;
            }
            else
            {
                // Set Navigation Panel Size
                buttonNavationPanel.Width = 140;

                //  Assign Text in Buttons
                btnDashboard.Text = "DASHBOARD";
                btnRecord.Text = "RECORD";
                btnReports.Text = "REPORTS";
                btnLogout.Text = "LOGOUT";

                // Buttons Width will adjust automatically
                btnDashboard.Width = 140;
                btnRecord.Width = 140;
                btnReports.Width = 140;
                btnLogout.Width = 140;

                // Buttons image align when inlarge
                btnDashboard.ImageAlign = ContentAlignment.MiddleLeft;
                btnRecord.ImageAlign = ContentAlignment.MiddleLeft;
                btnReports.ImageAlign = ContentAlignment.MiddleLeft;
                btnLogout.ImageAlign = ContentAlignment.MiddleLeft;

                btnMenu.Location = new Point((buttonNavationPanel.Width / 2) - (btnMenu.Width / 2), 11);

                activeMenu = true;
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you wan't to Logout?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                this.Close();
                threading = new Thread(Logins);
                threading.SetApartmentState(ApartmentState.STA);
                threading.Start();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tbTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
            tbDate.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            new ReportSummaryGenerator();
        }
    }
}
