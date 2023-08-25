using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public partial class Login : Form
    {
        Thread thread;
        private LoginAccountConnector account = new LoginAccountConnector();
        public Login()
        {
            InitializeComponent();
            new CreateDatabaseTable();
            
        }
        
        private void Login_Load(object sender, EventArgs e)
        {
            cbShowPassword.Checked = true;
            tbPassword.UseSystemPasswordChar = false;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TbUsername_Enter(object sender, EventArgs e)
        {
            tbUsername.Text = "";
            tbUsername.ForeColor = Color.Black;
        }

        private void TbUsername_Leave(object sender, EventArgs e)
        {
            if (tbUsername.Text == "")
            {
                tbUsername.Text = "Username";
                tbUsername.ForeColor = Color.Gainsboro;
            }
        }

        private void CbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
            {
                tbPassword.UseSystemPasswordChar = false;
            }
            else
            {
                tbPassword.UseSystemPasswordChar = true;
            }
        }
        private void BtnTriggerActivator()
        {

            if (tbUsername.Text != "" && tbPassword.Text != "")
            {
                btnLogin.Enabled = true;
            }
            else if (tbUsername.Text != "" || tbPassword.Text != "")
            {
                btnLogin.Enabled = false;
            }
            else
            {
                btnLogin.Enabled = false;
            }
        }

        private void TbUsername_TextChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
        }

        private void TbPassword_TextChanged(object sender, EventArgs e)
        {
            BtnTriggerActivator();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            account.AccountLogin(tbUsername, tbPassword, new Dashboard(), this);
        }

        private void TbPassword_Enter(object sender, EventArgs e)
        {
            tbPassword.Text = "";
            tbPassword.ForeColor = Color.Black;
        }

        private void TbPassword_Leave(object sender, EventArgs e)
        {
            if (tbPassword.Text == "")
            {
                tbPassword.ForeColor = Color.Gainsboro;
                tbPassword.Text = "Password";
            }
        }
    }
}
