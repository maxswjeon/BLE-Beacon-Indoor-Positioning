namespace BeaconManager.Forms
{
    partial class LocateForm
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
            this.status = new System.Windows.Forms.StatusStrip();
            this.status_text = new System.Windows.Forms.ToolStripStatusLabel();
            this.strip_blank = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_progress = new System.Windows.Forms.ToolStripProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_text,
            this.strip_blank,
            this.status_progress});
            this.status.Location = new System.Drawing.Point(0, 428);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(800, 22);
            this.status.TabIndex = 0;
            this.status.Text = "statusStrip1";
            // 
            // status_text
            // 
            this.status_text.Name = "status_text";
            this.status_text.Size = new System.Drawing.Size(0, 17);
            // 
            // strip_blank
            // 
            this.strip_blank.Name = "strip_blank";
            this.strip_blank.Size = new System.Drawing.Size(652, 17);
            this.strip_blank.Spring = true;
            // 
            // status_progress
            // 
            this.status_progress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.status_progress.Name = "status_progress";
            this.status_progress.Size = new System.Drawing.Size(100, 16);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button_start_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(586, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // LocateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.status);
            this.Name = "LocateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LocateForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ViewForm_FormClosed);
            this.Shown += new System.EventHandler(this.ViewForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LocateForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LocateForm_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LocateForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LocateForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LocateForm_MouseUp);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel status_text;
        private System.Windows.Forms.ToolStripProgressBar status_progress;
        private System.Windows.Forms.ToolStripStatusLabel strip_blank;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}