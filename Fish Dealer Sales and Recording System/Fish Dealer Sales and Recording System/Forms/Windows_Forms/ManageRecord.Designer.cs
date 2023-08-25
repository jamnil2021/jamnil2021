namespace Fish_Dealer_Sales_and_Recording_System
{
    partial class ManageRecord
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
            this.components = new System.ComponentModel.Container();
            this.buttonNavationPanel = new System.Windows.Forms.Panel();
            this.btnMenu = new FontAwesome.Sharp.IconButton();
            this.btnCrew = new FontAwesome.Sharp.IconButton();
            this.btnExpenses = new FontAwesome.Sharp.IconButton();
            this.btnTax = new FontAwesome.Sharp.IconButton();
            this.btnExport = new FontAwesome.Sharp.IconButton();
            this.btnImport = new FontAwesome.Sharp.IconButton();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelSwitchForm = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonNavationPanel.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonNavationPanel
            // 
            this.buttonNavationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.buttonNavationPanel.Controls.Add(this.btnMenu);
            this.buttonNavationPanel.Controls.Add(this.btnCrew);
            this.buttonNavationPanel.Controls.Add(this.btnExpenses);
            this.buttonNavationPanel.Controls.Add(this.btnTax);
            this.buttonNavationPanel.Controls.Add(this.btnExport);
            this.buttonNavationPanel.Controls.Add(this.btnImport);
            this.buttonNavationPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonNavationPanel.Location = new System.Drawing.Point(0, 32);
            this.buttonNavationPanel.Name = "buttonNavationPanel";
            this.buttonNavationPanel.Size = new System.Drawing.Size(47, 559);
            this.buttonNavationPanel.TabIndex = 2;
            // 
            // btnMenu
            // 
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.btnMenu.IconChar = FontAwesome.Sharp.IconChar.Navicon;
            this.btnMenu.IconColor = System.Drawing.Color.White;
            this.btnMenu.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnMenu.IconSize = 30;
            this.btnMenu.Location = new System.Drawing.Point(3, 14);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(41, 30);
            this.btnMenu.TabIndex = 6;
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.BtnMenu_Click);
            // 
            // btnCrew
            // 
            this.btnCrew.FlatAppearance.BorderSize = 0;
            this.btnCrew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrew.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrew.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCrew.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.btnCrew.IconColor = System.Drawing.Color.Gainsboro;
            this.btnCrew.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnCrew.IconSize = 30;
            this.btnCrew.Location = new System.Drawing.Point(5, 303);
            this.btnCrew.Name = "btnCrew";
            this.btnCrew.Size = new System.Drawing.Size(45, 41);
            this.btnCrew.TabIndex = 0;
            this.btnCrew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnCrew, "Open Crew Tab");
            this.btnCrew.UseVisualStyleBackColor = true;
            this.btnCrew.Click += new System.EventHandler(this.BtnCrew_Click);
            // 
            // btnExpenses
            // 
            this.btnExpenses.FlatAppearance.BorderSize = 0;
            this.btnExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpenses.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpenses.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnExpenses.IconChar = FontAwesome.Sharp.IconChar.Wallet;
            this.btnExpenses.IconColor = System.Drawing.Color.Gainsboro;
            this.btnExpenses.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnExpenses.IconSize = 30;
            this.btnExpenses.Location = new System.Drawing.Point(5, 231);
            this.btnExpenses.Name = "btnExpenses";
            this.btnExpenses.Size = new System.Drawing.Size(45, 41);
            this.btnExpenses.TabIndex = 3;
            this.btnExpenses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnExpenses, "Open Expenses Tab");
            this.btnExpenses.UseVisualStyleBackColor = true;
            this.btnExpenses.Click += new System.EventHandler(this.BtnExpenses_Click);
            // 
            // btnTax
            // 
            this.btnTax.FlatAppearance.BorderSize = 0;
            this.btnTax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTax.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTax.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnTax.IconChar = FontAwesome.Sharp.IconChar.Coins;
            this.btnTax.IconColor = System.Drawing.Color.Gainsboro;
            this.btnTax.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnTax.IconSize = 30;
            this.btnTax.Location = new System.Drawing.Point(5, 267);
            this.btnTax.Name = "btnTax";
            this.btnTax.Size = new System.Drawing.Size(45, 41);
            this.btnTax.TabIndex = 4;
            this.btnTax.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnTax, "Open Tax Tab");
            this.btnTax.UseVisualStyleBackColor = true;
            this.btnTax.Click += new System.EventHandler(this.BtnTax_Click);
            // 
            // btnExport
            // 
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnExport.IconChar = FontAwesome.Sharp.IconChar.ArrowRightFromFile;
            this.btnExport.IconColor = System.Drawing.Color.Gainsboro;
            this.btnExport.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnExport.IconSize = 30;
            this.btnExport.Location = new System.Drawing.Point(5, 195);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(45, 41);
            this.btnExport.TabIndex = 2;
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnExport, "Open Export Fish Tab");
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnImport.IconChar = FontAwesome.Sharp.IconChar.FileImport;
            this.btnImport.IconColor = System.Drawing.Color.Gainsboro;
            this.btnImport.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnImport.IconSize = 30;
            this.btnImport.Location = new System.Drawing.Point(5, 159);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(45, 41);
            this.btnImport.TabIndex = 1;
            this.btnImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnImport, "Open Import Fish Tab");
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(214)))), ((int)(((byte)(103)))));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.Multiply;
            this.btnExit.IconColor = System.Drawing.Color.Black;
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnExit.IconSize = 25;
            this.btnExit.Location = new System.Drawing.Point(972, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(40, 32);
            this.btnExit.TabIndex = 0;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(463, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "MANAGE";
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(214)))), ((int)(((byte)(103)))));
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.btnExit);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1012, 32);
            this.panelTop.TabIndex = 1;
            // 
            // panelSwitchForm
            // 
            this.panelSwitchForm.BackColor = System.Drawing.SystemColors.Control;
            this.panelSwitchForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSwitchForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSwitchForm.Location = new System.Drawing.Point(47, 32);
            this.panelSwitchForm.Name = "panelSwitchForm";
            this.panelSwitchForm.Size = new System.Drawing.Size(965, 559);
            this.panelSwitchForm.TabIndex = 3;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // ManageRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1012, 591);
            this.Controls.Add(this.panelSwitchForm);
            this.Controls.Add(this.buttonNavationPanel);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManageRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANAGE";
            this.Load += new System.EventHandler(this.ManageRecord_Load);
            this.buttonNavationPanel.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel buttonNavationPanel;
        private FontAwesome.Sharp.IconButton btnCrew;
        private FontAwesome.Sharp.IconButton btnTax;
        private FontAwesome.Sharp.IconButton btnExpenses;
        private FontAwesome.Sharp.IconButton btnExport;
        private FontAwesome.Sharp.IconButton btnImport;
        private FontAwesome.Sharp.IconButton btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelSwitchForm;
        private FontAwesome.Sharp.IconButton btnMenu;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}