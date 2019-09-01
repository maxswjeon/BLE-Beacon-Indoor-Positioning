namespace BeaconManager.Panels
{
    partial class BeaconPanel
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_name = new System.Windows.Forms.Label();
            this.label_status = new System.Windows.Forms.Label();
            this.button_toggle = new System.Windows.Forms.Button();
            this.button_live_data = new System.Windows.Forms.Button();
            this.label_ip = new System.Windows.Forms.Label();
            this.label_uuid = new System.Windows.Forms.Label();
            this.label_position = new System.Windows.Forms.Label();
            this.text_x = new System.Windows.Forms.TextBox();
            this.label_pos_x = new System.Windows.Forms.Label();
            this.label_pos_y = new System.Windows.Forms.Label();
            this.text_y = new System.Windows.Forms.TextBox();
            this.text_status = new System.Windows.Forms.Label();
            this.label_info = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_data = new System.Windows.Forms.Button();
            this.label_range = new System.Windows.Forms.Label();
            this.text_scan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("Noto Sans CJK KR Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_name.Location = new System.Drawing.Point(3, 3);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(271, 33);
            this.label_name.TabIndex = 0;
            this.label_name.Text = "BeaconModule Scanner";
            // 
            // label_status
            // 
            this.label_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_status.AutoSize = true;
            this.label_status.Font = new System.Drawing.Font("Noto Sans CJK KR Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_status.Location = new System.Drawing.Point(307, 55);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(55, 21);
            this.label_status.TabIndex = 1;
            this.label_status.Text = "Status";
            // 
            // button_toggle
            // 
            this.button_toggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_toggle.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_toggle.Location = new System.Drawing.Point(455, 55);
            this.button_toggle.Name = "button_toggle";
            this.button_toggle.Size = new System.Drawing.Size(75, 38);
            this.button_toggle.TabIndex = 2;
            this.button_toggle.Text = "Start";
            this.button_toggle.UseVisualStyleBackColor = true;
            this.button_toggle.Click += new System.EventHandler(this.Button_toggle_Click);
            // 
            // button_live_data
            // 
            this.button_live_data.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_live_data.Location = new System.Drawing.Point(11, 282);
            this.button_live_data.Name = "button_live_data";
            this.button_live_data.Size = new System.Drawing.Size(114, 32);
            this.button_live_data.TabIndex = 3;
            this.button_live_data.Text = "Get Live Data";
            this.button_live_data.UseVisualStyleBackColor = true;
            this.button_live_data.Click += new System.EventHandler(this.Button_live_data_Click);
            // 
            // label_ip
            // 
            this.label_ip.AutoSize = true;
            this.label_ip.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_ip.Location = new System.Drawing.Point(5, 76);
            this.label_ip.Name = "label_ip";
            this.label_ip.Size = new System.Drawing.Size(33, 21);
            this.label_ip.TabIndex = 4;
            this.label_ip.Text = "IP : ";
            // 
            // label_uuid
            // 
            this.label_uuid.AutoSize = true;
            this.label_uuid.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_uuid.Location = new System.Drawing.Point(5, 97);
            this.label_uuid.Name = "label_uuid";
            this.label_uuid.Size = new System.Drawing.Size(54, 21);
            this.label_uuid.TabIndex = 5;
            this.label_uuid.Text = "UUID : ";
            // 
            // label_position
            // 
            this.label_position.AutoSize = true;
            this.label_position.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_position.Location = new System.Drawing.Point(5, 173);
            this.label_position.Name = "label_position";
            this.label_position.Size = new System.Drawing.Size(64, 21);
            this.label_position.TabIndex = 6;
            this.label_position.Text = "Position";
            // 
            // text_x
            // 
            this.text_x.Location = new System.Drawing.Point(41, 197);
            this.text_x.Name = "text_x";
            this.text_x.Size = new System.Drawing.Size(100, 21);
            this.text_x.TabIndex = 7;
            // 
            // label_pos_x
            // 
            this.label_pos_x.AutoSize = true;
            this.label_pos_x.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_pos_x.Location = new System.Drawing.Point(7, 197);
            this.label_pos_x.Name = "label_pos_x";
            this.label_pos_x.Size = new System.Drawing.Size(28, 21);
            this.label_pos_x.TabIndex = 8;
            this.label_pos_x.Text = "X : ";
            // 
            // label_pos_y
            // 
            this.label_pos_y.AutoSize = true;
            this.label_pos_y.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_pos_y.Location = new System.Drawing.Point(158, 197);
            this.label_pos_y.Name = "label_pos_y";
            this.label_pos_y.Size = new System.Drawing.Size(27, 21);
            this.label_pos_y.TabIndex = 10;
            this.label_pos_y.Text = "Y : ";
            // 
            // text_y
            // 
            this.text_y.Location = new System.Drawing.Point(192, 197);
            this.text_y.Name = "text_y";
            this.text_y.Size = new System.Drawing.Size(100, 21);
            this.text_y.TabIndex = 9;
            // 
            // text_status
            // 
            this.text_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.text_status.AutoSize = true;
            this.text_status.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.text_status.ForeColor = System.Drawing.Color.DarkRed;
            this.text_status.Location = new System.Drawing.Point(307, 76);
            this.text_status.Name = "text_status";
            this.text_status.Size = new System.Drawing.Size(66, 21);
            this.text_status.TabIndex = 11;
            this.text_status.Text = "Stopped";
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.Font = new System.Drawing.Font("Noto Sans CJK KR Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_info.Location = new System.Drawing.Point(5, 55);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(38, 21);
            this.label_info.TabIndex = 12;
            this.label_info.Text = "Info";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Sans CJK KR Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(5, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 13;
            this.label1.Text = "Data";
            // 
            // button_data
            // 
            this.button_data.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_data.Location = new System.Drawing.Point(254, 246);
            this.button_data.Name = "button_data";
            this.button_data.Size = new System.Drawing.Size(85, 32);
            this.button_data.TabIndex = 14;
            this.button_data.Text = "Start";
            this.button_data.UseVisualStyleBackColor = true;
            this.button_data.Click += new System.EventHandler(this.Button_data_Click);
            // 
            // label_range
            // 
            this.label_range.AutoSize = true;
            this.label_range.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_range.Location = new System.Drawing.Point(7, 253);
            this.label_range.Name = "label_range";
            this.label_range.Size = new System.Drawing.Size(63, 21);
            this.label_range.TabIndex = 15;
            this.label_range.Text = "Scan for";
            // 
            // text_scan
            // 
            this.text_scan.Location = new System.Drawing.Point(76, 255);
            this.text_scan.Name = "text_scan";
            this.text_scan.Size = new System.Drawing.Size(100, 21);
            this.text_scan.TabIndex = 16;
            this.text_scan.TextChanged += new System.EventHandler(this.Text_scan_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(182, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 21);
            this.label2.TabIndex = 17;
            this.label2.Text = "Seconds";
            // 
            // BeaconPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text_scan);
            this.Controls.Add(this.label_range);
            this.Controls.Add(this.button_data);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_info);
            this.Controls.Add(this.text_status);
            this.Controls.Add(this.label_pos_y);
            this.Controls.Add(this.text_y);
            this.Controls.Add(this.label_pos_x);
            this.Controls.Add(this.text_x);
            this.Controls.Add(this.label_position);
            this.Controls.Add(this.label_uuid);
            this.Controls.Add(this.label_ip);
            this.Controls.Add(this.button_live_data);
            this.Controls.Add(this.button_toggle);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.label_name);
            this.Name = "BeaconPanel";
            this.Size = new System.Drawing.Size(542, 368);
            this.Load += new System.EventHandler(this.BeaconPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Button button_toggle;
        private System.Windows.Forms.Button button_live_data;
        private System.Windows.Forms.Label label_ip;
        private System.Windows.Forms.Label label_uuid;
        private System.Windows.Forms.Label label_position;
        private System.Windows.Forms.TextBox text_x;
        private System.Windows.Forms.Label label_pos_x;
        private System.Windows.Forms.Label label_pos_y;
        private System.Windows.Forms.TextBox text_y;
        private System.Windows.Forms.Label text_status;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_data;
        private System.Windows.Forms.Label label_range;
        private System.Windows.Forms.TextBox text_scan;
        private System.Windows.Forms.Label label2;
    }
}
