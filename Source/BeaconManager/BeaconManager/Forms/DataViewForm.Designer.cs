namespace BeaconManager.Forms
{
    partial class DataViewForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tab_graph_all = new System.Windows.Forms.TabPage();
            this.tab_dist = new System.Windows.Forms.TabPage();
            this.tab_statistics = new System.Windows.Forms.TabPage();
            this.chart_full = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_dist = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl.SuspendLayout();
            this.tab_graph_all.SuspendLayout();
            this.tab_dist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_full)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_dist)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tab_graph_all);
            this.tabControl.Controls.Add(this.tab_dist);
            this.tabControl.Controls.Add(this.tab_statistics);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Noto Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 450);
            this.tabControl.TabIndex = 0;
            // 
            // tab_graph_all
            // 
            this.tab_graph_all.Controls.Add(this.chart_full);
            this.tab_graph_all.Location = new System.Drawing.Point(4, 26);
            this.tab_graph_all.Name = "tab_graph_all";
            this.tab_graph_all.Padding = new System.Windows.Forms.Padding(3);
            this.tab_graph_all.Size = new System.Drawing.Size(792, 420);
            this.tab_graph_all.TabIndex = 0;
            this.tab_graph_all.Text = "Full Graph";
            this.tab_graph_all.UseVisualStyleBackColor = true;
            // 
            // tab_dist
            // 
            this.tab_dist.Controls.Add(this.chart_dist);
            this.tab_dist.Location = new System.Drawing.Point(4, 26);
            this.tab_dist.Name = "tab_dist";
            this.tab_dist.Padding = new System.Windows.Forms.Padding(3);
            this.tab_dist.Size = new System.Drawing.Size(792, 420);
            this.tab_dist.TabIndex = 1;
            this.tab_dist.Text = "Distribution Graph";
            this.tab_dist.UseVisualStyleBackColor = true;
            // 
            // tab_statistics
            // 
            this.tab_statistics.Location = new System.Drawing.Point(4, 26);
            this.tab_statistics.Name = "tab_statistics";
            this.tab_statistics.Padding = new System.Windows.Forms.Padding(3);
            this.tab_statistics.Size = new System.Drawing.Size(792, 420);
            this.tab_statistics.TabIndex = 2;
            this.tab_statistics.Text = "Statistics";
            this.tab_statistics.UseVisualStyleBackColor = true;
            // 
            // chart_full
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_full.ChartAreas.Add(chartArea1);
            this.chart_full.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart_full.Location = new System.Drawing.Point(3, 3);
            this.chart_full.Name = "chart_full";
            this.chart_full.Size = new System.Drawing.Size(786, 414);
            this.chart_full.TabIndex = 0;
            this.chart_full.Text = "chart1";
            // 
            // chart_dist
            // 
            chartArea2.Name = "ChartArea1";
            this.chart_dist.ChartAreas.Add(chartArea2);
            this.chart_dist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart_dist.Location = new System.Drawing.Point(3, 3);
            this.chart_dist.Name = "chart_dist";
            this.chart_dist.Size = new System.Drawing.Size(786, 414);
            this.chart_dist.TabIndex = 1;
            this.chart_dist.Text = "chart2";
            // 
            // DataViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Name = "DataViewForm";
            this.Text = "DataViewForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DataViewForm_FormClosed);
            this.tabControl.ResumeLayout(false);
            this.tab_graph_all.ResumeLayout(false);
            this.tab_dist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_full)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_dist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tab_graph_all;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_full;
        private System.Windows.Forms.TabPage tab_dist;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_dist;
        private System.Windows.Forms.TabPage tab_statistics;
    }
}