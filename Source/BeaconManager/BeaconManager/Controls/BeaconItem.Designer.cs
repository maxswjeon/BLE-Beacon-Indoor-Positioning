namespace BeaconManager.Controls
{
    partial class BeaconItem
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
            this.label_ip = new System.Windows.Forms.Label();
            this.label_uuid = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("Noto Sans CJK KR Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_name.Location = new System.Drawing.Point(2, 8);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(186, 22);
            this.label_name.TabIndex = 0;
            this.label_name.Text = "BeaconModule Scanner";
            this.label_name.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label_name_MouseClick);
            this.label_name.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BeaconItem_MouseDown);
            this.label_name.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BeaconItem_MouseUp);
            // 
            // label_ip
            // 
            this.label_ip.AutoSize = true;
            this.label_ip.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_ip.Location = new System.Drawing.Point(3, 30);
            this.label_ip.Name = "label_ip";
            this.label_ip.Size = new System.Drawing.Size(65, 16);
            this.label_ip.TabIndex = 1;
            this.label_ip.Text = "192.168.0.1";
            this.label_ip.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label_ip_MouseClick);
            this.label_ip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BeaconItem_MouseDown);
            this.label_ip.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BeaconItem_MouseUp);
            // 
            // label_uuid
            // 
            this.label_uuid.AutoSize = true;
            this.label_uuid.Font = new System.Drawing.Font("Noto Sans CJK KR Regular", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_uuid.Location = new System.Drawing.Point(3, 46);
            this.label_uuid.Name = "label_uuid";
            this.label_uuid.Size = new System.Drawing.Size(216, 15);
            this.label_uuid.TabIndex = 2;
            this.label_uuid.Text = "AD55DAB2-C44F-454A-AEFD-04A749310B9A";
            this.label_uuid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label_uuid_MouseClick);
            this.label_uuid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BeaconItem_MouseDown);
            this.label_uuid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BeaconItem_MouseUp);
            // 
            // BeaconItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label_uuid);
            this.Controls.Add(this.label_ip);
            this.Controls.Add(this.label_name);
            this.Name = "BeaconItem";
            this.Size = new System.Drawing.Size(223, 80);
            this.Load += new System.EventHandler(this.BeaconItem_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BeaconItem_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BeaconItem_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BeaconItem_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_ip;
        private System.Windows.Forms.Label label_uuid;
    }
}
