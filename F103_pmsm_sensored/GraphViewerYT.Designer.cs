namespace F103_pmsm_sensored
{
    partial class GraphViewerYT
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Ymax = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Ymin = new System.Windows.Forms.TextBox();
            this.tb_XaxisRange = new System.Windows.Forms.TextBox();
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
            this.zc1.Size = new System.Drawing.Size(593, 350);
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
            this.splitContainer1.Panel1.Controls.Add(this.chbox_autoYaxis);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.tb_Ymax);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.tb_Ymin);
            this.splitContainer1.Panel1.Controls.Add(this.tb_XaxisRange);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.zc1);
            this.splitContainer1.Size = new System.Drawing.Size(593, 400);
            this.splitContainer1.SplitterDistance = 46;
            this.splitContainer1.TabIndex = 11;
            // 
            // chbox_autoYaxis
            // 
            this.chbox_autoYaxis.AutoSize = true;
            this.chbox_autoYaxis.Location = new System.Drawing.Point(442, 14);
            this.chbox_autoYaxis.Name = "chbox_autoYaxis";
            this.chbox_autoYaxis.Size = new System.Drawing.Size(76, 17);
            this.chbox_autoYaxis.TabIndex = 2;
            this.chbox_autoYaxis.Text = "Auto Yaxis";
            this.chbox_autoYaxis.UseVisualStyleBackColor = true;
            this.chbox_autoYaxis.CheckedChanged += new System.EventHandler(this.chbox_autoYaxis_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(323, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ymax";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ymin";
            // 
            // tb_Ymax
            // 
            this.tb_Ymax.Location = new System.Drawing.Point(359, 12);
            this.tb_Ymax.Name = "tb_Ymax";
            this.tb_Ymax.Size = new System.Drawing.Size(77, 20);
            this.tb_Ymax.TabIndex = 0;
            this.tb_Ymax.TextChanged += new System.EventHandler(this.tb_Ymin_Ymax_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Xaxis range";
            // 
            // tb_Ymin
            // 
            this.tb_Ymin.Location = new System.Drawing.Point(240, 12);
            this.tb_Ymin.Name = "tb_Ymin";
            this.tb_Ymin.Size = new System.Drawing.Size(77, 20);
            this.tb_Ymin.TabIndex = 0;
            this.tb_Ymin.TextChanged += new System.EventHandler(this.tb_Ymin_Ymax_TextChanged);
            // 
            // tb_XaxisRange
            // 
            this.tb_XaxisRange.Location = new System.Drawing.Point(80, 12);
            this.tb_XaxisRange.Name = "tb_XaxisRange";
            this.tb_XaxisRange.Size = new System.Drawing.Size(77, 20);
            this.tb_XaxisRange.TabIndex = 0;
            this.tb_XaxisRange.TextChanged += new System.EventHandler(this.tb_XaxisRange_TextChanged);
            // 
            // GraphViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 400);
            this.Controls.Add(this.splitContainer1);
            this.Name = "GraphViewer";
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
        private System.Windows.Forms.TextBox tb_XaxisRange;
        private System.Windows.Forms.CheckBox chbox_autoYaxis;
    }
}