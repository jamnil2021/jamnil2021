namespace Fish_Dealer_Sales_and_Recording_System
{
    partial class ValueUpdater
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.tbItemName = new System.Windows.Forms.TextBox();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.tbItemValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAdd = new System.Windows.Forms.TextBox();
            this.tbMinus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpdate = new FontAwesome.Sharp.IconButton();
            this.tbItem = new System.Windows.Forms.TextBox();
            this.lblErrorMinus = new System.Windows.Forms.Label();
            this.lblErrorAdd = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(65)))));
            this.panelTop.Controls.Add(this.tbItemName);
            this.panelTop.Controls.Add(this.btnExit);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(549, 32);
            this.panelTop.TabIndex = 1;
            // 
            // tbItemName
            // 
            this.tbItemName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbItemName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(65)))));
            this.tbItemName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbItemName.Enabled = false;
            this.tbItemName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbItemName.ForeColor = System.Drawing.Color.White;
            this.tbItemName.Location = new System.Drawing.Point(150, 5);
            this.tbItemName.Name = "tbItemName";
            this.tbItemName.Size = new System.Drawing.Size(258, 22);
            this.tbItemName.TabIndex = 58;
            this.tbItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(65)))));
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.Multiply;
            this.btnExit.IconColor = System.Drawing.Color.White;
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnExit.IconSize = 25;
            this.btnExit.Location = new System.Drawing.Point(509, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(40, 32);
            this.btnExit.TabIndex = 0;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // tbItemValue
            // 
            this.tbItemValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbItemValue.Enabled = false;
            this.tbItemValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbItemValue.Location = new System.Drawing.Point(150, 74);
            this.tbItemValue.Name = "tbItemValue";
            this.tbItemValue.Size = new System.Drawing.Size(258, 29);
            this.tbItemValue.TabIndex = 52;
            this.tbItemValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(148, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 21);
            this.label1.TabIndex = 53;
            this.label1.Text = "Add Value";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbAdd
            // 
            this.tbAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAdd.Location = new System.Drawing.Point(152, 140);
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Size = new System.Drawing.Size(106, 29);
            this.tbAdd.TabIndex = 54;
            this.tbAdd.TextChanged += new System.EventHandler(this.TbAdd_TextChanged);
            this.tbAdd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbAdd_KeyPress);
            // 
            // tbMinus
            // 
            this.tbMinus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbMinus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMinus.Location = new System.Drawing.Point(302, 140);
            this.tbMinus.Name = "tbMinus";
            this.tbMinus.Size = new System.Drawing.Size(106, 29);
            this.tbMinus.TabIndex = 56;
            this.tbMinus.TextChanged += new System.EventHandler(this.TbMinus_TextChanged);
            this.tbMinus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbMinus_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(298, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 21);
            this.label2.TabIndex = 55;
            this.label2.Text = "Minus Value";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(111)))), ((int)(((byte)(229)))));
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnUpdate.IconChar = FontAwesome.Sharp.IconChar.FilePen;
            this.btnUpdate.IconColor = System.Drawing.Color.Gainsboro;
            this.btnUpdate.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnUpdate.IconSize = 25;
            this.btnUpdate.Location = new System.Drawing.Point(152, 195);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(256, 34);
            this.btnUpdate.TabIndex = 57;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // tbItem
            // 
            this.tbItem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbItem.BackColor = System.Drawing.Color.MediumTurquoise;
            this.tbItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbItem.Enabled = false;
            this.tbItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbItem.ForeColor = System.Drawing.Color.Black;
            this.tbItem.Location = new System.Drawing.Point(150, 46);
            this.tbItem.Name = "tbItem";
            this.tbItem.Size = new System.Drawing.Size(258, 22);
            this.tbItem.TabIndex = 59;
            this.tbItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblErrorMinus
            // 
            this.lblErrorMinus.AutoSize = true;
            this.lblErrorMinus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMinus.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMinus.Location = new System.Drawing.Point(299, 172);
            this.lblErrorMinus.Name = "lblErrorMinus";
            this.lblErrorMinus.Size = new System.Drawing.Size(76, 15);
            this.lblErrorMinus.TabIndex = 60;
            this.lblErrorMinus.Text = "Invalid Input!";
            this.lblErrorMinus.Visible = false;
            // 
            // lblErrorAdd
            // 
            this.lblErrorAdd.AutoSize = true;
            this.lblErrorAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorAdd.ForeColor = System.Drawing.Color.Red;
            this.lblErrorAdd.Location = new System.Drawing.Point(149, 172);
            this.lblErrorAdd.Name = "lblErrorAdd";
            this.lblErrorAdd.Size = new System.Drawing.Size(73, 15);
            this.lblErrorAdd.TabIndex = 61;
            this.lblErrorAdd.Text = "Invalid Input";
            this.lblErrorAdd.Visible = false;
            // 
            // ValueUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ClientSize = new System.Drawing.Size(549, 266);
            this.Controls.Add(this.lblErrorAdd);
            this.Controls.Add(this.lblErrorMinus);
            this.Controls.Add(this.tbItem);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.tbMinus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbItemValue);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ValueUpdater";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ValueUpdater";
            this.Load += new System.EventHandler(this.ValueUpdater_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private FontAwesome.Sharp.IconButton btnExit;
        private System.Windows.Forms.TextBox tbItemValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAdd;
        private System.Windows.Forms.TextBox tbMinus;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnUpdate;
        private System.Windows.Forms.TextBox tbItemName;
        private System.Windows.Forms.TextBox tbItem;
        private System.Windows.Forms.Label lblErrorMinus;
        private System.Windows.Forms.Label lblErrorAdd;
    }
}