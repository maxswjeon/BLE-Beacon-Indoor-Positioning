namespace BeaconManager.Forms
{
    partial class DataForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.listbox_uuid = new System.Windows.Forms.ListBox();
            this.listbox_major = new System.Windows.Forms.ListBox();
            this.listbox_minor = new System.Windows.Forms.ListBox();
            this.label_uuid = new System.Windows.Forms.Label();
            this.label_major = new System.Windows.Forms.Label();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.check_tohex = new System.Windows.Forms.CheckBox();
            this.label_info = new System.Windows.Forms.Label();
            this.label_sigma = new System.Windows.Forms.Label();
            this.label_mean = new System.Windows.Forms.Label();
            this.panel_info = new System.Windows.Forms.Panel();
            this.label_duration = new System.Windows.Forms.Label();
            this.label_kalman_mean = new System.Windows.Forms.Label();
            this.label_kalman_sigma = new System.Windows.Forms.Label();
            this.label_end = new System.Windows.Forms.Label();
            this.label_start = new System.Windows.Forms.Label();
            this.label_count = new System.Windows.Forms.Label();
            this.fileDialog = new System.Windows.Forms.SaveFileDialog();
            this.button_save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.panel_info.SuspendLayout();
            this.SuspendLayout();
            // 
            // listbox_uuid
            // 
            this.listbox_uuid.Enabled = false;
            this.listbox_uuid.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listbox_uuid.FormattingEnabled = true;
            this.listbox_uuid.ItemHeight = 19;
            this.listbox_uuid.Location = new System.Drawing.Point(16, 33);
            this.listbox_uuid.Name = "listbox_uuid";
            this.listbox_uuid.Size = new System.Drawing.Size(275, 156);
            this.listbox_uuid.TabIndex = 0;
            this.listbox_uuid.SelectedIndexChanged += new System.EventHandler(this.Listbox_uuid_SelectedIndexChanged);
            // 
            // listbox_major
            // 
            this.listbox_major.Enabled = false;
            this.listbox_major.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listbox_major.FormattingEnabled = true;
            this.listbox_major.ItemHeight = 19;
            this.listbox_major.Location = new System.Drawing.Point(297, 33);
            this.listbox_major.Name = "listbox_major";
            this.listbox_major.Size = new System.Drawing.Size(43, 156);
            this.listbox_major.TabIndex = 1;
            this.listbox_major.SelectedIndexChanged += new System.EventHandler(this.Listbox_major_SelectedIndexChanged);
            // 
            // listbox_minor
            // 
            this.listbox_minor.Enabled = false;
            this.listbox_minor.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listbox_minor.FormattingEnabled = true;
            this.listbox_minor.ItemHeight = 19;
            this.listbox_minor.Location = new System.Drawing.Point(346, 33);
            this.listbox_minor.Name = "listbox_minor";
            this.listbox_minor.Size = new System.Drawing.Size(43, 156);
            this.listbox_minor.TabIndex = 2;
            this.listbox_minor.SelectedIndexChanged += new System.EventHandler(this.Listbox_minor_SelectedIndexChanged);
            // 
            // label_uuid
            // 
            this.label_uuid.AutoSize = true;
            this.label_uuid.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_uuid.Location = new System.Drawing.Point(12, 9);
            this.label_uuid.Name = "label_uuid";
            this.label_uuid.Size = new System.Drawing.Size(96, 21);
            this.label_uuid.TabIndex = 7;
            this.label_uuid.Text = "Beacon UUID";
            // 
            // label_major
            // 
            this.label_major.AutoSize = true;
            this.label_major.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_major.Location = new System.Drawing.Point(246, 9);
            this.label_major.Name = "label_major";
            this.label_major.Size = new System.Drawing.Size(146, 21);
            this.label_major.TabIndex = 8;
            this.label_major.Text = "Beacon Major / Minor";
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Location = new System.Drawing.Point(16, 195);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(806, 321);
            this.chart.TabIndex = 9;
            this.chart.Text = "chart1";
            // 
            // check_tohex
            // 
            this.check_tohex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.check_tohex.AutoSize = true;
            this.check_tohex.Checked = true;
            this.check_tohex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_tohex.Font = new System.Drawing.Font("Noto Sans CJK KR Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.check_tohex.Location = new System.Drawing.Point(551, 12);
            this.check_tohex.Name = "check_tohex";
            this.check_tohex.Size = new System.Drawing.Size(271, 22);
            this.check_tohex.TabIndex = 10;
            this.check_tohex.Text = "Show Major / Minor Values as Hexademical";
            this.check_tohex.UseVisualStyleBackColor = true;
            this.check_tohex.CheckedChanged += new System.EventHandler(this.Check_tohex_CheckedChanged);
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.Font = new System.Drawing.Font("Noto Sans CJK KR Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_info.Location = new System.Drawing.Point(3, 1);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(73, 21);
            this.label_info.TabIndex = 15;
            this.label_info.Text = "Data Info";
            // 
            // label_sigma
            // 
            this.label_sigma.AutoSize = true;
            this.label_sigma.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_sigma.Location = new System.Drawing.Point(221, 43);
            this.label_sigma.Name = "label_sigma";
            this.label_sigma.Size = new System.Drawing.Size(61, 21);
            this.label_sigma.TabIndex = 14;
            this.label_sigma.Text = "Sigma : ";
            // 
            // label_mean
            // 
            this.label_mean.AutoSize = true;
            this.label_mean.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_mean.Location = new System.Drawing.Point(226, 22);
            this.label_mean.Name = "label_mean";
            this.label_mean.Size = new System.Drawing.Size(56, 21);
            this.label_mean.TabIndex = 13;
            this.label_mean.Text = "Mean : ";
            // 
            // panel_info
            // 
            this.panel_info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_info.AutoScroll = true;
            this.panel_info.Controls.Add(this.label_duration);
            this.panel_info.Controls.Add(this.label_kalman_mean);
            this.panel_info.Controls.Add(this.label_kalman_sigma);
            this.panel_info.Controls.Add(this.label_end);
            this.panel_info.Controls.Add(this.label_start);
            this.panel_info.Controls.Add(this.label_count);
            this.panel_info.Controls.Add(this.label_info);
            this.panel_info.Controls.Add(this.label_mean);
            this.panel_info.Controls.Add(this.label_sigma);
            this.panel_info.Location = new System.Drawing.Point(395, 33);
            this.panel_info.Name = "panel_info";
            this.panel_info.Size = new System.Drawing.Size(427, 156);
            this.panel_info.TabIndex = 17;
            this.panel_info.Visible = false;
            // 
            // label_duration
            // 
            this.label_duration.AutoSize = true;
            this.label_duration.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_duration.Location = new System.Drawing.Point(3, 64);
            this.label_duration.Name = "label_duration";
            this.label_duration.Size = new System.Drawing.Size(77, 21);
            this.label_duration.TabIndex = 22;
            this.label_duration.Text = "Duration : ";
            // 
            // label_kalman_mean
            // 
            this.label_kalman_mean.AutoSize = true;
            this.label_kalman_mean.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_kalman_mean.Location = new System.Drawing.Point(172, 64);
            this.label_kalman_mean.Name = "label_kalman_mean";
            this.label_kalman_mean.Size = new System.Drawing.Size(110, 21);
            this.label_kalman_mean.TabIndex = 20;
            this.label_kalman_mean.Text = "Filtered Mean : ";
            // 
            // label_kalman_sigma
            // 
            this.label_kalman_sigma.AutoSize = true;
            this.label_kalman_sigma.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_kalman_sigma.Location = new System.Drawing.Point(167, 85);
            this.label_kalman_sigma.Name = "label_kalman_sigma";
            this.label_kalman_sigma.Size = new System.Drawing.Size(115, 21);
            this.label_kalman_sigma.TabIndex = 21;
            this.label_kalman_sigma.Text = "Filtered Sigma : ";
            // 
            // label_end
            // 
            this.label_end.AutoSize = true;
            this.label_end.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_end.Location = new System.Drawing.Point(8, 43);
            this.label_end.Name = "label_end";
            this.label_end.Size = new System.Drawing.Size(46, 21);
            this.label_end.TabIndex = 19;
            this.label_end.Text = "End : ";
            // 
            // label_start
            // 
            this.label_start.AutoSize = true;
            this.label_start.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_start.Location = new System.Drawing.Point(3, 22);
            this.label_start.Name = "label_start";
            this.label_start.Size = new System.Drawing.Size(51, 21);
            this.label_start.TabIndex = 18;
            this.label_start.Text = "Start : ";
            // 
            // label_count
            // 
            this.label_count.AutoSize = true;
            this.label_count.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_count.Location = new System.Drawing.Point(3, 85);
            this.label_count.Name = "label_count";
            this.label_count.Size = new System.Drawing.Size(59, 21);
            this.label_count.TabIndex = 17;
            this.label_count.Text = "Count : ";
            // 
            // button_save
            // 
            this.button_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_save.Enabled = false;
            this.button_save.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_save.Location = new System.Drawing.Point(752, 522);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(70, 27);
            this.button_save.TabIndex = 23;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.Button_save_Click);
            // 
            // DataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(834, 561);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.panel_info);
            this.Controls.Add(this.check_tohex);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.label_major);
            this.Controls.Add(this.label_uuid);
            this.Controls.Add(this.listbox_minor);
            this.Controls.Add(this.listbox_major);
            this.Controls.Add(this.listbox_uuid);
            this.Name = "DataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BeaconModule Data";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.panel_info.ResumeLayout(false);
            this.panel_info.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listbox_uuid;
        private System.Windows.Forms.ListBox listbox_major;
        private System.Windows.Forms.ListBox listbox_minor;
        private System.Windows.Forms.Label label_uuid;
        private System.Windows.Forms.Label label_major;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.CheckBox check_tohex;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Label label_sigma;
        private System.Windows.Forms.Label label_mean;
        private System.Windows.Forms.Panel panel_info;
        private System.Windows.Forms.Label label_count;
        private System.Windows.Forms.Label label_end;
        private System.Windows.Forms.Label label_start;
        private System.Windows.Forms.Label label_kalman_mean;
        private System.Windows.Forms.Label label_kalman_sigma;
        private System.Windows.Forms.Label label_duration;
        private System.Windows.Forms.SaveFileDialog fileDialog;
        private System.Windows.Forms.Button button_save;
    }
}