namespace F103_pmsm_sensored
{
    partial class GraphViewerXY
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
            this.zc1 = new ZedGraph.ZedGraphControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chbox_autoYaxis = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Xmax = new System.Windows.Forms.TextBox();
            this.tb_Ymax = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Xmin = new System.Windows.Forms.TextBox();
            this.tb_Ymin = new System.Windows.Forms.TextBox();
            this.tb_TimeRange = new System.Windows.Forms.TextBox();
            this.chbox_swapXY = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // zc1
            // 
            this.zc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zc1.Location = new System.Drawing.Point(0, 0);
            this.zc1.Name = "zc1";
            this.zc1.ScrollGrace = 0D;
            this.zc1.ScrollMaxX = 0D;
            this.zc1.ScrollMaxY = 0D;
            this.zc1.ScrollMaxY2 = 0D;
            this.zc1.ScrollMinX = 0D;
            this.zc1.ScrollMinY = 0D;
            this.zc1.ScrollMinY2 = 0D;
            this.zc1.Size = new System.Drawing.Size(411, 395);
            this.zc1.TabIndex = 10;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chbox_swapXY);
            this.splitContainer1.Panel1.Controls.Add(this.chbox_autoYaxis);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.tb_Xmax);
            this.splitContainer1.Panel1.Controls.Add(this.tb_Ymax);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.tb_Xmin);
            this.splitContainer1.Panel1.Controls.Add(this.tb_Ymin);
            this.splitContainer1.Panel1.Controls.Add(this.tb_TimeRange);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.zc1);
            this.splitContainer1.Size = new System.Drawing.Size(411, 491);
            this.splitContainer1.SplitterDistance = 92;
            this.splitContainer1.TabIndex = 11;
            // 
            // chbox_autoYaxis
            // 
            this.chbox_autoYaxis.AutoSize = true;
            this.chbox_autoYaxis.Location = new System.Drawing.Point(264, 40);
            this.chbox_autoYaxis.Name = "chbox_autoYaxis";
            this.chbox_autoYaxis.Size = new System.Drawing.Size(76, 17);
            this.chbox_autoYaxis.TabIndex = 2;
            this.chbox_autoYaxis.Text = "Auto Yaxis";
            this.chbox_autoYaxis.UseVisualStyleBackColor = true;
            this.chbox_autoYaxis.CheckedChanged += new System.EventHandler(this.chbox_autoYaxis_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Xmax";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ymax";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Xmin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ymin";
            // 
            // tb_Xmax
            // 
            this.tb_Xmax.Location = new System.Drawing.Point(167, 37);
            this.tb_Xmax.Name = "tb_Xmax";
            this.tb_Xmax.Size = new System.Drawing.Size(77, 20);
            this.tb_Xmax.TabIndex = 0;
            this.tb_Xmax.TextChanged += new System.EventHandler(this.tb_XYminmax_TextChanged);
            // 
            // tb_Ymax
            // 
            this.tb_Ymax.Location = new System.Drawing.Point(167, 64);
            this.tb_Ymax.Name = "tb_Ymax";
            this.tb_Ymax.Size = new System.Drawing.Size(77, 20);
            this.tb_Ymax.TabIndex = 0;
            this.tb_Ymax.TextChanged += new System.EventHandler(this.tb_XYminmax_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Time range (ms)";
            // 
            // tb_Xmin
            // 
            this.tb_Xmin.Location = new System.Drawing.Point(48, 37);
            this.tb_Xmin.Name = "tb_Xmin";
            this.tb_Xmin.Size = new System.Drawing.Size(77, 20);
            this.tb_Xmin.TabIndex = 0;
            this.tb_Xmin.TextChanged += new System.EventHandler(this.tb_XYminmax_TextChanged);
            // 
            // tb_Ymin
            // 
            this.tb_Ymin.Location = new System.Drawing.Point(48, 64);
            this.tb_Ymin.Name = "tb_Ymin";
            this.tb_Ymin.Size = new System.Drawing.Size(77, 20);
            this.tb_Ymin.TabIndex = 0;
            this.tb_Ymin.TextChanged += new System.EventHandler(this.tb_XYminmax_TextChanged);
            // 
            // tb_TimeRange
            // 
            this.tb_TimeRange.Location = new System.Drawing.Point(100, 12);
            this.tb_TimeRange.Name = "tb_TimeRange";
            this.tb_TimeRange.Size = new System.Drawing.Size(77, 20);
            this.tb_TimeRange.TabIndex = 0;
            this.tb_TimeRange.TextChanged += new System.EventHandler(this.tb_timeRange_TextChanged);
            // 
            // chbox_swapXY
            // 
            this.chbox_swapXY.AutoSize = true;
            this.chbox_swapXY.Location = new System.Drawing.Point(264, 63);
            this.chbox_swapXY.Name = "chbox_swapXY";
            this.chbox_swapXY.Size = new System.Drawing.Size(70, 17);
            this.chbox_swapXY.TabIndex = 3;
            this.chbox_swapXY.Text = "Swap XY";
            this.chbox_swapXY.UseVisualStyleBackColor = true;
            this.chbox_swapXY.CheckedChanged += new System.EventHandler(this.chbox_swapXY_CheckedChanged);
            // 
            // GraphViewerXY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 491);
            this.Controls.Add(this.splitContainer1);
            this.Name = "GraphViewerXY";
            this.Text = "GraphViewer";
            this.Load += new System.EventHandler(this.GraphViewer_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zc1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Ymax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Ymin;
        private System.Windows.Forms.TextBox tb_TimeRange;
        private System.Windows.Forms.CheckBox chbox_autoYaxis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_Xmax;
        private System.Windows.Forms.TextBox tb_Xmin;
        private System.Windows.Forms.CheckBox chbox_swapXY;
    }
}