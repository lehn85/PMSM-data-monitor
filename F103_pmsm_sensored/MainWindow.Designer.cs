namespace F103_pmsm_sensored
{
    partial class MainWindow
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
            this.bt_connect = new System.Windows.Forms.Button();
            this.bt_sendstart = new System.Windows.Forms.Button();
            this.bt_sendstop = new System.Windows.Forms.Button();
            this.bt_refresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.zc1 = new ZedGraph.ZedGraphControl();
            this.nud_numDataPoint = new System.Windows.Forms.NumericUpDown();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.bt_set_speed = new System.Windows.Forms.Button();
            this.chbox_enable_set_speed = new System.Windows.Forms.CheckBox();
            this.tb_set_speed = new System.Windows.Forms.TextBox();
            this.bt_view_graph_XY = new System.Windows.Forms.Button();
            this.bt_view_graph_time = new System.Windows.Forms.Button();
            this.bt_varinfo_acquire = new System.Windows.Forms.Button();
            this.bt_apply_Yaxis = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nud_autorefreshinterval = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.chbox_autorefresh = new System.Windows.Forms.CheckBox();
            this.tb_minY1 = new System.Windows.Forms.TextBox();
            this.tb_maxY1 = new System.Windows.Forms.TextBox();
            this.tb_minY2 = new System.Windows.Forms.TextBox();
            this.tb_maxY2 = new System.Windows.Forms.TextBox();
            this.tb_minY3 = new System.Windows.Forms.TextBox();
            this.tb_maxY3 = new System.Windows.Forms.TextBox();
            this.tb_minY4 = new System.Windows.Forms.TextBox();
            this.tb_maxY4 = new System.Windows.Forms.TextBox();
            this.chbox_autoYaxis1 = new System.Windows.Forms.CheckBox();
            this.chbox_autoYaxis2 = new System.Windows.Forms.CheckBox();
            this.chbox_autoYaxis3 = new System.Windows.Forms.CheckBox();
            this.chbox_autoYaxis4 = new System.Windows.Forms.CheckBox();
            this.dgv_data2ms = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.nud_numDataPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_autorefreshinterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data2ms)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_connect
            // 
            this.bt_connect.Location = new System.Drawing.Point(12, 12);
            this.bt_connect.Name = "bt_connect";
            this.bt_connect.Size = new System.Drawing.Size(84, 37);
            this.bt_connect.TabIndex = 0;
            this.bt_connect.Text = "Connect";
            this.bt_connect.UseVisualStyleBackColor = true;
            this.bt_connect.Click += new System.EventHandler(this.bt_connect_Click);
            // 
            // bt_sendstart
            // 
            this.bt_sendstart.Location = new System.Drawing.Point(12, 55);
            this.bt_sendstart.Name = "bt_sendstart";
            this.bt_sendstart.Size = new System.Drawing.Size(79, 47);
            this.bt_sendstart.TabIndex = 3;
            this.bt_sendstart.Text = "Send start cmd";
            this.bt_sendstart.UseVisualStyleBackColor = true;
            this.bt_sendstart.Click += new System.EventHandler(this.bt_sendstart_Click);
            // 
            // bt_sendstop
            // 
            this.bt_sendstop.Location = new System.Drawing.Point(97, 55);
            this.bt_sendstop.Name = "bt_sendstop";
            this.bt_sendstop.Size = new System.Drawing.Size(88, 47);
            this.bt_sendstop.TabIndex = 4;
            this.bt_sendstop.Text = "Send stop cmd";
            this.bt_sendstop.UseVisualStyleBackColor = true;
            this.bt_sendstop.Click += new System.EventHandler(this.bt_sendstop_Click);
            // 
            // bt_refresh
            // 
            this.bt_refresh.Location = new System.Drawing.Point(197, 12);
            this.bt_refresh.Name = "bt_refresh";
            this.bt_refresh.Size = new System.Drawing.Size(95, 26);
            this.bt_refresh.TabIndex = 6;
            this.bt_refresh.Text = "Refresh last data";
            this.bt_refresh.UseVisualStyleBackColor = true;
            this.bt_refresh.Click += new System.EventHandler(this.bt_refresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Time, Xaxis (ms)";
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
            this.zc1.Size = new System.Drawing.Size(530, 512);
            this.zc1.TabIndex = 9;
            // 
            // nud_numDataPoint
            // 
            this.nud_numDataPoint.Location = new System.Drawing.Point(12, 163);
            this.nud_numDataPoint.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_numDataPoint.Name = "nud_numDataPoint";
            this.nud_numDataPoint.Size = new System.Drawing.Size(95, 20);
            this.nud_numDataPoint.TabIndex = 10;
            this.nud_numDataPoint.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.zc1);
            this.splitContainer1.Size = new System.Drawing.Size(873, 512);
            this.splitContainer1.SplitterDistance = 339;
            this.splitContainer1.TabIndex = 11;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.bt_set_speed);
            this.splitContainer2.Panel1.Controls.Add(this.chbox_enable_set_speed);
            this.splitContainer2.Panel1.Controls.Add(this.tb_set_speed);
            this.splitContainer2.Panel1.Controls.Add(this.bt_view_graph_XY);
            this.splitContainer2.Panel1.Controls.Add(this.bt_view_graph_time);
            this.splitContainer2.Panel1.Controls.Add(this.bt_varinfo_acquire);
            this.splitContainer2.Panel1.Controls.Add(this.bt_connect);
            this.splitContainer2.Panel1.Controls.Add(this.bt_sendstart);
            this.splitContainer2.Panel1.Controls.Add(this.bt_sendstop);
            this.splitContainer2.Panel1.Controls.Add(this.bt_refresh);
            this.splitContainer2.Panel1.Controls.Add(this.bt_apply_Yaxis);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.nud_numDataPoint);
            this.splitContainer2.Panel1.Controls.Add(this.nud_autorefreshinterval);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.chbox_autorefresh);
            this.splitContainer2.Panel1.Controls.Add(this.tb_minY1);
            this.splitContainer2.Panel1.Controls.Add(this.tb_maxY1);
            this.splitContainer2.Panel1.Controls.Add(this.tb_minY2);
            this.splitContainer2.Panel1.Controls.Add(this.tb_maxY2);
            this.splitContainer2.Panel1.Controls.Add(this.tb_minY3);
            this.splitContainer2.Panel1.Controls.Add(this.tb_maxY3);
            this.splitContainer2.Panel1.Controls.Add(this.tb_minY4);
            this.splitContainer2.Panel1.Controls.Add(this.tb_maxY4);
            this.splitContainer2.Panel1.Controls.Add(this.chbox_autoYaxis1);
            this.splitContainer2.Panel1.Controls.Add(this.chbox_autoYaxis2);
            this.splitContainer2.Panel1.Controls.Add(this.chbox_autoYaxis3);
            this.splitContainer2.Panel1.Controls.Add(this.chbox_autoYaxis4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgv_data2ms);
            this.splitContainer2.Size = new System.Drawing.Size(339, 512);
            this.splitContainer2.SplitterDistance = 341;
            this.splitContainer2.TabIndex = 17;
            // 
            // bt_set_speed
            // 
            this.bt_set_speed.Location = new System.Drawing.Point(191, 113);
            this.bt_set_speed.Name = "bt_set_speed";
            this.bt_set_speed.Size = new System.Drawing.Size(75, 23);
            this.bt_set_speed.TabIndex = 21;
            this.bt_set_speed.Text = "Set speed";
            this.bt_set_speed.UseVisualStyleBackColor = true;
            this.bt_set_speed.Click += new System.EventHandler(this.bt_set_speed_Click);
            // 
            // chbox_enable_set_speed
            // 
            this.chbox_enable_set_speed.AutoSize = true;
            this.chbox_enable_set_speed.Location = new System.Drawing.Point(12, 117);
            this.chbox_enable_set_speed.Name = "chbox_enable_set_speed";
            this.chbox_enable_set_speed.Size = new System.Drawing.Size(100, 17);
            this.chbox_enable_set_speed.TabIndex = 20;
            this.chbox_enable_set_speed.Text = "Allow set speed";
            this.chbox_enable_set_speed.UseVisualStyleBackColor = true;
            this.chbox_enable_set_speed.CheckedChanged += new System.EventHandler(this.chbox_enable_set_speed_CheckedChanged);
            // 
            // tb_set_speed
            // 
            this.tb_set_speed.Location = new System.Drawing.Point(118, 115);
            this.tb_set_speed.Name = "tb_set_speed";
            this.tb_set_speed.Size = new System.Drawing.Size(67, 20);
            this.tb_set_speed.TabIndex = 19;
            // 
            // bt_view_graph_XY
            // 
            this.bt_view_graph_XY.Location = new System.Drawing.Point(128, 315);
            this.bt_view_graph_XY.Name = "bt_view_graph_XY";
            this.bt_view_graph_XY.Size = new System.Drawing.Size(102, 24);
            this.bt_view_graph_XY.TabIndex = 17;
            this.bt_view_graph_XY.Text = "View graph XY";
            this.bt_view_graph_XY.UseVisualStyleBackColor = true;
            this.bt_view_graph_XY.Click += new System.EventHandler(this.bt_view_graph_XY_Click);
            // 
            // bt_view_graph_time
            // 
            this.bt_view_graph_time.Location = new System.Drawing.Point(12, 313);
            this.bt_view_graph_time.Name = "bt_view_graph_time";
            this.bt_view_graph_time.Size = new System.Drawing.Size(95, 26);
            this.bt_view_graph_time.TabIndex = 16;
            this.bt_view_graph_time.Text = "View graph time";
            this.bt_view_graph_time.UseVisualStyleBackColor = true;
            this.bt_view_graph_time.Click += new System.EventHandler(this.bt_view_graph_time_Click);
            // 
            // bt_varinfo_acquire
            // 
            this.bt_varinfo_acquire.Location = new System.Drawing.Point(102, 12);
            this.bt_varinfo_acquire.Name = "bt_varinfo_acquire";
            this.bt_varinfo_acquire.Size = new System.Drawing.Size(55, 37);
            this.bt_varinfo_acquire.TabIndex = 15;
            this.bt_varinfo_acquire.Text = "Acquire var info";
            this.bt_varinfo_acquire.UseVisualStyleBackColor = true;
            this.bt_varinfo_acquire.Click += new System.EventHandler(this.bt_varinfo_acquire_Click);
            // 
            // bt_apply_Yaxis
            // 
            this.bt_apply_Yaxis.Location = new System.Drawing.Point(245, 264);
            this.bt_apply_Yaxis.Name = "bt_apply_Yaxis";
            this.bt_apply_Yaxis.Size = new System.Drawing.Size(79, 35);
            this.bt_apply_Yaxis.TabIndex = 6;
            this.bt_apply_Yaxis.Text = "Apply Yaxis manual";
            this.bt_apply_Yaxis.UseVisualStyleBackColor = true;
            this.bt_apply_Yaxis.Click += new System.EventHandler(this.bt_apply_Yaxis_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Y axis limit";
            // 
            // nud_autorefreshinterval
            // 
            this.nud_autorefreshinterval.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_autorefreshinterval.Location = new System.Drawing.Point(197, 80);
            this.nud_autorefreshinterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_autorefreshinterval.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nud_autorefreshinterval.Name = "nud_autorefreshinterval";
            this.nud_autorefreshinterval.Size = new System.Drawing.Size(95, 20);
            this.nud_autorefreshinterval.TabIndex = 11;
            this.nud_autorefreshinterval.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nud_autorefreshinterval.ValueChanged += new System.EventHandler(this.nud_autorefreshinterval_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Auto refresh interval";
            // 
            // chbox_autorefresh
            // 
            this.chbox_autorefresh.AutoSize = true;
            this.chbox_autorefresh.Location = new System.Drawing.Point(197, 44);
            this.chbox_autorefresh.Name = "chbox_autorefresh";
            this.chbox_autorefresh.Size = new System.Drawing.Size(83, 17);
            this.chbox_autorefresh.TabIndex = 13;
            this.chbox_autorefresh.Text = "Auto refresh";
            this.chbox_autorefresh.UseVisualStyleBackColor = true;
            this.chbox_autorefresh.CheckedChanged += new System.EventHandler(this.chbox_autorefresh_CheckedChanged);
            // 
            // tb_minY1
            // 
            this.tb_minY1.Location = new System.Drawing.Point(12, 202);
            this.tb_minY1.Name = "tb_minY1";
            this.tb_minY1.Size = new System.Drawing.Size(79, 20);
            this.tb_minY1.TabIndex = 12;
            this.tb_minY1.Text = "-8000";
            // 
            // tb_maxY1
            // 
            this.tb_maxY1.Location = new System.Drawing.Point(97, 202);
            this.tb_maxY1.Name = "tb_maxY1";
            this.tb_maxY1.Size = new System.Drawing.Size(79, 20);
            this.tb_maxY1.TabIndex = 12;
            this.tb_maxY1.Text = "8000";
            // 
            // tb_minY2
            // 
            this.tb_minY2.Location = new System.Drawing.Point(12, 228);
            this.tb_minY2.Name = "tb_minY2";
            this.tb_minY2.Size = new System.Drawing.Size(79, 20);
            this.tb_minY2.TabIndex = 12;
            this.tb_minY2.Text = "-8000";
            // 
            // tb_maxY2
            // 
            this.tb_maxY2.Location = new System.Drawing.Point(97, 228);
            this.tb_maxY2.Name = "tb_maxY2";
            this.tb_maxY2.Size = new System.Drawing.Size(79, 20);
            this.tb_maxY2.TabIndex = 12;
            this.tb_maxY2.Text = "8000";
            // 
            // tb_minY3
            // 
            this.tb_minY3.Location = new System.Drawing.Point(12, 254);
            this.tb_minY3.Name = "tb_minY3";
            this.tb_minY3.Size = new System.Drawing.Size(79, 20);
            this.tb_minY3.TabIndex = 12;
            this.tb_minY3.Text = "-8000";
            // 
            // tb_maxY3
            // 
            this.tb_maxY3.Location = new System.Drawing.Point(97, 254);
            this.tb_maxY3.Name = "tb_maxY3";
            this.tb_maxY3.Size = new System.Drawing.Size(79, 20);
            this.tb_maxY3.TabIndex = 12;
            this.tb_maxY3.Text = "8000";
            // 
            // tb_minY4
            // 
            this.tb_minY4.Location = new System.Drawing.Point(12, 279);
            this.tb_minY4.Name = "tb_minY4";
            this.tb_minY4.Size = new System.Drawing.Size(79, 20);
            this.tb_minY4.TabIndex = 12;
            this.tb_minY4.Text = "-8000";
            // 
            // tb_maxY4
            // 
            this.tb_maxY4.Location = new System.Drawing.Point(97, 279);
            this.tb_maxY4.Name = "tb_maxY4";
            this.tb_maxY4.Size = new System.Drawing.Size(79, 20);
            this.tb_maxY4.TabIndex = 12;
            this.tb_maxY4.Text = "8000";
            // 
            // chbox_autoYaxis1
            // 
            this.chbox_autoYaxis1.AutoSize = true;
            this.chbox_autoYaxis1.Checked = true;
            this.chbox_autoYaxis1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbox_autoYaxis1.Location = new System.Drawing.Point(183, 204);
            this.chbox_autoYaxis1.Name = "chbox_autoYaxis1";
            this.chbox_autoYaxis1.Size = new System.Drawing.Size(48, 17);
            this.chbox_autoYaxis1.TabIndex = 14;
            this.chbox_autoYaxis1.Text = "Auto";
            this.chbox_autoYaxis1.UseVisualStyleBackColor = true;
            this.chbox_autoYaxis1.CheckedChanged += new System.EventHandler(this.chbox_autoYaxis_CheckedChanged);
            // 
            // chbox_autoYaxis2
            // 
            this.chbox_autoYaxis2.AutoSize = true;
            this.chbox_autoYaxis2.Location = new System.Drawing.Point(182, 230);
            this.chbox_autoYaxis2.Name = "chbox_autoYaxis2";
            this.chbox_autoYaxis2.Size = new System.Drawing.Size(48, 17);
            this.chbox_autoYaxis2.TabIndex = 14;
            this.chbox_autoYaxis2.Text = "Auto";
            this.chbox_autoYaxis2.UseVisualStyleBackColor = true;
            this.chbox_autoYaxis2.CheckedChanged += new System.EventHandler(this.chbox_autoYaxis_CheckedChanged);
            // 
            // chbox_autoYaxis3
            // 
            this.chbox_autoYaxis3.AutoSize = true;
            this.chbox_autoYaxis3.Location = new System.Drawing.Point(182, 256);
            this.chbox_autoYaxis3.Name = "chbox_autoYaxis3";
            this.chbox_autoYaxis3.Size = new System.Drawing.Size(48, 17);
            this.chbox_autoYaxis3.TabIndex = 14;
            this.chbox_autoYaxis3.Text = "Auto";
            this.chbox_autoYaxis3.UseVisualStyleBackColor = true;
            this.chbox_autoYaxis3.CheckedChanged += new System.EventHandler(this.chbox_autoYaxis_CheckedChanged);
            // 
            // chbox_autoYaxis4
            // 
            this.chbox_autoYaxis4.AutoSize = true;
            this.chbox_autoYaxis4.Location = new System.Drawing.Point(182, 281);
            this.chbox_autoYaxis4.Name = "chbox_autoYaxis4";
            this.chbox_autoYaxis4.Size = new System.Drawing.Size(48, 17);
            this.chbox_autoYaxis4.TabIndex = 14;
            this.chbox_autoYaxis4.Text = "Auto";
            this.chbox_autoYaxis4.UseVisualStyleBackColor = true;
            this.chbox_autoYaxis4.CheckedChanged += new System.EventHandler(this.chbox_autoYaxis_CheckedChanged);
            // 
            // dgv_data2ms
            // 
            this.dgv_data2ms.AllowUserToAddRows = false;
            this.dgv_data2ms.AllowUserToDeleteRows = false;
            this.dgv_data2ms.AllowUserToResizeColumns = false;
            this.dgv_data2ms.AllowUserToResizeRows = false;
            this.dgv_data2ms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_data2ms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_data2ms.Location = new System.Drawing.Point(0, 0);
            this.dgv_data2ms.Name = "dgv_data2ms";
            this.dgv_data2ms.ReadOnly = true;
            this.dgv_data2ms.RowHeadersVisible = false;
            this.dgv_data2ms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_data2ms.Size = new System.Drawing.Size(339, 167);
            this.dgv_data2ms.TabIndex = 15;
            this.dgv_data2ms.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_data2ms_CellDoubleClick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 512);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_numDataPoint)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_autorefreshinterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data2ms)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_connect;
        private System.Windows.Forms.Button bt_sendstart;
        private System.Windows.Forms.Button bt_sendstop;
        private System.Windows.Forms.Button bt_refresh;
        private System.Windows.Forms.Label label1;
        private ZedGraph.ZedGraphControl zc1;
        private System.Windows.Forms.NumericUpDown nud_numDataPoint;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox chbox_autorefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nud_autorefreshinterval;
        private System.Windows.Forms.TextBox tb_maxY4;
        private System.Windows.Forms.TextBox tb_minY4;
        private System.Windows.Forms.TextBox tb_maxY3;
        private System.Windows.Forms.TextBox tb_minY3;
        private System.Windows.Forms.TextBox tb_maxY2;
        private System.Windows.Forms.TextBox tb_minY2;
        private System.Windows.Forms.TextBox tb_maxY1;
        private System.Windows.Forms.TextBox tb_minY1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bt_apply_Yaxis;
        private System.Windows.Forms.CheckBox chbox_autoYaxis4;
        private System.Windows.Forms.CheckBox chbox_autoYaxis3;
        private System.Windows.Forms.CheckBox chbox_autoYaxis2;
        private System.Windows.Forms.CheckBox chbox_autoYaxis1;
        private System.Windows.Forms.DataGridView dgv_data2ms;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button bt_varinfo_acquire;
        private System.Windows.Forms.Button bt_view_graph_XY;
        private System.Windows.Forms.Button bt_view_graph_time;
        private System.Windows.Forms.Button bt_set_speed;
        private System.Windows.Forms.CheckBox chbox_enable_set_speed;
        private System.Windows.Forms.TextBox tb_set_speed;
    }
}

