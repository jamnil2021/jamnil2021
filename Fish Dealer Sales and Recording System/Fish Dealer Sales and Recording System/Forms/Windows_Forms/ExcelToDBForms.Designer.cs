namespace Fish_Dealer_Sales_and_Recording_System
{
    partial class ExcelToDBForms
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFolder = new System.Windows.Forms.OpenFileDialog();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.panelNav = new System.Windows.Forms.Panel();
            this.btnExpenses = new FontAwesome.Sharp.IconButton();
            this.btnVariety = new FontAwesome.Sharp.IconButton();
            this.SwitchForms = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            this.panelNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.panelTop.Controls.Add(this.btnExit);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(765, 32);
            this.panelTop.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btnExit.IconColor = System.Drawing.Color.Gainsboro;
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnExit.IconSize = 20;
            this.btnExit.Location = new System.Drawing.Point(723, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(42, 32);
            this.btnExit.TabIndex = 4;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // panelNav
            // 
            this.panelNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(65)))));
            this.panelNav.Controls.Add(this.btnExpenses);
            this.panelNav.Controls.Add(this.btnVariety);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelNav.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelNav.Location = new System.Drawing.Point(0, 32);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(153, 446);
            this.panelNav.TabIndex = 3;
            // 
            // btnExpenses
            // 
            this.btnExpenses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(65)))));
            this.btnExpenses.FlatAppearance.BorderSize = 0;
            this.btnExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpenses.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpenses.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnExpenses.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnExpenses.IconColor = System.Drawing.Color.Black;
            this.btnExpenses.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExpenses.Location = new System.Drawing.Point(0, 174);
            this.btnExpenses.Name = "btnExpenses";
            this.btnExpenses.Size = new System.Drawing.Size(160, 40);
            this.btnExpenses.TabIndex = 1;
            this.btnExpenses.Text = "EXPENSES";
            this.btnExpenses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExpenses.UseVisualStyleBackColor = false;
            this.btnExpenses.Click += new System.EventHandler(this.BtnExpenses_Click);
            // 
            // btnVariety
            // 
            this.btnVariety.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(65)))));
            this.btnVariety.FlatAppearance.BorderSize = 0;
            this.btnVariety.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVariety.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVariety.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnVariety.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnVariety.IconColor = System.Drawing.Color.Black;
            this.btnVariety.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVariety.Location = new System.Drawing.Point(0, 128);
            this.btnVariety.Name = "btnVariety";
            this.btnVariety.Size = new System.Drawing.Size(160, 40);
            this.btnVariety.TabIndex = 0;
            this.btnVariety.Text = "VARIETY OF FISH";
            this.btnVariety.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVariety.UseVisualStyleBackColor = false;
            this.btnVariety.Click += new System.EventHandler(this.BtnVariety_Click);
            // 
            // SwitchForms
            // 
            this.SwitchForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SwitchForms.Location = new System.Drawing.Point(153, 32);
            this.SwitchForms.Name = "SwitchForms";
            this.SwitchForms.Size = new System.Drawing.Size(612, 446);
            this.SwitchForms.TabIndex = 4;
            // 
            // ExcelToDBForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 478);
            this.Controls.Add(this.SwitchForms);
            this.Controls.Add(this.panelNav);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ExcelToDBForms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ExcelToDatabase";
            this.Load += new System.EventHandler(this.ExcelToDBForms_Load);
            this.panelTop.ResumeLayout(false);
            this.panelNav.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFolder;
        private System.Windows.Forms.Panel panelTop;
        private FontAwesome.Sharp.IconButton btnExit;
        private System.Windows.Forms.Panel panelNav;
        private FontAwesome.Sharp.IconButton btnVariety;
        private FontAwesome.Sharp.IconButton btnExpenses;
        private System.Windows.Forms.Panel SwitchForms;
    }
}