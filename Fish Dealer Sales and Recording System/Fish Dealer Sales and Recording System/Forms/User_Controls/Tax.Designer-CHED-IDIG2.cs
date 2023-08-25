namespace Fish_Dealer_Sales_and_Recording_System
{
    partial class Tax
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAdd = new FontAwesome.Sharp.IconButton();
            this.tbTax = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCommission = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbHandling = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbUnloading = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(65)))));
            this.btnAdd.Enabled = false;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAdd.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnAdd.IconColor = System.Drawing.Color.Gainsboro;
            this.btnAdd.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnAdd.IconSize = 25;
            this.btnAdd.Location = new System.Drawing.Point(384, 304);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(258, 38);
            this.btnAdd.TabIndex = 58;
            this.btnAdd.Text = "ADD";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // tbTax
            // 
            this.tbTax.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbTax.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTax.Location = new System.Drawing.Point(225, 151);
            this.tbTax.Name = "tbTax";
            this.tbTax.Size = new System.Drawing.Size(258, 27);
            this.tbTax.TabIndex = 57;
            this.tbTax.TextChanged += new System.EventHandler(this.TbTax_TextChanged);
            this.tbTax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbTax_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(219, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 21);
            this.label1.TabIndex = 59;
            this.label1.Text = "TAX PRICE PER BUCKET";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(221, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 21);
            this.label2.TabIndex = 61;
            this.label2.Text = "COMMISSION";
            // 
            // tbCommission
            // 
            this.tbCommission.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbCommission.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCommission.Location = new System.Drawing.Point(227, 229);
            this.tbCommission.Name = "tbCommission";
            this.tbCommission.Size = new System.Drawing.Size(258, 27);
            this.tbCommission.TabIndex = 60;
            this.tbCommission.TextChanged += new System.EventHandler(this.TbCommission_TextChanged);
            this.tbCommission.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbCommission_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(580, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 21);
            this.label3.TabIndex = 63;
            this.label3.Text = "HANDLING";
            // 
            // tbHandling
            // 
            this.tbHandling.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbHandling.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHandling.Location = new System.Drawing.Point(586, 152);
            this.tbHandling.Name = "tbHandling";
            this.tbHandling.Size = new System.Drawing.Size(258, 27);
            this.tbHandling.TabIndex = 62;
            this.tbHandling.TextChanged += new System.EventHandler(this.TbHandling_TextChanged);
            this.tbHandling.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbHandling_KeyPress);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(580, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 21);
            this.label4.TabIndex = 65;
            this.label4.Text = "UNLOADING";
            // 
            // tbUnloading
            // 
            this.tbUnloading.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbUnloading.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUnloading.Location = new System.Drawing.Point(584, 229);
            this.tbUnloading.Name = "tbUnloading";
            this.tbUnloading.Size = new System.Drawing.Size(258, 27);
            this.tbUnloading.TabIndex = 64;
            this.tbUnloading.TextChanged += new System.EventHandler(this.TbUnloading_TextChanged);
            this.tbUnloading.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbUnloading_KeyPress);
            // 
            // Tax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbUnloading);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbHandling);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCommission);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbTax);
            this.Name = "Tax";
            this.Size = new System.Drawing.Size(1012, 591);
            this.Load += new System.EventHandler(this.Tax_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnAdd;
        private System.Windows.Forms.TextBox tbTax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCommission;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbHandling;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbUnloading;
    }
}
