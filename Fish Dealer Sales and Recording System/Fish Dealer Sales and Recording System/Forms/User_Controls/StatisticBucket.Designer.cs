namespace Fish_Dealer_Sales_and_Recording_System.Forms.User_Controls
{
    partial class StatisticBucket
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnInfo = new FontAwesome.Sharp.IconButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chartBucket = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvBucket = new System.Windows.Forms.DataGridView();
            this.VarietyBucket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalBucket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBucket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBucket)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnInfo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.chartBucket);
            this.panel1.Controls.Add(this.dgvBucket);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(815, 519);
            this.panel1.TabIndex = 62;
            // 
            // btnInfo
            // 
            this.btnInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInfo.FlatAppearance.BorderSize = 0;
            this.btnInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfo.IconChar = FontAwesome.Sharp.IconChar.CircleQuestion;
            this.btnInfo.IconColor = System.Drawing.Color.Black;
            this.btnInfo.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnInfo.IconSize = 30;
            this.btnInfo.Location = new System.Drawing.Point(759, 15);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(36, 30);
            this.btnInfo.TabIndex = 58;
            this.toolTip1.SetToolTip(this.btnInfo, "This data Show the most buy Fish by the costumers. Using Graphs and Table for Ran" +
        "king");
            this.btnInfo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(367, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 57;
            this.label4.Text = "BUCKET\'S";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 17);
            this.label3.TabIndex = 55;
            this.label3.Text = "GRAPH SUMMARY";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 17);
            this.label5.TabIndex = 56;
            this.label5.Text = "TABLE RANKING ";
            // 
            // chartBucket
            // 
            this.chartBucket.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chartBucket.BorderlineColor = System.Drawing.Color.Black;
            this.chartBucket.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chartBucket.BorderlineWidth = 0;
            chartArea1.Name = "ChartArea1";
            this.chartBucket.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartBucket.Legends.Add(legend1);
            this.chartBucket.Location = new System.Drawing.Point(165, 35);
            this.chartBucket.Name = "chartBucket";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartBucket.Series.Add(series1);
            this.chartBucket.Size = new System.Drawing.Size(519, 264);
            this.chartBucket.TabIndex = 54;
            this.chartBucket.Text = "chart1";
            // 
            // dgvBucket
            // 
            this.dgvBucket.AllowUserToAddRows = false;
            this.dgvBucket.AllowUserToDeleteRows = false;
            this.dgvBucket.AllowUserToResizeColumns = false;
            this.dgvBucket.AllowUserToResizeRows = false;
            this.dgvBucket.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvBucket.BackgroundColor = System.Drawing.Color.White;
            this.dgvBucket.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBucket.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvBucket.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(152)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBucket.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBucket.ColumnHeadersHeight = 30;
            this.dgvBucket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBucket.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VarietyBucket,
            this.TotalBucket});
            this.dgvBucket.EnableHeadersVisualStyles = false;
            this.dgvBucket.Location = new System.Drawing.Point(165, 315);
            this.dgvBucket.Name = "dgvBucket";
            this.dgvBucket.ReadOnly = true;
            this.dgvBucket.RowHeadersVisible = false;
            this.dgvBucket.Size = new System.Drawing.Size(519, 183);
            this.dgvBucket.TabIndex = 52;
            // 
            // VarietyBucket
            // 
            this.VarietyBucket.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.VarietyBucket.DataPropertyName = "Variety";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.VarietyBucket.DefaultCellStyle = dataGridViewCellStyle2;
            this.VarietyBucket.FillWeight = 250F;
            this.VarietyBucket.HeaderText = "VARIETY";
            this.VarietyBucket.Name = "VarietyBucket";
            this.VarietyBucket.ReadOnly = true;
            this.VarietyBucket.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // TotalBucket
            // 
            this.TotalBucket.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TotalBucket.DataPropertyName = "Bucket";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.TotalBucket.DefaultCellStyle = dataGridViewCellStyle3;
            this.TotalBucket.FillWeight = 150F;
            this.TotalBucket.HeaderText = "TOTAL BUCKET/S";
            this.TotalBucket.Name = "TotalBucket";
            this.TotalBucket.ReadOnly = true;
            this.TotalBucket.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // StatisticBucket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "StatisticBucket";
            this.Size = new System.Drawing.Size(815, 519);
            this.Load += new System.EventHandler(this.StatisticBucket_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBucket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBucket)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBucket;
        private System.Windows.Forms.DataGridView dgvBucket;
        private System.Windows.Forms.DataGridViewTextBoxColumn VarietyBucket;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalBucket;
        private FontAwesome.Sharp.IconButton btnInfo;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
