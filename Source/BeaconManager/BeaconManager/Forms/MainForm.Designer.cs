namespace BeaconManager.Forms
{
    partial class MainForm
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
            this.label_title = new System.Windows.Forms.Label();
            this.label_data = new System.Windows.Forms.Label();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.label_locate = new System.Windows.Forms.Label();
            this.label_open = new System.Windows.Forms.Label();
            this.label_about = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_title.Font = new System.Drawing.Font("Noto Sans CJK KR Black", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_title.Location = new System.Drawing.Point(258, 95);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(286, 49);
            this.label_title.TabIndex = 0;
            this.label_title.Text = "Beacon Manager";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_data
            // 
            this.label_data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_data.Font = new System.Drawing.Font("Noto Sans CJK KR Medium", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_data.ForeColor = System.Drawing.Color.DimGray;
            this.label_data.Location = new System.Drawing.Point(271, 190);
            this.label_data.Name = "label_data";
            this.label_data.Size = new System.Drawing.Size(258, 28);
            this.label_data.TabIndex = 1;
            this.label_data.Text = "1. Get Beacon Module Data";
            this.label_data.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_data.Click += new System.EventHandler(this.Label_data_Click);
            this.label_data.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            this.label_data.MouseHover += new System.EventHandler(this.Label_MouseHover);
            // 
            // label_locate
            // 
            this.label_locate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_locate.Font = new System.Drawing.Font("Noto Sans CJK KR Medium", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_locate.ForeColor = System.Drawing.Color.DimGray;
            this.label_locate.Location = new System.Drawing.Point(271, 234);
            this.label_locate.Name = "label_locate";
            this.label_locate.Size = new System.Drawing.Size(169, 28);
            this.label_locate.TabIndex = 2;
            this.label_locate.Text = "2. Locate Beacon";
            this.label_locate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_locate.Click += new System.EventHandler(this.Label_locate_Click);
            this.label_locate.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            this.label_locate.MouseHover += new System.EventHandler(this.Label_MouseHover);
            // 
            // label_open
            // 
            this.label_open.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_open.Font = new System.Drawing.Font("Noto Sans CJK KR Medium", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_open.ForeColor = System.Drawing.Color.DimGray;
            this.label_open.Location = new System.Drawing.Point(271, 278);
            this.label_open.Name = "label_open";
            this.label_open.Size = new System.Drawing.Size(166, 28);
            this.label_open.TabIndex = 3;
            this.label_open.Text = "3. Open Data File";
            this.label_open.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_open.Click += new System.EventHandler(this.Label_open_Click);
            this.label_open.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            this.label_open.MouseHover += new System.EventHandler(this.Label_MouseHover);
            // 
            // label_about
            // 
            this.label_about.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_about.Font = new System.Drawing.Font("Noto Sans CJK KR Medium", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_about.ForeColor = System.Drawing.Color.DimGray;
            this.label_about.Location = new System.Drawing.Point(271, 322);
            this.label_about.Name = "label_about";
            this.label_about.Size = new System.Drawing.Size(215, 28);
            this.label_about.TabIndex = 4;
            this.label_about.Text = "4. About This Program";
            this.label_about.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_about.Click += new System.EventHandler(this.Label_about_Click);
            this.label_about.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            this.label_about.MouseHover += new System.EventHandler(this.Label_MouseHover);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_about);
            this.Controls.Add(this.label_open);
            this.Controls.Add(this.label_locate);
            this.Controls.Add(this.label_data);
            this.Controls.Add(this.label_title);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BeaconManager";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_data;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.Label label_locate;
        private System.Windows.Forms.Label label_open;
        private System.Windows.Forms.Label label_about;
    }
}