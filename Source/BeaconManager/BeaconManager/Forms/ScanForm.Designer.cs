namespace BeaconManager.Forms
{
    partial class ScanForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.box_interface = new System.Windows.Forms.ComboBox();
            this.label_interface = new System.Windows.Forms.Label();
            this.button_scan = new System.Windows.Forms.Button();
            this.button_refresh = new System.Windows.Forms.Button();
            this.check_unavailable = new System.Windows.Forms.CheckBox();
            this.panel_list = new System.Windows.Forms.Panel();
            this.panel_main = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // box_interface
            // 
            this.box_interface.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.box_interface.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.box_interface.Font = new System.Drawing.Font("Noto Sans CJK KR Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.box_interface.FormattingEnabled = true;
            this.box_interface.Location = new System.Drawing.Point(145, 12);
            this.box_interface.Name = "box_interface";
            this.box_interface.Size = new System.Drawing.Size(481, 26);
            this.box_interface.TabIndex = 0;
            this.box_interface.SelectedIndexChanged += new System.EventHandler(this.Box_interface_SelectedIndexChanged);
            // 
            // label_interface
            // 
            this.label_interface.AutoSize = true;
            this.label_interface.Font = new System.Drawing.Font("Noto Sans CJK KR Bold", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_interface.Location = new System.Drawing.Point(12, 14);
            this.label_interface.Name = "label_interface";
            this.label_interface.Size = new System.Drawing.Size(127, 19);
            this.label_interface.TabIndex = 1;
            this.label_interface.Text = "Network Interface";
            // 
            // button_scan
            // 
            this.button_scan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_scan.Enabled = false;
            this.button_scan.Font = new System.Drawing.Font("Noto Sans CJK KR Medium", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_scan.Location = new System.Drawing.Point(713, 12);
            this.button_scan.Name = "button_scan";
            this.button_scan.Size = new System.Drawing.Size(75, 26);
            this.button_scan.TabIndex = 2;
            this.button_scan.Text = "Scan";
            this.button_scan.UseVisualStyleBackColor = true;
            this.button_scan.Click += new System.EventHandler(this.Button_scan_Click);
            // 
            // button_refresh
            // 
            this.button_refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_refresh.Font = new System.Drawing.Font("Noto Sans CJK KR Medium", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_refresh.Location = new System.Drawing.Point(632, 12);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(75, 26);
            this.button_refresh.TabIndex = 3;
            this.button_refresh.Text = "Refresh";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.Button_refresh_Click);
            // 
            // check_unavailable
            // 
            this.check_unavailable.AutoSize = true;
            this.check_unavailable.Font = new System.Drawing.Font("Noto Sans CJK KR Medium", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.check_unavailable.Location = new System.Drawing.Point(145, 44);
            this.check_unavailable.Name = "check_unavailable";
            this.check_unavailable.Size = new System.Drawing.Size(173, 20);
            this.check_unavailable.TabIndex = 4;
            this.check_unavailable.Text = "Show Unavailable Interfaces";
            this.check_unavailable.UseVisualStyleBackColor = true;
            this.check_unavailable.CheckedChanged += new System.EventHandler(this.Check_unavailable_CheckedChanged);
            // 
            // panel_list
            // 
            this.panel_list.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_list.AutoScroll = true;
            this.panel_list.BackColor = System.Drawing.Color.White;
            this.panel_list.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_list.Location = new System.Drawing.Point(16, 70);
            this.panel_list.Name = "panel_list";
            this.panel_list.Size = new System.Drawing.Size(225, 368);
            this.panel_list.TabIndex = 6;
            // 
            // panel_main
            // 
            this.panel_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_main.BackColor = System.Drawing.Color.White;
            this.panel_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_main.Location = new System.Drawing.Point(240, 70);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(542, 368);
            this.panel_main.TabIndex = 7;
            // 
            // ScanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.panel_list);
            this.Controls.Add(this.check_unavailable);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.button_scan);
            this.Controls.Add(this.label_interface);
            this.Controls.Add(this.box_interface);
            this.Name = "ScanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BeaconManager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ScanForm_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox box_interface;
        private System.Windows.Forms.Label label_interface;
        private System.Windows.Forms.Button button_scan;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.CheckBox check_unavailable;
        private System.Windows.Forms.Panel panel_list;
        private System.Windows.Forms.Panel panel_main;
    }
}

